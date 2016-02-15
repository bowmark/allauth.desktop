using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AllAuth.Desktop.Common.Models;
using AllAuth.Lib;
using AllAuth.Lib.APIs;
using AllAuth.Lib.Crypto;
using AllAuth.Lib.ServerAPI;
using AllAuth.Lib.ServerAPI.Requests.Authenticated;
using Newtonsoft.Json;

namespace AllAuth.Desktop
{
    /// <summary>
    /// Handles syncing links with servers and other linked clients.
    /// </summary>
    internal sealed class Sync
    {
        public enum Statuses
        {
            UpToDate,
            Syncing,
            Offline
        }

        public event EventHandler<SendEntrySecretsMessageReceivedEventArgs> SendSecretShareMessageReceived;
        public event EventHandler<VerifyDeviceKeysResponseReceivedEventArgs> VerifyDeviceKeysResponseReceived;

        /// <summary>
        /// When set to true, tells the the sync loop thread to stop gracefully.
        /// </summary>
        private bool _stopSyncLoop;

        /// <summary>
        /// Used to pause between sync loop iterations.
        /// Can also be used to force a sync loop iteration if an action requires an immediate response.
        /// </summary>
        private readonly EventWaitHandle _syncLoopWait = new AutoResetEvent(false);

        /// <summary>
        /// Used to block the calling thread until the sync loop thread has stopped gracefully.
        /// </summary>
        private readonly EventWaitHandle _stopSyncLoopWait = new AutoResetEvent(false);
        
        private readonly int _serverAccountId;
        
        private bool _databasesLoaded;  
        
        private readonly Controller _controller;

        private bool _processMessagesOnly;
        private readonly object _processMessagesOnlyLock = new {};

        private AutoResetEvent _longpollInterrupt = new AutoResetEvent(false);

        private bool _serverInfoLoaded;
        private bool _userInfoLoaded;

        private int _requestErrors;

        private bool _processingSecretShares;

        private bool _databaseEntriesUploadRunning;
        private bool _databaseEntriesDownloadRunning;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="serverAccountId"></param>
        public Sync(Controller controller, int serverAccountId)
        {
            _controller = controller;
            _serverAccountId = serverAccountId;
        }

        /// <summary>
        /// Creates and starts the sync loop thread.
        /// </summary>
        public void Start()
        {
            Logger.Info("Starting the sync loop thread");
            
            _stopSyncLoop = false;

            var thread = new Thread(Run);
            thread.Start();

            Logger.Info("Sync loop thread started");
        }

        /// <summary>
        /// Tells the sync loop thread to stop at next possible opportunity.
        /// This will block until the thread has completed gracefully completed.
        /// </summary>
        public void Stop()
        {
            Logger.Info("Been told to stop the sync loop");

            // Tell the sync loop to stop (force an iteration if necessary), then block until completed.
            _stopSyncLoop = true;
            _syncLoopWait.Set();
            _longpollInterrupt.Set();
            _stopSyncLoopWait.WaitOne();

            Logger.Info("Stopped sync loop");
        }

        /// <summary>
        /// Reloads the database to sync.
        /// </summary>
        /// <param name="databaseIdentifier"></param>
        public void DatabaseModified(string databaseIdentifier)
        {
            _databasesLoaded = false;
        }

        /// <summary>
        /// Execute the sync loop.
        /// </summary>
        private void Run()
        {
            Logger.Verbose("Starting sync loop");
            
            while (true)
            {
                Logger.Verbose("Executing sync loop iteration");

                if (_stopSyncLoop)
                {
                    Logger.Info("Stopping sync loop");
                    break;
                }

                if (!_processMessagesOnly)
                {
                    GetServerInfo();
                    GetUserInfo();
                    LoadDatabases();
                    ProcessShares();
                    SyncDatabasesUpload();
                }

                if (_stopSyncLoop)
                {
                    Logger.Info("Stopping sync loop");
                    break;
                }

                ProcessMessages();

                if (_stopSyncLoop)
                {
                    Logger.Info("Stopping sync loop");
                    break;
                }

                var sleepTime = 0;
                if (_requestErrors > 15)
                    sleepTime = 30;
                else if (_requestErrors > 0)
                    sleepTime = _requestErrors*2;

                Logger.Verbose("Sync loop iteration completed. Sleeping for " + sleepTime + " secs");

                _syncLoopWait.WaitOne(sleepTime * 1000);
            }
            
            // Tell the calling thread we've stopped.
            _stopSyncLoopWait.Set();
        }

        private ApiClient GetApiClient()
        {
            var serverAccount = Model.ServerAccounts.Get(_serverAccountId);
            var serverAccountCryptoKey = Model.CryptoKeys.Get(serverAccount.CryptoKeyId);
            return new ApiClient(
                serverAccount.HttpsEnabled, 
                serverAccount.ServerHost, 
                serverAccount.ServerPort, 
                serverAccount.ServerApiVersion,
                serverAccount.ApiKey,
                serverAccountCryptoKey.PrivateKeyPem);
        }

        private ServerAccount GetServerAccount()
        {
            return Model.ServerAccounts.Get(_serverAccountId);
        }

        private Database GetDatabase(string databaseIdentifier)
        {
            return Model.Databases.Find(new Database
            {
                ServerAccountId = _serverAccountId,
                Identifier = databaseIdentifier
            }).FirstOrDefault();
        }

        private static Database GetDatabase(int databaseId)
        {
            return Model.Databases.Get(databaseId);
        }

