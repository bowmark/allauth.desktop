using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AllAuth.Lib;
using AllAuth.Lib.APIs;
using AllAuth.Lib.Crypto;
using AllAuth.Lib.ServerAPI;
using AllAuth.Lib.ServerAPI.Requests.Authenticated;
using AllAuth.Lib.Utils;
using AllAuth.Mobile.TestDevice.AccountModels;
using Newtonsoft.Json;

namespace AllAuth.Mobile.TestDevice
{
    internal sealed class SyncAccounts
    {
        /// <summary>
        /// Reference to the main program controller.
        /// </summary>
        private readonly Controller _controller;

        /// <summary>
        /// When set to true, tells the the sync loop thread to stop immediately 
        /// (or after it has completed processing the current iteration).
        /// </summary>
        private bool _stopSyncLoop;

        /// <summary>
        /// Used to pause between sync loop iterations.
        /// Can also be used to force a sync loop iteration if an action requires an immediate response.
        /// </summary>
        private readonly AutoResetEvent _syncLoopWait = new AutoResetEvent(false);

        /// <summary>
        /// Used to wait until the sync loop thread exits gracefully.
        /// </summary>
        private readonly AutoResetEvent _stopLoopWait = new AutoResetEvent(false);

        private readonly int _appServerAccountId;

        private readonly AccountModel _model;

        private AutoResetEvent _longpollInterrupt = new AutoResetEvent(false);

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="model"></param>
        public SyncAccounts(Controller controller, AccountModel model)
        {
            _controller = controller;
            _model = model;
            var accountSettings = _model.ServerAccountSettings.Query().First();

            // If this doesn't exist, the server probably hasn't been fully linked yet.
            var serverIdentifier = accountSettings.Identifier;
            if (serverIdentifier == null)
                return;

            _appServerAccountId = AppModel.GetServerAccountForIdentifier(serverIdentifier).Id;

            //_syncLoopThread = new Thread(Run);
        }

        /// <summary>
        /// Create and start a sync loop thread.
        /// </summary>
        public void Start()
        {
            var thread = new Thread(Run);
            thread.Start();
        }

        /// <summary>
        /// Tells the sync thread to end now, then waits until it has completed gracefully. 
        /// </summary>
        public void Stop()
        {
            Logger.Info("Been told to stop the sync loop");

            _stopSyncLoop = true;
            _longpollInterrupt.Set();
            _syncLoopWait.Set();
            _stopLoopWait.WaitOne();

            Logger.Info("Stopped sync loop");
        }

        /// <summary>
        /// Execute the sync loop. 
        /// </summary>
        private void Run()
        {
            Logger.Info("Starting device sync loop");

            while (true)
            {
                Logger.Verbose("Executing device sync loop iteration");

                if (_stopSyncLoop)
                {
                    Logger.Info("Stopping device sync loop");
                    break;
                }

                BackupEntrySecrets();
                ProcessMessages();

                Logger.Verbose("Device sync loop iteration completed. Sleeping...");
                _syncLoopWait.WaitOne(1000);
            }

            // TODO: Tell server we're leaving...

            // Tell the calling thread we've stopped.
            _stopLoopWait.Set();
        }
        
        /// <summary>
        /// Helper function to retrieve the ApiClient from the API clients dictionary.
        /// </summary>
        /// <returns></returns>
        private ApiClient GetApiClient()
        {
            var accountSettings = _model.ServerAccountSettings.Query().First();

            var cryptoKey = _model.CryptoKeys.Query().First(r => r.Id == accountSettings.ApiCryptoKeyId);

            var apiClient = new ApiClient(
                accountSettings.HttpsEnabled, accountSettings.Host, accountSettings.Port, accountSettings.ApiVersion,
                accountSettings.ApiKey, cryptoKey.PrivateKeyPem);
            
            return apiClient;
        }

