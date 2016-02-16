using System;
using System.Drawing;
using System.Windows.Forms;

namespace AllAuth.Desktop.Forms
{
    internal partial class SubscriptionInfoBar : Templates.BaseControl
    {
        private readonly Controller _controller;
        
        public SubscriptionInfoBar(Controller controller)
        {
            InitializeComponent();

            _controller = controller;

            Click += SubscriptionInfoBar_Click;
            panelContent.Click += SubscriptionInfoBar_Click;
            lblInfo.Click += SubscriptionInfoBar_Click;
        }

        private void SubscriptionInfoBar_Click(object sender, EventArgs e)
        {
            _controller.OpenAccountManagement("billing");
        }

        private void SubscriptionInfoBar_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
        }

        public void SetNotSubscribed()
        {
            panelBorder.BackColor = Color.FromArgb(242, 222, 222);
            panelContent.BackColor = Color.FromArgb(242, 222, 222);
            lblInfo.ForeColor = Color.FromArgb(169, 68, 66);
            lblInfo.Text = @"Your account has expired, you cannot create new entries. " +
                           @"Click here to purchase a subscription.";
        }

        public void SetInTrial(int daysRemaining)
        {
            if (daysRemaining > 3)
            {
                panelBorder.BackColor = Color.FromArgb(217, 237, 247);
                panelContent.BackColor = Color.FromArgb(217, 237, 247);
                lblInfo.ForeColor = Color.FromArgb(49, 112, 143);
            }
            else
            {
                panelBorder.BackColor = Color.FromArgb(252, 248, 227);
                panelContent.BackColor = Color.FromArgb(252, 248, 227);
                lblInfo.ForeColor = Color.FromArgb(138, 109, 59);
            }
            lblInfo.Text = 
                @"Your trial has " + daysRemaining + @" day"+ (daysRemaining > 1 ? "s" : "") +
                @" remaining. Click here to purchase AllAuth for only $15 per year.";
        }
    }
}