        private void GetServerInfo()
        {
            if (_serverInfoLoaded)
                return;
            
            GetServerInfoResponse response;
            try
            {
                response = GetApiClient().GetServerInfo(new GetServerInfoRequest());
            }
            catch (RequestException)
            {
                return;
            }

            Model.ServerAccounts.Update(_serverAccountId, new ServerAccount
            {
                ServerLabel = response.ServerLabel
            });

            _serverInfoLoaded = true;
        }
        
        private void GetUserInfo()
        {
            if (_userInfoLoaded)
                return;

            GetUserResponse response;
            try
            {
                response = GetApiClient().GetUser(new GetUserRequest());
            }
            catch (RequestException)
            {
                return;
            }

            var serverAccount = GetServerAccount();
            if (response.SecondDeviceSetupCompleted != serverAccount.LinkedDeviceSetup)
            {
                Model.ServerAccounts.Update(serverAccount.Id, new ServerAccount
                {
                    LinkedDeviceSetup = response.SecondDeviceSetupCompleted
                });
                _controller.UpdateHomePage();
            }

            _userInfoLoaded = true;
        }

        /// <summary>
        /// Creates a local backup file for all managed databases and loads it into memory for syncing.
        /// </summary>
        private void LoadDatabases()
        {
            if (_databasesLoaded)
                return;

            GetUserResponse userInfo;
            try
            {
                userInfo = GetApiClient().GetUser(new GetUserRequest());
            }
            catch (RequestException)
            {
                return;
            }

            _controller.SetServerSyncStatus(_serverAccountId, Statuses.Syncing);

            // Remove local databases that are no longer on the server.
            var databases = Model.Databases.Find(new Database {ServerAccountId = _serverAccountId});
            foreach (var database in databases)
            {
                if (userInfo.Links.All(databaseLink => databaseLink.Identifier != database.Identifier))
                    Model.Databases.Delete(database.Id);
            }

            // Add server databases for backup
            foreach (var databaseLink in userInfo.Links)
            {
                if (_stopSyncLoop)
                    break;

                var database = GetDatabase(databaseLink.Identifier);

                if (database == null)
                {
                    var success = CreateDatabaseFromServer(databaseLink.Identifier);
                    if (!success)
                        continue;

                    database = GetDatabase(databaseLink.Identifier);
                    if (database == null)
                        continue;
                }
                
                _controller.SetDatabaseSyncStatus(database.Id, Statuses.Syncing);

                SyncDatabaseDownloadGroups(database.Id);
                SyncDatabaseDownloadEntries(database.Id);

                _controller.SetDatabaseSyncStatus(database.Id, Statuses.UpToDate);
            }
            
            _controller.SetServerSyncStatus(_serverAccountId, Statuses.UpToDate);

            _controller.UpdateUi();
            _databasesLoaded = true;
        }

        private void ProcessMessages()
        {
            var apiClient = GetApiClient();
            var serverAccount = Model.ServerAccounts.Get(_serverAccountId);

            CryptoKey linkedDeviceCryptoKey = null;
            if (serverAccount.LinkedDeviceCryptoKeyId != 0)
                linkedDeviceCryptoKey = Model.CryptoKeys.Get(serverAccount.LinkedDeviceCryptoKeyId);
            
            GetMessagesLongpoll.ResponseParams longpollResponse;
            try
            {
                var longpollRequest = new GetMessagesLongpoll();
                _longpollInterrupt = new AutoResetEvent(false);
                longpollRequest.SetInteruptHandle(_longpollInterrupt);
                longpollResponse = longpollRequest.GetResponse(apiClient);
            }
            catch (NetworkErrorException)
            {
                Logger.Info("Network error attempting to obtain images.");
                _requestErrors++;
                return;
            }
            catch (RequestException)
            {
                return;
            }

            _requestErrors = 0;

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
                if (_stopSyncLoop)
                    return;

                var processedSucessfully = false;

                if (messageItem.Type == DeviceMessages.Types.DeviceToDeviceMessage)
                {
                    if (linkedDeviceCryptoKey == null)
                        continue;

                    var messageContents = messageItem.GetContent<DeviceMessages.DeviceToDeviceMessage>();

                    //if (!string.IsNullOrEmpty(messageContents.LinkIdentifier))
                    //{
                        var message = getMessagesRequest.DecryptClientMessage(
                            messageContents.EncryptedMessage, linkedDeviceCryptoKey.PublicKeyPem);

                        switch (message.Type)
                        {
                            case DeviceToDeviceMessages.Types.SendEntrySecrets:
                                if (SendSecretShareMessageReceived == null)
                                    break;
                                var args = new SendEntrySecretsMessageReceivedEventArgs(
                                    (DeviceToDeviceMessages.SendEntrySecrets)message.Message);
                                SendSecretShareMessageReceived.Invoke(this, args);
                                processedSucessfully = args.MessageHandledSuccessfully;
                                break;
                    }
                    //}
                }
                else
                {
                    switch (messageItem.Type)
                    {
                        case DeviceMessages.Types.VerifyDeviceKeysResponse:
                            if (VerifyDeviceKeysResponseReceived == null)
                                break;
                            var args = new VerifyDeviceKeysResponseReceivedEventArgs(
                                messageItem.GetContent<DeviceMessages.VerifyDeviceKeysResponse>());
                            VerifyDeviceKeysResponseReceived.Invoke(this, args);
                            processedSucessfully = args.MessageHandledSuccessfully;
                            break;
                    }
                }
                
                var processedRequest = new SetMessageStatus
                {
                    DeviceMessageIdentifier = messageItem.Identifier,
                    ProcessedSuccess = processedSucessfully
                };
                processedRequest.GetResponse(apiClient);
            }
        }
        
        private void SyncDatabasesUpload()
        {
            var databases = Model.Databases.Find(new Database {ServerAccountId = _serverAccountId});
            foreach (var database in databases)
            {
                SyncDatabaseUpload(database.Id);
            }
        }

