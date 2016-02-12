using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using AllAuth.Desktop.Common.Models;
using AllAuth.Desktop.Properties;

namespace AllAuth.Desktop.Forms
{
    internal partial class DatabaseViewEntryWebsite : Templates.BaseControl
    {
        private readonly Controller _controller;

        private readonly DatabaseView _databaseView;
        private readonly int _groupId;

        private bool _editEntry;
        private int _entryId;
        
        private Control _btnControl;

        private readonly Templates.TextBox _txtPassword;
        private readonly Label _lblPasswordShared;
        private bool _newPassword;
        
        public DatabaseViewEntryWebsite(Controller controller)
        {
            InitializeComponent();

            _controller = controller;
            lblTitle.ForeColor = UiStyle.AccentColor;

            _txtPassword = new Templates.TextBoxPassword
            {
                Dock = DockStyle.Fill,
                TabIndex = 1,
                TabStop = true
            };

            _lblPasswordShared = new Label
            {
                Text = @"Shared to device",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            
            tablePasswordContainer.Controls.Remove(_lblPasswordShared);
            tablePasswordContainer.Controls.Add(_txtPassword, 0, 0);
        }

        public DatabaseViewEntryWebsite(Controller controller, DatabaseView databaseView) : this(controller)
        {
            _databaseView = databaseView;
        }

        public DatabaseViewEntryWebsite(Controller controller, DatabaseView databaseView, int groupId) 
            : this(controller, databaseView)
        {
            _groupId = groupId;
        }
        
        private void DatabaseViewEntryWebsite_Load(object sender, EventArgs e)
        {
            _btnControl = btnSaveDisabled;

            txtUsername.TextChanged += TextBoxChanged;
            _txtPassword.TextChanged += TextBoxChanged;
            txtUrl.TextChanged += TextBoxChanged;
            txtUrl.TextChanged += UrlTextChanged;
            txtNotes.TextChanged += TextBoxChanged;

            if (!_editEntry)
            {
                txtUsername.Focus();
                lblDelete.Visible = false;
            }
        }

        public void SetExistingEntry(int entryId)
        {
            _editEntry = true;
            _entryId = entryId;

            var entry = Model.DatabasesEntries.Get(entryId);
            var entryData = Model.DatabasesEntriesData.Get(entry.DatabaseEntryDataId);
            lblTitle.Text = entryData.Name;
            txtUsername.Text = entryData.Username;
            _txtPassword.Text = entryData.Password;
            txtUrl.Text = entryData.Url;
            txtNotes.Text = entryData.Notes;

            if (entryData.PasswordShared)
            {
                tablePasswordContainer.Controls.Remove(_txtPassword);
                tablePasswordContainer.Controls.Add(_lblPasswordShared, 0, 0);
            }
        }

        private void TextBoxChanged(object sender, EventArgs e)
        {
            if (_btnControl is Templates.ButtonAccent)
                return;

            var newButton = new Templates.ButtonAccent
            {
                Text = @"Save",
                Dock = DockStyle.Right,
                Width = _btnControl.Width
            };
            newButton.Click += btnSave_Click;
            panelSaveBtn.Controls.Remove(_btnControl);
            panelSaveBtn.Controls.Add(newButton);
            _btnControl = newButton;
        }

        private void UrlTextChanged(object sender, EventArgs e)
        {
            try
            {
                var url = new Uri(txtUrl.Text);
                lblTitle.Text = url.Host;
            }
            catch (UriFormatException)
            {
                lblTitle.Text = txtUrl.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var entryData = new DatabaseEntryData
            {
                Name = lblTitle.Text.Trim(),
                Url = txtUrl.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Password = _txtPassword.Text,
                Notes = txtNotes.Text
            };

            if (_newPassword)
                entryData.PasswordShared = false;

            if (_editEntry)
            {
                var success = _databaseView.UpdateEntry(_entryId, entryData);
                if (!success)
                    return;

                var newButton = new Templates.ButtonDisabled
                {
                    Text = @"Save",
                    Dock = DockStyle.Right,
                    Width = _btnControl.Width
                };
                panelSaveBtn.Controls.Remove(_btnControl);
                panelSaveBtn.Controls.Add(newButton);
                _btnControl = newButton;
            }
            else
            {
                var newEntryId = _databaseView.NewEntry(entryData, _groupId);
                if (newEntryId == null)
                    return;

                _entryId = newEntryId.Value;
                _editEntry = true;

                var newButton = new Templates.ButtonDisabled
                {
                    Text = @"Save",
                    Dock = DockStyle.Right,
                    Width = _btnControl.Width
                };
                panelSaveBtn.Controls.Remove(_btnControl);
                panelSaveBtn.Controls.Add(newButton);
                _btnControl = newButton;

                _databaseView.UpdateControl(newEntryId.Value);
            }

            tablePasswordContainer.Controls.Remove(_txtPassword);
            tablePasswordContainer.Controls.Add(_lblPasswordShared);
            lblDelete.Visible = true;
            _newPassword = false;
        }
        
        private void lblCopyPassword_Click(object sender, EventArgs e)
        {
            if (!_editEntry)
            {
                Controller.CopyToClipboard(_txtPassword.Text);
                ShowClipboardCopiedLabel(lblCopyPassword);
                return;
            }

            if (_newPassword)
            {
                Controller.CopyToClipboard(_txtPassword.Text);
                ShowClipboardCopiedLabel(lblCopyPassword);
                return;
            }

            var entry = Model.DatabasesEntries.Get(_entryId);
            var entryData = Model.DatabasesEntriesData.Get(entry.DatabaseEntryDataId);
            if (!entryData.PasswordShared)
            {
                Controller.CopyToClipboard(entryData.Password);
                ShowClipboardCopiedLabel(lblCopyPassword);
                return;
            }
            
            var loaderImg = (Image)Resources.ResourceManager.GetObject("ajax_loader");
            lblCopyPassword.Image = loaderImg;

            var thread = new Thread(delegate()
            {
                var secret = _controller.GetSecret(
                    entry.DatabaseId, _entryId, entryData.PasswordSharedIdentifier, entryData.PasswordEncryptedData);

                if (secret == null)
                {
                    SecretNotReceived();
                    return;
                }

                SecretReceived(secret);
            });

            thread.Start();
        }

        private void SecretReceived(string secret)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker) delegate { SecretReceivedUnsafe(secret); });
            else
                SecretReceivedUnsafe(secret);
        }

