using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AllAuth.Lib;
using AllAuth.Lib.APIs;
using AllAuth.Lib.Crypto;
using AllAuth.Lib.ServerAPI;
using AllAuth.Mobile.TestDevice.AccountModels;
using AllAuth.Mobile.TestDevice.Forms;
using OathNet;
using ServerAPIRequests = AllAuth.Lib.ServerAPI.Requests.Authenticated;
using ServerAPIRequestsUnauthenticated = AllAuth.Lib.ServerAPI.Requests.Unauthenticated;

namespace AllAuth.Mobile.TestDevice
{
    internal sealed class Controller
    {
        private readonly BasicControls _mainForm;
        private readonly Dictionary<int, SyncAccounts> _syncAccounts = new Dictionary<int, SyncAccounts>();

        public int SelectedServerAccountId;

        public Controller()
        {
            _mainForm = new BasicControls(this);
            _mainForm.FormClosed += MainFormClosed;
            _mainForm.UpdateForm();

            var serverAccounts = AppModel.ServerAccounts.Query().ToList();
            foreach (var serverAccount in serverAccounts)
            {
                if (SelectedServerAccountId == 0)
                    SelectedServerAccountId = serverAccount.Id;

                var model = AccountModel.GetModel(serverAccount.Id);

                _syncAccounts.Add(serverAccount.Id, new SyncAccounts(this, model));
            }
        }

        /// <summary>
        /// Creates and starts the sync loop thread and application interface.
        /// </summary>
        public void Start()
        {
            foreach (var syncAccount in _syncAccounts)
                syncAccount.Value.Start();

            Application.Run(_mainForm);
        }

        /// <summary>
        /// Stop the sync thread and anything else that needs to be handled gracefully.
        /// </summary>
        public void Stop()
        {
            foreach (var syncAccount in _syncAccounts)
                syncAccount.Value.Stop();
            //foreach (var syncLinks in _syncDatabases)
            //    syncLinks.Value.Stop();
            Program.ProgramStopWait.Set();
        }

        /// <summary>
        /// A MainForm close event means the user has closed the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void MainFormClosed(object sender, FormClosedEventArgs args)
        {
            Stop();
        }

        /// <summary>
        /// Create and show the "New Link" form.
        /// </summary>
        public void AddNewServer()
        {
            var form = new AddNewServer(this);
            form.ShowDialog();
        }