        private void SyncDatabaseUpload(int databaseId)
        {
            SyncDatabaseUploadMeta(databaseId);
            SyncDatabaseUploadGroups(databaseId);
            SyncDatabaseUploadEntries(databaseId);
        }

        private void SyncDatabaseUploadMeta(int databaseId)
        {
            if (_stopSyncLoop)
                return;

            if (_processMessagesOnly)
                return;

            var updateRequests = Model.DatabasesMetaSync.Find(new DatabaseMetaSync
            {
                DatabaseId = databaseId
            });
            var updateRequestsSorted = updateRequests?.OrderByDescending(update => update.CreatedAt);
            var latestUpdateRequest = updateRequestsSorted?.FirstOrDefault();

            if (latestUpdateRequest == null)
                return;
            
            _controller.SetDatabaseSyncStatus(databaseId, Statuses.Syncing);

            // Remove duplicate update requests
            foreach (var updateRequest in updateRequestsSorted)
            {
                if (updateRequest.Id == latestUpdateRequest.Id)
                    continue;

                Model.DatabasesMetaSync.Delete(updateRequest.Id);
            }

            var serverAccount = GetServerAccount();
            var database = Model.Databases.Get(databaseId);
            var databaseMeta = Model.DatabasesMeta.Get(database.DatabaseMetaId);
            
            var newVersion = database.DatabaseMetaVersion + 1;
            var serializedEntry = JsonConvert.SerializeObject(databaseMeta);
            var encryptedData = new EncryptedDataWithPassword(
                Util.CompressData(serializedEntry), serverAccount.BackupEncryptionPassword).ToString();

            var request = new SetDatabaseMeta
            {
                LinkIdentifier = database.Identifier,
                Version = newVersion,
                DataType = "ModelJsonGz",
                Data = encryptedData
            };

            try
            {
                request.GetResponse(GetApiClient());
            }
            catch (ConflictException)
            {
                if (Program.AppEnvDebug)
                    throw new NotImplementedException("TODO: Download update to group");
                return;
            }
            catch (NetworkErrorException)
            {
                _requestErrors++;
                return;
            }
            catch (RequestException)
            {
                return;
            }

            _requestErrors = 0;

            // Create archive version
            var archiveMetaData = JsonConvert.DeserializeObject<DatabaseMeta>(serializedEntry);
            archiveMetaData.RemoveId();
            var archiveMetaDataId = Model.DatabasesMeta.Create(archiveMetaData);
            Model.DatabasesMetaVersions.Create(new DatabaseMetaVersion
            {
                DatabaseId = databaseId,
                Version = newVersion,
                DatabaseMetaId = archiveMetaDataId
            });

            // Update current record
            Model.Databases.Update(database.Id, new Database
            {
                DatabaseMetaVersion = newVersion
            });

            // Sync completed
            Model.DatabasesMetaSync.Delete(latestUpdateRequest.Id);

            _controller.SetDatabaseSyncStatus(databaseId, Statuses.UpToDate);
        }

        private void SyncDatabaseUploadGroups(int databaseId)
        {
            var serverAccount = GetServerAccount();
            var database = Model.Databases.Get(databaseId);
            var databaseGroups = Model.DatabasesGroups.Find(new DatabaseGroup {DatabaseId = databaseId});
            foreach (var group in databaseGroups)
            {
                if (_stopSyncLoop)
                    return;

                if (_processMessagesOnly)
                    return;

                var updateRequests = Model.DatabasesGroupsMetaSync.Find(new DatabaseGroupMetaSync
                {
                    DatabaseGroupId = group.Id
                });
                var updateRequestsSorted = updateRequests?.OrderByDescending(update => update.CreatedAt);
                var latestUpdateRequest =updateRequestsSorted?.FirstOrDefault();
                
                if (latestUpdateRequest == null)
                    continue;
                
                _controller.SetDatabaseSyncStatus(databaseId, Statuses.Syncing);

                // Remove duplicate update requests
                foreach (var updateRequest in updateRequestsSorted)
                {
                    if (updateRequest.Id == latestUpdateRequest.Id)
                        continue;

                    Model.DatabasesGroupsMetaSync.Delete(updateRequest.Id);
                }

                var newVersion = group.Version + 1;
                var groupMeta = Model.DatabasesGroupsMeta.Get(group.DatabaseGroupMetaId);
                var serializedEntry = JsonConvert.SerializeObject(groupMeta);
                var encryptedData = new EncryptedDataWithPassword(
                    Util.CompressData(serializedEntry), serverAccount.BackupEncryptionPassword).ToString();
                
                var request = new SetDatabaseGroup
                {
                    Version = newVersion,
                    DatabaseIdentifier = database.Identifier,
                    GroupIdentifier = group.Identifier,
                    DataType = "ModelJsonGz",
                    Data = encryptedData
                };

                try
                {
                    request.GetResponse(GetApiClient());
                    _requestErrors = 0;
                }
                catch (ConflictException)
                {
                    if (Program.AppEnvDebug)
                        throw new NotImplementedException("TODO: Download update to group");
                    continue;
                }
                catch (NetworkErrorException)
                {
                    _requestErrors++;
                    return;
                }
                catch (RequestException)
                {
                    continue;
                }

                // Create archive version
                var archiveMetaData = JsonConvert.DeserializeObject<DatabaseGroupMeta>(serializedEntry);
                archiveMetaData.RemoveId();
                var archiveMetaDataId = Model.DatabasesGroupsMeta.Create(archiveMetaData);
                Model.DatabasesGroupsMetaVersions.Create(new DatabaseGroupMetaVersion
                {
                    DatabaseGroupId = group.Id,
                    Version = newVersion,
                    DatabaseGroupMetaId = archiveMetaDataId
                });

                // Update current record
                Model.DatabasesGroups.Update(group.Id, new DatabaseGroup
                {
                    Version = newVersion
                });

                // Sync completed
                Model.DatabasesGroupsMetaSync.Delete(latestUpdateRequest.Id);

                _controller.SetDatabaseSyncStatus(databaseId, Statuses.UpToDate);
            }
        }

