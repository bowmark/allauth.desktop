namespace AllAuth.Desktop.Forms
{
    partial class DatabaseView
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.panelGroupsContainer = new System.Windows.Forms.Panel();
            this.panelAddGroupContainer = new System.Windows.Forms.Panel();
            this.lblNewGroup = new System.Windows.Forms.Label();
            this.splitContainerRight = new System.Windows.Forms.SplitContainer();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.panelEntriesContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblNewEntry = new System.Windows.Forms.Label();
            this.panelEntryDetailsContainer = new System.Windows.Forms.Panel();
            this.databaseViewEntryNone1 = new AllAuth.Desktop.Forms.DatabaseViewEntryNone();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelAddGroupContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).BeginInit();
            this.splitContainerRight.Panel1.SuspendLayout();
            this.splitContainerRight.Panel2.SuspendLayout();
            this.splitContainerRight.SuspendLayout();
            this.panelCenter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelEntryDetailsContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(225)))), ((int)(((byte)(226)))));
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panelLeft);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.splitContainerRight);
            this.splitContainer.Size = new System.Drawing.Size(802, 404);
            this.splitContainer.SplitterDistance = 163;
            this.splitContainer.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.panelLeft.Controls.Add(this.panelGroupsContainer);
            this.panelLeft.Controls.Add(this.panelAddGroupContainer);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(163, 404);
            this.panelLeft.TabIndex = 0;
            // 
            // panelGroupsContainer
            // 
            this.panelGroupsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGroupsContainer.Location = new System.Drawing.Point(0, 39);
            this.panelGroupsContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panelGroupsContainer.Name = "panelGroupsContainer";
            this.panelGroupsContainer.Size = new System.Drawing.Size(163, 365);
            this.panelGroupsContainer.TabIndex = 1;
            // 
            // panelAddGroupContainer
            // 
            this.panelAddGroupContainer.Controls.Add(this.panel3);
            this.panelAddGroupContainer.Controls.Add(this.lblNewGroup);
            this.panelAddGroupContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAddGroupContainer.Location = new System.Drawing.Point(0, 0);
            this.panelAddGroupContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelAddGroupContainer.Name = "panelAddGroupContainer";
            this.panelAddGroupContainer.Size = new System.Drawing.Size(163, 39);
            this.panelAddGroupContainer.TabIndex = 0;
            // 
            // lblNewGroup
            // 
            this.lblNewGroup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNewGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNewGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(172)))), ((int)(((byte)(57)))));
            this.lblNewGroup.Location = new System.Drawing.Point(0, 0);
            this.lblNewGroup.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNewGroup.Name = "lblNewGroup";
            this.lblNewGroup.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.lblNewGroup.Size = new System.Drawing.Size(163, 39);
            this.lblNewGroup.TabIndex = 0;
            this.lblNewGroup.Text = "+ New Group";
            this.lblNewGroup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNewGroup.Click += new System.EventHandler(this.lblNewGroup_Click);
            // 
            // splitContainerRight
            // 
            this.splitContainerRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(225)))), ((int)(((byte)(226)))));
            this.splitContainerRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerRight.IsSplitterFixed = true;
            this.splitContainerRight.Location = new System.Drawing.Point(0, 0);
            this.splitContainerRight.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainerRight.Name = "splitContainerRight";
            // 
            // splitContainerRight.Panel1
            // 
            this.splitContainerRight.Panel1.Controls.Add(this.panelCenter);
            // 
            // splitContainerRight.Panel2
            // 
            this.splitContainerRight.Panel2.Controls.Add(this.panelEntryDetailsContainer);
            this.splitContainerRight.Size = new System.Drawing.Size(635, 404);
            this.splitContainerRight.SplitterDistance = 253;
            this.splitContainerRight.SplitterWidth = 1;
            this.splitContainerRight.TabIndex = 0;
            // 
            // panelCenter
            // 
            this.panelCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panelCenter.Controls.Add(this.panelEntriesContainer);
            this.panelCenter.Controls.Add(this.panel1);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(0, 0);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(0);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(253, 404);
            this.panelCenter.TabIndex = 0;
            // 
            // panelEntriesContainer
            // 
            this.panelEntriesContainer.AutoScroll = true;
            this.panelEntriesContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEntriesContainer.Location = new System.Drawing.Point(0, 39);
            this.panelEntriesContainer.Margin = new System.Windows.Forms.Padding(0);
            this.panelEntriesContainer.Name = "panelEntriesContainer";
            this.panelEntriesContainer.Size = new System.Drawing.Size(253, 365);
            this.panelEntriesContainer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblNewEntry);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(253, 39);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(228)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(253, 1);
            this.panel2.TabIndex = 1;
            // 
            // lblNewEntry
            // 
            this.lblNewEntry.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNewEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNewEntry.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(172)))), ((int)(((byte)(57)))));
            this.lblNewEntry.Location = new System.Drawing.Point(0, 0);
            this.lblNewEntry.Margin = new System.Windows.Forms.Padding(0);
            this.lblNewEntry.Name = "lblNewEntry";
            this.lblNewEntry.Padding = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.lblNewEntry.Size = new System.Drawing.Size(253, 39);
            this.lblNewEntry.TabIndex = 0;
            this.lblNewEntry.Text = "+ New Entry";
            this.lblNewEntry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNewEntry.Click += new System.EventHandler(this.lblNewEntry_Click);
            // 
            // panelEntryDetailsContainer
            // 
            this.panelEntryDetailsContainer.AutoScroll = true;
            this.panelEntryDetailsContainer.Controls.Add(this.databaseViewEntryNone1);
            this.panelEntryDetailsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEntryDetailsContainer.Location = new System.Drawing.Point(0, 0);
            this.panelEntryDetailsContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelEntryDetailsContainer.Name = "panelEntryDetailsContainer";
            this.panelEntryDetailsContainer.Size = new System.Drawing.Size(381, 404);
            this.panelEntryDetailsContainer.TabIndex = 0;
            // 
            // databaseViewEntryNone1
            // 
            this.databaseViewEntryNone1.BackColor = System.Drawing.Color.White;
            this.databaseViewEntryNone1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databaseViewEntryNone1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.databaseViewEntryNone1.Location = new System.Drawing.Point(0, 0);
            this.databaseViewEntryNone1.Margin = new System.Windows.Forms.Padding(0);
            this.databaseViewEntryNone1.Name = "databaseViewEntryNone1";
            this.databaseViewEntryNone1.Size = new System.Drawing.Size(381, 404);
            this.databaseViewEntryNone1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(225)))), ((int)(((byte)(226)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 38);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(163, 1);
            this.panel3.TabIndex = 1;
            // 
            // DatabaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "DatabaseView";
            this.Size = new System.Drawing.Size(802, 404);
            this.Load += new System.EventHandler(this.DatabaseView_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelAddGroupContainer.ResumeLayout(false);
            this.splitContainerRight.Panel1.ResumeLayout(false);
            this.splitContainerRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerRight)).EndInit();
            this.splitContainerRight.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelEntryDetailsContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.SplitContainer splitContainerRight;
        internal System.Windows.Forms.Panel panelLeft;
        internal System.Windows.Forms.Panel panelCenter;
        private System.Windows.Forms.Panel panelEntryDetailsContainer;
        private System.Windows.Forms.Panel panelAddGroupContainer;
        private System.Windows.Forms.Label lblNewGroup;
        private System.Windows.Forms.Panel panelGroupsContainer;
        public System.Windows.Forms.Panel panelEntriesContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNewEntry;
        private DatabaseViewEntryNone databaseViewEntryNone1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