        /// <summary>
        /// Retrieve and process any outstanding messages from the server for the device.
        /// </summary>
        private void ProcessMessages()
        {
            var apiClient = GetApiClient();
            var accountSettings = _model.ServerAccountSettings.Query().First();

            GetMessagesLongpoll.ResponseParams longpollResponse;
            try
            {
                var longpollRequest = new GetMessagesLongpoll();
                _longpollInterrupt = new AutoResetEvent(false);
                longpollRequest.SetInteruptHandle(_longpollInterrupt);
                longpollResponse = longpollRequest.GetResponse(apiClient);
            }
            catch (RequestException)
            {
                return;
            }

            if (!longpollResponse.NewMessages)
                return;

            var getMessagesRequest = new GetMessages();
            GetMessages.ResponseParams messagesResponse;
            try
            {
                messagesResponse = getMessagesRequest.GetResponse(apiClient);
            }
            catch (RequestException)
            {
                return;
            }

            foreach (var messageItem in messagesResponse.Messages)
            {
                var processedSuccessfully = false;
                switch (messageItem.Type)
                {
                    case DeviceMessages.Types.ServerLoginRequest:
                        var loginRequestMessageContents = messageItem.GetContent<DeviceMessages.ServerLoginRequest>();
                        processedSuccessfully = ProcessMessageUserLoginRequest(loginRequestMessageContents);
                        break;

                    case DeviceMessages.Types.NewDatabase:
                        var newDatabaseMessageContents = messageItem.GetContent<DeviceMessages.NewDatabase>();
                        processedSuccessfully = ProcessMessageConfirmNewLink(newDatabaseMessageContents);
                        break;
                        
                    case DeviceMessages.Types.DeviceToDeviceMessage:
                        var messageContents = messageItem.GetContent<DeviceMessages.DeviceToDeviceMessage>();
                        var linkedDeviceCryptoKeyId = accountSettings.LinkedDeviceCryptoKeyId;
                        var linkedClientCryptoKey = _model.CryptoKeys.Query().First(r => r.Id == linkedDeviceCryptoKeyId);
                        if (!linkedClientCryptoKey.Trust)
                            break;

                        var message = getMessagesRequest.DecryptClientMessage(
                            messageContents.EncryptedMessage, linkedClientCryptoKey.PublicKeyPem);

                        processedSuccessfully = ProcessMessageFromDevice(messageItem, message);

                        break;

                    case DeviceMessages.Types.VerifyDeviceKeysRequest:
                        var verifyKeyMessageContents = messageItem.GetContent<DeviceMessages.VerifyDeviceKeysRequest>();
                        processedSuccessfully = ProcessMessageVerifyDeviceKeys(verifyKeyMessageContents);
                        break;

                    case DeviceMessages.Types.LinkedDeviceChange:
                        processedSuccessfully = ProcessMessageLinkedDeviceChange();
                        break;
                }

                var request = new SetMessageStatus
                {
                    DeviceMessageIdentifier = messageItem.Identifier,
                    ProcessedSuccess = processedSuccessfully
                };
                request.GetResponse(apiClient);
            }
        }

        private bool ProcessMessageUserLoginRequest(DeviceMessages.ServerLoginRequest messageItem)
        {
            var confirmRequest = _controller.PromptUserLoginRequestSafe(
                    messageItem.RequestingDeviceLabel,messageItem.RequestingDeviceType);

            if (!confirmRequest)
                return false;
            
            var apiRequest = new SendOtpLoginCode
            {
                LoginRequestIdentifier = messageItem.LoginRequestIdentifier,
                OtpDeviceCode = _controller.GenerateOtpCodeForServerAccount(_model)
            };
            apiRequest.GetResponse(GetApiClient());

            return true;
        }

        private bool ProcessMessageConfirmNewLink(DeviceMessages.NewDatabase messageItem)
        {
            _controller.CompleteNewLink(_model, messageItem.LinkIdentifier);
            return true;
        }
        
        private bool ProcessMessageFromDevice(
            GetMessages.ResponseParamsMessage messageItem, DeviceToDeviceMessages.Envelope deviceMessage)
        {
            switch (deviceMessage.Type)
            {
                case DeviceToDeviceMessages.Types.NewSecret:
                    return ProcessMessageNewSecretShare(deviceMessage.Message);

                case DeviceToDeviceMessages.Types.RequestEntrySecrets:
                    return ProcessMessageRequestEntrySecrets(messageItem, deviceMessage.Message);

                case DeviceToDeviceMessages.Types.DeleteSecret:
                    return ProcessMessageDeleteSecret(deviceMessage.Message);

                default:
                    return false;
            }
        }

