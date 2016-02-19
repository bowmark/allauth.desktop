using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AllAuth.Desktop.Common.Models;

namespace AllAuth.Desktop.Forms
{
    internal partial class DatabaseView : Templates.BaseControl
    {
        private readonly Controller _controller;
        private readonly int _serverAccountId;
        private readonly int _databaseId;

        private bool _activeGroupSet;
        private int _activeGroupId;

        private bool _activeEntrySet;
        private int _activeEntryId;

        public DatabaseView(Controller controller, int databaseId)
        {
            InitializeComponent();
            
            _controller = controller;
            _databaseId = databaseId;
        }
        
        private void DatabaseView_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            panelLeft.BackColor = Color.FromArgb(240, 240, 240);
            UpdateControl();
        }

        public void UpdateControl(int activeEntryId = 0)
        {
            var databaseGroups = Model.DatabasesGroups.Find(new DatabaseGroup {DatabaseId = _databaseId});

            var controlsList = new List<DatabaseViewGroup>();
            foreach (var databaseGroup in databaseGroups)
            {
                var groupMeta = Model.DatabasesGroupsMeta.Get(databaseGroup.DatabaseGroupMetaId);
                if (!_activeGroupSet)
                {
                    _activeGroupSet = true;
                    SetActiveGroup(databaseGroup.Id);
                }

                var control = new DatabaseViewGroup(databaseGroup.Id)
                {
                    Dock = DockStyle.Top,
                    lblGroupName = {Text = groupMeta.Name},
                    Selected = databaseGroup.Id == _activeGroupId
                };
                control.Click += DatabaseGroup_Click;
                controlsList.Add(control);
            }

            controlsList = controlsList.OrderByDescending(control => control.lblGroupName.Text).ToList();

            if (_activeGroupSet)
            {
                RefreshEntries(activeEntryId);
                panelEntriesContainer.Visible = true;
                lblNewEntry.Visible = true;
            }
            else
            {
                panelEntriesContainer.Visible = false;
                lblNewEntry.Visible = false;
            }

            panelGroupsContainer.Controls.Clear();
            foreach (var control in controlsList)
                panelGroupsContainer.Controls.Add(control);
        }

        private void lblNewGroup_Click(object sender, EventArgs e)
        {
            using (var form = new Dialogs.NewGroup())
            {
                form.ShowDialog();
                if (!form.Success)
                    return;

                var newGroupId = _controller.NewGroup(_databaseId, form.NewName);
                if (newGroupId == null)
                    return;

                SetActiveGroup(newGroupId.Value);
            }
        }

        private void DatabaseGroup_Click(object sender, EventArgs e)
        {
            var control = (DatabaseViewGroup) sender;
            SetActiveGroup(control.DatabaseGroupId);
        }

        private void DatabaseEntry_Click(object sender, EventArgs e)
        {
            var clickedControl = (DatabaseViewEntry)sender;

            var activateEntryItem = !_activeEntrySet || clickedControl.EntryId != _activeEntryId;
            
            SetActiveEntry(clickedControl.EntryId);
            foreach (var entryControlObj in panelEntriesContainer.Controls)
            {
                var entryControl = (DatabaseViewEntry) entryControlObj;
                entryControl.Selected = false;
            }

            if (activateEntryItem)
                clickedControl.Selected = true;

            // This is to minimise an AutoScroll issue when de-selecting an entry that's just been edited.
            // The panel will autoscroll to the last entry in the list as that is usually the last one to be
            // added (ie. has focus). Need a better solution as there are still quirks with this (after editing, 
            // select the entry below the one you just edited) but should do for now.
            clickedControl.Focus();
        }

        private void SetActiveGroup(int databaseGroupId)
        {
            if (databaseGroupId == _activeGroupId)
                return;

            _activeGroupId = databaseGroupId;
            
            var noEntrySelectedControl = new DatabaseViewEntryNone();
            panelEntryDetailsContainer.Controls.Clear();
            panelEntryDetailsContainer.Controls.Add(noEntrySelectedControl);

            foreach (var control in panelGroupsContainer.Controls)
            {
                var groupControl = (DatabaseViewGroup) control;
                groupControl.Selected = groupControl.DatabaseGroupId == _activeGroupId;
            }
            
            UpdateControl();
        }

