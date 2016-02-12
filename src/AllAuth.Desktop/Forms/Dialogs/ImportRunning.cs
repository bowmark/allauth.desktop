using System.Threading.Tasks;

namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class ImportRunning : Templates.FormDialog
    {
        public bool Success { get; private set; }

        private readonly string _importType;
        private readonly string _importFilePath;

        public ImportRunning(Controller controller, string importType, string importFilePath)
        {
            InitializeComponent();

            Controller = controller;
            _importType = importType;
            _importFilePath = importFilePath;
        }

        private async void OpeningAccountManagement_Shown(object sender, System.EventArgs e)
        {
            var success = false;
            await Task.Run(() =>
            {
                success = Controller.ImportProcess(_importType, _importFilePath);
            });

            Success = success;
            Close();
        }
    }
}