        private bool ProcessMessageNewSecretShare(DeviceToDeviceMessages.IMessage message)
        {
            var messageContents = (DeviceToDeviceMessages.NewSecret) message;

            var link = _model.Links.Query().FirstOrDefault(r => r.Identifier == messageContents.LinkIdentifier);
            if (link == null)
                return false;

            var entry =
                _model.Entries.Query()
                    .FirstOrDefault(r => r.LinkId == link.Id && r.Identifier == messageContents.EntryIdentifier);

            if (entry == null)
            {
                var entryId =
                    _model.Entries.Create(new Entry { Identifier = messageContents.EntryIdentifier, LinkId = link.Id });
                entry = _model.Entries.Query().First(r => r.Id == entryId);
            }
            
            var secretKey = messageContents.SecretIdentifier;
            var secret = messageContents.Secret;

            var existingEntryShares = 
                _model.EntriesSharedSecrets.Query()
                .Where(r => r.EntryId == entry.Id && r.SecretIdentifier == secretKey).ToList();

            foreach (var existingEntryShare in existingEntryShares)
            {
                _model.EntriesSharedSecrets.Delete(existingEntryShare.Id);
            }

            var newSecretDataId = _model.EntriesSharedSecretsData.Create(new EntrySharedSecretData
            {
                ShareType = "EncDataKey",
                Secret = secret
            });

            var newSecretId = _model.EntriesSharedSecrets.Create(new EntrySharedSecret
            {
                EntryId = entry.Id,
                SecretIdentifier = secretKey,
                EntrySecretDataId = newSecretDataId
            });

            _controller.SetEntrySecretAsModified(_appServerAccountId, newSecretId);

            return true;
        }

        private bool ProcessMessageRequestEntrySecrets(
            GetMessages.ResponseParamsMessage messageItem, DeviceToDeviceMessages.IMessage message)
        {
            var messageContents = (DeviceToDeviceMessages.RequestEntrySecrets)message;
            
            var accountSettings = _model.ServerAccountSettings.Query().First();

            var entry = _model.Entries.Query().FirstOrDefault(r => r.Identifier == messageContents.EntryIdentifier);
            if (entry == null)
                return false;
            
            var linkedDeviceCryptoKeyId = accountSettings.LinkedDeviceCryptoKeyId;
            var linkedDeviceCryptoKey = _model.CryptoKeys.Query().First(r => r.Id == linkedDeviceCryptoKeyId);

            var entrySecrets = new Dictionary<string, string>();
            foreach (var secretIdentifier in messageContents.SecretIdentifiers)
            {
                var entrySecretsResult = _model.EntriesSharedSecrets.Query()
                    .FirstOrDefault(r => r.EntryId == entry.Id && r.SecretIdentifier == secretIdentifier);

                if (entrySecretsResult == null)
                    continue;

                var entrySecretData = _model.EntriesSharedSecretsData.Query().First(r => r.Id == entrySecretsResult.EntrySecretDataId);
                entrySecrets.Add(entrySecretsResult.SecretIdentifier, entrySecretData.Secret);
            }

            if (entrySecrets.Count != messageContents.SecretIdentifiers.Count)
            {
                // We don't appear to have all the requested secrets.
                return false;
            }

            var requestConfirmed = _controller.PromptSecretShareRequestSafe();

            var apiRequest = new SendLinkedDeviceMessage
            {
                //LinkIdentifier = link.Identifier,
                SecondsValidFor = 30
            };
            if (!requestConfirmed)
            {
                var deniedMessage = new DeviceToDeviceMessages.SendEntrySecrets
                {
                    OriginalMessageIdentifier = messageItem.Identifier,
                    RequestAccepted = false
                };
                apiRequest.SetMessage(deniedMessage, linkedDeviceCryptoKey.PublicKeyPem);
                apiRequest.GetResponse(GetApiClient());
                return true;
            }

            var acceptedMessage = new DeviceToDeviceMessages.SendEntrySecrets
            {
                OriginalMessageIdentifier = messageItem.Identifier,
                RequestAccepted = true,
                Secrets = entrySecrets
            };
            apiRequest.SetMessage(acceptedMessage, linkedDeviceCryptoKey.PublicKeyPem);
            apiRequest.GetResponse(GetApiClient());

            return true;
        }

        private bool ProcessMessageDeleteSecret(DeviceToDeviceMessages.IMessage message)
        {
            var messageContent = (DeviceToDeviceMessages.DeleteSecret) message;

            var secret =
                _model.EntriesSharedSecrets.Query()
                    .FirstOrDefault(r => r.SecretIdentifier == messageContent.SecretIdentifier);

            if (secret == null)
                return false;

            // Mark the secret as deleted. The sync process will handle it.
            _model.EntriesSharedSecrets.Update(secret.Id, new EntrySharedSecret {ToBeDeleted = true});
            _controller.SetEntrySecretAsModified(_appServerAccountId, secret.Id);

            return true;
        }