        public bool RegisterInitialOtpDevice(string linkCodeString)
        {
            var linkCode = new LinkCodeRegisterInitialOtpDevice(linkCodeString);
            var newKeyPair = AsymmetricCryptoUtil.GenerateKeyPair();

            var apiClient = new ApiClient(
                linkCode.ServerHttps,
                linkCode.ServerHost,
                linkCode.ServerPort,
                linkCode.ServerApiVersion);
            var request = new ServerAPIRequestsUnauthenticated.RegisterSecondDevice
            {
                LoginRequestIdentifier = linkCode.LoginIdentifier,
                PublicKeyPem = newKeyPair.PublicPem,
                DeviceLabel = "My Test Device",
                DeviceType = "phone",
                DeviceSubtype = "testdevice"
            };
            var response = request.GetResponse(apiClient);

            var apiClientAuthenticated = new ApiClient(
                linkCode.ServerHttps,
                linkCode.ServerHost,
                linkCode.ServerPort,
                linkCode.ServerApiVersion,
                response.ApiKey,
                newKeyPair.PrivatePem);

            var totpcode = new TimeBasedOtpGenerator(new Key(response.Secret), response.Digits, new SHA1HMACAlgorithm())
                    .GenerateOtp(DateTime.UtcNow);

            try
            {
                var confirmRequest = new ServerAPIRequests.ConfirmSecondDevice
                {
                    OtpCode = totpcode
                };
                confirmRequest.GetResponse(apiClientAuthenticated);
            }
            catch (RequestException)
            {
                MessageBox.Show(@"Unable to validate the device. Please try again.");
                return false;
            }

            var serverInfo = apiClientAuthenticated.GetServerInfo(new GetServerInfoRequest());

            var newServerId = AppModel.ServerAccounts.Create(new AppModels.ServerAccount
            {
                ServerIdentifier = serverInfo.ServerIdentifier
            });

            var model = AccountModel.GetModel(newServerId);

            var newOtpAccountId = model.OtpAccounts.Create(new OtpAccount
            {
                Type = response.Type,
                Label = response.Label,
                Issuer = response.Issuer,
                Secret = response.Secret,
                Algorithm = response.Algorithm,
                Digits = response.Digits,
                Counter = response.Counter,
                Period = response.Period
            });

            var cryptoKeyId = model.CryptoKeys.Create(new CryptoKey
            {
                OwnKey = true,
                Trust = true,
                PrivateKeyPem = newKeyPair.PrivatePem,
                PublicKeyPem = newKeyPair.PublicPem,
                PublicKeyPemHash = HashUtil.Sha256(newKeyPair.PublicPem)
            });

            var serverAccountSettingsId = model.ServerAccountSettings.Create(new ServerAccountSetting
            {
                Identifier = serverInfo.ServerIdentifier,
                Label = serverInfo.ServerLabel,
                HttpsEnabled = linkCode.ServerHttps,
                Host = linkCode.ServerHost,
                Port= linkCode.ServerPort,
                ApiVersion = linkCode.ServerApiVersion,
                UserIdentifier = response.UserIdentifier,
                DeviceIdentifier = response.DeviceIdentifier,
                OtpAccountId = newOtpAccountId,
                ApiKey = response.ApiKey,
                EmailAddress = linkCode.EmailAddress,
                ApiCryptoKeyId = cryptoKeyId
            });
            
            var linkedDeviceRequest = new ServerAPIRequests.GetLinkedDevice();
            ServerAPIRequests.GetLinkedDevice.ResponseParams linkedDeviceResponse;
            linkedDeviceResponse = linkedDeviceRequest.GetResponse(apiClientAuthenticated);

            if (linkCode.InitiatingDevicePublicKeyPem != HashUtil.Sha256(linkedDeviceResponse.PublicKeyPem))
            {
                MessageBox.Show(@"Unable to verify device keys. You will need to do this manually from the desktop app.");
            }
            else
            {
                var linkedDeviceCryptoKeyId = model.CryptoKeys.Create(new CryptoKey
                {
                    Trust = true,
                    PublicKeyPem = linkedDeviceResponse.PublicKeyPem,
                    PublicKeyPemHash = HashUtil.Sha256(linkedDeviceResponse.PublicKeyPem)
                });
                model.ServerAccountSettings.Update(serverAccountSettingsId, new ServerAccountSetting
                {
                    LinkedDeviceCryptoKeyId = linkedDeviceCryptoKeyId
                });
            }
            
            _syncAccounts.Add(newServerId, new SyncAccounts(this, model));
            _syncAccounts[newServerId].Start();

            _mainForm.UpdateForm();

            return true;
        }

        /// <summary>
        /// Registers a new client with the server and completes the link with another client.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="newLinkIdentifier"></param>
        /// <returns></returns>
        public bool CompleteNewLink(AccountModel model, string newLinkIdentifier)
        {
            var serverAccountSettings = model.ServerAccountSettings.Query().First();
            var cryptoKeyId = serverAccountSettings.ApiCryptoKeyId;
            var cryptoKey = model.CryptoKeys.Query().First(r => r.Id == cryptoKeyId);

            var apiClient = new ApiClient(
                serverAccountSettings.HttpsEnabled,
                serverAccountSettings.Host,
                serverAccountSettings.Port,
                serverAccountSettings.ApiVersion,
                serverAccountSettings.ApiKey,
                cryptoKey.PrivateKeyPem);

            var completeLinkRequest = new ServerAPIRequests.CompleteLink
            {
                LinkIdentifier = newLinkIdentifier
            };
            completeLinkRequest.GetResponse(apiClient);

            var request = new ServerAPIRequests.GetLinkedDevice();
            var linkedDeviceResponse = request.GetResponse(apiClient);

            var linkedDeviceCryptoKey = model.CryptoKeys.Query()
                    .FirstOrDefault(r => r.PublicKeyPemHash == HashUtil.Sha256(linkedDeviceResponse.PublicKeyPem));

            if (linkedDeviceCryptoKey == null)
            {
                var newLinkedClientCryptoKeyId = model.CryptoKeys.Create(
                    new CryptoKey
                    {
                        PublicKeyPem = linkedDeviceResponse.PublicKeyPem,
                        PublicKeyPemHash = HashUtil.Sha256(linkedDeviceResponse.PublicKeyPem)
                    });
                linkedDeviceCryptoKey = model.CryptoKeys.Query().First(r => r.Id == newLinkedClientCryptoKeyId);
            }
            
            model.Links.Create(new Link
            {
                Identifier = newLinkIdentifier,
                //LinkedClientCryptoKeyId = linkedDeviceCryptoKeyId.Id
            });

            model.ServerAccountSettings.Update(serverAccountSettings.Id, new ServerAccountSetting
            {
                LinkedDeviceCryptoKeyId = linkedDeviceCryptoKey.Id
            });

            if (_mainForm.InvokeRequired)
                _mainForm.Invoke((MethodInvoker) delegate { _mainForm.UpdateForm(); });
            else
                _mainForm.UpdateForm();

            return true;
        }
        