        private void SyncDatabaseUploadEntries(int databaseId)
        {
            if (_databaseEntriesUploadRunning)
                return;

            if (_requestErrors > 0)
                return;

            var serverAccount = GetServerAccount();
            var linkedClientCryptoKey = Model.CryptoKeys.Get(serverAccount.LinkedDeviceCryptoKeyId);
            var database = Model.Databases.Get(databaseId);

            var entriesToBeDeleted = Model.DatabasesEntries.Find(new DatabaseEntry {ToBeDeleted = true}).ToList();
            foreach (var entryToBeDeleted in entriesToBeDeleted)
            {
                if (_stopSyncLoop || _processMessagesOnly)
                    return;

                var deleteRequest = new DeleteDatabaseEntry
                {
                    LinkIdentifier = database.Identifier,
                    EntryIdentifier = entryToBeDeleted.Identifier
                };

                var deleteOnDeviceMessageContent = new DeviceToDeviceMessages.DeleteEntry
                {
                    LinkIdentifier = database.Identifier,
                    EntryIdentifier = entryToBeDeleted.Identifier
                };
                var deleteOnDeviceMessageRequest = new SendLinkedDeviceMessage();
                deleteOnDeviceMessageRequest.SetMessage(deleteOnDeviceMessageContent, linkedClientCryptoKey.PublicKeyPem);

                try
                {
                    deleteRequest.GetResponse(GetApiClient());
                    deleteOnDeviceMessageRequest.GetResponse(GetApiClient());

                    _requestErrors = 0;
                }
                catch (NetworkErrorException)
                {
                    _requestErrors++;
                    return;
                }
                catch (RequestException)
                {
                    // Try again next time.
                    continue;
                }

                var versions = Model.DatabasesEntriesDataVersions.Find(new DatabaseEntryDataVersion
                {
                    DatabaseEntryId = entryToBeDeleted.Id
                });
                foreach (var version in versions)
                {
                    Model.DatabasesEntriesData.Delete(version.DatabaseEntryDataId);
                    Model.DatabasesEntriesDataVersions.Delete(version.Id);
                }

                Model.DatabasesEntries.Delete(entryToBeDeleted.Id);
            }

            _databaseEntriesUploadRunning = true;
            Task.Run(() =>
            {
                var databaseEntries = Model.DatabasesEntries.Find(new DatabaseEntry { DatabaseId = databaseId });

                var entriesToSend = new List<DatabaseEntry>();
                var entriesDataToSend = new List<DatabaseEntryData>();
                var entriesDataSerialized = new List<string>();
                var entriesSyncRequest = new List<DatabaseEntryDataSync>();
                var entriesUploadItems = new List<SetDatabaseEntries.EntryItem>();

                foreach (var entry in databaseEntries)
                {
                    if (_stopSyncLoop || _processMessagesOnly)
                    {
                        _databaseEntriesUploadRunning = false;
                        return;
                    }

                    var entryData = Model.DatabasesEntriesData.Get(entry.DatabaseEntryDataId);
                    if (!entryData.PasswordShared)
                        continue;

                    // Is there an update request for this entry?
                    var updateRequests = Model.DatabasesEntriesDataSync.Find(new DatabaseEntryDataSync
                    {
                        DatabaseEntryId = entry.Id
                    });
                    var updateRequestsSorted = updateRequests?.OrderByDescending(update => update.CreatedAt);
                    var latestUpdateRequest = updateRequestsSorted?.FirstOrDefault();
                    if (latestUpdateRequest == null)
                        continue;

                    // Remove duplicate update requests
                    foreach (var updateRequest in updateRequestsSorted)
                    {
                        if (updateRequest.Id == latestUpdateRequest.Id)
                            continue;

                        Model.DatabasesEntriesDataSync.Delete(updateRequest.Id);
                    }

                    var newVersion = entry.Version + 1;
                    var serializedEntry = JsonConvert.SerializeObject(entryData);
                    var encryptedData = new EncryptedDataWithPassword(
                        Util.CompressData(serializedEntry), serverAccount.BackupEncryptionPassword).ToString();

                    var group = Model.DatabasesGroups.Get(entry.DatabaseGroupId);
                    entriesUploadItems.Add(new SetDatabaseEntries.EntryItem
                    {
                        Version = newVersion,
                        GroupIdentifier = group.Identifier,
                        EntryIdentifier = entry.Identifier,
                        DataType = "ModelJsonGz",
                        Data = encryptedData
                    });

                    entriesToSend.Add(entry);
                    entriesDataToSend.Add(entryData);
                    entriesDataSerialized.Add(serializedEntry);
                    entriesSyncRequest.Add(latestUpdateRequest);
                }

                if (entriesToSend.Count == 0)
                {
                    _databaseEntriesUploadRunning = false;
                    return;
                }

                _controller.SetDatabaseSyncStatus(databaseId, Statuses.Syncing);

                var request = new SetDatabaseEntries
                {
                    LinkIdentifier = database.Identifier,
                    Entries = entriesUploadItems
                };

                try
                {
                    request.GetResponse(GetApiClient());
                    _requestErrors = 0;
                }
                catch (ConflictException)
                {
                    if (Program.AppEnvDebug)
                        throw new NotImplementedException("TODO: Download update to group");
                    _databaseEntriesUploadRunning = false;
                    return;
                }
                catch (NetworkErrorException)
                {
                    _requestErrors++;
                    _databaseEntriesUploadRunning = false;
                    return;
                }
                catch (RequestException)
                {
                    _databaseEntriesUploadRunning = false;
                    return;
                }

                for (var i = 0; i < entriesToSend.Count; i++)
                {
                    var entry = entriesToSend[i];
                    var entryUploadItem = entriesUploadItems[i];
                    var serializedEntry = entriesDataSerialized[i];
                    var latestUpdateRequest = entriesSyncRequest[i];
                    var newVersion = entryUploadItem.Version;

                    // Create archive version
                    var archiveData = JsonConvert.DeserializeObject<DatabaseEntryData>(serializedEntry);
                    archiveData.RemoveId();
                    var archiveDataId = Model.DatabasesEntriesData.Create(archiveData);
                    Model.DatabasesEntriesDataVersions.Create(new DatabaseEntryDataVersion
                    {
                        DatabaseEntryId = entry.Id,
                        Version = newVersion,
                        DatabaseEntryDataId = archiveDataId
                    });

                    // Update current record
                    Model.DatabasesEntries.Update(entry.Id, new DatabaseEntry
                    {
                        Version = newVersion
                    });

                    // Sync completed
                    Model.DatabasesEntriesDataSync.Delete(latestUpdateRequest.Id);
                }
                
                _controller.SetDatabaseSyncStatus(databaseId, Statuses.UpToDate);
                _databaseEntriesUploadRunning = false;
            });
        }

