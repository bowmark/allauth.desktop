using System.Windows.Forms;

namespace AllAuth.Desktop.Forms.Templates
{
    public partial class ButtonDisabled : UserControl, IButtonControl
    {
        public override string Text
        {
            get { return lblButton.Text; }
            set { lblButton.Text = value; }
        }

        /// <summary>
        /// This is a wrapper for the Text property which will actually show in the VS Designer.
        /// </summary>
        public string TextValue
        {
            get { return Text; }
            set { Text = value; }
        }
        
        public ButtonDisabled()
        {
            InitializeComponent();
        }

        public void NotifyDefault(bool value)
        {
        }

        public void PerformClick()
        {
        }

        public DialogResult DialogResult { get; set; }
    }
}
