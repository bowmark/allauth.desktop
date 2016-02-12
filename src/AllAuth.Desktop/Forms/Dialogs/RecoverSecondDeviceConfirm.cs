using System.Drawing;
using System.Windows.Forms;
using AllAuth.Desktop.Properties;

namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class RecoverSecondDeviceConfirm : Templates.FormDialogWithTitle
    {
        public bool Success { get; private set; }

        public RecoverSecondDeviceConfirm(Controller controller)
        {
            InitializeComponent();
            Controller = controller;
        }

        private async void btnStartRecovery_Click(object sender, System.EventArgs e)
        {
            var loaderImg = (Image) Resources.ResourceManager.GetObject("ajax_loader");
            var label = new Label
            {
                Dock = DockStyle.Fill,
                Text = "",
                Image = loaderImg,
                ImageAlign = ContentAlignment.MiddleCenter,
                AutoSize = false
            };

            panelButtons.Controls.Clear();
            panelButtons.Controls.Add(label);

            Success = await Controller.RecoverSecondDeviceConfirmed();
            
            Close();
        }

        private void linkCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Close();
        }
    }
}
