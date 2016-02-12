using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AllAuth.Desktop.App;
using AllAuth.Desktop.Common.Models;
using AllAuth.Desktop.Forms;
using AllAuth.Desktop.Forms.Dialogs;
using AllAuth.Lib;
using AllAuth.Lib.APIs;
using AllAuth.Lib.Crypto;
using AllAuth.Lib.ManagementAPI.Requests.Authenticated;
using AllAuth.Lib.ManagementAPI.Requests.Unauthenticated;
using AllAuth.Lib.ServerAPI.Requests.Authenticated;
using Microsoft.VisualBasic.FileIO;
using ApiClient = AllAuth.Lib.ManagementAPI.ApiClient;
using Logout = AllAuth.Lib.ServerAPI.Requests.Authenticated.Logout;
using ServerAPI = AllAuth.Lib.ServerAPI;

namespace AllAuth.Desktop
{
    internal sealed class Controller
    {
        private readonly MainForm _mainForm;
        private readonly Header _header;
        private readonly SubscriptionInfoBar _subscriptionInfoBar;
        private readonly HomePage _homePage;

        private readonly Dictionary<int, DatabaseView> _databaseViews = new Dictionary<int, DatabaseView>(); 
        private readonly Dictionary<int, Sync> _syncServers = new Dictionary<int, Sync>();

        private SyncManagement _syncManagement;
        private bool _activeDatabase;
        private int _activeDatabaseId;

        public Controller()
        {
            _header = new Header(this);
            _homePage = new HomePage(this);
            _subscriptionInfoBar = new SubscriptionInfoBar(this);
            _mainForm = new MainForm(this, _header, _subscriptionInfoBar);

            //SyncAccounts();

            var serverAccounts = Model.ServerAccounts.Find(new ServerAccount());
            foreach (var serverAccount in serverAccounts)
            {
                _syncServers.Add(serverAccount.Id, new Sync(this, serverAccount.Id));
                _syncServers[serverAccount.Id].Start();
            }

            var managementAccount = Model.ServerManagementAccounts.Find(new ServerManagementAccount()).FirstOrDefault();
            if (managementAccount != null)
            {
                _syncManagement = new SyncManagement(this, managementAccount.Id);
                _syncManagement.Start();
            }
        }

        public void Run()
        {
            var numServers = Model.ServerAccounts.Find(new ServerAccount()).Count();
            if (GetServerManagementAccount() == null && numServers == 0)
            {
                using (var form = new GettingStarted(this))
                {
                    form.ShowDialog();
                    if (!form.Success)
                        return;
                }
            }

            _activeDatabase = true;
            ShowHomePage();

            UpdateUiUnsafe();

            Application.Run(_mainForm);
        }

        public void Stop()
        {
            foreach (var server in _syncServers)
                server.Value.Stop();
            
            _syncManagement?.Stop();
        }

        public void SetActiveDatabase(int databaseId)
        {
            if (_activeDatabase && _activeDatabaseId == databaseId)
                return;

            _activeDatabase = true;
            _activeDatabaseId = databaseId;

            UpdateUiUnsafe();
            
            _mainForm.panelContentContainer.Controls.Clear();
            _mainForm.panelContentContainer.Controls.Add(_databaseViews[databaseId]);
        }
        
        public void ShowHomePage()
        {
            if (!_activeDatabase)
            {
                UpdateHomePage();
                return;
            }

            _activeDatabase = false;

            UpdateUiUnsafe();

            _mainForm.panelContentContainer.Controls.Clear();
            _mainForm.panelContentContainer.Controls.Add(_homePage);
        }

        public void UpdateUi()
        {
            if (_mainForm.InvokeRequired)
                _mainForm.Invoke((MethodInvoker) UpdateUiUnsafe);
            else
                UpdateUiUnsafe();
        }

        /// <summary>
        /// Performs a full UI update. Use sparingly.
        /// </summary>
        private void UpdateUiUnsafe()
        {
            UpdateHeader();
            UpdateSubscriptionInfoBarUnsafe();

            if (!_activeDatabase)
                UpdateHomePage();
            else
                UpdateDatabaseView();
        }
        
        public void UpdateHeader()
        {
            if (_mainForm.InvokeRequired)
                _mainForm.Invoke((MethodInvoker)UpdateHeaderUnsafe);
            else
                UpdateHeaderUnsafe();
        }

        private void UpdateHeaderUnsafe()
        {
            _header.ServerManagementAccount = 
                Model.ServerManagementAccounts.Find(new ServerManagementAccount()).FirstOrDefault();

            _header.ActiveDatabase = _activeDatabase;
            _header.ActiveDatabaseId = _activeDatabaseId;
            
            _header.UpdateControl();
        }

        public void UpdateSubscriptionInfoBar()
        {
            if (_mainForm.InvokeRequired)
                _mainForm.Invoke((MethodInvoker)UpdateSubscriptionInfoBarUnsafe);
            else
                UpdateSubscriptionInfoBarUnsafe();
        }

        private void UpdateSubscriptionInfoBarUnsafe()
        {
            var managementAccount = GetServerManagementAccount();

            if (managementAccount.Subscribed)
            {
                _mainForm.HideSubscriptionInfoBar();
            }
            else if (managementAccount.InTrial)
            {
                var daysLeft = 0;
                if (managementAccount.TrialEndsAt.HasValue)
                    daysLeft = (managementAccount.TrialEndsAt.Value - DateTime.Today).Days;

                _subscriptionInfoBar.SetInTrial(daysLeft);
                _mainForm.ShowSubscriptionInfoBar();
            }
            else
            {
                _subscriptionInfoBar.SetNotSubscribed();
                _mainForm.ShowSubscriptionInfoBar();
            }
        }

        public void UpdateHomePage()
        {
            if (_homePage.InvokeRequired)
                _homePage.Invoke((MethodInvoker)UpdateHomePageUnsafe);
            else
                UpdateHomePageUnsafe();
        }

        private void UpdateHomePageUnsafe()
        {
            _homePage.UpdateControl();
        }

