namespace AllAuth.Desktop.Forms.Templates
{
    internal class FormDialogWithTitle : FormDialog
    {
        private System.Windows.Forms.Panel panelTitleContainer;
        private System.Windows.Forms.Panel panelTitleSeparator;
        protected internal System.Windows.Forms.Label lblTitle;

        protected FormDialogWithTitle()
        {
            InitializeComponent();
            lblTitle.Font = UiStyle.DefaultFontTitle;
        }

        private void InitializeComponent()
        {
            this.panelTitleContainer = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelTitleSeparator = new System.Windows.Forms.Panel();
            this.panelFormContainer.SuspendLayout();
            this.panelTitleContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Controls.Add(this.panelTitleSeparator);
            this.panelFormContainer.Controls.Add(this.panelTitleContainer);
            this.panelFormContainer.Size = new System.Drawing.Size(691, 302);
            this.panelFormContainer.Controls.SetChildIndex(this.panelTitleContainer, 0);
            this.panelFormContainer.Controls.SetChildIndex(this.panelContentContainer, 0);
            this.panelFormContainer.Controls.SetChildIndex(this.panelTitleSeparator, 0);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Location = new System.Drawing.Point(6, 57);
            this.panelContentContainer.Size = new System.Drawing.Size(679, 240);
            // 
            // panelTitleContainer
            // 
            this.panelTitleContainer.Controls.Add(this.lblTitle);
            this.panelTitleContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleContainer.Location = new System.Drawing.Point(6, 5);
            this.panelTitleContainer.Name = "panelTitleContainer";
            this.panelTitleContainer.Size = new System.Drawing.Size(679, 52);
            this.panelTitleContainer.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Open Sans Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(172)))), ((int)(((byte)(57)))));
            this.lblTitle.Location = new System.Drawing.Point(9, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(282, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "FormDialogWithTitle";
            // 
            // panelTitleSeparator
            // 
            this.panelTitleSeparator.BackColor = System.Drawing.Color.LightGray;
            this.panelTitleSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleSeparator.ForeColor = System.Drawing.Color.LightGray;
            this.panelTitleSeparator.Location = new System.Drawing.Point(6, 57);
            this.panelTitleSeparator.Name = "panelTitleSeparator";
            this.panelTitleSeparator.Size = new System.Drawing.Size(679, 1);
            this.panelTitleSeparator.TabIndex = 2;
            // 
            // FormDialogWithTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(691, 302);
            this.Name = "FormDialogWithTitle";
            this.panelFormContainer.ResumeLayout(false);
            this.panelTitleContainer.ResumeLayout(false);
            this.panelTitleContainer.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
