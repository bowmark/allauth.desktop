using System.Windows.Forms;

namespace AllAuth.Mobile.TestDevice.Forms
{
    public partial class SetRecoveryKey : Form
    {
        public bool Success { get; private set; }
        public string RecoveryKeyPlaintext { get; private set; }

        public SetRecoveryKey()
        {
            InitializeComponent();
        }

        private void btnRecoveryKey_Click(object sender, System.EventArgs e)
        {
            var recoveryKey = txtRecoveryKey.Text.Trim();
            if (string.IsNullOrEmpty(recoveryKey))
                return;

            RecoveryKeyPlaintext = recoveryKey;
            Success = true;
            Close();
        }
    }
}
