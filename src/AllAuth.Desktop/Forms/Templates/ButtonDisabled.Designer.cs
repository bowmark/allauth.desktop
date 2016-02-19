namespace AllAuth.Desktop.Forms.Templates
{
    partial class ButtonDisabled
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblButton = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 32);
            this.panel1.TabIndex = 0;
            // 
            // lblButton
            // 
            this.lblButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblButton.ForeColor = System.Drawing.Color.Gray;
            this.lblButton.Location = new System.Drawing.Point(0, 0);
            this.lblButton.Name = "lblButton";
            this.lblButton.Size = new System.Drawing.Size(210, 32);
            this.lblButton.TabIndex = 0;
            this.lblButton.Text = "ButtonText";
            this.lblButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonDisabled
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ButtonDisabled";
            this.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Size = new System.Drawing.Size(218, 42);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblButton;
    }
}
