using System;
using System.Threading;
using AllAuth.Desktop.Common.Models;
using AllAuth.Lib;
using AllAuth.Lib.APIs;
using AllAuth.Lib.ManagementAPI.Requests.Authenticated;
using ApiClient = AllAuth.Lib.ManagementAPI.ApiClient;

namespace AllAuth.Desktop
{
    internal sealed class SyncManagement
    {
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

        private readonly int _managementAccountId;

        private DateTime _dateUserLastUpdated = DateTime.MinValue;

        private readonly Controller _controller;

        private int _requestErrors;
        
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="serverAccountId"></param>
        public SyncManagement(Controller controller, int managementAccountId)
        {
            _controller = controller;
            _managementAccountId = managementAccountId;
        }

        /// <summary>
        /// Creates and starts the sync loop thread.
        /// </summary>
        public void Start()
        {
            var thread = new Thread(Run);
            thread.Start();
        }

        /// <summary>
        /// Tells the sync loop thread to stop at next possible opportunity.
        /// This will block until the thread has completed gracefully completed.
        /// </summary>
        public void Stop()
        {
            Logger.Info("Been told to stop the management sync loop");

            // Tell the sync loop to stop (force an iteration if necessary), then block until completed.
            _stopSyncLoop = true;
            _syncLoopWait.Set();
            _stopSyncLoopWait.WaitOne();

            Logger.Info("Stopped management sync loop");
        }

        /// <summary>
        /// Execute the sync loop.
        /// </summary>
        private void Run()
        {
            Logger.Verbose("Starting management sync loop");

            while (true)
            {
                Logger.Verbose("Executing management sync loop iteration");

                if (_stopSyncLoop)
                {
                    Logger.Info("Stopping management sync loop");
                    break;
                }
                
                GetUserInfo();

                if (_stopSyncLoop)
                {
                    Logger.Info("Stopping management sync loop");
                    break;
                }

                var sleepTime = 120;
                if (_requestErrors > 15)
                    sleepTime = 120;
                else if (_requestErrors > 0)
                    sleepTime = _requestErrors*2;

                Logger.Verbose("Sync management loop iteration completed. Sleeping for " + sleepTime + " secs");
                _syncLoopWait.WaitOne(sleepTime * 1000);
            }

            // Tell the calling thread we've stopped.
            _stopSyncLoopWait.Set();
        }

        private ApiClient GetApiClient()
        {
            var managementAccount = Model.ServerManagementAccounts.Get(_managementAccountId);
            return new ApiClient(
                managementAccount.HttpsEnabled,
                managementAccount.Host,
                managementAccount.Port,
                managementAccount.ApiVersion,
                managementAccount.ApiKey);
        }

        private ServerManagementAccount GetAccount()
        {
            return Model.ServerManagementAccounts.Get(_managementAccountId);
        }

        private void GetUserInfo()
        {
            var request = new GetUser();
            GetUser.ResponseParams response;
            try
            {
                response = request.GetResponse(GetApiClient());
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

            var managementAccount = GetAccount();

            var updateRecord = false;
            if (managementAccount.Subscribed != response.IsSubscribed)
            {
                updateRecord = true;
            }
            else if (managementAccount.InTrial != response.InTrial)
            {
                updateRecord = true;
            }
            else if (managementAccount.TrialEndsAt != response.TrialEndsAt)
            {
                updateRecord = true;
            }

            if (updateRecord)
            {
                Model.ServerManagementAccounts.Update(_managementAccountId, new ServerManagementAccount
                {
                    Subscribed = response.IsSubscribed,
                    InTrial = response.InTrial,
                    TrialEndsAt = response.TrialEndsAt
                });

                // Update the parts of the UI that contain management account information.
                _controller.UpdateSubscriptionInfoBar();
            }
        }
    }
}
