using System.Reflection;

namespace AllAuth.Desktop.Forms.Dialogs
{
    internal partial class About : Templates.FormDialogWithTitle
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, System.EventArgs e)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lblVersion.Text = @"Version: " + version;

            lblCopyright.Text = @"Copyright © Bowmark Ltd.";
        }

        private void linkTerms_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://allauthapp.com/about/terms");
        }

        private void linkPrivacy_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://allauthapp.com/about/privacy");
        }

        private void linkLicenses_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://allauthapp.com/about/licenses");
        }
    }
}
