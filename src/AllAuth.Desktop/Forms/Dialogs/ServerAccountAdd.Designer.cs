using AllAuth.Desktop.Forms.Templates;

namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class ServerAccountAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLogin = new AllAuth.Desktop.Forms.Templates.ButtonAccent();
            this.txtEmailAddress = new AllAuth.Desktop.Forms.Templates.TextBox();
            this.txtHost = new AllAuth.Desktop.Forms.Templates.TextBox();
            this.txtRecoveryPassword = new AllAuth.Desktop.Forms.Templates.TextBoxPassword();
            this.txtPort = new AllAuth.Desktop.Forms.Templates.TextBox();
            this.txtApiVersion = new AllAuth.Desktop.Forms.Templates.TextBox();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(7, 4);
            this.lblTitle.Size = new System.Drawing.Size(160, 41);
            this.lblTitle.Text = "Add Server";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Size = new System.Drawing.Size(454, 349);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.txtApiVersion);
            this.panelContentContainer.Controls.Add(this.txtPort);
            this.panelContentContainer.Controls.Add(this.txtRecoveryPassword);
            this.panelContentContainer.Controls.Add(this.txtHost);
            this.panelContentContainer.Controls.Add(this.txtEmailAddress);
            this.panelContentContainer.Controls.Add(this.btnLogin);
            this.panelContentContainer.Controls.Add(this.label5);
            this.panelContentContainer.Controls.Add(this.label4);
            this.panelContentContainer.Controls.Add(this.label3);
            this.panelContentContainer.Controls.Add(this.label2);
            this.panelContentContainer.Controls.Add(this.label1);
            this.panelContentContainer.Size = new System.Drawing.Size(442, 287);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email Address";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F);
            this.label2.Location = new System.Drawing.Point(4, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Recovery Passphrase";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F);
            this.label3.Location = new System.Drawing.Point(44, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Domain Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F);
            this.label4.Location = new System.Drawing.Point(100, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Port";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F);
            this.label5.Location = new System.Drawing.Point(64, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "API Version";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(146, 234);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnLogin.Size = new System.Drawing.Size(288, 42);
            this.btnLogin.TabIndex = 10;
            this.btnLogin.TextValue = "Log in to server";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtEmailAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtEmailAddress.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailAddress.Location = new System.Drawing.Point(146, 24);
            this.txtEmailAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txtEmailAddress.MultiLine = false;
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtEmailAddress.Readonly = false;
            this.txtEmailAddress.Size = new System.Drawing.Size(288, 42);
            this.txtEmailAddress.TabIndex = 1;
            this.txtEmailAddress.TextValue = "";
            // 
            // txtHost
            // 
            this.txtHost.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtHost.BackColor = System.Drawing.Color.Transparent;
            this.txtHost.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHost.Location = new System.Drawing.Point(146, 108);
            this.txtHost.Margin = new System.Windows.Forms.Padding(0);
            this.txtHost.MultiLine = false;
            this.txtHost.Name = "txtHost";
            this.txtHost.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtHost.Readonly = false;
            this.txtHost.Size = new System.Drawing.Size(288, 42);
            this.txtHost.TabIndex = 3;
            this.txtHost.TextValue = "";
            // 
            // txtRecoveryPassword
            // 
            this.txtRecoveryPassword.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtRecoveryPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtRecoveryPassword.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecoveryPassword.Location = new System.Drawing.Point(146, 66);
            this.txtRecoveryPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtRecoveryPassword.MultiLine = false;
            this.txtRecoveryPassword.Name = "txtRecoveryPassword";
            this.txtRecoveryPassword.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtRecoveryPassword.Readonly = false;
            this.txtRecoveryPassword.Size = new System.Drawing.Size(288, 42);
            this.txtRecoveryPassword.TabIndex = 2;
            this.txtRecoveryPassword.TextValue = "";
            // 
            // txtPort
            // 
            this.txtPort.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtPort.BackColor = System.Drawing.Color.Transparent;
            this.txtPort.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.Location = new System.Drawing.Point(146, 150);
            this.txtPort.Margin = new System.Windows.Forms.Padding(0);
            this.txtPort.MultiLine = false;
            this.txtPort.Name = "txtPort";
            this.txtPort.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtPort.Readonly = false;
            this.txtPort.Size = new System.Drawing.Size(121, 42);
            this.txtPort.TabIndex = 4;
            this.txtPort.TextValue = "38750";
            // 
            // txtApiVersion
            // 
            this.txtApiVersion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtApiVersion.BackColor = System.Drawing.Color.Transparent;
            this.txtApiVersion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApiVersion.Location = new System.Drawing.Point(146, 192);
            this.txtApiVersion.Margin = new System.Windows.Forms.Padding(0);
            this.txtApiVersion.MultiLine = false;
            this.txtApiVersion.Name = "txtApiVersion";
            this.txtApiVersion.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtApiVersion.Readonly = false;
            this.txtApiVersion.Size = new System.Drawing.Size(121, 42);
            this.txtApiVersion.TabIndex = 5;
            this.txtApiVersion.TextValue = "1";
            // 
            // ServerAccountAdd
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.ClientSize = new System.Drawing.Size(454, 349);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ServerAccountAdd";
            this.Text = "Add Server";
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panelContentContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Templates.TextBoxPassword txtRecoveryPassword;
        private Templates.TextBox txtHost;
        private Templates.TextBox txtEmailAddress;
        private Templates.ButtonAccent btnLogin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Templates.TextBox txtApiVersion;
        private Templates.TextBox txtPort;
        private System.Windows.Forms.Label label1;
    }
}