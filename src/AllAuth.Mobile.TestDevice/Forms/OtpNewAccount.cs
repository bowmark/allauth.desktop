using System.Windows.Forms;

namespace AllAuth.Mobile.TestDevice.Forms
{
    internal partial class OtpNewAccount : Form
    {
        private Controller _controller;

        public OtpNewAccount(Controller controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        private void btnAdd_Click(object sender, System.EventArgs e)
        {
            var success = _controller.AddOtpAccount(txtOtpauthUri.Text);
            if (!success)
            {
                MessageBox.Show("Error parsing OTP code");
                return;
            }

            Close();
        }
    }
}
