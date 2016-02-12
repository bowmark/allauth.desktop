using System;
using System.Windows.Forms;

namespace AllAuth.Mobile.TestDevice.Forms
{
    internal partial class AddNewServer : Form
    {
        private Controller _controller;

        public AddNewServer(Controller controller)
        {
            InitializeComponent();
            _controller = controller;
        }
        
        private void btnLink_Click(object sender, EventArgs e)
        {
            var success = _controller.RegisterInitialOtpDevice(txtLinkCode.Text.Trim());
            if (success)
            {
                Close();
            }
        }
    }
}
