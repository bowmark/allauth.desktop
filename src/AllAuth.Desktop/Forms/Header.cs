using System;
using System.Drawing;
using System.Windows.Forms;
using AllAuth.Desktop.Forms.Dialogs;

namespace AllAuth.Desktop.Forms
{
    internal partial class Header : Templates.BaseControl
    {
        public Common.Models.ServerManagementAccount ServerManagementAccount { get; set; }

        private readonly Controller _controller;

        public bool ActiveDatabase { get; set; }
        public int ActiveDatabaseId { get; set; }

        public Header()
        {
            InitializeComponent();
        }

        public Header(Controller controller) : this()
        {
            _controller = controller;
        }
        
        private void Header_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            UpdateControl();
        }

        public void UpdateControl()
        {
            if (ServerManagementAccount == null)
                lblServerManagementInfo.Text = @"Log in to your AllAuth account";
            else
                lblServerManagementInfo.Text = ServerManagementAccount.EmailAddress;

            if (!ActiveDatabase)
            {
                lblDatabaseName.Visible = false;
            }
            else
            {
                var database = Model.Databases.Get(ActiveDatabaseId);
                var databaseMeta = Model.DatabasesMeta.Get(database.DatabaseMetaId);
                lblDatabaseName.Text = databaseMeta.Name;
                lblDatabaseName.Visible = true;
            }
        }
        
        private void lblOptionsMenu_Click(object sender, EventArgs e)
        {
            var location = new Point(Width - ctxAppOptions.Height, Height);
            ctxAppOptions.Show(this, location);
        }

        private void lblLogo_Click(object sender, EventArgs e)
        {
            _controller.ShowHomePage();
        }

        private void lblDatabaseName_Click(object sender, EventArgs e)
        {
            if (!ActiveDatabase)
                return;

            using (var form = new Dialogs.EditDatabase(_controller, ActiveDatabaseId))
            {
                form.ShowDialog();
                if (!form.Success)
                    return;
            }

            UpdateControl();
        }
        
        private async void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new LoggingOut(_controller))
            {
                form.ShowDialog();
            }
        }

        public void UpdateDatabaseSyncStatus(int databaseId, Sync.Statuses status)
        {
            if (!ActiveDatabase || ActiveDatabaseId != databaseId)
                return;

            var database = Model.Databases.Get(databaseId);
            var databaseMeta = Model.DatabasesMeta.Get(database.DatabaseMetaId);
            if (status == Sync.Statuses.Syncing)
                lblDatabaseName.Text = databaseMeta.Name + @" (syncing)";
            else if (status == Sync.Statuses.Offline)
                lblDatabaseName.Text = databaseMeta.Name + @" (offline)";
            else
                lblDatabaseName.Text = databaseMeta.Name;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.ShowSettings();
        }

        private void abountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new Dialogs.About())
            {
                form.ShowDialog();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.Close();
        }
        
        private void manageAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.OpenAccountManagement();
        }
        
        private void lblDatabaseName_MouseEnter(object sender, EventArgs e)
        {
            var newFont = new Font(lblDatabaseName.Font, FontStyle.Underline);
            lblDatabaseName.Font = newFont;
        }

        private void lblDatabaseName_MouseLeave(object sender, EventArgs e)
        {
            var newFont = new Font(lblDatabaseName.Font, FontStyle.Regular);
            lblDatabaseName.Font = newFont;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _controller.OpenAccountManagement();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                @"Are you sure you wish to logout of your account?

You will require your recovery passphrase to log back in. Be sure you remember it before proceeding.",
                @"Confirm logout", 
                MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;

            using (var form = new LoggingOut(_controller))
            {
                form.ShowDialog();
            }
        }

        private void helpAndSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://allauthapp.com/support");
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controller.ImportStart();
        }

        private void changeRecoveryPassphraseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new ChangeRecoveryPassphrase(_controller))
            {
                form.ShowDialog();
            }
        }
    }
}
