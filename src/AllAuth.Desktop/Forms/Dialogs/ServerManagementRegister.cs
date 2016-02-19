using System.Threading;
using System.Windows.Forms;

namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class ServerManagementRegister : Templates.FormDialogWithTitle
    {
        public bool Success { get; private set; }
        public string EmailAddress { get; private set; }
        public string RecoveryPasswordPlainText { get; private set; }
        public string RegistrationIdentifier { get; private set; }
        public string ClientToken { get; private set; }

        public ServerManagementRegister(Controller controller)
        {
            InitializeComponent();

            Controller = controller;
            
            if (Program.AppEnvDebug)
            {
                txtEmailAddress.Text = @"my@email.address";
                txtRecoveryPassphraseFirst.Text = @"mydatabaserecoverypassphrase#123";
                txtRecoveryPassphraseRepeat.Text = @"mydatabaserecoverypassphrase#123";
            }
        }

        private void btnRegister_Click(object sender, System.EventArgs e)
        {
            var recoveryPassphrase = txtRecoveryPassphraseFirst.Text;
            if (string.IsNullOrEmpty(recoveryPassphrase))
                return;

            if (recoveryPassphrase.Length < 8)
            {
                MessageBox.Show(@"Your passphrase should be a minimum of 8 characters.");
                return;
            }

            if (recoveryPassphrase != txtRecoveryPassphraseRepeat.Text)
            {
                MessageBox.Show(@"The passphrases do not match.");
                return;
            }

            lblLoginLoading.Visible = true;
            btnRegister.Enabled = false;

            var thread = new Thread(delegate ()
            {
                string registrationIdentifier;
                string clientToken;

                var success = Controller.RegisterWithServerManagement(txtEmailAddress.Text.Trim(),
                    recoveryPassphrase, out registrationIdentifier, out clientToken);

                if (!success)
                {
                    Invoke((MethodInvoker) delegate
                    {
                        MessageBox.Show(@"Unexpected error during registration. Please try again.");
                        lblLoginLoading.Visible = false;
                        btnRegister.Enabled = true;
                    });
                    return;
                }

                Success = true;
                EmailAddress = txtEmailAddress.Text;
                RecoveryPasswordPlainText = recoveryPassphrase;
                RegistrationIdentifier = registrationIdentifier;
                ClientToken = clientToken;

                Invoke((MethodInvoker)Close);
            });

            thread.Start();
        }
    }
}
