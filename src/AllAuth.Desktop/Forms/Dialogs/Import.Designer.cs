namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class Import
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
            this.listImportTypes = new AllAuth.Desktop.Forms.Templates.DropDownList();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new AllAuth.Desktop.Forms.Templates.ButtonAccent();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(8, 4);
            this.lblTitle.Size = new System.Drawing.Size(104, 41);
            this.lblTitle.Text = "Import";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelFormContainer.Size = new System.Drawing.Size(649, 204);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.panel2);
            this.panelContentContainer.Controls.Add(this.panel1);
            this.panelContentContainer.Controls.Add(this.btnImport);
            this.panelContentContainer.Controls.Add(this.label1);
            this.panelContentContainer.Controls.Add(this.listImportTypes);
            this.panelContentContainer.Location = new System.Drawing.Point(5, 57);
            this.panelContentContainer.Size = new System.Drawing.Size(639, 142);
            // 
            // listImportTypes
            // 
            this.listImportTypes.BackColor = System.Drawing.Color.Transparent;
            this.listImportTypes.DataSource = null;
            this.listImportTypes.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listImportTypes.Location = new System.Drawing.Point(15, 45);
            this.listImportTypes.Margin = new System.Windows.Forms.Padding(0);
            this.listImportTypes.Name = "listImportTypes";
            this.listImportTypes.Padding = new System.Windows.Forms.Padding(5);
            this.listImportTypes.Size = new System.Drawing.Size(328, 42);
            this.listImportTypes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Import Type";
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.Transparent;
            this.btnImport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnImport.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(15, 87);
            this.btnImport.Margin = new System.Windows.Forms.Padding(0);
            this.btnImport.Name = "btnImport";
            this.btnImport.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImport.Size = new System.Drawing.Size(328, 43);
            this.btnImport.TabIndex = 2;
            this.btnImport.TextValue = "Select file";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(369, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 142);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(20, 20, 10, 20);
            this.label2.Size = new System.Drawing.Size(270, 142);
            this.label2.TabIndex = 0;
            this.label2.Text = "Please note that this process will create duplicates if your import file contains" +
    " entries that are already in your database.";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(368, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 142);
            this.panel2.TabIndex = 5;
            // 
            // Import
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 204);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Import";
            this.Text = "Import";
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panelContentContainer.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Templates.DropDownList listImportTypes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private Templates.ButtonAccent btnImport;
        private System.Windows.Forms.Label label1;
    }
}