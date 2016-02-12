using System.Threading;
using System.Windows.Forms;
using AllAuth.Desktop.Common.Models;

namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class ServerManagementRegisterConfirm : Templates.FormDialogWithTitle
    {
        public bool Success { get; private set; }
        public string ServerRegistrationIdentifier { get; private set; }
        public string ServerClientToken { get; private set; }

        private readonly ServerManagementAccount _serverManagementAccount;
        private readonly string _registrationIdentifier;
        private readonly string _clientToken;

        public ServerManagementRegisterConfirm(Controller controller, ServerManagementAccount serverManagementAccount, 
            string registrationIdentifier, string clientToken)
        {
            InitializeComponent();

            Controller = controller;
            _serverManagementAccount = serverManagementAccount;
            _registrationIdentifier = registrationIdentifier;
            _clientToken = clientToken;
        }

        private void btnComplete_Click(object sender, System.EventArgs e)
        {
            txtEmailCode.Text = txtEmailCode.Text.Trim();
            if (string.IsNullOrEmpty(txtEmailCode.Text))
                return;
            
            lblLoading.Visible = true;
            btnComplete.Enabled = false;

            var thread = new Thread(delegate ()
            {
                string serverRegistrationIdentifier;
                string serverClientToken;

                var success = Controller.RegisterWithServerManagementComplete(
                    _serverManagementAccount, _registrationIdentifier, _clientToken, txtEmailCode.Text,
                    out serverRegistrationIdentifier, out serverClientToken);

                if (!success)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        lblLoading.Visible = false;
                        btnComplete.Enabled = true;
                    });
                    return;
                }

                Success = true;
                ServerRegistrationIdentifier = serverRegistrationIdentifier;
                ServerClientToken = serverClientToken;

                Invoke((MethodInvoker)Close);
            });

            thread.Start();
        }
    }
}