        private void SyncDatabaseDownloadGroups(int databaseId)
        {
            var database = GetDatabase(databaseId);
            var request = new GetDatabaseGroups {LinkIdentifier = database.Identifier};

            GetDatabaseGroups.ResponseParams response;
            try
            {
                response = request.GetResponse(GetApiClient());
                _requestErrors = 0;
            }
            catch (NetworkErrorException)
            {
                _requestErrors++;
                return;
            }
            catch (RequestException)
            {
                return;
            }

            foreach (var servergroup in response.Groups)
            {
                if (_stopSyncLoop)
                    return;

                var localGroup = Model.DatabasesGroups.Find(new DatabaseGroup
                {
                    DatabaseId = databaseId,
                    Identifier = servergroup.GroupIdentifier
                }).FirstOrDefault();
                
                if (servergroup.Version < localGroup?.Version)
                {
                    // Server is out of date. Force an update at next possible opportunity.
                    Model.DatabasesGroupsMetaSync.Create(new DatabaseGroupMetaSync { DatabaseGroupId = localGroup.Id });
                    continue;
                }
                
                if (localGroup == null)
                {
                    var serverGroupMeta = DownloadDatabaseGroupMeta(database.Id, servergroup.GroupIdentifier);
                    if (serverGroupMeta == null)
                        continue;

                    serverGroupMeta.RemoveId();
                    var groupMetaId = Model.DatabasesGroupsMeta.Create(serverGroupMeta);

                    var newGroupId = Model.DatabasesGroups.Create(new DatabaseGroup
                    {
                        Identifier = servergroup.GroupIdentifier,
                        DatabaseId = databaseId,
                        DatabaseGroupMetaId = groupMetaId,
                        Version = servergroup.Version
                    });

                    var archiveId = Model.DatabasesGroupsMeta.Create(serverGroupMeta);
                    Model.DatabasesGroupsMetaVersions.Create(new DatabaseGroupMetaVersion
                    {
                        DatabaseGroupId = newGroupId,
                        Version = servergroup.Version,
                        DatabaseGroupMetaId = archiveId
                    });

                    continue;
                }
                
                if (IsDatabaseGroupModified(localGroup.Id))
                {
                    // It's conflict time!
                    // We're just going to bump the local version number to the same as the server version
                    // then force an update. This will cause the server entry to be overwritten, 
                    // but can be retrieved again through version history.
                    Model.DatabasesGroups.Update(localGroup.Id, new DatabaseGroup {Version = servergroup.Version});
                    Model.DatabasesGroupsMetaSync.Create(new DatabaseGroupMetaSync {DatabaseGroupId = localGroup.Id});
                    continue;
                }

                if (servergroup.Version == localGroup.Version)
                {
                    // No changes required, as there are no local modifications nor any server updates.
                    continue;
                }

                // Update local to the latest server version.
                var downloadedServerGroupMeta = DownloadDatabaseGroupMeta(database.Id, servergroup.GroupIdentifier);
                if (downloadedServerGroupMeta == null)
                    continue;
                Model.DatabasesGroupsMeta.Update(localGroup.Id, downloadedServerGroupMeta);
                Model.DatabasesGroups.Update(localGroup.Id, new DatabaseGroup
                {
                    Version = servergroup.Version
                });

                var localArchiveId = Model.DatabasesGroupsMeta.Create(downloadedServerGroupMeta);
                Model.DatabasesGroupsMetaVersions.Create(new DatabaseGroupMetaVersion
                {
                    DatabaseGroupId = localGroup.Id,
                    Version = servergroup.Version,
                    DatabaseGroupMetaId = localArchiveId
                });
            }
        }

