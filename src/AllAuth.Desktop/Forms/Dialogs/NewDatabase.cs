using System;
using System.Windows.Forms;

namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class NewDatabase : Templates.FormDialogWithTitle
    {
        private const string DefaultDatabaseName = "My Database";

        public bool NewDatabaseNameSet { get; private set; }
        public string NewDatabaseName { get; private set; }

        public NewDatabase(Controller controller)
        {
            InitializeComponent();
            Controller = controller;

            txtDbName.Text = DefaultDatabaseName;
        }
        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var dbName = txtDbName.Text.Trim();
            if (string.IsNullOrWhiteSpace(dbName))
            {
                MessageBox.Show("Please provide a database name");
                return;
            }

            NewDatabaseNameSet = true;
            NewDatabaseName = dbName;

            Close();
        }
    }
}
