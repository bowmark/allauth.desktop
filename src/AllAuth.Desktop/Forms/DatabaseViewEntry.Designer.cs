namespace AllAuth.Desktop.Forms
{
    partial class DatabaseViewEntry
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
            this.lblEntryName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblEntryName
            // 
            this.lblEntryName.AutoEllipsis = true;
            this.lblEntryName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblEntryName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEntryName.Location = new System.Drawing.Point(0, 0);
            this.lblEntryName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEntryName.Name = "lblEntryName";
            this.lblEntryName.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblEntryName.Size = new System.Drawing.Size(299, 39);
            this.lblEntryName.TabIndex = 1;
            this.lblEntryName.Text = "<EntryName>";
            this.lblEntryName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEntryName.Click += new System.EventHandler(this.lblEntryName_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 1);
            this.panel1.TabIndex = 2;
            // 
            // DatabaseViewEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblEntryName);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DatabaseViewEntry";
            this.Size = new System.Drawing.Size(299, 40);
            this.Load += new System.EventHandler(this.DatabaseViewEntry_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblEntryName;
        private System.Windows.Forms.Panel panel1;
    }
}