        private void SyncDatabaseDownloadEntries(int databaseId)
        {
            if (_databaseEntriesUploadRunning || _databaseEntriesDownloadRunning)
                return;

            _databaseEntriesDownloadRunning = true;

            // I think, but not entirely certain that this method needs a complete refactoring.....

            Task.Run(() =>
            {
                var database = GetDatabase(databaseId);
                var request = new GetDatabaseEntries { LinkIdentifier = database.Identifier };

                GetDatabaseEntries.ResponseParams response;
                try
                {
                    response = request.GetResponse(GetApiClient());
                    _requestErrors = 0;
                }
                catch (NetworkErrorException)
                {
                    _requestErrors++;
                    _databaseEntriesDownloadRunning = false;
                    return;
                }
                catch (RequestException)
                {
                    _databaseEntriesDownloadRunning = false;
                    return;
                }

                var serverEntriesToCreate = new List<GetDatabaseEntries.ResponseParamsItem>();

                foreach (var serverEntry in response.Entries)
                {
                    if (_stopSyncLoop)
                    {
                        _databaseEntriesDownloadRunning = false;
                        return;
                    }

                    var localEntry = Model.DatabasesEntries.Find(new DatabaseEntry
                    {
                        DatabaseId = databaseId,
                        Identifier = serverEntry.EntryIdentifier
                    }).FirstOrDefault();

                    if (serverEntry.Version < localEntry?.Version)
                    {
                        // Server is out of date. Force an update at next possible opportunity.
                        Model.DatabasesEntriesDataSync.Create(new DatabaseEntryDataSync { DatabaseEntryId = localEntry.Id });
                        continue;
                    }

                    if (localEntry == null)
                    {
                        serverEntriesToCreate.Add(serverEntry);
                        continue;
                    }

                    if (IsDatabaseEntryModified(localEntry.Id))
                    {
                        // It's conflict time!
                        // We're just going to bump the local version number to the same as the server version
                        // then force an update. This will cause the server entry to be overwritten, 
                        // but can be retrieved again through version history.
                        Model.DatabasesEntries.Update(localEntry.Id, new DatabaseEntry { Version = serverEntry.Version });
                        Model.DatabasesEntriesDataSync.Create(new DatabaseEntryDataSync { DatabaseEntryId = localEntry.Id });
                        continue;
                    }

                    if (serverEntry.Version == localEntry.Version)
                    {
                        // No changes required, as there are no local modifications nor any server updates.
                        continue;
                    }

                    // Update local to the latest server version.
                    var downloadedServerEntryData = DownloadDatabaseEntryData(database.Id, serverEntry.EntryIdentifier);
                    if (downloadedServerEntryData == null)
                        continue;
                    Model.DatabasesEntriesData.Update(localEntry.Id, downloadedServerEntryData);
                    Model.DatabasesEntries.Update(localEntry.Id, new DatabaseEntry
                    {
                        Version = serverEntry.Version
                    });

                    var localArchiveId = Model.DatabasesEntriesData.Create(downloadedServerEntryData);
                    Model.DatabasesEntriesDataVersions.Create(new DatabaseEntryDataVersion
                    {
                        DatabaseEntryId = localEntry.Id,
                        Version = serverEntry.Version,
                        DatabaseEntryDataId = localArchiveId
                    });
                }

                if (serverEntriesToCreate.Count == 0)
                {
                    _databaseEntriesDownloadRunning = false;
                    return;
                }

                // Split entries to download into chunks of 50
                var entriesToCreateSegments = serverEntriesToCreate.Select((x, i) => new { Index = i, Value = x })
                    .GroupBy(x => x.Index / 50)
                    .Select(x => x.Select(v => v.Value).ToList())
                    .ToList();

                var count = 0;
                foreach (var entriesToCreateSegment in entriesToCreateSegments)
                {
                    var downloadDataRequest = new GetDatabaseEntryData
                    {
                        LinkIdentifier = database.Identifier,
                        EntryIdentifiers = entriesToCreateSegment.Select(r => r.EntryIdentifier).ToList()
                    };

                    GetDatabaseEntryData.ResponseParams downloadDataResponse;
                    try
                    {
                        downloadDataResponse = downloadDataRequest.GetResponse(GetApiClient());
                    }
                    catch (RequestException)
                    {
                        _databaseEntriesDownloadRunning = false;
                        return;
                    }

                    foreach (var downloadEntryData in downloadDataResponse.EntriesData)
                    {
                        var serverEntry = serverEntriesToCreate[count];
                        var serverEntryData = DecryptServerDatabaseEntryData(downloadEntryData.Data);

                        count++;

                        var localGroup = Model.DatabasesGroups.Find(
                            new DatabaseGroup
                            {
                                DatabaseId = databaseId,
                                Identifier = serverEntry.GroupIdentifier
                            }).FirstOrDefault();

                        var entryDataId = Model.DatabasesEntriesData.Create(serverEntryData);

                        var newEntryId = Model.DatabasesEntries.Create(new DatabaseEntry
                        {
                            Identifier = serverEntry.EntryIdentifier,
                            DatabaseId = databaseId,
                            DatabaseGroupId = localGroup?.Id ?? 0,
                            DatabaseEntryDataId = entryDataId,
                            Version = serverEntry.Version
                        });

                        var archiveId = Model.DatabasesEntriesData.Create(serverEntryData);
                        Model.DatabasesEntriesDataVersions.Create(new DatabaseEntryDataVersion
                        {
                            DatabaseEntryId = newEntryId,
                            Version = serverEntry.Version,
                            DatabaseEntryDataId = archiveId
                        });
                    }
                }

                _databaseEntriesDownloadRunning = false;
            });
        }

