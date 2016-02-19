using AllAuth.Desktop.Forms.Templates;

namespace AllAuth.Desktop.Forms
{
    partial class GettingStarted
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelLoginRegister = new System.Windows.Forms.Panel();
            this.panelRegister = new System.Windows.Forms.Panel();
            this.panelRegisterButton = new System.Windows.Forms.Panel();
            this.btnRegister = new AllAuth.Desktop.Forms.Templates.ButtonAccent();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblRegisterDescription = new System.Windows.Forms.Label();
            this.lblRegisterTitle = new System.Windows.Forms.Label();
            this.panelVerticalSplitLine = new System.Windows.Forms.Panel();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.panelLoginButton = new System.Windows.Forms.Panel();
            this.lblLoginLoading = new System.Windows.Forms.Label();
            this.btnLoginStep1 = new AllAuth.Desktop.Forms.Templates.ButtonAccent();
            this.panelLoginButtonSpacing = new System.Windows.Forms.Panel();
            this.txtLoginPassword = new AllAuth.Desktop.Forms.Templates.TextBoxPassword();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtLoginEmailAddress = new AllAuth.Desktop.Forms.Templates.TextBox();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.labelLoginTitle = new System.Windows.Forms.Label();
            this.panelHeaderContainer = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelOptionsContainer = new System.Windows.Forms.Panel();
            this.lblManualServerAddTop = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.panelLoginRegister.SuspendLayout();
            this.panelRegister.SuspendLayout();
            this.panelRegisterButton.SuspendLayout();
            this.panelLogin.SuspendLayout();
            this.panelLoginButton.SuspendLayout();
            this.panelHeaderContainer.SuspendLayout();
            this.panelOptionsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Padding = new System.Windows.Forms.Padding(0);
            this.panelFormContainer.Size = new System.Drawing.Size(868, 342);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.panelLoginRegister);
            this.panelContentContainer.Controls.Add(this.panel3);
            this.panelContentContainer.Controls.Add(this.panelHeaderContainer);
            this.panelContentContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContentContainer.Margin = new System.Windows.Forms.Padding(2);
            this.panelContentContainer.Size = new System.Drawing.Size(868, 342);
            // 
            // panelLoginRegister
            // 
            this.panelLoginRegister.Controls.Add(this.panelRegister);
            this.panelLoginRegister.Controls.Add(this.panelVerticalSplitLine);
            this.panelLoginRegister.Controls.Add(this.panelLogin);
            this.panelLoginRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLoginRegister.Location = new System.Drawing.Point(0, 57);
            this.panelLoginRegister.Name = "panelLoginRegister";
            this.panelLoginRegister.Padding = new System.Windows.Forms.Padding(18, 20, 18, 20);
            this.panelLoginRegister.Size = new System.Drawing.Size(868, 285);
            this.panelLoginRegister.TabIndex = 11;
            // 
            // panelRegister
            // 
            this.panelRegister.Controls.Add(this.panelRegisterButton);
            this.panelRegister.Controls.Add(this.panel2);
            this.panelRegister.Controls.Add(this.lblRegisterDescription);
            this.panelRegister.Controls.Add(this.lblRegisterTitle);
            this.panelRegister.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRegister.Location = new System.Drawing.Point(460, 20);
            this.panelRegister.Name = "panelRegister";
            this.panelRegister.Padding = new System.Windows.Forms.Padding(44, 0, 9, 9);
            this.panelRegister.Size = new System.Drawing.Size(390, 245);
            this.panelRegister.TabIndex = 4;
            // 
            // panelRegisterButton
            // 
            this.panelRegisterButton.Controls.Add(this.btnRegister);
            this.panelRegisterButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRegisterButton.Location = new System.Drawing.Point(44, 123);
            this.panelRegisterButton.Name = "panelRegisterButton";
            this.panelRegisterButton.Size = new System.Drawing.Size(337, 42);
            this.panelRegisterButton.TabIndex = 4;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRegister.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(0, 0);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(0);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Padding = new System.Windows.Forms.Padding(5);
            this.btnRegister.Size = new System.Drawing.Size(187, 42);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.TextValue = "Register";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(44, 114);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 9);
            this.panel2.TabIndex = 15;
            // 
            // lblRegisterDescription
            // 
            this.lblRegisterDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegisterDescription.Location = new System.Drawing.Point(44, 42);
            this.lblRegisterDescription.Name = "lblRegisterDescription";
            this.lblRegisterDescription.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.lblRegisterDescription.Size = new System.Drawing.Size(337, 72);
            this.lblRegisterDescription.TabIndex = 3;
            this.lblRegisterDescription.Text = "All you need is your email address to start your 14 day free trial.";
            // 
            // lblRegisterTitle
            // 
            this.lblRegisterTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRegisterTitle.Font = new System.Drawing.Font("Open Sans Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegisterTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(75)))));
            this.lblRegisterTitle.Location = new System.Drawing.Point(44, 0);
            this.lblRegisterTitle.Name = "lblRegisterTitle";
            this.lblRegisterTitle.Size = new System.Drawing.Size(337, 42);
            this.lblRegisterTitle.TabIndex = 1;
            this.lblRegisterTitle.Text = "Don\'t have an account?";
            this.lblRegisterTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelVerticalSplitLine
            // 
            this.panelVerticalSplitLine.BackColor = System.Drawing.Color.LightGray;
            this.panelVerticalSplitLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelVerticalSplitLine.ForeColor = System.Drawing.Color.Silver;
            this.panelVerticalSplitLine.Location = new System.Drawing.Point(458, 20);
            this.panelVerticalSplitLine.Name = "panelVerticalSplitLine";
            this.panelVerticalSplitLine.Size = new System.Drawing.Size(2, 245);
            this.panelVerticalSplitLine.TabIndex = 1;
            // 
            // panelLogin
            // 
            this.panelLogin.Controls.Add(this.panelLoginButton);
            this.panelLogin.Controls.Add(this.panelLoginButtonSpacing);
            this.panelLogin.Controls.Add(this.txtLoginPassword);
            this.panelLogin.Controls.Add(this.lblPassword);
            this.panelLogin.Controls.Add(this.txtLoginEmailAddress);
            this.panelLogin.Controls.Add(this.lblEmailAddress);
            this.panelLogin.Controls.Add(this.labelLoginTitle);
            this.panelLogin.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLogin.Location = new System.Drawing.Point(18, 20);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Padding = new System.Windows.Forms.Padding(9, 0, 20, 9);
            this.panelLogin.Size = new System.Drawing.Size(440, 245);
            this.panelLogin.TabIndex = 0;
            // 
            // panelLoginButton
            // 
            this.panelLoginButton.Controls.Add(this.lblLoginLoading);
            this.panelLoginButton.Controls.Add(this.btnLoginStep1);
            this.panelLoginButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLoginButton.Location = new System.Drawing.Point(9, 198);
            this.panelLoginButton.Name = "panelLoginButton";
            this.panelLoginButton.Size = new System.Drawing.Size(411, 42);
            this.panelLoginButton.TabIndex = 11;
            // 
            // lblLoginLoading
            // 
            this.lblLoginLoading.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLoginLoading.Image = global::AllAuth.Desktop.Properties.Resources.ajax_loader;
            this.lblLoginLoading.Location = new System.Drawing.Point(185, 0);
            this.lblLoginLoading.Name = "lblLoginLoading";
            this.lblLoginLoading.Size = new System.Drawing.Size(32, 42);
            this.lblLoginLoading.TabIndex = 1;
            this.lblLoginLoading.Visible = false;
            // 
            // btnLoginStep1
            // 
            this.btnLoginStep1.BackColor = System.Drawing.Color.Transparent;
            this.btnLoginStep1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLoginStep1.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnLoginStep1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoginStep1.Location = new System.Drawing.Point(0, 0);
            this.btnLoginStep1.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoginStep1.Name = "btnLoginStep1";
            this.btnLoginStep1.Padding = new System.Windows.Forms.Padding(5);
            this.btnLoginStep1.Size = new System.Drawing.Size(185, 42);
            this.btnLoginStep1.TabIndex = 3;
            this.btnLoginStep1.TextValue = "Login";
            this.btnLoginStep1.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panelLoginButtonSpacing
            // 
            this.panelLoginButtonSpacing.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLoginButtonSpacing.Location = new System.Drawing.Point(9, 189);
            this.panelLoginButtonSpacing.Name = "panelLoginButtonSpacing";
            this.panelLoginButtonSpacing.Size = new System.Drawing.Size(411, 9);
            this.panelLoginButtonSpacing.TabIndex = 10;
            // 
            // txtLoginPassword
            // 
            this.txtLoginPassword.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtLoginPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtLoginPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLoginPassword.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginPassword.Location = new System.Drawing.Point(9, 147);
            this.txtLoginPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtLoginPassword.MaximumSize = new System.Drawing.Size(356, 42);
            this.txtLoginPassword.MultiLine = false;
            this.txtLoginPassword.Name = "txtLoginPassword";
            this.txtLoginPassword.Padding = new System.Windows.Forms.Padding(5);
            this.txtLoginPassword.Readonly = false;
            this.txtLoginPassword.Size = new System.Drawing.Size(356, 42);
            this.txtLoginPassword.TabIndex = 2;
            this.txtLoginPassword.TextValue = "";
            // 
            // lblPassword
            // 
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPassword.ForeColor = System.Drawing.Color.DimGray;
            this.lblPassword.Location = new System.Drawing.Point(9, 115);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblPassword.Size = new System.Drawing.Size(411, 32);
            this.lblPassword.TabIndex = 7;
            this.lblPassword.Text = "Recovery Passphrase";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtLoginEmailAddress
            // 
            this.txtLoginEmailAddress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtLoginEmailAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtLoginEmailAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLoginEmailAddress.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginEmailAddress.Location = new System.Drawing.Point(9, 73);
            this.txtLoginEmailAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txtLoginEmailAddress.MaximumSize = new System.Drawing.Size(356, 42);
            this.txtLoginEmailAddress.MultiLine = false;
            this.txtLoginEmailAddress.Name = "txtLoginEmailAddress";
            this.txtLoginEmailAddress.Padding = new System.Windows.Forms.Padding(5);
            this.txtLoginEmailAddress.Readonly = false;
            this.txtLoginEmailAddress.Size = new System.Drawing.Size(356, 42);
            this.txtLoginEmailAddress.TabIndex = 1;
            this.txtLoginEmailAddress.TextValue = "";
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEmailAddress.ForeColor = System.Drawing.Color.DimGray;
            this.lblEmailAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEmailAddress.Location = new System.Drawing.Point(9, 42);
            this.lblEmailAddress.Margin = new System.Windows.Forms.Padding(0);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lblEmailAddress.Size = new System.Drawing.Size(411, 31);
            this.lblEmailAddress.TabIndex = 3;
            this.lblEmailAddress.Text = "Email address";
            this.lblEmailAddress.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // labelLoginTitle
            // 
            this.labelLoginTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelLoginTitle.Font = new System.Drawing.Font("Open Sans Light", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoginTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(75)))));
            this.labelLoginTitle.Location = new System.Drawing.Point(9, 0);
            this.labelLoginTitle.Name = "labelLoginTitle";
            this.labelLoginTitle.Size = new System.Drawing.Size(411, 42);
            this.labelLoginTitle.TabIndex = 0;
            this.labelLoginTitle.Text = "Log in to your account";
            this.labelLoginTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelHeaderContainer
            // 
            this.panelHeaderContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(172)))), ((int)(((byte)(57)))));
            this.panelHeaderContainer.Controls.Add(this.lblLogo);
            this.panelHeaderContainer.Controls.Add(this.panelOptionsContainer);
            this.panelHeaderContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderContainer.Location = new System.Drawing.Point(0, 0);
            this.panelHeaderContainer.Name = "panelHeaderContainer";
            this.panelHeaderContainer.Size = new System.Drawing.Size(868, 55);
            this.panelHeaderContainer.TabIndex = 14;
            // 
            // lblLogo
            // 
            this.lblLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLogo.Image = global::AllAuth.Desktop.Properties.Resources.Logo_Full_white_131x31;
            this.lblLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.lblLogo.Size = new System.Drawing.Size(188, 55);
            this.lblLogo.TabIndex = 13;
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelOptionsContainer
            // 
            this.panelOptionsContainer.Controls.Add(this.lblManualServerAddTop);
            this.panelOptionsContainer.Controls.Add(this.panel1);
            this.panelOptionsContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelOptionsContainer.Location = new System.Drawing.Point(647, 0);
            this.panelOptionsContainer.Name = "panelOptionsContainer";
            this.panelOptionsContainer.Size = new System.Drawing.Size(221, 55);
            this.panelOptionsContainer.TabIndex = 12;
            // 
            // lblManualServerAddTop
            // 
            this.lblManualServerAddTop.AutoSize = true;
            this.lblManualServerAddTop.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblManualServerAddTop.ForeColor = System.Drawing.Color.White;
            this.lblManualServerAddTop.Location = new System.Drawing.Point(51, 22);
            this.lblManualServerAddTop.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblManualServerAddTop.Name = "lblManualServerAddTop";
            this.lblManualServerAddTop.Padding = new System.Windows.Forms.Padding(0, 0, 9, 0);
            this.lblManualServerAddTop.Size = new System.Drawing.Size(170, 20);
            this.lblManualServerAddTop.TabIndex = 11;
            this.lblManualServerAddTop.Text = "Using your own server?";
            this.lblManualServerAddTop.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblManualServerAddTop.Visible = false;
            this.lblManualServerAddTop.Click += new System.EventHandler(this.lblManualServerAddTop_Click);
            this.lblManualServerAddTop.MouseEnter += new System.EventHandler(this.lblManualServerAddTop_MouseEnter);
            this.lblManualServerAddTop.MouseLeave += new System.EventHandler(this.lblManualServerAddTop_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 22);
            this.panel1.TabIndex = 12;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(868, 2);
            this.panel3.TabIndex = 15;
            // 
            // GettingStarted
            // 
            this.AcceptButton = this.btnLoginStep1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(868, 342);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "GettingStarted";
            this.ShowIcon = true;
            this.ShowInTaskbar = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Getting Started";
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panelLoginRegister.ResumeLayout(false);
            this.panelRegister.ResumeLayout(false);
            this.panelRegisterButton.ResumeLayout(false);
            this.panelLogin.ResumeLayout(false);
            this.panelLoginButton.ResumeLayout(false);
            this.panelHeaderContainer.ResumeLayout(false);
            this.panelOptionsContainer.ResumeLayout(false);
            this.panelOptionsContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Panel panelLoginRegister;
        private System.Windows.Forms.Panel panelVerticalSplitLine;
        private System.Windows.Forms.Panel panelRegister;
        private System.Windows.Forms.Label labelLoginTitle;
        private System.Windows.Forms.Label lblEmailAddress;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel panelLoginButtonSpacing;
        private ButtonAccent btnRegister;
        private System.Windows.Forms.Label lblRegisterTitle;
        private System.Windows.Forms.Panel panelRegisterButton;
        private System.Windows.Forms.Label lblRegisterDescription;
        private System.Windows.Forms.Panel panelLoginButton;
        private ButtonAccent btnLoginStep1;
        private TextBox txtLoginEmailAddress;
        private TextBoxPassword txtLoginPassword;
        private System.Windows.Forms.Panel panelHeaderContainer;
        private System.Windows.Forms.Panel panelOptionsContainer;
        private System.Windows.Forms.Label lblManualServerAddTop;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLoginLoading;
        private System.Windows.Forms.Panel panel3;
    }
}