using System.Drawing;

namespace AllAuth.Desktop.Forms
{
    internal partial class HomePageServer : Templates.BaseControl
    {
        public int ServerAccountId { get; }

        private Sync.Statuses _syncStatus;
        public Sync.Statuses SyncStatus
        {
            get { return _syncStatus; }
            set
            {
                SetSyncStatus(value);
                _syncStatus = value;
            }
        }

        public bool SecondDeviceSetup { get; private set; }
        public bool DeviceKeysVerified { get; private set; }
        
        private readonly Controller _controller;

        public HomePageServer(Controller controller, int serverAccountId)
        {
            InitializeComponent();

            _controller = controller;
            ServerAccountId = serverAccountId;

            var serverAccount = Model.ServerAccounts.Get(serverAccountId);

            panelSecondDeviceNotLinked.Visible = !serverAccount.LinkedDeviceSetup;
            SecondDeviceSetup = serverAccount.LinkedDeviceSetup;

            if (serverAccount.LinkedDeviceSetup)
            {
                if (serverAccount.LinkedDeviceCryptoKeyId == 0)
                {
                    panelVerifyDeviceKeys.Visible = true;
                    DeviceKeysVerified = false;
                }
                else
                {
                    var linkedDeviceCryptoKey = Model.CryptoKeys.Get(serverAccount.LinkedDeviceCryptoKeyId);
                    if (!linkedDeviceCryptoKey.Trust)
                    {
                        panelVerifyDeviceKeys.Visible = true;
                        DeviceKeysVerified = false;
                    }
                    else
                    {
                        panelVerifyDeviceKeys.Visible = false;
                        DeviceKeysVerified = true;
                    }
                }
            }
        }

        private void lblServerActionAddDatabase_Click(object sender, System.EventArgs e)
        {
            _controller.NewDatabase(ServerAccountId);
        }

        private void SetSyncStatus(Sync.Statuses syncStatus)
        {
            var server = Model.ServerAccounts.Get(ServerAccountId);

            if (syncStatus == Sync.Statuses.Syncing)
                lblServerName.Text = server.ServerLabel + @" (syncing)";
            else
                lblServerName.Text = server.ServerLabel;
        }

        private void lblSecondDeviceNotLinked_Click(object sender, System.EventArgs e)
        {
            var success = _controller.LinkSecondDevice(ServerAccountId);
            if (success)
                _controller.UpdateHomePage();
        }

        private void lblVerifyDeviceKeys_Click(object sender, System.EventArgs e)
        {
            var success = _controller.VerifyDeviceKeys(ServerAccountId);
            if (success)
                _controller.UpdateHomePage();
        }

        private void lblServerOptions_Click(object sender, System.EventArgs e)
        {
            var location = new Point(lblServerOptions.Width - ctxServerOptions.Width, lblServerOptions.Height);
            ctxServerOptions.Show(lblServerOptions, location);
        }

        private void recoverPhoneToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            _controller.RecoverSecondDevice(ServerAccountId);
        }
    }
}