        private bool IsDatabaseGroupModified(int groupId)
        {
            var group = Model.DatabasesGroups.Get(groupId);
            var currentMeta = Model.DatabasesGroupsMeta.Get(group.DatabaseGroupMetaId);
            var currentVersion = Model.DatabasesGroupsMetaVersions.Find(new DatabaseGroupMetaVersion
            {
                DatabaseGroupId = groupId,
                Version = group.Version
            }).FirstOrDefault();

            if (currentVersion == null)
            {
                // No previous version to compare against. 
                return true;
            }

            var currentVersionMeta = Model.DatabasesGroupsMeta.Get(currentVersion.DatabaseGroupMetaId);

            return currentMeta.ModifiedAt != currentVersionMeta.ModifiedAt;
        }

        private bool IsDatabaseEntryModified(int entryId)
        {
            var entry = Model.DatabasesEntries.Get(entryId);
            var currentData = Model.DatabasesEntriesData.Get(entry.DatabaseEntryDataId);
            var currentVersion = Model.DatabasesEntriesDataVersions.Find(new DatabaseEntryDataVersion
            {
                DatabaseEntryId = entryId,
                Version = entry.Version
            }).FirstOrDefault();

            if (currentVersion == null)
            {
                // No previous version to compare against. 
                return true;
            }

            var currentVersionData = Model.DatabasesEntriesData.Get(currentVersion.DatabaseEntryDataId);
            

            return currentData.ModifiedAt != currentVersionData.ModifiedAt;
        }

        private DatabaseGroupMeta DownloadDatabaseGroupMeta(int databaseId, string groupIdentifier)
        {
            var serverAccount = GetServerAccount();
            if (string.IsNullOrEmpty(serverAccount.BackupEncryptionPassword))
                return null;

            var database = GetDatabase(databaseId);
            var request = new GetDatabaseGroup
            {
                LinkIdentifier = database.Identifier,
                GroupIdentifier = groupIdentifier
            };

            GetDatabaseGroup.ResponseParams response;
            try
            {
                response = request.GetResponse(GetApiClient());
            }
            catch (RequestException)
            {
                return null;
            }
            
            var decryptedData = EncryptedDataWithPassword.DecryptDataAsBytes(
                response.Data, serverAccount.BackupEncryptionPassword);
            var dataJson = Util.DecompressData(decryptedData);

            var data = JsonConvert.DeserializeObject<DatabaseGroupMeta>(dataJson);
            data.RemoveId();
            
            return data;
        }

        private DatabaseEntryData DownloadDatabaseEntryData(int databaseId, string entryIdentifier)
        {
            var serverAccount = GetServerAccount();
            if (string.IsNullOrEmpty(serverAccount.BackupEncryptionPassword))
                return null;

            var database = GetDatabase(databaseId);
            var request = new GetDatabaseEntryData
            {
                LinkIdentifier = database.Identifier,
                EntryIdentifiers = new List<string> { entryIdentifier }
            };

            GetDatabaseEntryData.ResponseParams response;
            try
            {
                response = request.GetResponse(GetApiClient());
            }
            catch (RequestException)
            {
                return null;
            }

            var decryptedData = EncryptedDataWithPassword.DecryptDataAsBytes(
                response.EntriesData[0].Data, serverAccount.BackupEncryptionPassword);
            var dataJson = Util.DecompressData(decryptedData);

            var data = JsonConvert.DeserializeObject<DatabaseEntryData>(dataJson);
            data.RemoveId();
            
            return data;
        }

        private DatabaseEntryData DecryptServerDatabaseEntryData(string serverEntryData)
        {
            var serverAccount = GetServerAccount();

            var decryptedData = EncryptedDataWithPassword.DecryptDataAsBytes(
                serverEntryData, serverAccount.BackupEncryptionPassword);
            var dataJson = Util.DecompressData(decryptedData);

            var data = JsonConvert.DeserializeObject<DatabaseEntryData>(dataJson);
            data.RemoveId();

            return data;
        }

        private bool CreateDatabaseFromServer(string databaseIdentifier)
        {
            var databaseCheck = Model.Databases.Find(new Database
            {
                ServerAccountId = _serverAccountId,
                Identifier = databaseIdentifier
            }).FirstOrDefault();
            if (databaseCheck != null)
                return false;
            
            var serverAccount = GetServerAccount();
            if (string.IsNullOrEmpty(serverAccount.BackupEncryptionPassword))
                return false;

            var request = new GetDatabaseMeta {DatabaseIdentifier = databaseIdentifier};
            GetDatabaseMeta.ResponseParams response;
            try
            {
                response = request.GetResponse(GetApiClient());
            }
            catch (RequestException)
            {
                return false;
            }

            int databaseMetaId;
            if (response.Version != 0)
            {
                var decryptedData = EncryptedDataWithPassword.DecryptDataAsBytes(
                    response.Data, serverAccount.BackupEncryptionPassword);
                var databaseJson = Util.DecompressData(decryptedData);
                var databaseMeta = JsonConvert.DeserializeObject<DatabaseMeta>(databaseJson);

                databaseMetaId = Model.DatabasesMeta.Create(new DatabaseMeta
                {
                    Name = databaseMeta.Name
                });
            }
            else
            {
                databaseMetaId = Model.DatabasesMeta.Create(new DatabaseMeta());
            }

            Model.Databases.Create(new Database
            {
                ServerAccountId = _serverAccountId,
                Identifier = databaseIdentifier,
                DatabaseMetaId = databaseMetaId,
                DatabaseMetaVersion = response.Version
            });

            return true;
        }

        private void ProcessShares()
        {
            var databases = Model.Databases.Find(new Database {ServerAccountId = _serverAccountId});
            foreach (var database in databases)
                ProcessShares(database.Id);
        }