        public void UpdateDatabaseView()
        {
            if (_mainForm.InvokeRequired)
                _mainForm.Invoke((MethodInvoker)UpdateDatabaseViewUnsafe);
            else
                UpdateDatabaseViewUnsafe();
        }

        public void UpdateDatabaseViewUnsafe()
        {
            if (!_databaseViews.ContainsKey(_activeDatabaseId))
                _databaseViews.Add(_activeDatabaseId, new DatabaseView(this, _activeDatabaseId));

            var databaseView = _databaseViews[_activeDatabaseId];

            databaseView.UpdateControl();
        }
        
        public bool NewDatabase(int serverAccountId)
        {
            string newDatabaseName;
            using (var form = new NewDatabase(this))
            {
                form.ShowDialog();
                if (!form.NewDatabaseNameSet)
                    return false;

                newDatabaseName = form.NewDatabaseName;
            }

            return NewDatabase(newDatabaseName, serverAccountId);
        }

        private bool NewDatabase(string dbName, int serverAccountId)
        {
            var apiClient = GetApiClient(serverAccountId);
            var request = new CreateDatabase {Name = dbName};

            CreateDatabase.ResponseParams response;
            try
            {
                response = request.GetResponse(apiClient);
            }
            catch (RequestException e)
            {
                MessageBox.Show(e.ErrorCode);
                return false;
            }

            /*var linkSuccessful = false;
            var startTime = DateTime.Now;
            while (!linkSuccessful)
            {
                Thread.Sleep(2000);

                if (startTime.AddSeconds(30) < DateTime.Now)
                    break;

                var checkRequest = new CheckClientLink {LinkIdentifier = response.DatabaseIdentifier};

                CheckClientLink.ResponseParams checkLinkResponse;
                try
                {
                    checkLinkResponse = checkRequest.GetResponse(apiClient);
                }
                catch (BadRequestException e)
                {
                    MessageBox.Show(e.ErrorCode);
                    return false;
                }

                if (checkLinkResponse.LinkEstablished)
                    linkSuccessful = true;
            }

            if (!linkSuccessful)
                return false;*/

            var newDatabaseMetaId = Model.DatabasesMeta.Create(new DatabaseMeta {Name = dbName});
            var newDatabaseId = Model.Databases.Create(new AllAuth.Desktop.Common.Models.Database
            {
                Identifier = response.DatabaseIdentifier,
                ServerAccountId = serverAccountId,
                DatabaseMetaId = newDatabaseMetaId
            });
            SetDatabaseAsModified(newDatabaseId);

            var newGroupIdentifier = Guid.NewGuid().ToString();
            var groupMetaId = Model.DatabasesGroupsMeta.Create(new DatabaseGroupMeta {Name = "Websites"});
            var groupId = Model.DatabasesGroups.Create(new DatabaseGroup
            {
                Identifier = newGroupIdentifier,
                DatabaseId = newDatabaseId,
                DatabaseGroupMetaId = groupMetaId
            });
            SetGroupAsModified(groupId);

            UpdateHomePage();

            return true;
        }

        private static ServerAPI.ApiClient GetApiClient(int serverAccountId)
        {
            var serverAccount = Model.ServerAccounts.Get(serverAccountId);
            var cryptoKey = Model.CryptoKeys.Get(serverAccount.CryptoKeyId);
            return new ServerAPI.ApiClient(
                serverAccount.HttpsEnabled, serverAccount.ServerHost, serverAccount.ServerPort, 
                serverAccount.ServerApiVersion, serverAccount.ApiKey, cryptoKey.PrivateKeyPem);
        }

        private static ApiClient GetApiClientForServerManagement()
        {
            var serverManagement = Model.ServerManagementAccounts.Find(new ServerManagementAccount()).FirstOrDefault();
            if (serverManagement == null)
                return null;

            var apiClient = new ApiClient(serverManagement.HttpsEnabled, serverManagement.Host, serverManagement.Port,
                serverManagement.ApiVersion, serverManagement.ApiKey);
            
            return apiClient;
        }

        private static ApiClient GetDefaultApiClientForServerManagement()
        {
            var apiClient = new ApiClient(
                Config.ManagementHttps, Config.ManagementHost, Config.ManagementPort, Config.ManagementApiVersion);
            
            return apiClient;
        }

        public int? NewEntry(DatabaseEntryData entryData, int groupId)
        {
            if (groupId == 0)
            {
                if (Program.AppEnvDebug)
                    throw new Exception("Group ID cannot be empty");
                return null;
            }
            if (entryData.GetModifiedProperties().Count == 0)
            {
                MessageBox.Show(@"There is no entry information to save");
                return null;
            }

            var group = Model.DatabasesGroups.Get(groupId);

            var entryDataId = Model.DatabasesEntriesData.Create(entryData);
            var newEntryIdentifier = Guid.NewGuid().ToString();
            var entryId = Model.DatabasesEntries.Create(new DatabaseEntry
            {
                DatabaseId = group.DatabaseId,
                DatabaseGroupId = groupId,
                Identifier = newEntryIdentifier,
                DatabaseEntryDataId = entryDataId
            });
            SetEntryAsModified(entryId);

            return entryId;
        }

        public int? NewGroup(int databaseId, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return null;

            var newGroupIdentifier = Guid.NewGuid().ToString();
            var groupMetaId = Model.DatabasesGroupsMeta.Create(new DatabaseGroupMeta {Name = name});
            var newGroupId = Model.DatabasesGroups.Create(new DatabaseGroup
            {
                DatabaseId = databaseId,
                Identifier = newGroupIdentifier,
                DatabaseGroupMetaId = groupMetaId
            });
            SetGroupAsModified(newGroupId);

            return newGroupId;
        }

        public bool UpdateEntry(int entryId, DatabaseEntryData entryData)
        {
            if (entryId == 0)
            {
                if (Program.AppEnvDebug)
                    throw new Exception("Entry ID cannot be empty");
                return false;
            }

            if (entryData.GetModifiedProperties().Count == 0)
                return false;

            var entry = Model.DatabasesEntries.Get(entryId);
            Model.DatabasesEntriesData.Update(entry.DatabaseEntryDataId, entryData);

            SetEntryAsModified(entryId);

            return true;
        }

