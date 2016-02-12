using AllAuth.Desktop.Forms.Templates;

namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class ServerManagementRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerManagementRegister));
            this.txtEmailAddress = new AllAuth.Desktop.Forms.Templates.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRecoveryPassphraseRepeat = new AllAuth.Desktop.Forms.Templates.TextBoxPassword();
            this.txtRecoveryPassphraseFirst = new AllAuth.Desktop.Forms.Templates.TextBoxPassword();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLoginLoading = new System.Windows.Forms.Label();
            this.btnRegister = new AllAuth.Desktop.Forms.Templates.ButtonAccent();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
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
            this.lblTitle.Size = new System.Drawing.Size(308, 41);
            this.lblTitle.Text = "Register a new account";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelFormContainer.Size = new System.Drawing.Size(732, 383);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.panel1);
            this.panelContentContainer.Controls.Add(this.panelSeparator);
            this.panelContentContainer.Controls.Add(this.panel2);
            this.panelContentContainer.Location = new System.Drawing.Point(4, 57);
            this.panelContentContainer.Size = new System.Drawing.Size(724, 321);
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtEmailAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtEmailAddress.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailAddress.Location = new System.Drawing.Point(12, 40);
            this.txtEmailAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txtEmailAddress.MultiLine = false;
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtEmailAddress.Readonly = false;
            this.txtEmailAddress.Size = new System.Drawing.Size(372, 42);
            this.txtEmailAddress.TabIndex = 0;
            this.txtEmailAddress.TextValue = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 98);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(213, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Database recovery passphrase";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Your email address";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtRecoveryPassphraseRepeat);
            this.panel1.Controls.Add(this.txtRecoveryPassphraseFirst);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lblLoginLoading);
            this.panel1.Controls.Add(this.btnRegister);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtEmailAddress);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 321);
            this.panel1.TabIndex = 4;
            // 
            // txtRecoveryPassphraseRepeat
            // 
            this.txtRecoveryPassphraseRepeat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtRecoveryPassphraseRepeat.BackColor = System.Drawing.Color.Transparent;
            this.txtRecoveryPassphraseRepeat.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecoveryPassphraseRepeat.Location = new System.Drawing.Point(14, 203);
            this.txtRecoveryPassphraseRepeat.Margin = new System.Windows.Forms.Padding(0);
            this.txtRecoveryPassphraseRepeat.MultiLine = false;
            this.txtRecoveryPassphraseRepeat.Name = "txtRecoveryPassphraseRepeat";
            this.txtRecoveryPassphraseRepeat.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtRecoveryPassphraseRepeat.Readonly = false;
            this.txtRecoveryPassphraseRepeat.Size = new System.Drawing.Size(370, 42);
            this.txtRecoveryPassphraseRepeat.TabIndex = 2;
            this.txtRecoveryPassphraseRepeat.TextValue = "";
            // 
            // txtRecoveryPassphraseFirst
            // 
            this.txtRecoveryPassphraseFirst.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtRecoveryPassphraseFirst.BackColor = System.Drawing.Color.Transparent;
            this.txtRecoveryPassphraseFirst.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecoveryPassphraseFirst.Location = new System.Drawing.Point(12, 123);
            this.txtRecoveryPassphraseFirst.Margin = new System.Windows.Forms.Padding(0);
            this.txtRecoveryPassphraseFirst.MultiLine = false;
            this.txtRecoveryPassphraseFirst.Name = "txtRecoveryPassphraseFirst";
            this.txtRecoveryPassphraseFirst.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtRecoveryPassphraseFirst.Readonly = false;
            this.txtRecoveryPassphraseFirst.Size = new System.Drawing.Size(372, 42);
            this.txtRecoveryPassphraseFirst.TabIndex = 1;
            this.txtRecoveryPassphraseFirst.TextValue = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 179);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.label4.Size = new System.Drawing.Size(197, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Repeat recovery passphrase";
            // 
            // lblLoginLoading
            // 
            this.lblLoginLoading.Image = global::AllAuth.Desktop.Properties.Resources.ajax_loader;
            this.lblLoginLoading.Location = new System.Drawing.Point(213, 264);
            this.lblLoginLoading.Name = "lblLoginLoading";
            this.lblLoginLoading.Size = new System.Drawing.Size(30, 30);
            this.lblLoginLoading.TabIndex = 5;
            this.lblLoginLoading.Visible = false;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(14, 258);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(0);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRegister.Size = new System.Drawing.Size(203, 43);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.TextValue = "Register";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(416, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(18, 20, 18, 20);
            this.panel2.Size = new System.Drawing.Size(308, 321);
            this.panel2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(18, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(272, 281);
            this.label3.TabIndex = 0;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // panelSeparator
            // 
            this.panelSeparator.BackColor = System.Drawing.Color.Gainsboro;
            this.panelSeparator.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSeparator.Location = new System.Drawing.Point(415, 0);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(1, 321);
            this.panelSeparator.TabIndex = 6;
            // 
            // ServerManagementRegister
            // 
            this.AcceptButton = this.btnRegister;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 383);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.Name = "ServerManagementRegister";
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
        private Templates.ButtonAccent btnRegister;
        private System.Windows.Forms.Label label2;
        private Templates.TextBox txtEmailAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLoginLoading;
        private TextBoxPassword txtRecoveryPassphraseRepeat;
        private TextBoxPassword txtRecoveryPassphraseFirst;
        private System.Windows.Forms.Label label4;
    }
}