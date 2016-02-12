namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class About
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
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.linkTerms = new System.Windows.Forms.LinkLabel();
            this.linkPrivacy = new System.Windows.Forms.LinkLabel();
            this.linkLicenses = new System.Windows.Forms.LinkLabel();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(7, 4);
            this.lblTitle.Size = new System.Drawing.Size(96, 41);
            this.lblTitle.Text = "About";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelFormContainer.Size = new System.Drawing.Size(401, 202);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.linkLicenses);
            this.panelContentContainer.Controls.Add(this.linkPrivacy);
            this.panelContentContainer.Controls.Add(this.linkTerms);
            this.panelContentContainer.Controls.Add(this.lblCopyright);
            this.panelContentContainer.Controls.Add(this.lblVersion);
            this.panelContentContainer.Location = new System.Drawing.Point(4, 57);
            this.panelContentContainer.Size = new System.Drawing.Size(393, 140);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(11, 26);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(144, 20);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Version: <VERSION>";
            // 
            // lblCopyright
            // 
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Location = new System.Drawing.Point(11, 60);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(179, 20);
            this.lblCopyright.TabIndex = 1;
            this.lblCopyright.Text = "Copyright: <COPYRIGHT>";
            // 
            // linkTerms
            // 
            this.linkTerms.AutoSize = true;
            this.linkTerms.Location = new System.Drawing.Point(11, 98);
            this.linkTerms.Name = "linkTerms";
            this.linkTerms.Size = new System.Drawing.Size(121, 20);
            this.linkTerms.TabIndex = 2;
            this.linkTerms.TabStop = true;
            this.linkTerms.Text = "Terms of Service ";
            this.linkTerms.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkTerms_LinkClicked);
            // 
            // linkPrivacy
            // 
            this.linkPrivacy.AutoSize = true;
            this.linkPrivacy.Location = new System.Drawing.Point(138, 98);
            this.linkPrivacy.Name = "linkPrivacy";
            this.linkPrivacy.Size = new System.Drawing.Size(97, 20);
            this.linkPrivacy.TabIndex = 3;
            this.linkPrivacy.TabStop = true;
            this.linkPrivacy.Text = "Privacy Policy";
            this.linkPrivacy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkPrivacy_LinkClicked);
            // 
            // linkLicenses
            // 
            this.linkLicenses.AutoSize = true;
            this.linkLicenses.Location = new System.Drawing.Point(241, 98);
            this.linkLicenses.Name = "linkLicenses";
            this.linkLicenses.Size = new System.Drawing.Size(115, 20);
            this.linkLicenses.TabIndex = 3;
            this.linkLicenses.TabStop = true;
            this.linkLicenses.Text = "Licenses/Credits";
            this.linkLicenses.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLicenses_LinkClicked);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 202);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "About";
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panelContentContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCopyright;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.LinkLabel linkLicenses;
        private System.Windows.Forms.LinkLabel linkPrivacy;
        private System.Windows.Forms.LinkLabel linkTerms;
    }
}