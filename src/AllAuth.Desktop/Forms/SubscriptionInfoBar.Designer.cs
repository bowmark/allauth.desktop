namespace AllAuth.Desktop.Forms
{
    partial class SubscriptionInfoBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelBorder = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panelBorder.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBorder
            // 
            this.panelBorder.Controls.Add(this.panelContent);
            this.panelBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorder.Location = new System.Drawing.Point(0, 0);
            this.panelBorder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Size = new System.Drawing.Size(868, 42);
            this.panelBorder.TabIndex = 0;
            // 
            // panelContent
            // 
            this.panelContent.AutoSize = true;
            this.panelContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelContent.Controls.Add(this.lblInfo);
            this.panelContent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelContent.Name = "panelContent";
            this.panelContent.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.panelContent.Size = new System.Drawing.Size(868, 42);
            this.panelContent.TabIndex = 0;
            // 
            // lblInfo
            // 
            this.lblInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Location = new System.Drawing.Point(20, 0);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(828, 42);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "<text>";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SubscriptionInfoBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panelBorder);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "SubscriptionInfoBar";
            this.Size = new System.Drawing.Size(868, 42);
            this.Load += new System.EventHandler(this.SubscriptionInfoBar_Load);
            this.panelBorder.ResumeLayout(false);
            this.panelBorder.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBorder;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label lblInfo;
    }
}
