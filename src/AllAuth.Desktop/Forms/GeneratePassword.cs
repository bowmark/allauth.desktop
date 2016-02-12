using System;
using System.Windows.Forms;
using AllAuth.Lib.Crypto;

namespace AllAuth.Desktop.Forms
{
    internal partial class GeneratePassword : Templates.FormDialogWithTitle
    {
        public bool Success { get; private set; }
        public string Password { get; private set; }

        public GeneratePassword()
        {
            InitializeComponent();
        }

        private void GeneratePassword_Load(object sender, EventArgs e)
        {
            GenerateNewPassword();
        }

        private RandomUtil.StringGeneratorOptions GetGeneratorOptions()
        {
            var options = new RandomUtil.StringGeneratorOptions();
            if (cbUppercase.Checked)
                options = options | RandomUtil.StringGeneratorOptions.UpperCase;
            if (cbLowercase.Checked)
                options = options | RandomUtil.StringGeneratorOptions.LowerCase;
            if (cbDigits.Checked)
                options = options | RandomUtil.StringGeneratorOptions.Digits;
            if (cbSymbols.Checked)
                options = options | RandomUtil.StringGeneratorOptions.Special;
            
            return options;
        }

        private void lblGenerate_Click(object sender, EventArgs e)
        {
            GenerateNewPassword();
        }

        private void btnUsePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGeneratedString.Text))
            {
                var dialogText = @"No password was entered. Are you sure?";
                var dialogTitle = @"No Password Entered";
                var result = MessageBox.Show(dialogText, dialogTitle, MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                    return;
            }

            Success = true;
            Password = txtGeneratedString.Text;
            Close();
        }

        private void cbUppercase_CheckedChanged(object sender, EventArgs e)
        {
            GenerateNewPassword();
        }

        private void GenerateNewPassword()
        {
            var options = GetGeneratorOptions();
            if (options == 0)
                return;

            txtGeneratedString.Text = RandomUtil.GenerateRandomString((int)txtLength.Value, options);
        }

        private void cbLowercase_CheckedChanged(object sender, EventArgs e)
        {
            GenerateNewPassword();
        }

        private void cbDigits_CheckedChanged(object sender, EventArgs e)
        {
            GenerateNewPassword();
        }

        private void cbSymbols_CheckedChanged(object sender, EventArgs e)
        {
            GenerateNewPassword();
        }

        private void txtLength_ValueChanged(object sender, EventArgs e)
        {
            GenerateNewPassword();
        }
    }
}
