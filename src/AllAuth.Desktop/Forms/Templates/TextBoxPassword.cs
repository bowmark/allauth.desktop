namespace AllAuth.Desktop.Forms.Templates
{
    internal partial class TextBoxPassword : TextBox
    {
        public TextBoxPassword()
        {
            InitializeComponent();
            ControlTextBox.PasswordChar = '•';
        }
    }
}