        private void ProcessShares(int databaseId)
        {
            if (_processingSecretShares)
                return;

            var serverAccount = GetServerAccount();

            if (serverAccount.LinkedDeviceCryptoKeyId == 0)
                return;

            var apiClient = GetApiClient();
            var database = Model.Databases.Get(databaseId);
            var linkedClientCryptoKey = Model.CryptoKeys.Get(serverAccount.LinkedDeviceCryptoKeyId);
            
            _processingSecretShares = true;
            Task.Run(() => 
            {
                bool moreToProcess;
                do
                {
                    moreToProcess = false;
                    var entries = Model.DatabasesEntries.Find(new DatabaseEntry { DatabaseId = databaseId });
                    var entriesToSend = new List<DatabaseEntry>();
                    var entriesDataToSend = new List<DatabaseEntryData>();
                    foreach (var entry in entries)
                    {
                        var entryData = Model.DatabasesEntriesData.Get(entry.DatabaseEntryDataId);
                        if (entryData.PasswordShared)
                            continue;

                        if (entryData.Password == "")
                            continue;

                        if (entriesToSend.Count > 50)
                        {
                            moreToProcess = true;
                            break;
                        }

                        entriesToSend.Add(entry);
                        entriesDataToSend.Add(entryData);
                    }

                    if (entriesToSend.Count == 0)
                    {
                        _processingSecretShares = false;
                        return;
                    }

                    var entrySecretsToSend = new List<DeviceToDeviceMessages.NewSecretItem>();
                    var entriesEncryptedPassword = new List<EncryptedData>();
                    for (var i = 0; i < entriesToSend.Count; i++)
                    {
                        var entry = entriesToSend[i];
                        var entryData = entriesDataToSend[i];

                        var encryptedPassword = new EncryptedData(entryData.Password);
                        var newSecretIdentifier = Guid.NewGuid().ToString();

                        entrySecretsToSend.Add(new DeviceToDeviceMessages.NewSecretItem
                        {
                            EntryIdentifier = entry.Identifier,
                            SecretIdentifier = newSecretIdentifier,
                            Secret = encryptedPassword.Key
                        });

                        entriesEncryptedPassword.Add(encryptedPassword);
                    }

                    var message = new DeviceToDeviceMessages.NewSecret
                    {
                        LinkIdentifier = database.Identifier,
                        Secrets = entrySecretsToSend
                    };
                    var request = new SendLinkedDeviceMessage
                    {
                        SecondsValidFor = 120
                    };
                    request.SetMessage(message, linkedClientCryptoKey.PublicKeyPem);

                    SendLinkedDeviceMessage.ResponseParams response;
                    try
                    {
                        response = request.GetResponse(apiClient);
                    }
                    catch (RequestException)
                    {
                        // Try again later
                        _processingSecretShares = false;
                        return;
                    }

                    var processedSuccess = ProcessSharesCheckReceived(response.MessageIdentifier);
                    if (!processedSuccess)
                    {
                        _processingSecretShares = false;
                        return;
                    }

                    for (var i = 0; i < entriesToSend.Count; i++)
                    {
                        var entry = entriesToSend[i];
                        var entryData = entriesDataToSend[i];
                        var entrySecret = entrySecretsToSend[i];
                        var entryEncryptedPassword = entriesEncryptedPassword[i];

                        var originalSecretIdentifier = entryData.PasswordSharedIdentifier;
                        var newSecretIdentifier = entrySecret.SecretIdentifier;

                        Model.DatabasesEntriesData.Update(entryData.Id, new DatabaseEntryData
                        {
                            Password = "",
                            PasswordShared = true,
                            PasswordSharedIdentifier = newSecretIdentifier,
                            PasswordEncryptedData = entryEncryptedPassword.ToString()
                        });
                        Model.DatabasesEntriesDataSync.Create(new DatabaseEntryDataSync { DatabaseEntryId = entry.Id });

                        if (!string.IsNullOrEmpty(originalSecretIdentifier))
                        {
                            // Tell the device the previous secret can be deleted.

                            var deleteSecretMessage = new DeviceToDeviceMessages.DeleteSecret
                            {
                                SecretIdentifier = originalSecretIdentifier
                            };

                            var deleteSecretRequest = new SendLinkedDeviceMessage();
                            deleteSecretRequest.SetMessage(deleteSecretMessage, linkedClientCryptoKey.PublicKeyPem);

                            try
                            {
                                deleteSecretRequest.GetResponse(apiClient);
                            }
                            catch (RequestException)
                            {
                                // Errr, probably should retry this another time, but lots of effort for little gain.
                                // I'll come back to it later.
                            }
                        }
                    }

                } while (moreToProcess);

                _processingSecretShares = false;

                RestartSyncLoop();
            });
        }

        private bool ProcessSharesCheckReceived(string messageIdentifier)
        {
            var apiClient = GetApiClient();
            var processedSuccess = false;
            var request = new GetMessageStatus { MessageIdentifier = messageIdentifier };
            var startTime = DateTime.UtcNow;
            while (startTime.AddSeconds(120000) > DateTime.UtcNow)
            {
                Thread.Sleep(2000);

                GetMessageStatus.ResponseParams response;
                try
                {
                    response = request.GetResponse(apiClient);
                }
                catch (RequestException)
                {
                    continue;
                }

                if (!response.ProcessedSuccess)
                    continue;

                processedSuccess = true;
                break;
            }

            return processedSuccess;
        }

        public void ProcessMessagesOnly()
        {
            lock (_processMessagesOnlyLock)
                _processMessagesOnly = true;

            _longpollInterrupt.Set();
            _syncLoopWait.Set();
        }

        public void ProcessMessagesOnlyStop()
        {
            lock (_processMessagesOnlyLock)
                _processMessagesOnly = false;

            _syncLoopWait.Set();
        }

        public void RestartSyncLoop()
        {
            _longpollInterrupt.Set();
        }
    }
}
