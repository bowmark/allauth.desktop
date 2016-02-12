using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AllAuth.Mobile.TestDevice.Forms
{
    internal partial class BasicControls : Form
    {
        public int SelectedServerId
        {
            get { return cmbAccounts.Items.Count == 0 ? 0 : _serverAccountsIds.ElementAt(cmbAccounts.SelectedIndex); }
        }

        private List<int> _serverAccountsIds = new List<int>();

        private readonly Controller _controller;

        public BasicControls(Controller controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void btnLinkDatabase_Click(object sender, EventArgs args)
        {
            _controller.AddNewServer();
        }

        public void UpdateAccountsList()
        {
            var accounts = AppModel.ServerAccounts.Query().ToList();
            var accountsList = new List<string>();
            var serverAccountsIds = new List<int>();

            foreach (var account in accounts)
            {
                var model = AccountModel.GetModel(account.Id);
                var settings = model.ServerAccountSettings.Query().First();
                
                serverAccountsIds.Add(account.Id);
                accountsList.Add(settings.Label + " - " + settings.EmailAddress);
            }

            _serverAccountsIds = serverAccountsIds;
            cmbAccounts.DataSource = accountsList;
            cmbAccounts.Enabled = accountsList.Count != 0;
            btnNewLink.Enabled = accountsList.Count != 0;

            if (accountsList.Count > 0)
            {
                var model = AccountModel.GetModel(SelectedServerId);
                var accountSettings = model.ServerAccountSettings.Query().First();
                btnSetRecoveryKey.Enabled = !accountSettings.BackupRecoveryPasswordHashSet;
            }
            else
            {
                btnSetRecoveryKey.Enabled = false;
            }
        }

        public void UpdateOtpAccountsList()
        {
            if (_serverAccountsIds.Count == 0)
                return;

            var model = AccountModel.GetModel(SelectedServerId);
            var otpAccounts = model.OtpAccounts.Query().ToList();
            var otpAccountsList = new List<string>();

            foreach (var account in otpAccounts)
                otpAccountsList.Add(account.Label);

            cmbOtpAccounts.DataSource = otpAccountsList;
            cmbOtpAccounts.Enabled = otpAccountsList.Count != 0;
            btnGetMfaCode.Enabled = otpAccountsList.Count != 0;
        }

        public void UpdateLinksList()
        {
            var linksList = new List<string>();

            if (_controller.SelectedServerAccountId == 0)
            {
                cmbLinks.DataSource = linksList;
                cmbLinks.Enabled = false;
                return;
            }

            var links = AccountModel.GetModel(SelectedServerId).Links.Query().ToList();
            linksList.AddRange(links.Select(link => link.Identifier));

            cmbLinks.DataSource = linksList;
            cmbLinks.Enabled = linksList.Count > 0;
        }
        
        public void UpdateForm()
        {
            UpdateAccountsList();
            UpdateOtpAccountsList();
            UpdateLinksList();
        }

        private void BasicControls_Load(object sender, EventArgs e)
        {
            Activate();
        }

        private void btnRegisterWithServer_Click(object sender, EventArgs e)
        {
            _controller.ShowRegisterWithServerForm();
        }

        private void btnAddMfaAccount_Click(object sender, EventArgs e)
        {
            var form = new OtpNewAccount(_controller);
            form.ShowDialog();
        }

        private void btnGetMfaCode_Click(object sender, EventArgs e)
        {
            var form = new OtpCode(_controller);
            form.SetOtpCode(_controller.GenerateOtpCode(SelectedServerId, cmbOtpAccounts.Text));
            form.ShowDialog();
        }

        private void cmbAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            _controller.SelectedServerAccountId = _serverAccountsIds.ElementAt(cmbAccounts.SelectedIndex);
        }

        private void btnSetRecoveryKey_Click(object sender, EventArgs e)
        {
            _controller.SetRecoveryKey();
        }
    }
}
