﻿namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class OpeningAccountManagement
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
            this.lblLoadingImage = new System.Windows.Forms.Label();
            this.lblLoadingText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Padding = new System.Windows.Forms.Padding(5);
            this.panelFormContainer.Size = new System.Drawing.Size(519, 117);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.panel1);
            this.panelContentContainer.Controls.Add(this.lblLoadingImage);
            this.panelContentContainer.Location = new System.Drawing.Point(5, 5);
            this.panelContentContainer.Size = new System.Drawing.Size(509, 107);
            // 
            // lblLoadingImage
            // 
            this.lblLoadingImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLoadingImage.Image = global::AllAuth.Desktop.Properties.Resources.loading_spinner;
            this.lblLoadingImage.Location = new System.Drawing.Point(0, 0);
            this.lblLoadingImage.Name = "lblLoadingImage";
            this.lblLoadingImage.Size = new System.Drawing.Size(127, 107);
            this.lblLoadingImage.TabIndex = 0;
            // 
            // lblLoadingText
            // 
            this.lblLoadingText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoadingText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingText.Location = new System.Drawing.Point(0, 0);
            this.lblLoadingText.Name = "lblLoadingText";
            this.lblLoadingText.Size = new System.Drawing.Size(382, 107);
            this.lblLoadingText.TabIndex = 1;
            this.lblLoadingText.Text = "Opening account management in your web browser...";
            this.lblLoadingText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLoadingText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(127, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 107);
            this.panel1.TabIndex = 2;
            // 
            // OpeningAccountManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(519, 117);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "OpeningAccountManagement";
            this.Shown += new System.EventHandler(this.OpeningAccountManagement_Shown);
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLoadingImage;
        private System.Windows.Forms.Label lblLoadingText;
        private System.Windows.Forms.Panel panel1;
    }
}