        private void SetDatabaseAsModified(int databaseId)
        {
            Model.DatabasesMetaSync.Create(new DatabaseMetaSync { DatabaseId = databaseId });

            var database = Model.Databases.Get(databaseId);
            if (!_syncServers.ContainsKey(database.ServerAccountId))
                return;
            _syncServers[database.ServerAccountId].RestartSyncLoop();
        }

        private void SetGroupAsModified(int groupId)
        {
            Model.DatabasesGroupsMetaSync.Create(new DatabaseGroupMetaSync { DatabaseGroupId = groupId });

            var group = Model.DatabasesGroups.Get(groupId);
            var database = Model.Databases.Get(group.DatabaseId);
            if (!_syncServers.ContainsKey(database.ServerAccountId))
                return;
            _syncServers[database.ServerAccountId].RestartSyncLoop();
        }
        
        public void SetEntryAsModified(int entryId, bool restartSyncLoop = true)
        {
            Model.DatabasesEntriesDataSync.Create(new DatabaseEntryDataSync { DatabaseEntryId = entryId });

            if (restartSyncLoop)
            {
                var entry = Model.DatabasesEntries.Get(entryId);
                var database = Model.Databases.Get(entry.DatabaseId);
                if (!_syncServers.ContainsKey(database.ServerAccountId))
                    return;
                _syncServers[database.ServerAccountId].RestartSyncLoop();
            }
        }

        private static ServerManagementAccount GetServerManagementAccount()
        {
            return Model.ServerManagementAccounts.Find(new ServerManagementAccount()).FirstOrDefault();
        }

        public bool LoginToServer(ServerAccount newServerAccount, string recoveryPasswordPlaintext)
        {
            // Duplicate check
            var existingServers = Model.ServerAccounts.Find(new ServerAccount
            {
                ServerHost = newServerAccount.ServerHost,
                ServerPort = newServerAccount.ServerPort,
                EmailAddress = newServerAccount.EmailAddress
            });
            if (existingServers.Any())
            {
                MessageBox.Show(@"You are already logged in to this server. ");
                return false;
            }

            var newKeyPair = AsymmetricCryptoUtil.GenerateKeyPair();
            var recoveryPasswordHash = HashUtil.GenerateServerRecoveryPasswordHash(
                newServerAccount.EmailAddress, recoveryPasswordPlaintext);

            var apiClientUnauthenticated = new ServerAPI.ApiClient(newServerAccount.HttpsEnabled,
                newServerAccount.ServerHost, newServerAccount.ServerPort, newServerAccount.ServerApiVersion);

            var loginRequest = new ServerAPI.Requests.Unauthenticated.LoginWithDatabaseRecoveryKey
            {
                EmailAddress = newServerAccount.EmailAddress,
                RecoveryPasswordClientHash = recoveryPasswordHash,
                DeviceLabel = "My Desktop App",
                DeviceType = "desktop",
                DeviceSubtype = "windows",
                PublicKeyPem = newKeyPair.PublicPem
            };

            ServerAPI.Requests.Unauthenticated.LoginWithDatabaseRecoveryKey.ResponseParams loginResponse;
            try
            {
                loginResponse = loginRequest.GetResponse(apiClientUnauthenticated);
            }
            catch (UnauthorizedException)
            {
                MessageBox.Show(@"Incorrect email address or recovery passphrase.");
                return false;
            }
            catch (RequestException)
            {
                MessageBox.Show(@"There was an error attempting to log in to the server.");
                return false;
            }
            
            var apiClient = new ServerAPI.ApiClient(
                newServerAccount.HttpsEnabled,
                newServerAccount.ServerHost,
                newServerAccount.ServerPort,
                newServerAccount.ServerApiVersion,
                loginResponse.ApiKey,
                newKeyPair.PrivatePem);
            
            var serverInfo = apiClient.GetServerInfo(new ServerAPI.GetServerInfoRequest());

            newServerAccount.ServerIdentifier = serverInfo.ServerIdentifier;
            newServerAccount.ServerLabel = serverInfo.ServerLabel;
            newServerAccount.UserIdentifier = loginResponse.UserIdentifier;
            newServerAccount.DeviceIdentifier = loginResponse.DeviceIdentifier;
            newServerAccount.ApiKey = loginResponse.ApiKey;
            newServerAccount.BackupEncryptionPassword = 
                HashUtil.GenerateDatabaseBackupPasswordHash(newServerAccount.EmailAddress, recoveryPasswordPlaintext);

            var newCryptoKeyId = Model.CryptoKeys.Create(new CryptoKey
            {
                OwnKey = true,
                Trust = true,
                PrivateKeyPem = newKeyPair.PrivatePem,
                PublicKeyPem = newKeyPair.PublicPem
            });
            newServerAccount.CryptoKeyId = newCryptoKeyId;

            ServerAPI.GetUserResponse userInfo;
            try
            {
                userInfo = apiClient.GetUser(new ServerAPI.GetUserRequest());

                if (userInfo.SecondDeviceSetupCompleted)
                {
                    // Retrieve the linked device public key
                    var linkedDeviceResponse = new GetLinkedDevice().GetResponse(apiClient);
                    var linkedDeviceCryptoKeyId = Model.CryptoKeys.Create(new CryptoKey
                    {
                        PublicKeyPem = linkedDeviceResponse.PublicKeyPem,
                        PublicKeyPemHash = HashUtil.Sha256(linkedDeviceResponse.PublicKeyPem)
                    });
                    newServerAccount.LinkedDeviceCryptoKeyId = linkedDeviceCryptoKeyId;
                }
            }
            catch (RequestException)
            {
                MessageBox.Show(@"There was an error attempting to retrieve linked device details.");
                return false;
            }
            
            var newServerAccountId = Model.ServerAccounts.Create(newServerAccount);
            
            if (!userInfo.SecondDeviceSetupCompleted)
            {
                Model.ServerAccounts.Update(newServerAccountId, new ServerAccount {LinkedDeviceSetup = true});
                
                if (userInfo.Links.Count == 0)
                    NewDatabase("My Database", newServerAccountId);
            }
            
            if (!_syncServers.ContainsKey(newServerAccountId))
            {
                _syncServers.Add(newServerAccountId, new Sync(this, newServerAccountId));
                _syncServers[newServerAccountId].Start();
            }

            UpdateHomePage();

            return true;
        }

