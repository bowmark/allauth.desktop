using System.Collections.Generic;

namespace AllAuth.Desktop.Forms
{
    internal partial class Settings : Templates.FormDialogWithTitle
    {
        private List<int> _customServersIdsList = new List<int>();

        public Settings(Controller controller)
        {
            InitializeComponent();

            Controller = controller;
        }

        private void Settings_Load(object sender, System.EventArgs e)
        {
            UpdateForm();
        }

        private void UpdateForm()
        {
            var customServers = Model.ServerAccounts.Find(new AllAuth.Desktop.Common.Models.ServerAccount {Managed = false});

            _customServersIdsList = new List<int>();
            var customServersList = new List<string>();
            foreach (var customServer in customServers)
            {
                _customServersIdsList.Add(customServer.Id);
                customServersList.Add(customServer.ServerLabel);
            }
            listCustomServers.DataSource = customServersList;
        }

        private void btnAddCustomServer_Click(object sender, System.EventArgs e)
        {
            using (var form = new Dialogs.ServerAccountAdd(Controller))
            {
                form.ShowDialog();
                if (!form.Success)
                    return;
            }

            UpdateForm();
        }

        private void btnRemoveCustomServer_Click(object sender, System.EventArgs e)
        {
            if (listCustomServers.Items.Count == 0)
                return;

            Controller.LogoutServer(_customServersIdsList[listCustomServers.SelectedIndex]);
            UpdateForm();
        }
    }
}
