using System;
using System.Windows.Forms;

namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class NewGroup : Templates.FormDialogWithTitle
    {
        private const string DefaultName = "My New Group";

        public bool Success { get; private set; }
        public string NewName { get; private set; }

        public NewGroup()
        {
            InitializeComponent();
            
            txtName.Text = DefaultName;
        }
        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            txtName.Text = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show(@"Please enter a name");
                return;
            }

            Success = true;
            NewName = txtName.Text;

            Close();
        }
    }
}