        public bool ServerCheckOtpDeviceSetup(ServerAccount server, string loginRequestIdentifier)
        {
            var apiClient = GetApiClient(server.Id);
            var request = new CheckSecondDeviceSetup {LoginRequestIdentifier = loginRequestIdentifier};
            
            try
            {
                return request.GetResponse(apiClient).SecondDeviceCompletedSetup;
            }
            catch (RequestException)
            {
                return false;
            }
        }

        public bool CheckDeviceMessageStatus(int serverAccountId, string messageIdentifier, out bool processedSuccess)
        {
            var request = new GetMessageStatus { MessageIdentifier = messageIdentifier };
            var response = request.GetResponse(GetApiClient(serverAccountId));

            if (!response.Processed)
            {
                processedSuccess = false;
                return false;
            }

            processedSuccess = response.ProcessedSuccess;
            return true;
        }

        public bool LoginToServerManagement(string emailAddress, string recoveryPassword)
        {
            var apiClient = new ApiClient(
                Config.ManagementHttps, Config.ManagementHost, Config.ManagementPort, Config.ManagementApiVersion);

            LoginWithRecoveryKey.ResponseParams response;
            try
            {
                var request = new LoginWithRecoveryKey
                {
                    EmailAddress = emailAddress,
                    RecoveryPasswordClientHash =
                        HashUtil.GenerateServerManagerRecoveryPasswordHash(emailAddress, recoveryPassword)
                };
                response = request.GetResponse(apiClient);
            }
            catch (UnauthorizedException)
            {
                MessageBox.Show(@"Incorrect email or recovery passphrase");
                return false;
            }
            catch (RequestException)
            {
                MessageBox.Show(@"Error logging in to server");
                return false;
            }

            var managementAccountId = Model.ServerManagementAccounts.Create(new ServerManagementAccount
            {
                HttpsEnabled = Config.ManagementHttps,
                Host = Config.ManagementHost,
                Port = Config.ManagementPort, 
                ApiVersion = Config.ManagementApiVersion,
                UserIdentifier = response.UserIdentifier,
                EmailAddress = emailAddress,
                ApiKey = response.ApiKey
            });

            _syncManagement = new SyncManagement(this, managementAccountId);
            _syncManagement.Start();

            UpdateHeader();
            GetServersFromServerManagement(recoveryPassword);

            return true;
        }

        private void GetServersFromServerManagement(string recoveryPassword)
        {
            var serverManagement = GetServerManagementAccount();
            if (serverManagement == null)
                return;

            var apiClient = GetApiClientForServerManagement();

            GetUser.ResponseParams response;
            try
            {
                response = new GetUser().GetResponse(apiClient);
            }
            catch (RequestException)
            {
                if (Program.AppEnvDebug)
                    throw;

                MessageBox.Show(@"There was an error communicating with the server. " +
                    @"If this does not automatically rectify soon, please contact support.");
                return;
            }

            if (response.Servers.Count == 0)
                return;

            if (response.Servers.Count > 1)
                throw new NotImplementedException("Multiple server import is not yet supported");

            var server = response.Servers[0];

            var newServerAccount = new ServerAccount
            {
                Managed = true,
                ServerIdentifier = server.Identifier,
                ServerLabel = server.Label,
                HttpsEnabled = server.HttpsEnabled,
                ServerHost = server.Hostname,
                ServerPort = server.Port,
                ServerApiVersion = server.ApiVersion,
                EmailAddress = serverManagement.EmailAddress
            };

            var existingServer = Model.ServerAccounts.Find(new ServerAccount
            {
                ServerIdentifier = newServerAccount.ServerIdentifier,
                EmailAddress = newServerAccount.EmailAddress
            }).FirstOrDefault();
            
            if (existingServer != null)
            {
                // We probably logged out of the management server and logged back in.
                Model.ServerAccounts.Update(existingServer.Id, new ServerAccount {Managed = true});
                return;
            }
            
            // New server account
            LoginToServer(newServerAccount, recoveryPassword);
        }

        public bool EditDatabase(int databaseId, DatabaseMeta databaseMeta)
        {
            var database = Model.Databases.Get(databaseId);
            Model.DatabasesMeta.Update(database.DatabaseMetaId, databaseMeta);
            SetDatabaseAsModified(databaseId);
            
            return true;
        }

        public async Task<bool> LogoutServerManagement()
        {
            var serverManagementAccount = GetServerManagementAccount();
            var managedServers = Model.ServerAccounts.Find(new ServerAccount {Managed = true});

            foreach (var server in managedServers)
            {
                await LogoutServer(server.Id, false);

                var databases = Model.Databases.Find(new Database {ServerAccountId = server.Id});
                foreach (var database in databases)
                {
                    if (_activeDatabaseId == database.Id)
                    {
                        _activeDatabase = false;
                        _activeDatabaseId = 0;
                    }

                    if (_databaseViews.ContainsKey(database.Id))
                    {
                        _databaseViews[database.Id].Dispose();
                        _databaseViews.Remove(database.Id);
                    }
                }
            }

            // Logout locally, then attempt to revoke the API key remotely.
            var apiClient = GetApiClientForServerManagement();
            Model.ServerManagementAccounts.Delete(serverManagementAccount.Id);
            
            try
            {
                await new Lib.ManagementAPI.Requests.Authenticated.Logout().GetResponseAsync(apiClient);
            }
            catch (RequestException)
            {
                // We'll handle this silently and assume the API key has already been revoked 
                // for some other reason.
            }

            Program.Restart = true;
            _mainForm.Invoke((MethodInvoker)_mainForm.Close);

            return true;
        }

