namespace AllAuth.Desktop.Forms
{
    partial class HomePage
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
            this.panelContentContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentContainer.Location = new System.Drawing.Point(0, 0);
            this.panelContentContainer.Name = "panelContentContainer";
            this.panelContentContainer.Padding = new System.Windows.Forms.Padding(20);
            this.panelContentContainer.Size = new System.Drawing.Size(622, 208);
            this.panelContentContainer.TabIndex = 2;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelContentContainer);
            this.Font = new System.Drawing.Font("Segoe UI Semilight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "HomePage";
            this.Size = new System.Drawing.Size(622, 208);
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelContentContainer;
    }
}
