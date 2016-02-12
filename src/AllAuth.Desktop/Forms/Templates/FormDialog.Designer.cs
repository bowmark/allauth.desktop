namespace AllAuth.Desktop.Forms.Templates
{
    partial class FormDialog
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
            this.panelFormContainer = new System.Windows.Forms.Panel();
            this.panelContentContainer = new System.Windows.Forms.Panel();
            this.panelFormContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Controls.Add(this.panelContentContainer);
            this.panelFormContainer.ForeColor = System.Drawing.Color.Black;
            this.panelFormContainer.Location = new System.Drawing.Point(0, 0);
            this.panelFormContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panelFormContainer.Name = "panelFormContainer";
            this.panelFormContainer.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panelFormContainer.Size = new System.Drawing.Size(690, 302);
            this.panelFormContainer.TabIndex = 0;
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentContainer.ForeColor = System.Drawing.Color.DimGray;
            this.panelContentContainer.Location = new System.Drawing.Point(6, 5);
            this.panelContentContainer.Name = "panelContentContainer";
            this.panelContentContainer.Size = new System.Drawing.Size(678, 292);
            this.panelContentContainer.TabIndex = 0;
            // 
            // FormDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(752, 409);
            this.Controls.Add(this.panelFormContainer);
            this.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DimGray;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FormDialogTemplate_Load);
            this.panelFormContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        protected internal System.Windows.Forms.Panel panelFormContainer;
        protected internal System.Windows.Forms.Panel panelContentContainer;
    }
}