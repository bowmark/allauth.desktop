namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class SetupOtpDeviceLink
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
            this.txtOtpDeviceLinkCode = new System.Windows.Forms.TextBox();
            this.lblQrCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(11, 8);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Size = new System.Drawing.Size(296, 41);
            this.lblTitle.Text = "Link device to account";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Padding = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.panelFormContainer.Size = new System.Drawing.Size(413, 427);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.lblQrCode);
            this.panelContentContainer.Controls.Add(this.txtOtpDeviceLinkCode);
            this.panelContentContainer.Controls.Add(this.label2);
            this.panelContentContainer.Location = new System.Drawing.Point(5, 59);
            this.panelContentContainer.Margin = new System.Windows.Forms.Padding(4);
            this.panelContentContainer.Size = new System.Drawing.Size(403, 361);
            // 
            // txtOtpDeviceLinkCode
            // 
            this.txtOtpDeviceLinkCode.Location = new System.Drawing.Point(17, 317);
            this.txtOtpDeviceLinkCode.Margin = new System.Windows.Forms.Padding(4, 13, 4, 4);
            this.txtOtpDeviceLinkCode.Name = "txtOtpDeviceLinkCode";
            this.txtOtpDeviceLinkCode.Size = new System.Drawing.Size(370, 27);
            this.txtOtpDeviceLinkCode.TabIndex = 1;
            this.txtOtpDeviceLinkCode.Visible = false;
            // 
            // lblQrCode
            // 
            this.lblQrCode.Image = global::AllAuth.Desktop.Properties.Resources.loading_spinner;
            this.lblQrCode.Location = new System.Drawing.Point(83, 136);
            this.lblQrCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblQrCode.Name = "lblQrCode";
            this.lblQrCode.Size = new System.Drawing.Size(232, 232);
            this.lblQrCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(394, 130);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select \"Add Account\" from the main menu within the AllAuth app on your phone and " +
    "scan the image below with the camera.\r\n\r\nOnce scanned, the process will continue" +
    " automatically.";
            // 
            // SetupOtpDeviceLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(425, 440);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.Name = "SetupOtpDeviceLink";
            this.Padding = new System.Windows.Forms.Padding(12, 13, 12, 13);
            this.Text = "Link Device To Account";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupOtpDeviceLink_FormClosing);
            this.Load += new System.EventHandler(this.SetupOtpDeviceLink_Load);
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panelContentContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtOtpDeviceLinkCode;
        private System.Windows.Forms.Label lblQrCode;
        private System.Windows.Forms.Label label2;
    }
}