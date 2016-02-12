using System.Windows.Forms;

namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class ServerAccountAdd : Templates.FormDialogWithTitle
    {
        public bool Success { get; private set; }

        public ServerAccountAdd()
        {
            InitializeComponent();
        }

        public ServerAccountAdd(Controller controller)
        {
            InitializeComponent();
            Controller = controller;
            btnLogin.Text = @"Log in to server";
            AcceptButton = btnLogin;

            if (Program.AppEnvDebug)
            {
                txtEmailAddress.Text = @"my@email.address";
                txtRecoveryPassword.Text = @"mypassword";
                txtHost.Text = @"localhost";
                txtPort.Text = @"38750";
                txtApiVersion.Text = @"1";
            }
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            txtEmailAddress.Text = txtEmailAddress.Text.Trim();
            if (string.IsNullOrEmpty(txtEmailAddress.Text))
            {
                MessageBox.Show(@"Please enter the email address you are registered to the server with.");
                return;
            }

            txtRecoveryPassword.Text = txtRecoveryPassword.Text.Trim();
            if (string.IsNullOrEmpty(txtRecoveryPassword.Text))
            {
                MessageBox.Show(@"Please enter your password.");
                return;
            }

            txtHost.Text = txtHost.Text.Trim();
            if (string.IsNullOrEmpty(txtHost.Text))
            {
                MessageBox.Show(@"Please enter the server's domain name.");
                return;
            }

            int serverPort;
            if (!int.TryParse(txtPort.Text, out serverPort))
            {
                MessageBox.Show(@"The server port entered is not a number");
                return;
            }

            int apiVersion;
            if (!int.TryParse(txtApiVersion.Text, out apiVersion))
            {
                MessageBox.Show(@"The API version entered is not a number");
                return;
            }

            var newServerAccount = new AllAuth.Desktop.Common.Models.ServerAccount
            {
                Managed = false,
                HttpsEnabled = false,
                ServerHost = txtHost.Text,
                ServerPort = serverPort,
                ServerApiVersion = apiVersion,
                EmailAddress = txtEmailAddress.Text
            };

            var loginSuccessful = Controller.LoginToServer(newServerAccount, txtRecoveryPassword.Text);

            if (!loginSuccessful)
                return;

            Success = true;
            Close();
        }
    }
}
