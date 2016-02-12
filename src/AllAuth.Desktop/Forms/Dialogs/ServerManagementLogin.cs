namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class ServerManagementLogin : Templates.FormDialogWithTitle
    {
        public bool Success { get; private set; }

        public ServerManagementLogin(Controller controller)
        {
            InitializeComponent();
            Controller = controller;
            
            if (Program.AppEnvDebug)
            {
                txtEmailAddress.Text = @"my@email.address";
                txtRecoveryPassword.Text = @"mypassword";
            }
        }
        
        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            Success = Controller.LoginToServerManagement(
                txtEmailAddress.Text.Trim(), txtRecoveryPassword.Text.Trim());

            if (!Success)
                return;
            
            Close();
        }
    }
}
