using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class Import : Templates.FormDialogWithTitle
    {
        public bool Success { get; private set; }

        private readonly Dictionary<string, string> _importTypes; 

        public Import(Controller controller)
        {
            InitializeComponent();
            Controller = controller;

            _importTypes = Controller.GetImportTypes();

            var list = new List<string>();
            foreach (var importType in _importTypes)
                list.Add(importType.Value);
            listImportTypes.DataSource = list;
        }

        private async void btnImport_Click(object sender, System.EventArgs e)
        {
            string filePath;
            using (var openFileDialog1 = new OpenFileDialog())
            {
                var result = openFileDialog1.ShowDialog();
                if (result != DialogResult.OK)
                    return;
                filePath = openFileDialog1.FileName;
            }

            var importType = _importTypes.ElementAt(listImportTypes.SelectedIndex).Key;

            using (var form = new ImportRunning(Controller, importType, filePath))
            {
                form.ShowDialog();
                if (!form.Success)
                {
                    Close();
                    return;
                }
            }
            
            Success = true;
            Close();
        }
    }
}