        public async Task<bool> LogoutServer(int serverAccountId, bool updateUi = true)
        {
            if (_syncServers.ContainsKey(serverAccountId))
            {
                _syncServers[serverAccountId].Stop();
                _syncServers.Remove(serverAccountId);
            }

            try
            {
                await new Logout().GetResponseAsync(GetApiClient(serverAccountId));
            }
            catch (RequestException)
            {
                // We'll handle this silently and assume the API key has already been revoked 
                // for some other reason.
            }

            Model.ServerAccounts.Delete(serverAccountId);

            if (updateUi)
                UpdateUi();

            return true;
        }

        public void SetDatabaseSyncStatus(int databaseId, Sync.Statuses status)
        {
            if (_mainForm.InvokeRequired)
                _mainForm.Invoke((MethodInvoker) delegate { SetDatabaseSyncStatusUnsafe(databaseId, status); });
            else
                SetDatabaseSyncStatusUnsafe(databaseId, status);
        }

        private void SetDatabaseSyncStatusUnsafe(int databaseId, Sync.Statuses status)
        {
            if (!_activeDatabase || _activeDatabaseId != databaseId)
                return;

            _header.UpdateDatabaseSyncStatus(databaseId, status);
        }

        public void SetServerSyncStatus(int serverId, Sync.Statuses status)
        {
            if (_mainForm.InvokeRequired)
                _mainForm.Invoke((MethodInvoker) delegate { SetServerSyncStatusUnsafe(serverId, status); });
            else
                SetServerSyncStatusUnsafe(serverId, status);
        }

        private void SetServerSyncStatusUnsafe(int serverId, Sync.Statuses status)
        {
            _homePage.SetServerSyncStatus(serverId, status);
        }

        public void ShowSettings()
        {
            using (var form = new Settings(this))
            {
                form.ShowDialog();
            }
            UpdateUiUnsafe();
        }

        public static void CopyToClipboard(string stringToCopy)
        {
            if (string.IsNullOrEmpty(stringToCopy))
                return;

            Clipboard.SetText(stringToCopy);
        }

        public string GetSecret(int databaseId, int entryId, string secretIdentifier, string secretEncryptedData)
        {
            var database = Model.Databases.Get(databaseId);
            var serverAccount = Model.ServerAccounts.Get(database.ServerAccountId);
            var linkedDeviceCryptoKey = Model.CryptoKeys.Get(serverAccount.LinkedDeviceCryptoKeyId);
            var entry = Model.DatabasesEntries.Get(entryId);
            var deviceMessage = new ServerAPI.DeviceToDeviceMessages.RequestEntrySecrets
            {
                EntryIdentifier = entry.Identifier,
                SecretIdentifiers = new List<string> { secretIdentifier }
            };
            var request = new SendLinkedDeviceMessage
            {
                //LinkIdentifier = database.Identifier,
                SecondsValidFor = 30
            };
            request.SetMessage(deviceMessage, linkedDeviceCryptoKey.PublicKeyPem);

            SendLinkedDeviceMessage.ResponseParams response;
            try
            {
                response = request.GetResponse(GetApiClient(serverAccount.Id));
            }
            catch (RequestException)
            {
                return null;
            }

            var messageHandler = new SendSecretShareMessageHandler(
                _syncServers[serverAccount.Id], response.MessageIdentifier);

            // Give the sync process a kick up the arse
            _syncServers[serverAccount.Id].ProcessMessagesOnly();

            var replyReceived = messageHandler.WaitForReply();
            
            // Give the sync process a kick up the arse
            _syncServers[serverAccount.Id].ProcessMessagesOnlyStop();

            if (!replyReceived)
            {
                MessageBox.Show(@"Secret share request timed out");
                return null;
            }

            var secretShareMessage = messageHandler.Reply;

            if (!secretShareMessage.RequestAccepted)
            {
                MessageBox.Show(@"Secret share request denied");
                return null;
            }

            string secretShare;
            secretShareMessage.Secrets.TryGetValue(secretIdentifier, out secretShare);
            if (string.IsNullOrEmpty(secretShare))
            {
                messageHandler.MarkAsProcessed(false);
                MessageBox.Show(@"Error obtaining secret share");
                return null;
            }
            
            var decryptedData = EncryptedData.DecryptData(secretShare, secretEncryptedData);
            
            messageHandler.MarkAsProcessed(true);

            return decryptedData;
        }

        public bool RegisterWithServerManagement()
        {
            var serverManagementAccount = new ServerManagementAccount
            {
                HttpsEnabled = Config.ManagementHttps,
                Host = Config.ManagementHost,
                Port = Config.ManagementPort,
                ApiVersion = Config.ManagementApiVersion,
                Label = Config.ManagementLabel,
                Subscribed = false,
                InTrial = true,
                TrialEndsAt = DateTime.Today.AddDays(Config.TrialLengthDays)
            };

            using (var form = new ServerManagementRegister(this))
            {
                form.ShowDialog();
                if (!form.Success)
                    return false;
                
                using (var formConfirm = new ServerManagementRegisterConfirm(this, serverManagementAccount, 
                    form.RegistrationIdentifier, form.ClientToken))
                {
                    formConfirm.ShowDialog();
                    if (!formConfirm.Success)
                        return false;

                    serverManagementAccount.EmailAddress = form.EmailAddress;
                    
                    var newManagementAccountId = Model.ServerManagementAccounts.Create(serverManagementAccount);

                    _syncManagement = new SyncManagement(this, newManagementAccountId);
                    _syncManagement.Start();

                    var registrationIdentifier = formConfirm.ServerRegistrationIdentifier;
                    var clientToken = formConfirm.ServerClientToken;
                    var recoveryPasswordPlaintext = form.RecoveryPasswordPlainText;

                    Task.Run(() => RegisterServerComplete(registrationIdentifier,
                        clientToken, recoveryPasswordPlaintext));
                }
            }
            
            return true;
        }
        
