using System.Windows.Forms;

namespace AllAuth.Mobile.TestDevice.Forms
{
    public partial class VerifyRecoveryPublicKey : Form
    {
        public bool VerificationCodeEntered;
        public string VerificationCode;

        public VerifyRecoveryPublicKey()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            VerificationCodeEntered = true;
            VerificationCode = textBox1.Text;
            Close();
        }
    }
}
