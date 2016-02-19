namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class OpeningAccountManagement : Templates.FormDialog
    {
        public bool Success { get; private set; }
        public string LoginLink { get; private set; }

        public OpeningAccountManagement(Controller controller)
        {
            InitializeComponent();
            Controller = controller;

            StartLoadingAnimation(lblLoadingImage);
        }

        private async void OpeningAccountManagement_Shown(object sender, System.EventArgs e)
        {
            var loginLink = await Controller.GetAccountManagementLoginLink();
            if (string.IsNullOrEmpty(loginLink))
            {
                Close();
                return;
            }

            Success = true;
            LoginLink = loginLink;
            Close();
        }
    }
}
