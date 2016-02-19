using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AllAuth.Desktop.Forms
{
    internal partial class HomePage : Templates.BaseControl
    {
        private readonly Controller _controller;

        private bool _loadingAnimationRunning;
        private Label _loadingAnimation;

        public HomePage(Controller controller)
        {
            InitializeComponent();
            _controller = controller;

            _loadingAnimation = new Label
            {
                Dock = DockStyle.Fill,
                Image = Properties.Resources.loading_spinner_greybg,
                ImageAlign = ContentAlignment.MiddleCenter,
                AutoSize = false
            };
        }

        private void HomePage_Load(object sender, System.EventArgs e)
        {
            Dock = DockStyle.Fill;
            UpdateControl();
        }

        public void UpdateControl()
        {
            var serverAccounts = Model.ServerAccounts.Find(new Common.Models.ServerAccount()).ToList();
            
            if (serverAccounts.Count == 0)
            {
                if (!_loadingAnimationRunning)
                {
                    _loadingAnimationRunning = true;
                    ImageAnimator.Animate(_loadingAnimation.Image, AnimateLoader);
                }

                // There shouldn't be a case where the main form has loaded without any server accounts.
                
                panelContentContainer.Controls.Clear();
                panelContentContainer.Controls.Add(_loadingAnimation);
                return;
            }

            if (_loadingAnimationRunning)
            {
                ImageAnimator.StopAnimate(_loadingAnimation.Image, AnimateLoader);
                _loadingAnimationRunning = false;
            }

            var contentControls = new List<Control>();
            foreach (var serverAccount in serverAccounts)
            {
                var serverGroupControl = new HomePageServer(_controller, serverAccount.Id)
                {
                    Dock = DockStyle.Top,
                    lblServerName = { Text = serverAccount.ServerLabel },
                    lblEmailAddress = { Text = serverAccount.EmailAddress }
                };

//                serverGroupControl.lblServerActionAddDatabase.Click += delegate
//                {
//                    var createSuccess = _controller.CreateAndLinkNewDatabase(serverAccount);
//                    if (createSuccess)
//                        _controller.UpdateUiSafe();
//                };

                var databases = Model.Databases.Find(new AllAuth.Desktop.Common.Models.Database
                {
                    ServerAccountId = serverAccount.Id
                });

                var numDatabases = 0;
                foreach (var database in databases)
                {
                    var databaseMeta = Model.DatabasesMeta.Get(database.DatabaseMetaId);

                    numDatabases++;
                    if (numDatabases == 1)
                    {
                        serverGroupControl.panelDatabasesContainer.Controls.Add(new Panel
                        {
                            Height = 1,
                            Dock = DockStyle.Top,
                            BackColor = Color.FromArgb(240, 240, 240)
                        });
                    }
                    

                    //var databaseStatus = _controller.GetDatabasesSyncStatus(serverAccount, database.Identifier);

                    var databaseContainer = new Panel
                    {
                        Height = 40,
                        Padding = new Padding(10),
                        Dock = DockStyle.Top,
                        Cursor = Cursors.Hand
                    };

                    var databaseCanOpen = true;

                    databaseContainer.MouseEnter += delegate { OnDatabaseContainerMouseEnter(databaseContainer); };
                    databaseContainer.MouseLeave += delegate { OnDatabaseContainerMouseLeave(databaseContainer); };

                    if (databaseCanOpen)
                        databaseContainer.Click += delegate { _controller.SetActiveDatabase(database.Id); };

                    var newlblDatabaseName = new Label
                    {
                        Text = databaseMeta.Name,
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleLeft,
                        Cursor = Cursors.Hand
                    };
                    newlblDatabaseName.MouseEnter += delegate { OnDatabaseContainerMouseEnter(databaseContainer); };
                    newlblDatabaseName.MouseLeave += delegate { OnDatabaseContainerMouseLeave(databaseContainer); };

                    if (databaseCanOpen)
                        newlblDatabaseName.Click += delegate { _controller.SetActiveDatabase(database.Id); };

                    databaseContainer.Controls.Add(newlblDatabaseName);
                    
                    serverGroupControl.panelDatabasesContainer.Controls.Add(databaseContainer);
                }
                
                var headerHeight =
                    serverGroupControl.panelHeaderTop.Height +
                    serverGroupControl.panelHeaderBottom.Height +
                    serverGroupControl.panelSeparator.Height;

                if (!serverGroupControl.SecondDeviceSetup)
                    headerHeight += 35;
                else if (!serverGroupControl.DeviceKeysVerified)
                    headerHeight += 35;

                var databaseContainerHeight = 0;
                if (serverGroupControl.SecondDeviceSetup && serverGroupControl.DeviceKeysVerified)
                    databaseContainerHeight = (numDatabases * 40);
                
                serverGroupControl.Height =
                    headerHeight +
                    databaseContainerHeight +
                    serverGroupControl.panelDatabasesContainer.Padding.Top +
                    serverGroupControl.panelDatabasesContainer.Padding.Bottom;
                    
                contentControls.Add(serverGroupControl);
            }

            panelContentContainer.Controls.Clear();
            foreach (var control in contentControls)
                panelContentContainer.Controls.Add(control);
        }

        private void AnimateLoader(object sender, EventArgs eventArgs)
        {
            if (!_loadingAnimationRunning)
                return;
            ImageAnimator.UpdateFrames();
            _loadingAnimation.Invalidate();
        }

        private void OnDatabaseContainerMouseEnter(Panel databaseContainer)
        {
            databaseContainer.BackColor = Color.FromArgb(238, 238, 238);
        }

        private void OnDatabaseContainerMouseLeave(Panel databaseContainer)
        {
            databaseContainer.BackColor = Color.Transparent;
        }

        public void SetServerSyncStatus(int serverId, Sync.Statuses status)
        {
            foreach (var control in panelContentContainer.Controls)
            {
                var serverControl = (HomePageServer) control;
                if (serverControl.ServerAccountId != serverId)
                    continue;

                serverControl.SyncStatus = status;
            }
        }
    }
}
