using System.Drawing;

namespace AllAuth.Desktop.Forms
{
    internal partial class DatabaseViewEntry : Templates.BaseControl
    {
        public int EntryId { get; }

        private bool _selected;
        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                BackColor = value ? Color.FromArgb(240, 240, 240) : Color.FromArgb(248, 248, 248);
            }
        }

        public DatabaseViewEntry()
        {
            InitializeComponent();
        }

        public DatabaseViewEntry(int entryId) : this()
        {
            EntryId = entryId;
        }

        private void DatabaseViewEntry_Load(object sender, System.EventArgs e)
        {
            //BackColor = Color.FromArgb(248, 248, 248);
        }
        
        private void lblEntryName_Click(object sender, System.EventArgs e)
        {
            OnClick(e);
        }
    }
}