        public bool PromptSecretShareRequestSafe()
        {
            bool returnVal = false;

            if (_mainForm.InvokeRequired)
                _mainForm.Invoke((MethodInvoker) delegate { returnVal = PromptSecretShareRequest(); });
            else
                returnVal = PromptSecretShareRequest();

            return returnVal;
        }

        private bool PromptSecretShareRequest()
        {
            _mainForm.Activate();
            var result = MessageBox.Show(@"Secret share has been requested.", @"Secret Share Request",
                MessageBoxButtons.YesNo);
            return result == DialogResult.Yes;
        }

        public void ShowRegisterWithServerForm()
        {
            var form = new AddNewServer(this);
            form.ShowDialog();
        }

        public bool AddOtpAccount(string otpAuthUri)
        {
            var model = AccountModel.GetModel(_mainForm.SelectedServerId);

            var uri = new Uri(otpAuthUri);

            if (uri.Scheme != "otpauth")
                return false;

            if (uri.Host != "totp")
                return false;

            var accountName = uri.LocalPath.Trim(new char['/']);
            if (string.IsNullOrEmpty(accountName))
                return false;

            var secret = System.Web.HttpUtility.ParseQueryString(uri.Query).Get("secret");
            if (string.IsNullOrEmpty(secret))
                return false;

            model.OtpAccounts.Create(new OtpAccount
            {
                Type = uri.Host,
                Label = accountName,
                Secret = secret,
                Issuer = "",
                Algorithm = "",
                Digits = 6,
                Counter = 0,
                Period = 30
            });

            return true;
        }

        public string GenerateOtpCodeForServerAccount(AccountModel model)
        {
            var serverAccount = model.ServerAccountSettings.Query().First();
            var otpAccount = model.OtpAccounts.Query().First(r => r.Id == serverAccount.OtpAccountId);
            
            var totpcode = new TimeBasedOtpGenerator(
                new Key(otpAccount.Secret), 
                otpAccount.Digits, 
                new SHA1HMACAlgorithm());
                  
            return totpcode.GenerateOtp(DateTime.UtcNow);
        }

        public string GenerateOtpCode(int serverAccountId, string accountName)
        {
            var model = AccountModel.GetModel(serverAccountId);

            var otpAccount = model.OtpAccounts.Query().FirstOrDefault(r => r.Label == accountName);
            if (otpAccount == null)
                throw new Exception("Could not find OTP account for given name");
            
            var totpcode = new TimeBasedOtpGenerator(
                new Key(otpAccount.Secret),
                otpAccount.Digits,
                new SHA1HMACAlgorithm());

            return totpcode.GenerateOtp(DateTime.UtcNow);
        }

        public bool PromptUserLoginRequestSafe(string deviceLabel, string deviceType)
        {
            var returnVar = false;

            if (_mainForm.InvokeRequired)
            {
                _mainForm.Invoke((MethodInvoker) delegate
                {
                    returnVar = PromptUserLoginRequest(deviceLabel, deviceType);
                });
            }
            else
            {
                returnVar = PromptUserLoginRequest(deviceLabel, deviceType);
            }

            return returnVar;
        }

        private bool PromptUserLoginRequest(string deviceLabel, string deviceType)
        {
            _mainForm.Activate();
            var message = "Confirm login request to your account from " +
                          deviceLabel + " (" + deviceType + ")?";

            var result = MessageBox.Show(message, @"User Login Request", MessageBoxButtons.YesNo);
            return result == DialogResult.Yes;
        }

        public bool PromptNewLinkRequestSafe()
        {
            var returnVar = false;
            if (_mainForm.InvokeRequired)
                _mainForm.Invoke((MethodInvoker) delegate { returnVar = PromptNewLinkRequest(); });
            else
                returnVar = PromptNewLinkRequest();

            return returnVar;
        }

        private bool PromptNewLinkRequest()
        {
            _mainForm.Activate();
            var dialogResult = MessageBox.Show(@"Confirm new database link request?", @"User Login Request",
                MessageBoxButtons.YesNo);
            return dialogResult == DialogResult.Yes;
        }

        public bool PromptRecoveryPublicKeyVerifySafe(string recoveryPublicKey)
        {
            var returnVar = false;

            if (_mainForm.InvokeRequired)
                _mainForm.Invoke(
                    (MethodInvoker) delegate { returnVar = PromptRecoveryPublicKeyVerify(recoveryPublicKey); });
            else
                returnVar = PromptRecoveryPublicKeyVerify(recoveryPublicKey);

            return returnVar;
        }