        private void SecretReceivedUnsafe(string secret)
        {
            Controller.CopyToClipboard(secret);
            ShowClipboardCopiedLabel(lblCopyPassword);
            var origIcon = (Image)Resources.ResourceManager.GetObject("paper42_green_16px");
            lblCopyPassword.Image = origIcon;
        }

        private void SecretNotReceived()
        {
            if (InvokeRequired)
                Invoke((MethodInvoker) SecretNotReceivedUnsafe);
            else
                SecretNotReceivedUnsafe();
        }

        private void SecretNotReceivedUnsafe()
        {
            var origIcon = (Image) Resources.ResourceManager.GetObject("paper42_green_16px");
            lblCopyPassword.Image = origIcon;
        }

        private void lblCopyUsername_Click(object sender, EventArgs e)
        {
            Controller.CopyToClipboard(txtUsername.Text);
            ShowClipboardCopiedLabel(lblCopyUsername);
        }

        private void lblOpenURL_Click(object sender, EventArgs e)
        {
            if (!_editEntry)
                return;

            Uri result;
            if (!Uri.TryCreate(txtUrl.Text, UriKind.Absolute, out result))
                return;

            System.Diagnostics.Process.Start(result.AbsoluteUri);
        }

        private void lblGeneratePassword_Click(object sender, EventArgs e)
        {
            using (var form = new GeneratePassword())
            {
                form.ShowDialog();
                if (!form.Success)
                    return;

                _txtPassword.Text = form.Password;
                _txtPassword.Visible = true;

                tablePasswordContainer.Controls.Remove(_lblPasswordShared);
                tablePasswordContainer.Controls.Add(_txtPassword);

                _newPassword = true;
            }
        }

        private void ShowClipboardCopiedLabel(Control control)
        {
            var screenCoord = control.PointToScreen(Point.Empty);
            var controlLoc = PointToClient(screenCoord);
            toolTip2.Show("Copied to clipboard!", this, controlLoc, 2000);
        }

        private void lblDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                @"Are you sure you wish to delete this entry?", @"Delete Entry", MessageBoxButtons.YesNo);

            if (result != DialogResult.Yes)
                return;

            _controller.DeleteEntry(_entryId);
        }
    }
}
