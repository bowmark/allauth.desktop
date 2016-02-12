namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class LoggingOut
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
            this.lblLoadingText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelFormContainer.Size = new System.Drawing.Size(399, 117);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.panel1);
            this.panelContentContainer.Controls.Add(this.label1);
            this.panelContentContainer.Location = new System.Drawing.Point(5, 5);
            this.panelContentContainer.Size = new System.Drawing.Size(389, 107);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Image = global::AllAuth.Desktop.Properties.Resources.loading_spinner;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 107);
            this.label1.TabIndex = 0;
            // 
            // lblLoadingText
            // 
            this.lblLoadingText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoadingText.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingText.Location = new System.Drawing.Point(0, 0);
            this.lblLoadingText.Name = "lblLoadingText";
            this.lblLoadingText.Size = new System.Drawing.Size(262, 107);
            this.lblLoadingText.TabIndex = 1;
            this.lblLoadingText.Text = "Logging you out of your account...";
            this.lblLoadingText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLoadingText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(127, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 107);
            this.panel1.TabIndex = 2;
            // 
            // LoggingOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 117);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "LoggingOut";
            this.Shown += new System.EventHandler(this.OpeningAccountManagement_Shown);
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoadingText;
        private System.Windows.Forms.Panel panel1;
    }
}