        public bool RegisterWithServerManagement(string emailAddress, string recoveryPassphrasePlaintext,
            out string registrationIdentifier, out string clientToken)
        {
            registrationIdentifier = "";
            clientToken = "";

            var apiClient = GetDefaultApiClientForServerManagement();
            
            var recoveryHash = HashUtil.GenerateServerManagerRecoveryPasswordHash(
                emailAddress, recoveryPassphrasePlaintext);

            var request = new Register
            {
                EmailAddress = emailAddress,
                RecoveryPasswordClientHash = recoveryHash
            };

            Register.ResponseParams response;
            try
            {
                response = request.GetResponse(apiClient);
            }
            catch (RequestException e)
            {
                if (Program.AppEnvDebug)
                    MessageBox.Show(@"Unexpected error contacting server: " + e.Message);
                else
                    MessageBox.Show(@"Unexpected error contacting server");

                return false;
            }

            registrationIdentifier = response.RegistrationIdentifier;
            clientToken = response.ClientToken;
            return true;
        }
        
        public bool RegisterWithServerManagementComplete(ServerManagementAccount serverManagementAccount,
            string registrationIdentifier, string clientToken, string emailToken, 
            out string serverRegistrationIdentifier, out string serverClientToken)
        {
            serverRegistrationIdentifier = "";
            serverClientToken = "";

            var apiClient = new ApiClient(serverManagementAccount.HttpsEnabled, serverManagementAccount.Host, 
                serverManagementAccount.Port, serverManagementAccount.ApiVersion);

            var request = new RegisterComplete
            {
                RegistrationIdentifier = registrationIdentifier,
                ClientToken = clientToken, 
                EmailToken = emailToken
            };

            RegisterComplete.ResponseParams response;
            try
            {
                response = request.GetResponse(apiClient);
            }
            catch (NotFoundException)
            {
                MessageBox.Show(@"The code appears to be incorrect.");
                return false;
            }
            catch (RequestException)
            {
                MessageBox.Show(@"An unexpected error occured contacting the server.");
                return false;
            }

            serverManagementAccount.UserIdentifier = response.UserIdentifier;
            serverManagementAccount.ApiKey = response.ApiKey;

            serverRegistrationIdentifier = response.ServerRegistrationIdentfier;
            serverClientToken = response.ServerClientToken;

            return true;
        }

        private void RegisterServerComplete(string registrationIdentifier, string clientToken, 
            string recoveryPasswordPlaintext)
        {
            var managementAccount = GetServerManagementAccount();
            var managementApiClient = GetApiClientForServerManagement();

            var serversRequest = new GetUser();
            GetUser.ResponseParams serversResponse;
            try
            {
                serversResponse = serversRequest.GetResponse(managementApiClient);
            }
            catch (RequestException)
            {
                if (Program.AppEnvDebug) throw;

                MessageBox.Show(@"There was an error downloading the required information to setup your account.");
                return;
            }

            if (serversResponse.Servers.Count != 1)
            {
                if (Program.AppEnvDebug) throw new Exception ("Unsupported number of servers for user");

                MessageBox.Show(@"There was an error downloading the required information to setup your account.");
                return;
            }

            var server = serversResponse.Servers[0];
            var serverApiClient = new ServerAPI.ApiClient(
                server.HttpsEnabled, server.Hostname, server.Port, server.ApiVersion);
            var newKeypair = AsymmetricCryptoUtil.GenerateKeyPair();
            var registerRequest = new ServerAPI.Requests.Unauthenticated.RegisterComplete
            {
                RegisterRequestIdentifier = registrationIdentifier,
                ClientToken = clientToken,
                DeviceLabel = "My Desktop App",
                DeviceType = "desktop",
                DeviceSubtype = "windows",
                PublicKeyPem = newKeypair.PublicPem,
                RecoveryPasswordClientHash = HashUtil.GenerateServerRecoveryPasswordHash(
                    managementAccount.EmailAddress, recoveryPasswordPlaintext)
            };

            ServerAPI.Requests.Unauthenticated.RegisterComplete.ResponseParams registerResponse;
            try
            {
                registerResponse = registerRequest.GetResponse(serverApiClient);
            }
            catch (RequestException e)
            {
                if (Program.AppEnvDebug)
                    throw new Exception("Unexpected network error", e);

                MessageBox.Show(@"There was an error downloading the required information to setup your account.");
                return;
            }

            var cryptoKeyId = Model.CryptoKeys.Create(new CryptoKey
            {
                OwnKey = true,
                Trust = true,
                PrivateKeyPem = newKeypair.PrivatePem,
                PublicKeyPem = newKeypair.PublicPem
            });
            var newServer = new ServerAccount
            {
                Managed = true,
                HttpsEnabled = server.HttpsEnabled,
                ServerIdentifier = server.Identifier,
                ServerLabel = server.Label ?? "",
                ServerHost = server.Hostname,
                ServerPort = server.Port,
                ServerApiVersion = server.ApiVersion,
                UserIdentifier = registerResponse.UserIdentifier,
                DeviceIdentifier = registerResponse.DeviceIdentifier,
                EmailAddress = managementAccount.EmailAddress,
                ApiKey = registerResponse.ApiKey,
                CryptoKeyId = cryptoKeyId,
                BackupEncryptionPassword =
                    HashUtil.GenerateDatabaseBackupPasswordHash(managementAccount.EmailAddress, recoveryPasswordPlaintext)
            };
            var newServerAccountId = Model.ServerAccounts.Create(newServer);
            newServer.Id = newServerAccountId;

            var serverApiClientAuthenticated = new ServerAPI.ApiClient(server.HttpsEnabled,
                server.Hostname, server.Port, server.ApiVersion, registerResponse.ApiKey, newKeypair.PrivatePem);

            /*var deviceRegisterRequest = new InitiateDeviceLogin();
            InitiateDeviceLogin.ResponseParams deviceRegisterResponse;
            try
            {
                deviceRegisterResponse = deviceRegisterRequest.GetResponse(serverApiClientAuthenticated);
            }
            catch (RequestException)
            {
                if (Program.AppEnvDebug) throw;

                MessageBox.Show(@"There was an unknown error registering mobile device with the server");
                return;
            }
            
            var linkCode = new LinkCodeRegisterInitialOtpDevice(newServer.HttpsEnabled,
                newServer.ServerHost, newServer.ServerPort, newServer.ServerApiVersion,
                deviceRegisterResponse.LoginRequestIdentifier, newServer.EmailAddress, HashUtil.Sha256(newKeypair.PublicPem));

            using (var form = new SetupOtpDeviceLink(this, linkCode.ToString(), newServer,
                deviceRegisterResponse.LoginRequestIdentifier))
            {
                form.ShowDialog();
                if (!form.Success)
                {
                    MessageBox.Show(@"Link to second device was not established.");
                    return;
                }
            }*/
            
            // We need to verify the new keys with the second device.
            /*var publicKeyHash = HashUtil.Sha256(newKeypair.PublicPem);
            RequestKeyVerification.ResponseParams verificationResponse;
            try
            {
                verificationResponse = new RequestKeyVerification().GetResponse(serverApiClientAuthenticated);
            }
            catch (RequestException)
            {
                if (Program.AppEnvDebug) throw;

                MessageBox.Show(@"There was an error verifying keys with your mobile device.");
                return;
            }

            using (var form = new VerifyKeyOnSecondDevice(
                this, newServerAccountId, publicKeyHash, verificationResponse.MessageIdentifier))
            {
                form.ShowDialog();
                if (!form.Success)
                {
                    MessageBox.Show(
                        @"Could not verify encryption keys with device.\r\n\r\n" +
                        @"You will encounter a lack of functionality until this has been completed.");
                }
            }*/

//            // TODO: Verify the linked device key properly.
//            GetLinkedDevice.ResponseParams linkedDeviceResponse;
//            try
//            {
//                linkedDeviceResponse = new GetLinkedDevice().GetResponse(serverApiClientAuthenticated);
//            }
//            catch (RequestException)
//            {
//                if (Program.AppEnvDebug) throw new Exception("Error getting linked device info");
//
//                MessageBox.Show(@"There was an error verifying mobile device key.");
//                return;
//            }
//             
//            var linkedDeviceCryptoKeyId = Model.CryptoKeys.Create(new CryptoKey
//            {
//                Trust = true,
//                PublicKeyPem = linkedDeviceResponse.PublicKeyPem
//            });
//            Model.ServerAccounts.Update(newServerAccountId, new ServerAccount
//            {
//                LinkedDeviceCryptoKeyId = linkedDeviceCryptoKeyId
//            });


            ServerAPI.GetUserResponse userInfoResponse;
            try
            {
                userInfoResponse = serverApiClientAuthenticated.GetUser(new ServerAPI.GetUserRequest());
            }
            catch (RequestException e)
            {
                if (Program.AppEnvDebug)
                    throw new Exception("Unexpected error getting user info", e);

                MessageBox.Show(@"There was an error retrieving server information.");
                return;
            }

            // We can't do this yet. The server sends this to the second device as it is right now,
            // which hasn't been set.
            //if (userInfoResponse.Links.Count == 0)
            //    NewDatabase("My Database", newServerAccountId);

            if (!_syncServers.ContainsKey(newServerAccountId))
            {
                _syncServers.Add(newServerAccountId, new Sync(this, newServerAccountId));
                _syncServers[newServerAccountId].Start();
            }

            UpdateHomePage();
        }

