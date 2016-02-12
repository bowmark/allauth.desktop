using System.Drawing;
using System.Windows.Forms;

namespace AllAuth.Desktop.Forms
{
    internal partial class MainForm : Form
    {
        private readonly Controller _controller;
        private readonly Header _header;
        private readonly SubscriptionInfoBar _subscriptionInfoBar;

        public MainForm(Controller controller, Header header, SubscriptionInfoBar subscriptionInfoBar)
        {
            InitializeComponent();
            
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);

            _controller = controller;
            _header = header;
            _subscriptionInfoBar = subscriptionInfoBar;

            panelHeaderContainer.Controls.Add(_header);
            panelSubscriptionInfoBar.Controls.Add(_subscriptionInfoBar);
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            Font = UiStyle.DefaultFont;
            Activate();
        }

        public void ShowSubscriptionInfoBar()
        {
            panelSubscriptionInfoBar.Show();
        }

        public void HideSubscriptionInfoBar()
        {
            panelSubscriptionInfoBar.Hide();
        }
    }
}
