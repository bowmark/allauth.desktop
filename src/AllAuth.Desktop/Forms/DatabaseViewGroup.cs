using System.Drawing;

namespace AllAuth.Desktop.Forms
{
    internal partial class DatabaseViewGroup : Templates.BaseControl
    {
        public int DatabaseGroupId { get; }

        private bool _selected;
        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                BackColor = value ? Color.FromArgb(248, 248, 248) : Color.FromArgb(240, 240, 240);
            }
        }

        public DatabaseViewGroup()
        {
            InitializeComponent();
        }

        public DatabaseViewGroup(int databaseGroupId) : this()
        {
            DatabaseGroupId = databaseGroupId;
        }

        private void DatabaseViewGroup_Load(object sender, System.EventArgs e)
        {
            Height = 30;
            //ForeColor = Color.FromArgb(68,68,68);
        }

        private void lblGroupName_MouseEnter(object sender, System.EventArgs e)
        {
            //BackColor = Color.FromArgb(221,221,221);
        }

        private void lblGroupName_MouseLeave(object sender, System.EventArgs e)
        {
            //BackColor = Color.Transparent;
        }

        private void lblGroupName_Click(object sender, System.EventArgs e)
        {
            OnClick(e);
        }
    }
}