        public bool LinkSecondDevice(int serverAccountId, bool isRecovery = false)
        {
            var serverAccount = Model.ServerAccounts.Get(serverAccountId);
            var apiClient = GetApiClient(serverAccountId);
            var cryptoKey = Model.CryptoKeys.Get(serverAccount.CryptoKeyId);
            
            using (var form = new SetupOtpDeviceLink(this, apiClient, serverAccount,
                cryptoKey))
            {
                form.ShowDialog();
                if (!form.Success)
                {
                    //MessageBox.Show(@"Link to second device was not established.");
                    return false;
                }
            }

            // TODO: Verify the linked device key properly.
            GetLinkedDevice.ResponseParams linkedDeviceResponse;
            try
            {
                linkedDeviceResponse = new GetLinkedDevice().GetResponse(apiClient);
            }
            catch (RequestException e)
            {
                if (Program.AppEnvDebug)
                    throw new Exception("Error getting linked device info", e);

                MessageBox.Show(@"There was an error verifying phone's device key.");
                return false;
            }

            var linkedDeviceCryptoKeyId = Model.CryptoKeys.Create(new CryptoKey
            {
                //Trust = true,
                PublicKeyPem = linkedDeviceResponse.PublicKeyPem,
                PublicKeyPemHash = HashUtil.Sha256(linkedDeviceResponse.PublicKeyPem)
            });
            Model.ServerAccounts.Update(serverAccountId, new ServerAccount
            {
                LinkedDeviceSetup = true,
                LinkedDeviceCryptoKeyId = linkedDeviceCryptoKeyId
            });

            ServerAPI.GetUserResponse userInfoResponse;
            try
            {
                userInfoResponse = apiClient.GetUser(new ServerAPI.GetUserRequest());
            }
            catch (RequestException e)
            {
                if (Program.AppEnvDebug)
                    throw new Exception("Unexpected error getting user info", e);

                return true;
            }

            if (userInfoResponse.Links.Count == 0)
                NewDatabase("My Database", serverAccountId);

            VerifyDeviceKeys(serverAccountId);

            UpdateHomePage();

            return true;
        }

        public bool VerifyDeviceKeys(int serverAccountId)
        {
            var serverAccount = Model.ServerAccounts.Get(serverAccountId);
            var apiClient = GetApiClient(serverAccountId);
            var cryptoKey = Model.CryptoKeys.Get(serverAccount.CryptoKeyId);
            var nonce = RandomUtil.GenerateRandomByteString(32);

            var apiRequest = new RequestKeyVerification
            {
                Nonce = nonce,
                NonceSigned = AsymmetricCryptoUtil.CreateSignature(nonce, cryptoKey.PrivateKeyPem)
            };
            try
            {
                apiRequest.GetResponse(apiClient);
            }
            catch (RequestException)
            {
                return false;
            }

            var form = new VerifyKeyOnSecondDevice(
                this, serverAccountId, cryptoKey.Id, nonce);

            using (form)
            {
                form.ShowDialog();
                if (!form.Success)
                {
                    return false;
                }
            }

            // TODO: Verify the linked device key properly.
            /*var linkedDevice = new GetLinkedDevice().GetResponse(apiClient);
            var linkedDeviceCryptoKeyId = Model.CryptoKeys.Create(new CryptoKey
            {
                Trust = true,
                PublicKeyPem = linkedDevice.PublicKeyPem
            });
            Model.ServerAccounts.Update(serverAccountId, new ServerAccount
            {
                LinkedDeviceCryptoKeyId = linkedDeviceCryptoKeyId
            });*/

            return true;
        }

