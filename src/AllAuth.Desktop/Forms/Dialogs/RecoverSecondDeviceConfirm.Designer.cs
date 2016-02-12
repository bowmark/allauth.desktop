using AllAuth.Desktop.Forms.Templates;

namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class RecoverSecondDeviceConfirm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecoverSecondDeviceConfirm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStartRecovery = new ButtonAccent();
            this.linkCancel = new System.Windows.Forms.LinkLabel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(8, 4);
            this.lblTitle.Size = new System.Drawing.Size(325, 41);
            this.lblTitle.Text = "Confirm phone recovery";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelFormContainer.Size = new System.Drawing.Size(479, 363);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.panelButtons);
            this.panelContentContainer.Controls.Add(this.label2);
            this.panelContentContainer.Controls.Add(this.label1);
            this.panelContentContainer.Location = new System.Drawing.Point(5, 57);
            this.panelContentContainer.Padding = new System.Windows.Forms.Padding(10);
            this.panelContentContainer.Size = new System.Drawing.Size(469, 301);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(449, 147);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(449, 68);
            this.label2.TabIndex = 1;
            this.label2.Text = "Make sure you know the recovery passphrase for your phone before continuing (reme" +
    "mber, it is not the same as the one for this computer).";
            // 
            // btnStartRecovery
            // 
            this.btnStartRecovery.BackColor = System.Drawing.Color.Transparent;
            this.btnStartRecovery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnStartRecovery.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartRecovery.Location = new System.Drawing.Point(139, 0);
            this.btnStartRecovery.Margin = new System.Windows.Forms.Padding(0);
            this.btnStartRecovery.Name = "btnStartRecovery";
            this.btnStartRecovery.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartRecovery.Size = new System.Drawing.Size(305, 43);
            this.btnStartRecovery.TabIndex = 2;
            this.btnStartRecovery.TextValue = "I understand, continue recovery";
            this.btnStartRecovery.Click += new System.EventHandler(this.btnStartRecovery_Click);
            // 
            // linkCancel
            // 
            this.linkCancel.AutoSize = true;
            this.linkCancel.Location = new System.Drawing.Point(3, 11);
            this.linkCancel.Name = "linkCancel";
            this.linkCancel.Size = new System.Drawing.Size(53, 20);
            this.linkCancel.TabIndex = 3;
            this.linkCancel.TabStop = true;
            this.linkCancel.Text = "Cancel";
            this.linkCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCancel_LinkClicked);
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.btnStartRecovery);
            this.panelButtons.Controls.Add(this.linkCancel);
            this.panelButtons.Location = new System.Drawing.Point(15, 240);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(444, 43);
            this.panelButtons.TabIndex = 4;
            // 
            // RecoverSecondDeviceConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 363);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "RecoverSecondDeviceConfirm";
            this.Text = "Confirm Phone Recovery";
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panelButtons.ResumeLayout(false);
            this.panelButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Templates.ButtonAccent btnStartRecovery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkCancel;
        private System.Windows.Forms.Panel panelButtons;
    }
}