        private bool ProcessMessageVerifyDeviceKeys(DeviceMessages.VerifyDeviceKeysRequest message)
        {
            /*var keyHash = HashUtil.Sha256(message.PublicKeyPem);
            var cryptoKey = _model.CryptoKeys.Query()
                .FirstOrDefault(r => r.PublicKeyPemHash == keyHash);

            if (cryptoKey != null && cryptoKey.Trust)
                return true;

            var confirmed = _controller.PromptVerifyDeviceKeysSafe(message.PublicKeyPem);
            if (!confirmed)
                return false;

            if (cryptoKey == null)
            {
                _model.CryptoKeys.Create(new CryptoKey
                {
                    Trust = true,
                    PublicKeyPem = message.PublicKeyPem,
                    PublicKeyPemHash = keyHash
                });
            }
            else
            {
                _model.CryptoKeys.Update(cryptoKey.Id, new CryptoKey {Trust = true});
            }*/

            // TEMP return false;

            return true;
        }

        private bool ProcessMessageLinkedDeviceChange()
        {
            var linkedDeviceResponse = new GetLinkedDevice().GetResponse(GetApiClient());

            var keyHash = HashUtil.Sha256(linkedDeviceResponse.PublicKeyPem);

            var cryptoKey = _model.CryptoKeys.Query().FirstOrDefault(r => r.PublicKeyPemHash == keyHash);

            if (cryptoKey == null)
            {
                var newCryptoKeyId = _model.CryptoKeys.Create(new CryptoKey
                {
                    PublicKeyPem = linkedDeviceResponse.PublicKeyPem,
                    PublicKeyPemHash = keyHash
                });
                cryptoKey = _model.CryptoKeys.Query().First(r => r.Id == newCryptoKeyId);
            }

            var accountSettings = _model.ServerAccountSettings.Query().First();
            _model.ServerAccountSettings.Update(accountSettings.Id, new ServerAccountSetting
            {
                LinkedDeviceCryptoKeyId = cryptoKey.Id
            });

            return true;
        }

        private void BackupEntrySecrets()
        {
            var accountSettings = _model.ServerAccountSettings.Query().First();

            if (!accountSettings.BackupRecoveryPasswordHashSet)
                return;

            var secrets = _model.EntriesSharedSecrets.Query().ToList();
            foreach (var secret in secrets)
            {
                var entry = _model.Entries.Query().First(r => r.Id == secret.EntryId);
                var database = _model.Links.Query().First(r => r.Id == entry.LinkId);

                if (secret.ToBeDeleted)
                {
                    var deleteRequest = new DeleteDatabaseEntryDeviceSecret
                    {
                        LinkIdentifier = database.Identifier,
                        SecretIdentifier = secret.SecretIdentifier
                    };

                    try
                    {
                        deleteRequest.GetResponse(GetApiClient());
                    }
                    catch (RequestException)
                    {
                        // Try again next time.
                        continue;
                    }

                    _model.EntriesSharedSecretsData.Delete(secret.EntrySecretDataId);
                    _model.EntriesSharedSecrets.Delete(secret.Id);

                    continue;
                }

                // Is there an update request for this entry?
                var updateRequests = _model.EntriesSharedSecretsSync.Query()
                    .Where(r => r.EntrySecretId == secret.Id).ToList();

                if (updateRequests.Count == 0)
                    continue;

                var updateRequestsSorted = updateRequests.OrderByDescending(update => update.CreatedAt);
                var latestUpdateRequest = updateRequestsSorted.First();
                
                // Remove duplicate update requests
                foreach (var updateRequest in updateRequestsSorted)
                {
                    if (updateRequest.Id == latestUpdateRequest.Id)
                        continue;

                    _model.EntriesSharedSecretsSync.Delete(updateRequest.Id);
                }
                
                var secretData = _model.EntriesSharedSecretsData.Query().First(r => r.Id == secret.EntrySecretDataId);
                var serializedEntry = JsonConvert.SerializeObject(secretData);
                var encryptedData = new EncryptedDataWithPassword(
                    Compression.Compress(serializedEntry), accountSettings.BackupRecoveryPasswordHash).ToString();
                
                var request = new SetDatabaseEntryDeviceSecret
                {
                    LinkIdentifier = database.Identifier,
                    EntryIdentifier = entry.Identifier,
                    SecretIdentifier = secret.SecretIdentifier,
                    DataType = "ModelJsonGz",
                    Data = encryptedData
                };

                try
                {
                    request.GetResponse(GetApiClient());
                }
                catch (RequestException)
                {
                    // Try again later
                    continue;
                }
                
                // Sync completed
                _model.EntriesSharedSecretsSync.Delete(latestUpdateRequest.Id);
            }
        }
        
        public void RestartSyncLoop()
        {
            _longpollInterrupt.Set();
        }
    }
}
