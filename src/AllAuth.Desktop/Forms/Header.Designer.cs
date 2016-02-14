namespace AllAuth.Desktop.Forms
{
    partial class Header
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Header));
            this.panelTabsOuterContainer = new System.Windows.Forms.Panel();
            this.panelServerManagementInfo = new System.Windows.Forms.Panel();
            this.lblServerManagementInfo = new System.Windows.Forms.Label();
            this.panelDatabaseInfo = new System.Windows.Forms.Panel();
            this.lblDatabaseName = new System.Windows.Forms.Label();
            this.ctxAppOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpAndSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblOptionsMenu = new System.Windows.Forms.Label();
            this.lblLogo = new System.Windows.Forms.Label();
            this.changeRecoveryPassphraseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.panelTabsOuterContainer.SuspendLayout();
            this.panelServerManagementInfo.SuspendLayout();
            this.panelDatabaseInfo.SuspendLayout();
            this.ctxAppOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTabsOuterContainer
            // 
            this.panelTabsOuterContainer.Controls.Add(this.panelServerManagementInfo);
            this.panelTabsOuterContainer.Controls.Add(this.panelDatabaseInfo);
            this.panelTabsOuterContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabsOuterContainer.Location = new System.Drawing.Point(163, 0);
            this.panelTabsOuterContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panelTabsOuterContainer.Name = "panelTabsOuterContainer";
            this.panelTabsOuterContainer.Size = new System.Drawing.Size(567, 55);
            this.panelTabsOuterContainer.TabIndex = 2;
            // 
            // panelServerManagementInfo
            // 
            this.panelServerManagementInfo.Controls.Add(this.lblServerManagementInfo);
            this.panelServerManagementInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelServerManagementInfo.Location = new System.Drawing.Point(295, 0);
            this.panelServerManagementInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelServerManagementInfo.Name = "panelServerManagementInfo";
            this.panelServerManagementInfo.Size = new System.Drawing.Size(272, 55);
            this.panelServerManagementInfo.TabIndex = 1;
            // 
            // lblServerManagementInfo
            // 
            this.lblServerManagementInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServerManagementInfo.ForeColor = System.Drawing.Color.White;
            this.lblServerManagementInfo.Location = new System.Drawing.Point(0, 0);
            this.lblServerManagementInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerManagementInfo.Name = "lblServerManagementInfo";
            this.lblServerManagementInfo.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblServerManagementInfo.Size = new System.Drawing.Size(272, 55);
            this.lblServerManagementInfo.TabIndex = 0;
            this.lblServerManagementInfo.Text = "<ServerManagementLoginInfo>";
            this.lblServerManagementInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelDatabaseInfo
            // 
            this.panelDatabaseInfo.Controls.Add(this.lblDatabaseName);
            this.panelDatabaseInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDatabaseInfo.Location = new System.Drawing.Point(0, 0);
            this.panelDatabaseInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelDatabaseInfo.Name = "panelDatabaseInfo";
            this.panelDatabaseInfo.Size = new System.Drawing.Size(268, 55);
            this.panelDatabaseInfo.TabIndex = 0;
            // 
            // lblDatabaseName
            // 
            this.lblDatabaseName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDatabaseName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDatabaseName.ForeColor = System.Drawing.Color.White;
            this.lblDatabaseName.Location = new System.Drawing.Point(0, 0);
            this.lblDatabaseName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatabaseName.Name = "lblDatabaseName";
            this.lblDatabaseName.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.lblDatabaseName.Size = new System.Drawing.Size(268, 55);
            this.lblDatabaseName.TabIndex = 0;
            this.lblDatabaseName.Text = "<DatabaseName>";
            this.lblDatabaseName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDatabaseName.Click += new System.EventHandler(this.lblDatabaseName_Click);
            this.lblDatabaseName.MouseEnter += new System.EventHandler(this.lblDatabaseName_MouseEnter);
            this.lblDatabaseName.MouseLeave += new System.EventHandler(this.lblDatabaseName_MouseLeave);
            // 
            // ctxAppOptions
            // 
            this.ctxAppOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripSeparator3,
            this.toolsToolStripMenuItem,
            this.toolStripSeparator1,
            this.helpAndSupportToolStripMenuItem,
            this.abountToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.ctxAppOptions.Name = "ctxAppOptions";
            this.ctxAppOptions.Size = new System.Drawing.Size(168, 176);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.toolStripMenuItem1.Text = "Manage Account";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(167, 22);
            this.toolStripMenuItem2.Text = "Logout";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.toolStripSeparator4,
            this.changeRecoveryPassphraseToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(164, 6);
            // 
            // helpAndSupportToolStripMenuItem
            // 
            this.helpAndSupportToolStripMenuItem.Name = "helpAndSupportToolStripMenuItem";
            this.helpAndSupportToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.helpAndSupportToolStripMenuItem.Text = "Help and Support";
            this.helpAndSupportToolStripMenuItem.Click += new System.EventHandler(this.helpAndSupportToolStripMenuItem_Click);
            // 
            // abountToolStripMenuItem
            // 
            this.abountToolStripMenuItem.Name = "abountToolStripMenuItem";
            this.abountToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.abountToolStripMenuItem.Text = "About";
            this.abountToolStripMenuItem.Click += new System.EventHandler(this.abountToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(164, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // lblOptionsMenu
            // 
            this.lblOptionsMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOptionsMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblOptionsMenu.Image = ((System.Drawing.Image)(resources.GetObject("lblOptionsMenu.Image")));
            this.lblOptionsMenu.Location = new System.Drawing.Point(730, 0);
            this.lblOptionsMenu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOptionsMenu.Name = "lblOptionsMenu";
            this.lblOptionsMenu.Size = new System.Drawing.Size(68, 55);
            this.lblOptionsMenu.TabIndex = 1;
            this.lblOptionsMenu.Click += new System.EventHandler(this.lblOptionsMenu_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblLogo.Image = global::AllAuth.Desktop.Properties.Resources.Logo_Full_white_131x31;
            this.lblLogo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.lblLogo.Size = new System.Drawing.Size(163, 55);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogo.Click += new System.EventHandler(this.lblLogo_Click);
            // 
            // changeRecoveryPassphraseToolStripMenuItem
            // 
            this.changeRecoveryPassphraseToolStripMenuItem.Name = "changeRecoveryPassphraseToolStripMenuItem";
            this.changeRecoveryPassphraseToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.changeRecoveryPassphraseToolStripMenuItem.Text = "Change recovery passphrase";
            this.changeRecoveryPassphraseToolStripMenuItem.Click += new System.EventHandler(this.changeRecoveryPassphraseToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(221, 6);
            // 
            // Header
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(172)))), ((int)(((byte)(57)))));
            this.Controls.Add(this.panelTabsOuterContainer);
            this.Controls.Add(this.lblOptionsMenu);
            this.Controls.Add(this.lblLogo);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Header";
            this.Size = new System.Drawing.Size(798, 55);
            this.Load += new System.EventHandler(this.Header_Load);
            this.panelTabsOuterContainer.ResumeLayout(false);
            this.panelServerManagementInfo.ResumeLayout(false);
            this.panelDatabaseInfo.ResumeLayout(false);
            this.ctxAppOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblOptionsMenu;
        private System.Windows.Forms.Panel panelTabsOuterContainer;
        internal System.Windows.Forms.Label lblDatabaseName;
        internal System.Windows.Forms.Label lblServerManagementInfo;
        internal System.Windows.Forms.Panel panelDatabaseInfo;
        internal System.Windows.Forms.Panel panelServerManagementInfo;
        private System.Windows.Forms.ContextMenuStrip ctxAppOptions;
        private System.Windows.Forms.ToolStripMenuItem abountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem helpAndSupportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem changeRecoveryPassphraseToolStripMenuItem;
    }
}
