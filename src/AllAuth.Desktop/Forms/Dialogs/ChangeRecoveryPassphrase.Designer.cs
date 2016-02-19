namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class ChangeRecoveryPassphrase
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
            this.txtCurrentPassphrase = new AllAuth.Desktop.Forms.Templates.TextBoxPassword();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPassphrase = new AllAuth.Desktop.Forms.Templates.TextBoxPassword();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewPassphraseRepeat = new AllAuth.Desktop.Forms.Templates.TextBoxPassword();
            this.btnChangePassphrase = new AllAuth.Desktop.Forms.Templates.ButtonAccent();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLoading = new System.Windows.Forms.Label();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(8, 4);
            this.lblTitle.Size = new System.Drawing.Size(409, 41);
            this.lblTitle.Text = "Change recovery passphrase";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Padding = new System.Windows.Forms.Padding(5);
            this.panelFormContainer.Size = new System.Drawing.Size(704, 373);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.lblLoading);
            this.panelContentContainer.Controls.Add(this.panel1);
            this.panelContentContainer.Controls.Add(this.btnChangePassphrase);
            this.panelContentContainer.Controls.Add(this.label3);
            this.panelContentContainer.Controls.Add(this.txtNewPassphraseRepeat);
            this.panelContentContainer.Controls.Add(this.label2);
            this.panelContentContainer.Controls.Add(this.txtNewPassphrase);
            this.panelContentContainer.Controls.Add(this.label1);
            this.panelContentContainer.Controls.Add(this.txtCurrentPassphrase);
            this.panelContentContainer.Location = new System.Drawing.Point(5, 57);
            this.panelContentContainer.Size = new System.Drawing.Size(694, 311);
            // 
            // txtCurrentPassphrase
            // 
            this.txtCurrentPassphrase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtCurrentPassphrase.BackColor = System.Drawing.Color.Transparent;
            this.txtCurrentPassphrase.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentPassphrase.Location = new System.Drawing.Point(15, 45);
            this.txtCurrentPassphrase.Margin = new System.Windows.Forms.Padding(0);
            this.txtCurrentPassphrase.MultiLine = false;
            this.txtCurrentPassphrase.Name = "txtCurrentPassphrase";
            this.txtCurrentPassphrase.Padding = new System.Windows.Forms.Padding(5);
            this.txtCurrentPassphrase.Readonly = false;
            this.txtCurrentPassphrase.Size = new System.Drawing.Size(315, 42);
            this.txtCurrentPassphrase.TabIndex = 0;
            this.txtCurrentPassphrase.TextValue = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Current recovery passphrase";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "New passphrase";
            // 
            // txtNewPassphrase
            // 
            this.txtNewPassphrase.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtNewPassphrase.BackColor = System.Drawing.Color.Transparent;
            this.txtNewPassphrase.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassphrase.Location = new System.Drawing.Point(15, 119);
            this.txtNewPassphrase.Margin = new System.Windows.Forms.Padding(0);
            this.txtNewPassphrase.MultiLine = false;
            this.txtNewPassphrase.Name = "txtNewPassphrase";
            this.txtNewPassphrase.Padding = new System.Windows.Forms.Padding(5);
            this.txtNewPassphrase.Readonly = false;
            this.txtNewPassphrase.Size = new System.Drawing.Size(315, 42);
            this.txtNewPassphrase.TabIndex = 2;
            this.txtNewPassphrase.TextValue = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Repeat new passphrase";
            // 
            // txtNewPassphraseRepeat
            // 
            this.txtNewPassphraseRepeat.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtNewPassphraseRepeat.BackColor = System.Drawing.Color.Transparent;
            this.txtNewPassphraseRepeat.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPassphraseRepeat.Location = new System.Drawing.Point(15, 194);
            this.txtNewPassphraseRepeat.Margin = new System.Windows.Forms.Padding(0);
            this.txtNewPassphraseRepeat.MultiLine = false;
            this.txtNewPassphraseRepeat.Name = "txtNewPassphraseRepeat";
            this.txtNewPassphraseRepeat.Padding = new System.Windows.Forms.Padding(5);
            this.txtNewPassphraseRepeat.Readonly = false;
            this.txtNewPassphraseRepeat.Size = new System.Drawing.Size(315, 42);
            this.txtNewPassphraseRepeat.TabIndex = 4;
            this.txtNewPassphraseRepeat.TextValue = "";
            // 
            // btnChangePassphrase
            // 
            this.btnChangePassphrase.BackColor = System.Drawing.Color.Transparent;
            this.btnChangePassphrase.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnChangePassphrase.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangePassphrase.Location = new System.Drawing.Point(15, 252);
            this.btnChangePassphrase.Margin = new System.Windows.Forms.Padding(0);
            this.btnChangePassphrase.Name = "btnChangePassphrase";
            this.btnChangePassphrase.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnChangePassphrase.Size = new System.Drawing.Size(315, 43);
            this.btnChangePassphrase.TabIndex = 6;
            this.btnChangePassphrase.TextValue = "Update passphrase";
            this.btnChangePassphrase.Click += new System.EventHandler(this.btnChangePassphrase_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(364, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 311);
            this.panel1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(1, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(20);
            this.label4.Size = new System.Drawing.Size(329, 311);
            this.label4.TabIndex = 1;
            this.label4.Text = "Changing the recovery passphrase will invalidate your existing backup data.\r\n\r\nAf" +
    "ter changing the passphrase, you should wait until your account has completed sy" +
    "ncing before closing the app.";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 311);
            this.panel2.TabIndex = 0;
            // 
            // lblLoading
            // 
            this.lblLoading.Image = global::AllAuth.Desktop.Properties.Resources.ajax_loader;
            this.lblLoading.Location = new System.Drawing.Point(160, 260);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(26, 27);
            this.lblLoading.TabIndex = 2;
            this.lblLoading.Visible = false;
            // 
            // ChangeRecoveryPassphrase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(704, 373);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ChangeRecoveryPassphrase";
            this.Text = "Change Recovery Passphrase";
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panelContentContainer.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Templates.TextBoxPassword txtCurrentPassphrase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private Templates.ButtonAccent btnChangePassphrase;
        private System.Windows.Forms.Label label3;
        private Templates.TextBoxPassword txtNewPassphraseRepeat;
        private System.Windows.Forms.Label label2;
        private Templates.TextBoxPassword txtNewPassphrase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLoading;
    }
}