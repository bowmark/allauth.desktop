using System.Windows.Forms;

namespace AllAuth.Mobile.TestDevice.Forms
{
    internal partial class OtpCode : Form
    {
        public OtpCode(Controller _controller)
        {
            InitializeComponent();
        }

        public void SetOtpCode(string code)
        {
            txtOtpCode.Text = code;
        }
    }
}
