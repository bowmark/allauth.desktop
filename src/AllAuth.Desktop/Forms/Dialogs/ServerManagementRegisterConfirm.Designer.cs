using AllAuth.Desktop.Forms.Templates;

namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class ServerManagementRegisterConfirm
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
            this.txtEmailCode = new AllAuth.Desktop.Forms.Templates.TextBox();
            this.lblConfirmCode = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLoading = new System.Windows.Forms.Label();
            this.btnComplete = new AllAuth.Desktop.Forms.Templates.ButtonAccent();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblHelp = new System.Windows.Forms.Label();
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(7, 4);
            this.lblTitle.Size = new System.Drawing.Size(309, 41);
            this.lblTitle.Text = "Account confirmation";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelFormContainer.Size = new System.Drawing.Size(626, 219);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.panel1);
            this.panelContentContainer.Controls.Add(this.panelSeparator);
            this.panelContentContainer.Controls.Add(this.panel2);
            this.panelContentContainer.Location = new System.Drawing.Point(4, 57);
            this.panelContentContainer.Size = new System.Drawing.Size(618, 157);
            // 
            // txtEmailCode
            // 
            this.txtEmailCode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtEmailCode.BackColor = System.Drawing.Color.Transparent;
            this.txtEmailCode.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailCode.Location = new System.Drawing.Point(22, 45);
            this.txtEmailCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtEmailCode.MultiLine = false;
            this.txtEmailCode.Name = "txtEmailCode";
            this.txtEmailCode.Padding = new System.Windows.Forms.Padding(5);
            this.txtEmailCode.Readonly = false;
            this.txtEmailCode.Size = new System.Drawing.Size(203, 42);
            this.txtEmailCode.TabIndex = 0;
            this.txtEmailCode.TextValue = "";
            // 
            // lblConfirmCode
            // 
            this.lblConfirmCode.AutoSize = true;
            this.lblConfirmCode.Location = new System.Drawing.Point(24, 20);
            this.lblConfirmCode.Name = "lblConfirmCode";
            this.lblConfirmCode.Size = new System.Drawing.Size(133, 20);
            this.lblConfirmCode.TabIndex = 3;
            this.lblConfirmCode.Text = "Confirmation code";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLoading);
            this.panel1.Controls.Add(this.btnComplete);
            this.panel1.Controls.Add(this.lblConfirmCode);
            this.panel1.Controls.Add(this.txtEmailCode);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 157);
            this.panel1.TabIndex = 4;
            // 
            // lblLoading
            // 
            this.lblLoading.Image = global::AllAuth.Desktop.Properties.Resources.ajax_loader;
            this.lblLoading.Location = new System.Drawing.Point(222, 108);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(30, 30);
            this.lblLoading.TabIndex = 5;
            this.lblLoading.Visible = false;
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.Color.Transparent;
            this.btnComplete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnComplete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComplete.Location = new System.Drawing.Point(22, 101);
            this.btnComplete.Margin = new System.Windows.Forms.Padding(0);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnComplete.Size = new System.Drawing.Size(203, 43);
            this.btnComplete.TabIndex = 4;
            this.btnComplete.TextValue = "Complete registration";
            this.btnComplete.Click += new System.EventHandler(this.btnComplete_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblHelp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(282, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(18, 20, 18, 20);
            this.panel2.Size = new System.Drawing.Size(336, 157);
            this.panel2.TabIndex = 5;
            // 
            // lblHelp
            // 
            this.lblHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHelp.Location = new System.Drawing.Point(18, 20);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.Size = new System.Drawing.Size(300, 117);
            this.lblHelp.TabIndex = 0;
            this.lblHelp.Text = "You have mail! Please enter the code within the email you should shortly receive " +
    "from us.";
            // 
            // panelSeparator
            // 
            this.panelSeparator.BackColor = System.Drawing.Color.Gainsboro;
            this.panelSeparator.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSeparator.Location = new System.Drawing.Point(281, 0);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(1, 157);
            this.panelSeparator.TabIndex = 6;
            // 
            // ServerManagementRegisterConfirm
            // 
            this.AcceptButton = this.btnComplete;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(626, 219);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "ServerManagementRegisterConfirm";
            this.Text = "Register";
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Templates.ButtonAccent btnComplete;
        private System.Windows.Forms.Label lblConfirmCode;
        private Templates.TextBox txtEmailCode;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblHelp;
        private System.Windows.Forms.Label lblLoading;
    }
}