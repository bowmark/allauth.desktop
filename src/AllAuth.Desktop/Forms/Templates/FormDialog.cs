using System.Drawing;
using System.Windows.Forms;

namespace AllAuth.Desktop.Forms.Templates
{
    internal partial class FormDialog : Form
    {
        protected Controller Controller;

        protected FormDialog()
        {
            InitializeComponent();
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
        
        private void FormDialogTemplate_Load(object sender, System.EventArgs e)
        {
            Activate();
            Font = UiStyle.DefaultFont;
        }
    }
}