        public void DeleteEntry(int entryId)
        {
            var entry = Model.DatabasesEntries.Get(entryId);
            Model.DatabasesEntries.Update(entryId, new DatabaseEntry {ToBeDeleted = true});

            _databaseViews[entry.DatabaseId].DeselectEntry();
            _databaseViews[entry.DatabaseId].UpdateControl();
            SetEntryAsModified(entryId);
        }

        public void Close()
        {
            _mainForm.Close();
        }

        public void RecoverSecondDevice(int serverAccountId)
        {
            using (var form = new RecoverSecondDeviceConfirm(this))
            {
                form.ShowDialog();
                if (!form.Success)
                    return;
            }
            
            LinkSecondDevice(serverAccountId);
        }
        
        public async Task<bool> RecoverSecondDeviceConfirmed()
        {
            var database = Model.Databases.Get(_activeDatabaseId);
            var apiClient = GetApiClient(database.ServerAccountId);
            var request = new ResetSecondDevice();

            try
            {
                await request.GetResponseAsync(apiClient);
            }
            catch (RequestException)
            {
                _mainForm.Invoke((MethodInvoker) delegate
                {
                    MessageBox.Show(@"There was an unexpected error attempting to reset the second device. " +
                                    @"Please try again later.");
                });
                return false;
            }

            Model.ServerAccounts.Update(database.ServerAccountId, new ServerAccount {LinkedDeviceSetup = false});

            _mainForm.Invoke((MethodInvoker) ShowHomePage);

            return true;
        }

        public void OpenAccountManagement(string openSection = null)
        {
            string link;
            using (var form = new OpeningAccountManagement(this))
            {
                form.ShowDialog();

                if (!form.Success)
                    return;

                link = form.LoginLink;
            }

            if (openSection != null)
                link += "&section=billing";

            System.Diagnostics.Process.Start(link);
        }

        public async Task<string> GetAccountManagementLoginLink()
        {
            var request = new GetLoginKeyAccountManagement();
            GetLoginKeyAccountManagement.ResponseParams response;
            try
            {
                response = await request.GetResponseAsync(GetApiClientForServerManagement());
            }
            catch (RequestException)
            {
                return null;
            }

            return Config.AppAccountManagementUrl + "/login/with_key?key=" + response.LoginKey;
        }
        
        public Sync GetSyncServerInstance(int serverAccountId)
        {
            return _syncServers[serverAccountId];
        }

        public static Dictionary<string, string> GetImportTypes()
        {
            var list = new Dictionary<string, string>
            {
                {"lastpass", "LastPass"}
            };
            return list;
        }

        public void ImportStart()
        {
            if (!_activeDatabase || _activeDatabaseId == 0)
            {
                MessageBox.Show(@"Please open the database you would like to import into before running the import.");
                return;
            }

            using (var form = new Import(this))
            {
                form.ShowDialog();
            }
        }

        public bool ImportProcess(string importType, string importFilePath)
        {
            using (var fileStream = new FileStream(importFilePath, FileMode.Open))
            {
                switch (importType)
                {
                    case "lastpass":
                        return ImportLastPass(fileStream);
                }
            }

            return false;
        }
        
        private int CreateDatabaseGroup(int databaseId, string name)
        {
            var groups = Model.DatabasesGroups.Find(new DatabaseGroup());
            foreach (var group in groups)
            {
                var groupMeta = Model.DatabasesGroupsMeta.Get(group.DatabaseGroupMetaId);
                if (groupMeta.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return group.Id;
                }
            }

            var newGroupIdentifier = Guid.NewGuid().ToString();
            var newGroupMetaId = Model.DatabasesGroupsMeta.Create(new DatabaseGroupMeta { Name = name });
            var newGroupId = Model.DatabasesGroups.Create(new DatabaseGroup
            {
                DatabaseId = databaseId,
                Identifier = newGroupIdentifier,
                DatabaseGroupMetaId = newGroupMetaId
            });
            SetGroupAsModified(newGroupId);

            return newGroupId;
        }

        private bool ImportLastPass(Stream inputStream)
        {
            var websitesGroupId = CreateDatabaseGroup(_activeDatabaseId, "Websites");
            var notesGroupId = CreateDatabaseGroup(_activeDatabaseId, "Secure Notes");

            using (var parser = new TextFieldParser(inputStream))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");

                var header = true;
                while (!parser.EndOfData)
                {
                    var fields = parser.ReadFields();

                    if (header)
                    {
                        header = false;
                        continue;
                    }

                    if (fields == null || fields.Length != 7)
                        continue;

                    var url = fields[0];
                    var username = fields[1];
                    var password = fields[2];
                    var extra = fields[3];
                    var name = fields[4];
                    var grouping = fields[5];
                    var fav = fields[6];

                    var newEntryDataId = Model.DatabasesEntriesData.Create(new DatabaseEntryData
                    {
                        Name = name,
                        Url = url,
                        Username = username,
                        Password = password,
                        Notes = extra
                    });

                    var groupIdForEntry = grouping == "Secure Notes" ? notesGroupId : websitesGroupId;

                    var newEntryIdentifier = Guid.NewGuid().ToString();
                    var newEntryId = Model.DatabasesEntries.Create(new DatabaseEntry
                    {
                        Identifier = newEntryIdentifier,
                        DatabaseId = _activeDatabaseId,
                        DatabaseGroupId = groupIdForEntry,
                        DatabaseEntryDataId = newEntryDataId
                    });

                    SetEntryAsModified(newEntryId, false);
                }
            }

            UpdateDatabaseView();

            return true;
        }
    }
}
