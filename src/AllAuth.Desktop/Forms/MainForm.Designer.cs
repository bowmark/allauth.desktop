namespace AllAuth.Desktop.Forms
{
    partial class MainForm
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
            this.panelHeaderContainer = new System.Windows.Forms.Panel();
            this.panelContentContainer = new System.Windows.Forms.Panel();
            this.panelSubscriptionInfoBar = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelHeaderContainer
            // 
            this.panelHeaderContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderContainer.Location = new System.Drawing.Point(0, 0);
            this.panelHeaderContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeaderContainer.Name = "panelHeaderContainer";
            this.panelHeaderContainer.Size = new System.Drawing.Size(933, 55);
            this.panelHeaderContainer.TabIndex = 0;
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentContainer.Location = new System.Drawing.Point(0, 88);
            this.panelContentContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panelContentContainer.Name = "panelContentContainer";
            this.panelContentContainer.Size = new System.Drawing.Size(933, 359);
            this.panelContentContainer.TabIndex = 1;
            // 
            // panelSubscriptionInfoBar
            // 
            this.panelSubscriptionInfoBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSubscriptionInfoBar.Location = new System.Drawing.Point(0, 55);
            this.panelSubscriptionInfoBar.Name = "panelSubscriptionInfoBar";
            this.panelSubscriptionInfoBar.Size = new System.Drawing.Size(933, 32);
            this.panelSubscriptionInfoBar.TabIndex = 4;
            this.panelSubscriptionInfoBar.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(933, 1);
            this.panel1.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(933, 447);
            this.Controls.Add(this.panelContentContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSubscriptionInfoBar);
            this.Controls.Add(this.panelHeaderContainer);
            this.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(800, 39);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AllAuth";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Panel panelHeaderContainer;
        internal System.Windows.Forms.Panel panelContentContainer;
        private System.Windows.Forms.Panel panelSubscriptionInfoBar;
        private System.Windows.Forms.Panel panel1;
    }
}

