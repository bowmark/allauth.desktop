using AllAuth.Desktop.Forms.Templates;

namespace AllAuth.Desktop.Forms
{
    partial class DatabaseViewEntryWebsite
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
            this.panelContents = new System.Windows.Forms.Panel();
            this.tableEntryContainer = new System.Windows.Forms.TableLayoutPanel();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.tablePasswordContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tableUsernameContainer = new System.Windows.Forms.TableLayoutPanel();
            this.txtUsername = new TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtUrl = new TextBox();
            this.panelTitleOuterContainer = new System.Windows.Forms.Panel();
            this.panelTitleContainer = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSaveDisabled = new ButtonDisabled();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panelSaveBtn = new System.Windows.Forms.Panel();
            this.lblCopyPassword = new System.Windows.Forms.Label();
            this.lblGeneratePassword = new System.Windows.Forms.Label();
            this.lblCopyUsername = new System.Windows.Forms.Label();
            this.lblOpenURL = new System.Windows.Forms.Label();
            this.lblDelete = new System.Windows.Forms.Label();
            this.panelContents.SuspendLayout();
            this.tableEntryContainer.SuspendLayout();
            this.tablePasswordContainer.SuspendLayout();
            this.tableUsernameContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelTitleOuterContainer.SuspendLayout();
            this.panelTitleContainer.SuspendLayout();
            this.panelFooter.SuspendLayout();
            this.panelSaveBtn.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContents
            // 
            this.panelContents.Controls.Add(this.tableEntryContainer);
            this.panelContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContents.Location = new System.Drawing.Point(0, 51);
            this.panelContents.Name = "panelContents";
            this.panelContents.Padding = new System.Windows.Forms.Padding(18, 10, 18, 20);
            this.panelContents.Size = new System.Drawing.Size(410, 313);
            this.panelContents.TabIndex = 11;
            // 
            // tableEntryContainer
            // 
            this.tableEntryContainer.ColumnCount = 2;
            this.tableEntryContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 89F));
            this.tableEntryContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableEntryContainer.Controls.Add(this.lblPassword, 0, 1);
            this.tableEntryContainer.Controls.Add(this.lblUrl, 0, 2);
            this.tableEntryContainer.Controls.Add(this.lblNotes, 0, 3);
            this.tableEntryContainer.Controls.Add(this.txtNotes, 1, 3);
            this.tableEntryContainer.Controls.Add(this.lblUsername, 0, 0);
            this.tableEntryContainer.Controls.Add(this.tablePasswordContainer, 1, 1);
            this.tableEntryContainer.Controls.Add(this.tableUsernameContainer, 1, 0);
            this.tableEntryContainer.Controls.Add(this.tableLayoutPanel1, 1, 2);
            this.tableEntryContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableEntryContainer.Location = new System.Drawing.Point(18, 10);
            this.tableEntryContainer.Margin = new System.Windows.Forms.Padding(0);
            this.tableEntryContainer.Name = "tableEntryContainer";
            this.tableEntryContainer.RowCount = 4;
            this.tableEntryContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableEntryContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableEntryContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableEntryContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableEntryContainer.Size = new System.Drawing.Size(374, 283);
            this.tableEntryContainer.TabIndex = 10;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPassword.Location = new System.Drawing.Point(4, 42);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(81, 42);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUrl.Location = new System.Drawing.Point(4, 84);
            this.lblUrl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(81, 42);
            this.lblUrl.TabIndex = 1;
            this.lblUrl.Text = "URL";
            this.lblUrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNotes.Location = new System.Drawing.Point(4, 126);
            this.lblNotes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblNotes.Size = new System.Drawing.Size(81, 157);
            this.lblNotes.TabIndex = 1;
            this.lblNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtNotes.BackColor = System.Drawing.Color.Transparent;
            this.txtNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNotes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(89, 126);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(0);
            this.txtNotes.MultiLine = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtNotes.Readonly = false;
            this.txtNotes.Size = new System.Drawing.Size(285, 157);
            this.txtNotes.TabIndex = 3;
            this.txtNotes.TextValue = "";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsername.Location = new System.Drawing.Point(3, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(83, 42);
            this.lblUsername.TabIndex = 9;
            this.lblUsername.Text = "Username";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tablePasswordContainer
            // 
            this.tablePasswordContainer.ColumnCount = 3;
            this.tablePasswordContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePasswordContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tablePasswordContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tablePasswordContainer.Controls.Add(this.lblCopyPassword, 2, 0);
            this.tablePasswordContainer.Controls.Add(this.lblGeneratePassword, 1, 0);
            this.tablePasswordContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePasswordContainer.Location = new System.Drawing.Point(89, 42);
            this.tablePasswordContainer.Margin = new System.Windows.Forms.Padding(0);
            this.tablePasswordContainer.Name = "tablePasswordContainer";
            this.tablePasswordContainer.RowCount = 1;
            this.tablePasswordContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePasswordContainer.Size = new System.Drawing.Size(285, 42);
            this.tablePasswordContainer.TabIndex = 1;
            // 
            // tableUsernameContainer
            // 
            this.tableUsernameContainer.ColumnCount = 2;
            this.tableUsernameContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableUsernameContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableUsernameContainer.Controls.Add(this.lblCopyUsername, 1, 0);
            this.tableUsernameContainer.Controls.Add(this.txtUsername, 0, 0);
            this.tableUsernameContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableUsernameContainer.Location = new System.Drawing.Point(89, 0);
            this.tableUsernameContainer.Margin = new System.Windows.Forms.Padding(0);
            this.tableUsernameContainer.Name = "tableUsernameContainer";
            this.tableUsernameContainer.RowCount = 1;
            this.tableUsernameContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableUsernameContainer.Size = new System.Drawing.Size(285, 42);
            this.tableUsernameContainer.TabIndex = 0;
            // 
            // txtUsername
            // 
            this.txtUsername.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(0, 0);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(0);
            this.txtUsername.MultiLine = false;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtUsername.Readonly = false;
            this.txtUsername.Size = new System.Drawing.Size(249, 42);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.TextValue = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel1.Controls.Add(this.lblOpenURL, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtUrl, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(89, 84);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(285, 42);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // txtUrl
            // 
            this.txtUrl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtUrl.BackColor = System.Drawing.Color.Transparent;
            this.txtUrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUrl.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.Location = new System.Drawing.Point(0, 0);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(0);
            this.txtUrl.MultiLine = false;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.txtUrl.Readonly = false;
            this.txtUrl.Size = new System.Drawing.Size(249, 42);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.TextValue = "";
            // 
            // panelTitleOuterContainer
            // 
            this.panelTitleOuterContainer.Controls.Add(this.panelTitleContainer);
            this.panelTitleOuterContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleOuterContainer.Location = new System.Drawing.Point(0, 0);
            this.panelTitleOuterContainer.Name = "panelTitleOuterContainer";
            this.panelTitleOuterContainer.Padding = new System.Windows.Forms.Padding(10, 5, 5, 5);
            this.panelTitleOuterContainer.Size = new System.Drawing.Size(410, 51);
            this.panelTitleOuterContainer.TabIndex = 9;
            // 
            // panelTitleContainer
            // 
            this.panelTitleContainer.Controls.Add(this.lblTitle);
            this.panelTitleContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTitleContainer.Location = new System.Drawing.Point(10, 5);
            this.panelTitleContainer.Name = "panelTitleContainer";
            this.panelTitleContainer.Size = new System.Drawing.Size(395, 41);
            this.panelTitleContainer.TabIndex = 5;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Open Sans Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(395, 41);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "New Entry";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSaveDisabled
            // 
            this.btnSaveDisabled.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveDisabled.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSaveDisabled.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSaveDisabled.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDisabled.Location = new System.Drawing.Point(5, 5);
            this.btnSaveDisabled.Margin = new System.Windows.Forms.Padding(0);
            this.btnSaveDisabled.Name = "btnSaveDisabled";
            this.btnSaveDisabled.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSaveDisabled.Size = new System.Drawing.Size(152, 42);
            this.btnSaveDisabled.TabIndex = 4;
            this.btnSaveDisabled.TextValue = "Save";
            // 
            // toolTip2
            // 
            this.toolTip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            this.toolTip2.ForeColor = System.Drawing.Color.White;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panelFooter.Controls.Add(this.lblDelete);
            this.panelFooter.Controls.Add(this.panelSaveBtn);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 364);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(410, 52);
            this.panelFooter.TabIndex = 12;
            // 
            // panelSaveBtn
            // 
            this.panelSaveBtn.Controls.Add(this.btnSaveDisabled);
            this.panelSaveBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelSaveBtn.Location = new System.Drawing.Point(248, 0);
            this.panelSaveBtn.Name = "panelSaveBtn";
            this.panelSaveBtn.Padding = new System.Windows.Forms.Padding(5);
            this.panelSaveBtn.Size = new System.Drawing.Size(162, 52);
            this.panelSaveBtn.TabIndex = 6;
            // 
            // lblCopyPassword
            // 
            this.lblCopyPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCopyPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCopyPassword.Image = global::AllAuth.Desktop.Properties.Resources.paper42_green_16px;
            this.lblCopyPassword.Location = new System.Drawing.Point(252, 0);
            this.lblCopyPassword.Name = "lblCopyPassword";
            this.lblCopyPassword.Size = new System.Drawing.Size(30, 42);
            this.lblCopyPassword.TabIndex = 9;
            this.lblCopyPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblCopyPassword, "Copy password to clipboard");
            this.lblCopyPassword.Click += new System.EventHandler(this.lblCopyPassword_Click);
            // 
            // lblGeneratePassword
            // 
            this.lblGeneratePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGeneratePassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGeneratePassword.Image = global::AllAuth.Desktop.Properties.Resources.reload18_green_16px;
            this.lblGeneratePassword.Location = new System.Drawing.Point(216, 0);
            this.lblGeneratePassword.Name = "lblGeneratePassword";
            this.lblGeneratePassword.Size = new System.Drawing.Size(30, 42);
            this.lblGeneratePassword.TabIndex = 10;
            this.toolTip1.SetToolTip(this.lblGeneratePassword, "Generate new password");
            this.lblGeneratePassword.Click += new System.EventHandler(this.lblGeneratePassword_Click);
            // 
            // lblCopyUsername
            // 
            this.lblCopyUsername.AutoSize = true;
            this.lblCopyUsername.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCopyUsername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCopyUsername.Image = global::AllAuth.Desktop.Properties.Resources.paper42_green_16px;
            this.lblCopyUsername.Location = new System.Drawing.Point(252, 0);
            this.lblCopyUsername.Name = "lblCopyUsername";
            this.lblCopyUsername.Size = new System.Drawing.Size(30, 42);
            this.lblCopyUsername.TabIndex = 10;
            this.lblCopyUsername.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblCopyUsername, "Copy username to clipboard");
            this.lblCopyUsername.Click += new System.EventHandler(this.lblCopyUsername_Click);
            // 
            // lblOpenURL
            // 
            this.lblOpenURL.AutoSize = true;
            this.lblOpenURL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOpenURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOpenURL.Image = global::AllAuth.Desktop.Properties.Resources.global50_green_16px;
            this.lblOpenURL.Location = new System.Drawing.Point(252, 0);
            this.lblOpenURL.Name = "lblOpenURL";
            this.lblOpenURL.Size = new System.Drawing.Size(30, 42);
            this.lblOpenURL.TabIndex = 10;
            this.lblOpenURL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblOpenURL, "Open URL in browser");
            this.lblOpenURL.Click += new System.EventHandler(this.lblOpenURL_Click);
            // 
            // lblDelete
            // 
            this.lblDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDelete.Image = global::AllAuth.Desktop.Properties.Resources.rubbish_grey_16px;
            this.lblDelete.Location = new System.Drawing.Point(9, 9);
            this.lblDelete.Name = "lblDelete";
            this.lblDelete.Size = new System.Drawing.Size(35, 34);
            this.lblDelete.TabIndex = 5;
            this.lblDelete.Click += new System.EventHandler(this.lblDelete_Click);
            // 
            // DatabaseViewEntryWebsite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContents);
            this.Controls.Add(this.panelTitleOuterContainer);
            this.Controls.Add(this.panelFooter);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DatabaseViewEntryWebsite";
            this.Size = new System.Drawing.Size(410, 416);
            this.Load += new System.EventHandler(this.DatabaseViewEntryWebsite_Load);
            this.panelContents.ResumeLayout(false);
            this.tableEntryContainer.ResumeLayout(false);
            this.tableEntryContainer.PerformLayout();
            this.tablePasswordContainer.ResumeLayout(false);
            this.tableUsernameContainer.ResumeLayout(false);
            this.tableUsernameContainer.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panelTitleOuterContainer.ResumeLayout(false);
            this.panelTitleContainer.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            this.panelSaveBtn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelTitleOuterContainer;
        private System.Windows.Forms.Panel panelContents;
        private Templates.ButtonDisabled btnSaveDisabled;
        private System.Windows.Forms.Panel panelTitleContainer;
        private System.Windows.Forms.Label lblCopyPassword;
        private System.Windows.Forms.TableLayoutPanel tablePasswordContainer;
        private System.Windows.Forms.Label lblUsername;
        private Templates.TextBox txtNotes;
        private Templates.TextBox txtUrl;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblPassword;
        private Templates.TextBox txtUsername;
        private System.Windows.Forms.TableLayoutPanel tableEntryContainer;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TableLayoutPanel tableUsernameContainer;
        private System.Windows.Forms.Label lblCopyUsername;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblOpenURL;
        private System.Windows.Forms.Label lblGeneratePassword;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblDelete;
        private System.Windows.Forms.Panel panelSaveBtn;
    }
}
