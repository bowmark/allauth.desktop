using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AllAuth.Desktop.Forms.Dialogs;
using AllAuth.Desktop.Forms.Templates;

namespace AllAuth.Desktop.Forms
{
    internal partial class GettingStarted : FormDialog
    {
        public bool Success { get; private set; }

        public GettingStarted(Controller controller)
        {
            Font = UiStyle.DefaultFont;
            InitializeComponent();
            Controller = controller;
            
            labelLoginTitle.Font = UiStyle.DefaultFontTitle;
            lblRegisterTitle.Font = UiStyle.DefaultFontTitle;


            if (Program.AppEnvDebug)
            {
                txtLoginEmailAddress.Text = @"my@email.address";
                txtLoginPassword.Text = @"mydatabaserecoverypassphrase#123";
            }
        }
        
        private void lblManualServerAddTop_MouseEnter(object sender, EventArgs e)
        {
            lblManualServerAddTop.ForeColor = Color.Gainsboro;
        }

        private void lblManualServerAddTop_MouseLeave(object sender, EventArgs e)
        {
            lblManualServerAddTop.ForeColor = Color.White;
        }
        
        private void lblManualServerAddTop_Click(object sender, EventArgs e)
        {
            using (var form = new ServerAccountAdd(Controller))
            {
                form.ShowDialog();
                if (!form.Success)
                    return;
            }
            
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblLoginLoading.Visible = true;
            btnLoginStep1.Enabled = false;

            var thread = new Thread(delegate ()
            {
                var loginSuccess = Controller.LoginToServerManagement(
                    txtLoginEmailAddress.Text.Trim(), txtLoginPassword.Text.Trim());

                if (!loginSuccess)
                {
                    Invoke((MethodInvoker) delegate
                    {
                        lblLoginLoading.Visible = false;
                        btnLoginStep1.Enabled = true;
                    });
                    return;
                }

                Success = true;
                Invoke((MethodInvoker) Close);
            });

            thread.Start();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var success = Controller.RegisterWithServerManagement();
            if (!success)
                return;

            Success = true;
            Close();

//            using (var form = new ServerManagementRegister(Controller))
//            {
//                form.ShowDialog();
//                if (!form.Success)
//                    return;
//                
//                using (var formConfirm = new ServerManagementRegisterConfirm(Controller, se))
//                {
//
//                }
//
//                Close();
//            }

        }
    }
}
