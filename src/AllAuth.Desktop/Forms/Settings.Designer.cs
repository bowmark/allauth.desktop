using AllAuth.Desktop.Forms.Templates;

namespace AllAuth.Desktop.Forms
{
    partial class Settings
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
            this.listCustomServers = new DropDownList();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddCustomServer = new ButtonAccent();
            this.btnRemoveCustomServer = new ButtonAccent();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(122, 39);
            this.lblTitle.Text = "Settings";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Size = new System.Drawing.Size(402, 214);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.btnRemoveCustomServer);
            this.panelContentContainer.Controls.Add(this.btnAddCustomServer);
            this.panelContentContainer.Controls.Add(this.label1);
            this.panelContentContainer.Controls.Add(this.listCustomServers);
            this.panelContentContainer.Size = new System.Drawing.Size(390, 152);
            // 
            // listCustomServers
            // 
            this.listCustomServers.BackColor = System.Drawing.Color.Transparent;
            this.listCustomServers.DataSource = null;
            this.listCustomServers.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listCustomServers.Location = new System.Drawing.Point(16, 43);
            this.listCustomServers.Margin = new System.Windows.Forms.Padding(0);
            this.listCustomServers.Name = "listCustomServers";
            this.listCustomServers.Padding = new System.Windows.Forms.Padding(5);
            this.listCustomServers.Size = new System.Drawing.Size(356, 42);
            this.listCustomServers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Custom AllAuth servers";
            // 
            // btnAddCustomServer
            // 
            this.btnAddCustomServer.BackColor = System.Drawing.Color.Transparent;
            this.btnAddCustomServer.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAddCustomServer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomServer.Location = new System.Drawing.Point(16, 85);
            this.btnAddCustomServer.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddCustomServer.Name = "btnAddCustomServer";
            this.btnAddCustomServer.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddCustomServer.Size = new System.Drawing.Size(174, 43);
            this.btnAddCustomServer.TabIndex = 2;
            this.btnAddCustomServer.TextValue = "Add new server";
            this.btnAddCustomServer.Click += new System.EventHandler(this.btnAddCustomServer_Click);
            // 
            // btnRemoveCustomServer
            // 
            this.btnRemoveCustomServer.BackColor = System.Drawing.Color.Transparent;
            this.btnRemoveCustomServer.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnRemoveCustomServer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveCustomServer.Location = new System.Drawing.Point(200, 85);
            this.btnRemoveCustomServer.Margin = new System.Windows.Forms.Padding(0);
            this.btnRemoveCustomServer.Name = "btnRemoveCustomServer";
            this.btnRemoveCustomServer.Padding = new System.Windows.Forms.Padding(5);
            this.btnRemoveCustomServer.Size = new System.Drawing.Size(172, 43);
            this.btnRemoveCustomServer.TabIndex = 2;
            this.btnRemoveCustomServer.TextValue = "Remove selected";
            this.btnRemoveCustomServer.Click += new System.EventHandler(this.btnRemoveCustomServer_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 214);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panelContentContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Templates.DropDownList listCustomServers;
        private Templates.ButtonAccent btnRemoveCustomServer;
        private Templates.ButtonAccent btnAddCustomServer;
        private System.Windows.Forms.Label label1;
    }
}