namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class LoggingOut : Templates.FormDialog
    {
        public bool Success { get; private set; }
        public string LoginLink { get; private set; }

        public LoggingOut(Controller controller)
        {
            InitializeComponent();

            Controller = controller;
        }

        private async void OpeningAccountManagement_Shown(object sender, System.EventArgs e)
        {
            await Controller.LogoutServerManagement();

            Success = true;
            Close();
        }
    }
}
