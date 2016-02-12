namespace AllAuth.Desktop.Forms
{
    partial class DatabaseViewGroup
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
            this.lblGroupName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGroupName
            // 
            this.lblGroupName.BackColor = System.Drawing.Color.Transparent;
            this.lblGroupName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGroupName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGroupName.Location = new System.Drawing.Point(0, 0);
            this.lblGroupName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblGroupName.Size = new System.Drawing.Size(299, 33);
            this.lblGroupName.TabIndex = 0;
            this.lblGroupName.Text = "<GroupName>";
            this.lblGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGroupName.Click += new System.EventHandler(this.lblGroupName_Click);
            this.lblGroupName.MouseEnter += new System.EventHandler(this.lblGroupName_MouseEnter);
            this.lblGroupName.MouseLeave += new System.EventHandler(this.lblGroupName_MouseLeave);
            // 
            // DatabaseViewGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.lblGroupName);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DatabaseViewGroup";
            this.Size = new System.Drawing.Size(299, 33);
            this.Load += new System.EventHandler(this.DatabaseViewGroup_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblGroupName;
    }
}
