namespace AllAuth.Mobile.TestDevice.Forms
{
    partial class BasicControls
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
            this.btnNewLink = new System.Windows.Forms.Button();
            this.cmbLinks = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbAccounts = new System.Windows.Forms.ComboBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddMfaAccount = new System.Windows.Forms.Button();
            this.btnGetMfaCode = new System.Windows.Forms.Button();
            this.cmbOtpAccounts = new System.Windows.Forms.ComboBox();
            this.btnSetRecoveryKey = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewLink
            // 
            this.btnNewLink.Enabled = false;
            this.btnNewLink.Location = new System.Drawing.Point(6, 19);
            this.btnNewLink.Name = "btnNewLink";
            this.btnNewLink.Size = new System.Drawing.Size(66, 22);
            this.btnNewLink.TabIndex = 0;
            this.btnNewLink.Text = "New Link";
            this.btnNewLink.UseVisualStyleBackColor = true;
            this.btnNewLink.Click += new System.EventHandler(this.btnLinkDatabase_Click);
            // 
            // cmbLinks
            // 
            this.cmbLinks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLinks.Enabled = false;
            this.cmbLinks.FormattingEnabled = true;
            this.cmbLinks.Location = new System.Drawing.Point(78, 20);
            this.cmbLinks.Name = "cmbLinks";
            this.cmbLinks.Size = new System.Drawing.Size(250, 21);
            this.cmbLinks.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNewLink);
            this.groupBox1.Controls.Add(this.cmbLinks);
            this.groupBox1.Location = new System.Drawing.Point(12, 210);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 50);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Password Databases";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSetRecoveryKey);
            this.groupBox2.Controls.Add(this.cmbAccounts);
            this.groupBox2.Controls.Add(this.btnRegister);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 106);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Accounts";
            // 
            // cmbAccounts
            // 
            this.cmbAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccounts.Enabled = false;
            this.cmbAccounts.FormattingEnabled = true;
            this.cmbAccounts.Location = new System.Drawing.Point(7, 48);
            this.cmbAccounts.Name = "cmbAccounts";
            this.cmbAccounts.Size = new System.Drawing.Size(321, 21);
            this.cmbAccounts.TabIndex = 0;
            this.cmbAccounts.SelectedIndexChanged += new System.EventHandler(this.cmbAccounts_SelectedIndexChanged);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(6, 19);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(322, 23);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "Add Account";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegisterWithServer_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAddMfaAccount);
            this.groupBox3.Controls.Add(this.btnGetMfaCode);
            this.groupBox3.Controls.Add(this.cmbOtpAccounts);
            this.groupBox3.Location = new System.Drawing.Point(12, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(334, 80);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "One-Time-Passwords";
            // 
            // btnAddMfaAccount
            // 
            this.btnAddMfaAccount.Location = new System.Drawing.Point(7, 20);
            this.btnAddMfaAccount.Name = "btnAddMfaAccount";
            this.btnAddMfaAccount.Size = new System.Drawing.Size(321, 23);
            this.btnAddMfaAccount.TabIndex = 2;
            this.btnAddMfaAccount.Text = "Add New OTP Account";
            this.btnAddMfaAccount.UseVisualStyleBackColor = true;
            this.btnAddMfaAccount.Click += new System.EventHandler(this.btnAddMfaAccount_Click);
            // 
            // btnGetMfaCode
            // 
            this.btnGetMfaCode.Location = new System.Drawing.Point(253, 49);
            this.btnGetMfaCode.Name = "btnGetMfaCode";
            this.btnGetMfaCode.Size = new System.Drawing.Size(75, 23);
            this.btnGetMfaCode.TabIndex = 1;
            this.btnGetMfaCode.Text = "Get Code";
            this.btnGetMfaCode.UseVisualStyleBackColor = true;
            this.btnGetMfaCode.Click += new System.EventHandler(this.btnGetMfaCode_Click);
            // 
            // cmbOtpAccounts
            // 
            this.cmbOtpAccounts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOtpAccounts.Enabled = false;
            this.cmbOtpAccounts.FormattingEnabled = true;
            this.cmbOtpAccounts.Location = new System.Drawing.Point(7, 51);
            this.cmbOtpAccounts.Name = "cmbOtpAccounts";
            this.cmbOtpAccounts.Size = new System.Drawing.Size(240, 21);
            this.cmbOtpAccounts.TabIndex = 0;
            // 
            // btnSetRecoveryKey
            // 
            this.btnSetRecoveryKey.Location = new System.Drawing.Point(6, 75);
            this.btnSetRecoveryKey.Name = "btnSetRecoveryKey";
            this.btnSetRecoveryKey.Size = new System.Drawing.Size(322, 23);
            this.btnSetRecoveryKey.TabIndex = 6;
            this.btnSetRecoveryKey.Text = "Set Recovery Key";
            this.btnSetRecoveryKey.UseVisualStyleBackColor = true;
            this.btnSetRecoveryKey.Click += new System.EventHandler(this.btnSetRecoveryKey_Click);
            // 
            // BasicControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 273);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BasicControls";
            this.Text = "BasicControls";
            this.Load += new System.EventHandler(this.BasicControls_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewLink;
        private System.Windows.Forms.ComboBox cmbLinks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbAccounts;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAddMfaAccount;
        private System.Windows.Forms.Button btnGetMfaCode;
        private System.Windows.Forms.ComboBox cmbOtpAccounts;
        private System.Windows.Forms.Button btnSetRecoveryKey;
    }
}