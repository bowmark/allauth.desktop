using AllAuth.Desktop.Forms.Templates;

namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class NewGroup
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
            this.txtName = new TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreate = new ButtonAccent();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(14, 6);
            this.lblTitle.Size = new System.Drawing.Size(215, 39);
            this.lblTitle.Text = "Add new group";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.panelFormContainer.Size = new System.Drawing.Size(489, 209);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.btnCreate);
            this.panelContentContainer.Controls.Add(this.label1);
            this.panelContentContainer.Controls.Add(this.txtName);
            this.panelContentContainer.Location = new System.Drawing.Point(7, 57);
            this.panelContentContainer.Size = new System.Drawing.Size(475, 147);
            // 
            // txtName
            // 
            this.txtName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtName.BackColor = System.Drawing.Color.Transparent;
            this.txtName.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(21, 39);
            this.txtName.Margin = new System.Windows.Forms.Padding(0);
            this.txtName.MultiLine = false;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtName.Readonly = false;
            this.txtName.Size = new System.Drawing.Size(434, 42);
            this.txtName.TabIndex = 0;
            this.txtName.TextValue = "My Group";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name of group";
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreate.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCreate.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(21, 90);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(0);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCreate.Size = new System.Drawing.Size(434, 42);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.TextValue = "Add New Group";
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // NewGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 209);
            this.Name = "NewGroup";
            this.Text = "New Group";
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panelContentContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Templates.ButtonAccent btnCreate;
        private System.Windows.Forms.Label label1;
        private Templates.TextBox txtName;
    }
}