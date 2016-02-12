using System;
using System.Windows.Forms;

namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class EditDatabase : Templates.FormDialogWithTitle
    {
        public bool Success { get; private set; }

        private readonly int _databaseId;

        public EditDatabase(Controller controller, int databaseId)
        {
            InitializeComponent();

            Controller = controller;
            _databaseId = databaseId;
        }
        
        private void EditDatabase_Load(object sender, EventArgs e)
        {
            var database = Model.Databases.Get(_databaseId);
            var databaseMeta = Model.DatabasesMeta.Get(database.DatabaseMetaId);

            txtDbName.Text = databaseMeta.Name;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtDbName.Text = txtDbName.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtDbName.Text))
            {
                MessageBox.Show(@"Please enter a database name");
                return;
            }

            if (txtDbName.Text.Length > 50)
            {
                MessageBox.Show(@"Please reduce the database name to below 50 characters");
                return;
            }
            
            var updateData = new AllAuth.Desktop.Common.Models.DatabaseMeta
            {
                Name = txtDbName.Text
            };

            Success = Controller.EditDatabase(_databaseId, updateData);
            if (!Success)
                return;

            Close();
        }
    }
}