        private bool PromptRecoveryPublicKeyVerify(string recoveryPublicKey)
        {
            _mainForm.Activate();
            using (var form = new VerifyRecoveryPublicKey())
            {
                form.ShowDialog();
                if (!form.VerificationCodeEntered)
                    return false;

                if (!HashUtil.Sha256(recoveryPublicKey).Equals(form.VerificationCode))
                    return false;
            }

            return true;
        }

        public bool PromptVerifyDeviceKeysSafe(string publicKeyToVerify)
        {
            var returnVar = false;

            if (_mainForm.InvokeRequired)
                _mainForm.Invoke((MethodInvoker) delegate { returnVar = PromptVerifyDeviceKeys(publicKeyToVerify); });
            else
                returnVar = PromptVerifyDeviceKeys(publicKeyToVerify);

            return returnVar;
        }

        private bool PromptVerifyDeviceKeys(string publicKeyToVerify)
        {
            _mainForm.Activate();
            using (var form = new VerifyRecoveryPublicKey())
            {
                form.ShowDialog();
                if (!form.VerificationCodeEntered)
                    return false;

                if (!HashUtil.Sha256(publicKeyToVerify).Equals(form.VerificationCode))
                    return false;
            }

            return true;
        }

        private ApiClient GetApiClientForAccount(int serverAccountId)
        {
            var model = AccountModel.GetModel(serverAccountId);
            var accountSettings = model.ServerAccountSettings.Query().First();
            var cryptoKey = model.CryptoKeys.Query().First(r => r.Id == accountSettings.ApiCryptoKeyId);

            var apiClient = new ApiClient(
                accountSettings.HttpsEnabled, accountSettings.Host, accountSettings.Port, 
                accountSettings.ApiVersion, accountSettings.ApiKey, cryptoKey.PrivateKeyPem);

            return apiClient;
        }

        public bool SetRecoveryKey()
        {
            var model = AccountModel.GetModel(SelectedServerAccountId);
            var accountSettings = model.ServerAccountSettings.Query().First();
            var apiClient = GetApiClientForAccount(SelectedServerAccountId);
            
            if (accountSettings.BackupRecoveryPasswordHashSet)
            {
                MessageBox.Show("Recovery passphrase already set");
                return false;
            }

            string recoveryKeyPlaintext;
            using (var form = new SetRecoveryKey())
            {
                form.ShowDialog();
                if (!form.Success)
                    return false;
                
                recoveryKeyPlaintext = form.RecoveryKeyPlaintext;
            }

            // This is the key used to encrypt the backup data.
            var backupEncryptionKeyHash = HashUtil.GenerateDeviceBackupPasswordHash(
                accountSettings.EmailAddress, recoveryKeyPlaintext);
            
            GetUserResponse userInfo;
            try
            {
                userInfo = apiClient.GetUser(new GetUserRequest());
            }
            catch (RequestException)
            {
                return false;
            }

            if (userInfo.DeviceRecoverySetup)
            {
                // This means we need to recover existing data.
                var recoveryKeyCheckHash = HashUtil.GenerateDeviceBackupPasswordCheckHash(
                    accountSettings.EmailAddress, recoveryKeyPlaintext);

                var checkRequest = new ServerAPIRequests.CheckSecondDeviceRecoveryKey
                {
                    RecoveryKeyClientHash = recoveryKeyCheckHash
                };
                ServerAPIRequests.CheckSecondDeviceRecoveryKey.ResponseParams checkResponse;
                try
                {
                    checkResponse = checkRequest.GetResponse(apiClient);
                }
                catch (RequestException)
                {
                    MessageBox.Show("Error contacting server to verify recovery key. Please try again later.");
                    return false;
                }

                if (!checkResponse.Success)
                {
                    MessageBox.Show("Recovery key is incorrect. Please try again.");
                    return false;
                }

                var recoverySuccess = RecoverDeviceData(SelectedServerAccountId, backupEncryptionKeyHash);
                if (!recoverySuccess)
                {
                    MessageBox.Show("There was an error recovering your data. Please try again later.");
                    return false;
                }
            }
            else
            {
                // Save the "check" key on the server, so that we can easily verify the recovery key when required.
                var backupKeyCheckHash = HashUtil.GenerateDeviceBackupPasswordCheckHash(
                    accountSettings.EmailAddress, recoveryKeyPlaintext);
                var request = new ServerAPIRequests.UpdateDeviceRecoveryInfo { PasswordClientHash = backupKeyCheckHash };
                try
                {
                    request.GetResponse(apiClient);
                }
                catch (RequestException)
                {
                    MessageBox.Show("There was an error contacting the server. Please try again later.");
                    return false;
                }
            }
            
            model.ServerAccountSettings.Update(accountSettings.Id, new ServerAccountSetting
            {
                BackupRecoveryPasswordHashSet = true,
                BackupRecoveryPasswordHash = backupEncryptionKeyHash
            });

            _mainForm.UpdateForm();
            
            if (_syncAccounts.ContainsKey(SelectedServerAccountId))
                _syncAccounts[SelectedServerAccountId].RestartSyncLoop();

            return true;
        }

