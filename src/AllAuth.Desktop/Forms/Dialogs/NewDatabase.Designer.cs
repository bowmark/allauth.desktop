using AllAuth.Desktop.Forms.Templates;

namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class NewDatabase
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
            this.btnCreate = new AllAuth.Desktop.Forms.Templates.ButtonAccent();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(12, 6);
            this.lblTitle.Size = new System.Drawing.Size(303, 41);
            this.lblTitle.Text = "Create new database";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Size = new System.Drawing.Size(435, 209);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.btnCreate);
            this.panelContentContainer.Controls.Add(this.label1);
            this.panelContentContainer.Controls.Add(this.txtDbName);
            this.panelContentContainer.Size = new System.Drawing.Size(423, 147);
            // 
            // txtDbName
            // 
            this.txtDbName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtDbName.BackColor = System.Drawing.Color.Transparent;
            this.txtDbName.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDbName.Location = new System.Drawing.Point(19, 39);
            this.txtDbName.Margin = new System.Windows.Forms.Padding(0);
            this.txtDbName.MultiLine = false;
            this.txtDbName.Name = "txtDbName";
            this.txtDbName.Padding = new System.Windows.Forms.Padding(5);
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
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreate.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCreate.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(19, 90);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Padding = new System.Windows.Forms.Padding(5);
            this.btnCreate.Size = new System.Drawing.Size(386, 42);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.TextValue = "Create New Database";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // NewDatabase
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(435, 209);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "NewDatabase";
            this.Text = "New Database";
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panelContentContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Templates.ButtonAccent btnCreate;
        private System.Windows.Forms.Label label1;
        private Templates.TextBox txtDbName;
    }
}