namespace AllAuth.Desktop.Forms
{
    partial class HomePageServer
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
            this.ctxServerOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.recoverPhoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelControlBorder = new System.Windows.Forms.Panel();
            this.panelControlContent = new System.Windows.Forms.Panel();
            this.panelDatabasesContainer = new System.Windows.Forms.Panel();
            this.panelVerifyDeviceKeys = new System.Windows.Forms.Panel();
            this.lblVerifyDeviceKeys = new System.Windows.Forms.Label();
            this.panelSecondDeviceNotLinked = new System.Windows.Forms.Panel();
            this.lblSecondDeviceNotLinked = new System.Windows.Forms.Label();
            this.panelSeparator = new System.Windows.Forms.Panel();
            this.panelHeaderBottom = new System.Windows.Forms.Panel();
            this.lblEmailAddress = new System.Windows.Forms.Label();
            this.panelHeaderTop = new System.Windows.Forms.Panel();
            this.panelServerNameContainer = new System.Windows.Forms.Panel();
            this.lblServerName = new System.Windows.Forms.Label();
            this.lblServerOptions = new System.Windows.Forms.Label();
            this.ctxServerOptions.SuspendLayout();
            this.panelControlBorder.SuspendLayout();
            this.panelControlContent.SuspendLayout();
            this.panelVerifyDeviceKeys.SuspendLayout();
            this.panelSecondDeviceNotLinked.SuspendLayout();
            this.panelHeaderBottom.SuspendLayout();
            this.panelHeaderTop.SuspendLayout();
            this.panelServerNameContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctxServerOptions
            // 
            this.ctxServerOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recoverPhoneToolStripMenuItem});
            this.ctxServerOptions.Name = "ctxServerOptions";
            this.ctxServerOptions.ShowImageMargin = false;
            this.ctxServerOptions.Size = new System.Drawing.Size(129, 48);
            // 
            // recoverPhoneToolStripMenuItem
            // 
            this.recoverPhoneToolStripMenuItem.Name = "recoverPhoneToolStripMenuItem";
            this.recoverPhoneToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.recoverPhoneToolStripMenuItem.Text = "Recover Phone";
            this.recoverPhoneToolStripMenuItem.Click += new System.EventHandler(this.recoverPhoneToolStripMenuItem_Click);
            // 
            // panelControlBorder
            // 
            this.panelControlBorder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControlBorder.BackColor = System.Drawing.Color.Gainsboro;
            this.panelControlBorder.Controls.Add(this.panelControlContent);
            this.panelControlBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlBorder.Location = new System.Drawing.Point(0, 0);
            this.panelControlBorder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelControlBorder.Name = "panelControlBorder";
            this.panelControlBorder.Padding = new System.Windows.Forms.Padding(1);
            this.panelControlBorder.Size = new System.Drawing.Size(763, 243);
            this.panelControlBorder.TabIndex = 0;
            // 
            // panelControlContent
            // 
            this.panelControlContent.AutoSize = true;
            this.panelControlContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelControlContent.BackColor = System.Drawing.Color.White;
            this.panelControlContent.Controls.Add(this.panelDatabasesContainer);
            this.panelControlContent.Controls.Add(this.panelVerifyDeviceKeys);
            this.panelControlContent.Controls.Add(this.panelSecondDeviceNotLinked);
            this.panelControlContent.Controls.Add(this.panelSeparator);
            this.panelControlContent.Controls.Add(this.panelHeaderBottom);
            this.panelControlContent.Controls.Add(this.panelHeaderTop);
            this.panelControlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControlContent.Location = new System.Drawing.Point(1, 1);
            this.panelControlContent.Margin = new System.Windows.Forms.Padding(0);
            this.panelControlContent.Name = "panelControlContent";
            this.panelControlContent.Size = new System.Drawing.Size(761, 241);
            this.panelControlContent.TabIndex = 0;
            // 
            // panelDatabasesContainer
            // 
            this.panelDatabasesContainer.AutoSize = true;
            this.panelDatabasesContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelDatabasesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatabasesContainer.Location = new System.Drawing.Point(0, 149);
            this.panelDatabasesContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panelDatabasesContainer.Name = "panelDatabasesContainer";
            this.panelDatabasesContainer.Size = new System.Drawing.Size(761, 92);
            this.panelDatabasesContainer.TabIndex = 3;
            // 
            // panelVerifyDeviceKeys
            // 
            this.panelVerifyDeviceKeys.Controls.Add(this.lblVerifyDeviceKeys);
            this.panelVerifyDeviceKeys.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelVerifyDeviceKeys.Location = new System.Drawing.Point(0, 114);
            this.panelVerifyDeviceKeys.Margin = new System.Windows.Forms.Padding(0);
            this.panelVerifyDeviceKeys.Name = "panelVerifyDeviceKeys";
            this.panelVerifyDeviceKeys.Size = new System.Drawing.Size(761, 35);
            this.panelVerifyDeviceKeys.TabIndex = 4;
            this.panelVerifyDeviceKeys.Visible = false;
            // 
            // lblVerifyDeviceKeys
            // 
            this.lblVerifyDeviceKeys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.lblVerifyDeviceKeys.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblVerifyDeviceKeys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblVerifyDeviceKeys.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.lblVerifyDeviceKeys.Location = new System.Drawing.Point(0, 0);
            this.lblVerifyDeviceKeys.Name = "lblVerifyDeviceKeys";
            this.lblVerifyDeviceKeys.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblVerifyDeviceKeys.Size = new System.Drawing.Size(761, 35);
            this.lblVerifyDeviceKeys.TabIndex = 0;
            this.lblVerifyDeviceKeys.Text = "To communicate securely with your phone, you need to verify it. Click here to do " +
    "this now.";
            this.lblVerifyDeviceKeys.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVerifyDeviceKeys.Click += new System.EventHandler(this.lblVerifyDeviceKeys_Click);
            // 
            // panelSecondDeviceNotLinked
            // 
            this.panelSecondDeviceNotLinked.Controls.Add(this.lblSecondDeviceNotLinked);
            this.panelSecondDeviceNotLinked.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSecondDeviceNotLinked.Location = new System.Drawing.Point(0, 79);
            this.panelSecondDeviceNotLinked.Margin = new System.Windows.Forms.Padding(0);
            this.panelSecondDeviceNotLinked.Name = "panelSecondDeviceNotLinked";
            this.panelSecondDeviceNotLinked.Size = new System.Drawing.Size(761, 35);
            this.panelSecondDeviceNotLinked.TabIndex = 0;
            this.panelSecondDeviceNotLinked.Visible = false;
            // 
            // lblSecondDeviceNotLinked
            // 
            this.lblSecondDeviceNotLinked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(222)))), ((int)(((byte)(222)))));
            this.lblSecondDeviceNotLinked.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSecondDeviceNotLinked.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSecondDeviceNotLinked.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(68)))), ((int)(((byte)(66)))));
            this.lblSecondDeviceNotLinked.Location = new System.Drawing.Point(0, 0);
            this.lblSecondDeviceNotLinked.Margin = new System.Windows.Forms.Padding(0);
            this.lblSecondDeviceNotLinked.Name = "lblSecondDeviceNotLinked";
            this.lblSecondDeviceNotLinked.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblSecondDeviceNotLinked.Size = new System.Drawing.Size(761, 35);
            this.lblSecondDeviceNotLinked.TabIndex = 0;
            this.lblSecondDeviceNotLinked.Text = "You have not yet linked your phone with this account. Click here to do this now.";
            this.lblSecondDeviceNotLinked.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSecondDeviceNotLinked.Click += new System.EventHandler(this.lblSecondDeviceNotLinked_Click);
            // 
            // panelSeparator
            // 
            this.panelSeparator.BackColor = System.Drawing.Color.Gainsboro;
            this.panelSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeparator.Location = new System.Drawing.Point(0, 78);
            this.panelSeparator.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(761, 1);
            this.panelSeparator.TabIndex = 1;
            // 
            // panelHeaderBottom
            // 
            this.panelHeaderBottom.Controls.Add(this.lblEmailAddress);
            this.panelHeaderBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderBottom.Location = new System.Drawing.Point(0, 46);
            this.panelHeaderBottom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelHeaderBottom.Name = "panelHeaderBottom";
            this.panelHeaderBottom.Size = new System.Drawing.Size(761, 32);
            this.panelHeaderBottom.TabIndex = 2;
            // 
            // lblEmailAddress
            // 
            this.lblEmailAddress.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblEmailAddress.ForeColor = System.Drawing.Color.DimGray;
            this.lblEmailAddress.Location = new System.Drawing.Point(0, 0);
            this.lblEmailAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmailAddress.Name = "lblEmailAddress";
            this.lblEmailAddress.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.lblEmailAddress.Size = new System.Drawing.Size(478, 32);
            this.lblEmailAddress.TabIndex = 0;
            this.lblEmailAddress.Text = "<ServerEmailAddress>";
            // 
            // panelHeaderTop
            // 
            this.panelHeaderTop.Controls.Add(this.panelServerNameContainer);
            this.panelHeaderTop.Controls.Add(this.lblServerOptions);
            this.panelHeaderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderTop.Location = new System.Drawing.Point(0, 0);
            this.panelHeaderTop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelHeaderTop.Name = "panelHeaderTop";
            this.panelHeaderTop.Size = new System.Drawing.Size(761, 46);
            this.panelHeaderTop.TabIndex = 0;
            // 
            // panelServerNameContainer
            // 
            this.panelServerNameContainer.Controls.Add(this.lblServerName);
            this.panelServerNameContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelServerNameContainer.Location = new System.Drawing.Point(0, 0);
            this.panelServerNameContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelServerNameContainer.Name = "panelServerNameContainer";
            this.panelServerNameContainer.Size = new System.Drawing.Size(669, 46);
            this.panelServerNameContainer.TabIndex = 0;
            // 
            // lblServerName
            // 
            this.lblServerName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblServerName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerName.ForeColor = System.Drawing.Color.Black;
            this.lblServerName.Location = new System.Drawing.Point(0, 0);
            this.lblServerName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblServerName.Name = "lblServerName";
            this.lblServerName.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblServerName.Size = new System.Drawing.Size(669, 46);
            this.lblServerName.TabIndex = 0;
            this.lblServerName.Text = "<ServerName>";
            this.lblServerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblServerOptions
            // 
            this.lblServerOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblServerOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblServerOptions.Image = global::AllAuth.Desktop.Properties.Resources.show8;
            this.lblServerOptions.Location = new System.Drawing.Point(711, 0);
            this.lblServerOptions.Name = "lblServerOptions";
            this.lblServerOptions.Size = new System.Drawing.Size(50, 46);
            this.lblServerOptions.TabIndex = 1;
            this.lblServerOptions.Click += new System.EventHandler(this.lblServerOptions_Click);
            // 
            // HomePageServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelControlBorder);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "HomePageServer";
            this.Size = new System.Drawing.Size(763, 243);
            this.ctxServerOptions.ResumeLayout(false);
            this.panelControlBorder.ResumeLayout(false);
            this.panelControlBorder.PerformLayout();
            this.panelControlContent.ResumeLayout(false);
            this.panelControlContent.PerformLayout();
            this.panelVerifyDeviceKeys.ResumeLayout(false);
            this.panelSecondDeviceNotLinked.ResumeLayout(false);
            this.panelHeaderBottom.ResumeLayout(false);
            this.panelHeaderTop.ResumeLayout(false);
            this.panelServerNameContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelControlBorder;
        private System.Windows.Forms.Panel panelControlContent;
        private System.Windows.Forms.Panel panelServerNameContainer;
        internal System.Windows.Forms.Panel panelDatabasesContainer;
        internal System.Windows.Forms.Label lblEmailAddress;
        internal System.Windows.Forms.Label lblServerName;
        internal System.Windows.Forms.Panel panelSeparator;
        internal System.Windows.Forms.Panel panelHeaderTop;
        internal System.Windows.Forms.Panel panelHeaderBottom;
        private System.Windows.Forms.Panel panelSecondDeviceNotLinked;
        private System.Windows.Forms.Label lblSecondDeviceNotLinked;
        private System.Windows.Forms.Panel panelVerifyDeviceKeys;
        private System.Windows.Forms.Label lblVerifyDeviceKeys;
        private System.Windows.Forms.Label lblServerOptions;
        private System.Windows.Forms.ContextMenuStrip ctxServerOptions;
        private System.Windows.Forms.ToolStripMenuItem recoverPhoneToolStripMenuItem;
    }
}
