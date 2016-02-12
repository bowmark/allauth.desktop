using AllAuth.Desktop.Forms.Templates;

namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class EditDatabase
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
            this.txtDbName = new AllAuth.Desktop.Forms.Templates.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEdit = new AllAuth.Desktop.Forms.Templates.ButtonAccent();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 6);
            this.lblTitle.Size = new System.Drawing.Size(188, 41);
            this.lblTitle.Text = "Edit database";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Size = new System.Drawing.Size(435, 209);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.btnEdit);
            this.panelContentContainer.Controls.Add(this.label1);
            this.panelContentContainer.Controls.Add(this.txtDbName);
            this.panelContentContainer.Size = new System.Drawing.Size(423, 147);
            // 
            // txtDbName
            // 
            this.txtDbName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtDbName.BackColor = System.Drawing.Color.Transparent;
            this.txtDbName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDbName.Location = new System.Drawing.Point(19, 39);
            this.txtDbName.Margin = new System.Windows.Forms.Padding(0);
            this.txtDbName.MultiLine = false;
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtDbName.Readonly = false;
            this.txtDbName.Size = new System.Drawing.Size(386, 42);
            this.txtDbName.TabIndex = 0;
            this.txtDbName.TextValue = "My Database";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name of database";
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEdit.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(19, 90);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.btnEdit.Size = new System.Drawing.Size(386, 42);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.TextValue = "Edit database";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // EditDatabase
            // 
            this.AcceptButton = this.btnEdit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 209);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EditDatabase";
            this.Text = "Edit Database";
            this.Load += new System.EventHandler(this.EditDatabase_Load);
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panelContentContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Templates.ButtonAccent btnEdit;
        private System.Windows.Forms.Label label1;
        private Templates.TextBox txtDbName;
    }
}