        private async void RefreshEntries(int activeEntryId = 0)
        {
            if (!_activeGroupSet)
                return;
            
//            panelEntriesContainer.Controls.Clear();
//            panelEntriesContainer.Controls.Add(new Label
//            {
//                Dock = DockStyle.Fill,
//                ImageAlign = ContentAlignment.MiddleCenter,
//                Image = Properties.Resources.loading_spinner
//            });
            
            var groupEntries = Model.DatabasesEntries.Find(new DatabaseEntry
            {
                DatabaseId = _databaseId,
                DatabaseGroupId = _activeGroupId,
                ToBeDeleted = false
            });

            Control selectedControl = null;
            var controlsList = new List<DatabaseViewEntry>();
            foreach (var entry in groupEntries)
            {
                var entryData = Model.DatabasesEntriesData.Get(entry.DatabaseEntryDataId);

                var control = new DatabaseViewEntry(entry.Id)
                {
                    Dock = DockStyle.Top,
                    lblEntryName = { Text = entryData.Name },
                    Selected = activeEntryId == entry.Id
                };
                
                control.Click += DatabaseEntry_Click;
                controlsList.Add(control);

                if (control.Selected)
                    selectedControl = control;
            }

            // OrderByDescending because each control added to the panel puts it at the top.
            controlsList = controlsList.OrderByDescending(control => control.lblEntryName.Text).ToList();

            panelEntriesContainer.AutoScroll = false;
            var origScrollPositition = AutoScrollPosition;
            
            panelEntriesContainer.SuspendLayout();
            panelEntriesContainer.Controls.Clear();
            panelEntriesContainer.Controls.AddRange(controlsList.ToArray());
            //foreach (var control in controlsList)
            //    panelEntriesContainer.Controls.Add(control);
            panelEntriesContainer.ResumeLayout(false);
            
            panelEntriesContainer.AutoScroll = true;
            panelEntriesContainer.AutoScrollPosition = origScrollPositition;

            if (selectedControl != null)
                panelEntriesContainer.ScrollControlIntoView(selectedControl);

            if (Program.IsRunningOnMono())
            {
                // Mono doesn't seem to wan't to automatically show scroll bars, so we'll have to force it
                panelEntriesContainer.VerticalScroll.Visible = true;
            }

            panelEntriesContainer.Focus();
        }

        public void DeselectEntry()
        {
            _activeEntrySet = false;
            var noEntrySelectedControl = new DatabaseViewEntryNone();
            panelEntryDetailsContainer.Controls.Clear();
            panelEntryDetailsContainer.Controls.Add(noEntrySelectedControl);
        }

        private void SetActiveEntry(int databaseEntryId)
        {
            if (_activeEntrySet && databaseEntryId == _activeEntryId)
            {
                _activeEntrySet = false;
                var noEntrySelectedControl = new DatabaseViewEntryNone();
                panelEntryDetailsContainer.Controls.Clear();
                panelEntryDetailsContainer.Controls.Add(noEntrySelectedControl);
                return;
            }

            _activeEntrySet = true;
            _activeEntryId = databaseEntryId;

            var control = new DatabaseViewEntryWebsite(_controller, this) {Dock = DockStyle.Fill};
            control.SetExistingEntry(databaseEntryId);

            panelEntryDetailsContainer.Controls.Clear();
            panelEntryDetailsContainer.Controls.Add(control);
        }

        private void lblNewEntry_Click(object sender, EventArgs e)
        {
            _activeEntrySet = false;
            foreach (var entryControlObj in panelEntriesContainer.Controls)
            {
                var entryControl = (DatabaseViewEntry)entryControlObj;
                entryControl.Selected = false;
            }

            var control = new DatabaseViewEntryWebsite(_controller, this, _activeGroupId) {Dock = DockStyle.Fill};
            panelEntryDetailsContainer.Controls.Clear();
            panelEntryDetailsContainer.Controls.Add(control);
        }

        public int? NewEntry(DatabaseEntryData entryData, int groupId)
        {
            return _controller.NewEntry(entryData, groupId);
        }

        public bool UpdateEntry(int entryId, DatabaseEntryData entryData)
        {
            return _controller.UpdateEntry(entryId, entryData);
        }
    }
}
