using System.Threading.Tasks;
using System.Windows.Forms;

namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class ChangeRecoveryPassphrase : Templates.FormDialogWithTitle
    {
        public ChangeRecoveryPassphrase(Controller controller)
        {
            InitializeComponent();
            Controller = controller;

            if (Program.AppEnvDebug)
                txtCurrentPassphrase.Text = @"mydatabaserecoverypassphrase#123";
        }

        private async void btnChangePassphrase_Click(object sender, System.EventArgs e)
        {
            var currentPassphrase = txtCurrentPassphrase.Text;
            var newPassphrase = txtNewPassphrase.Text;
            var newPassphraseRepeat = txtNewPassphraseRepeat.Text;

            if (string.IsNullOrEmpty(currentPassphrase))
            {
                MessageBox.Show(@"Please enter your current passphrase.");
                return;
            }

            if (string.IsNullOrEmpty(newPassphrase))
            {
                MessageBox.Show(@"Please enter a new passphrase.");
                return;
            }

            if (newPassphrase.Length < 8)
            {
                MessageBox.Show(@"Your passphrase should be a minimum of 8 characters.");
                return;
            }

            if (!newPassphrase.Equals(newPassphraseRepeat))
            {
                MessageBox.Show(@"Your new passphrases do not match.");
                return;
            }

            btnChangePassphrase.Visible = false;
            lblLoading.Visible = true;

            var success = false;
            await Task.Run(() =>
            {
                success = Controller.ChangeRecoveryPassphrase(currentPassphrase, newPassphrase);
            });

            if (!success)
            {
                MessageBox.Show(@"Changing the recovery passphrase failed.");
                btnChangePassphrase.Visible = true;
                lblLoading.Visible = false;
                return;
            }

            Close();
        }
    }
}
