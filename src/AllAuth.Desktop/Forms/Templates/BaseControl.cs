using System.Windows.Forms;

namespace AllAuth.Desktop.Forms.Templates
{
    internal partial class BaseControl : UserControl
    {
        public BaseControl()
        {
            InitializeComponent();
        }

        private void BaseControl_Load(object sender, System.EventArgs e)
        {
            Font = UiStyle.DefaultFont;
        }
    }
}
