﻿using AllAuth.Desktop.Forms.Templates;

namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class ServerManagementLogin
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
            this.panelEmailPassword = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLogin = new AllAuth.Desktop.Forms.Templates.ButtonAccent();
            this.txtEmailAddress = new AllAuth.Desktop.Forms.Templates.TextBox();
            this.txtRecoveryPassword = new AllAuth.Desktop.Forms.Templates.TextBoxPassword();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.panelEmailPassword.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(84, 19);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(36, 0, 36, 0);
            this.lblTitle.Size = new System.Drawing.Size(426, 41);
            this.lblTitle.Text = "Log in to your AllAuth account";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Padding = new System.Windows.Forms.Padding(72, 24, 72, 24);
            this.panelFormContainer.Size = new System.Drawing.Size(6336, 998);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.panelEmailPassword);
            this.panelContentContainer.Location = new System.Drawing.Point(72, 76);
            this.panelContentContainer.Margin = new System.Windows.Forms.Padding(36, 14, 36, 14);
            this.panelContentContainer.Padding = new System.Windows.Forms.Padding(120, 48, 120, 48);
            this.panelContentContainer.Size = new System.Drawing.Size(6192, 898);
            // 
            // panelEmailPassword
            // 
            this.panelEmailPassword.AutoSize = true;
            this.panelEmailPassword.BackColor = System.Drawing.Color.White;
            this.panelEmailPassword.Controls.Add(this.tableLayoutPanel1);
            this.panelEmailPassword.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEmailPassword.Location = new System.Drawing.Point(120, 48);
            this.panelEmailPassword.Margin = new System.Windows.Forms.Padding(36, 14, 36, 14);
            this.panelEmailPassword.Name = "panelEmailPassword";
            this.panelEmailPassword.Size = new System.Drawing.Size(5952, 642);
            this.panelEmailPassword.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnLogin, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtEmailAddress, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtRecoveryPassword, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(132, 14);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(36, 14, 36, 14);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(5916, 614);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(36, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(36, 0, 36, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 202);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email address";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semilight", 12F);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(36, 202);
            this.label6.Margin = new System.Windows.Forms.Padding(36, 0, 36, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 202);
            this.label6.TabIndex = 6;
            this.label6.Text = "Recovery passphrase";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(224, 404);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(0);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Padding = new System.Windows.Forms.Padding(60, 24, 60, 24);
            this.btnLogin.Size = new System.Drawing.Size(2316, 202);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.TextValue = "Log in";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtEmailAddress
            // 
            this.txtEmailAddress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtEmailAddress.BackColor = System.Drawing.Color.Transparent;
            this.txtEmailAddress.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailAddress.Location = new System.Drawing.Point(224, 0);
            this.txtEmailAddress.Margin = new System.Windows.Forms.Padding(0);
            this.txtEmailAddress.MultiLine = false;
            this.txtEmailAddress.Name = "txtEmailAddress";
            this.txtEmailAddress.Padding = new System.Windows.Forms.Padding(60, 24, 60, 24);
            this.txtEmailAddress.Readonly = false;
            this.txtEmailAddress.Size = new System.Drawing.Size(4020, 202);
            this.txtEmailAddress.TabIndex = 8;
            this.txtEmailAddress.TextValue = "";
            // 
            // txtRecoveryPassword
            // 
            this.txtRecoveryPassword.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtRecoveryPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtRecoveryPassword.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecoveryPassword.Location = new System.Drawing.Point(224, 202);
            this.txtRecoveryPassword.Margin = new System.Windows.Forms.Padding(0);
            this.txtRecoveryPassword.MultiLine = false;
            this.txtRecoveryPassword.Name = "txtRecoveryPassword";
            this.txtRecoveryPassword.Padding = new System.Windows.Forms.Padding(60, 24, 60, 24);
            this.txtRecoveryPassword.Readonly = false;
            this.txtRecoveryPassword.Size = new System.Drawing.Size(4020, 202);
            this.txtRecoveryPassword.TabIndex = 9;
            this.txtRecoveryPassword.TextValue = "";
            // 
            // ServerManagementLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.ClientSize = new System.Drawing.Size(1596, 873);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(48, 24, 48, 24);
            this.Name = "ServerManagementLogin";
            this.Text = "Log in";
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panelContentContainer.PerformLayout();
            this.panelEmailPassword.ResumeLayout(false);
            this.panelEmailPassword.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelEmailPassword;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private Templates.ButtonAccent btnLogin;
        private Templates.TextBox txtEmailAddress;
        private Templates.TextBoxPassword txtRecoveryPassword;
        private System.Windows.Forms.Label label6;
    }
}