        private bool RecoverDeviceData(int serverAccountId, string recoveryKeyHash)
        {
            var model = AccountModel.GetModel(serverAccountId);
            var apiClient = GetApiClientForAccount(serverAccountId);

            GetUserResponse userInfo;
            try
            {
                userInfo = apiClient.GetUser(new GetUserRequest());
            }
            catch (RequestException)
            {
                return false;
            }

            foreach (var serverDatabase in userInfo.Links)
            {
                var localDatabase = model.Links.Query().FirstOrDefault(r => r.Identifier == serverDatabase.Identifier);
                if (localDatabase == null)
                {
                    // Create the database locally
                    var newLocalDatabaseId = model.Links.Create(new Link {Identifier = serverDatabase.Identifier});
                    localDatabase = model.Links.Query().First(r => r.Id == newLocalDatabaseId);
                }

                var entriesRequest = new ServerAPIRequests.GetDatabaseEntries
                {
                    LinkIdentifier = serverDatabase.Identifier
                };
                ServerAPIRequests.GetDatabaseEntries.ResponseParams entriesResponse;
                try
                {
                    entriesResponse = entriesRequest.GetResponse(apiClient);
                }
                catch (RequestException)
                {
                    return false;
                }

                foreach (var serverEntry in entriesResponse.Entries)
                {
                    var localEntry = model.Entries.Query().FirstOrDefault(
                        r => r.LinkId == localDatabase.Id && r.Identifier == serverEntry.EntryIdentifier);

                    if (localEntry == null)
                    {
                        var newLocalEntryId = model.Entries.Create(new Entry
                        {
                            LinkId = localDatabase.Id,
                            Identifier = serverEntry.EntryIdentifier
                        });
                        localEntry = model.Entries.Query().First(r => r.Id == newLocalEntryId);
                    }

                    var secretsRequest = new ServerAPIRequests.GetDatabaseEntryDeviceSecrets
                    {
                        LinkIdentifier = serverDatabase.Identifier,
                        EntryIdentifier = serverEntry.EntryIdentifier
                    };
                    ServerAPIRequests.GetDatabaseEntryDeviceSecrets.ResponseParams secretsResponse;
                    try
                    {
                        secretsResponse = secretsRequest.GetResponse(apiClient);
                    }
                    catch (RequestException)
                    {
                        return false;
                    }

                    foreach (var serverSecret in secretsResponse.Secrets)
                    {
                        var localSecret = model.EntriesSharedSecrets.Query().FirstOrDefault(
                            r => r.EntryId == localEntry.Id && r.SecretIdentifier == serverSecret.SecretIdentifier);

                        if (localSecret != null)
                            continue;

                        var decryptedData = EncryptedDataWithPassword.DecryptDataAsBytes(
                            serverSecret.Data, recoveryKeyHash);
                        var dataJson = AllAuth.Lib.Utils.Compression.Decompress(decryptedData);

                        var data = Newtonsoft.Json.JsonConvert.DeserializeObject<EntrySharedSecretData>(dataJson);
                        data.RemoveId();

                        var newSecretDataId = model.EntriesSharedSecretsData.Create(data);
                        model.EntriesSharedSecrets.Create(new EntrySharedSecret
                        {
                            EntryId = localEntry.Id,
                            SecretIdentifier = serverSecret.SecretIdentifier,
                            EntrySecretDataId = newSecretDataId
                        });
                    }
                }
            }

            return true;
        }

        public void SetEntrySecretAsModified(int serverAccountId, int entrySecretId)
        {
            var model = AccountModel.GetModel(serverAccountId);
            model.EntriesSharedSecretsSync.Create(new EntrySharedSecretSync {EntrySecretId = entrySecretId});
            
            if (!_syncAccounts.ContainsKey(serverAccountId))
                return;

            _syncAccounts[serverAccountId].RestartSyncLoop();
        }
    }
}
