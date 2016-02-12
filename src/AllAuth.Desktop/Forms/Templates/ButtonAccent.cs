using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AllAuth.Desktop.Forms.Templates
{
    [DefaultEvent("Click")]
    public partial class ButtonAccent : UserControl, IButtonControl
    {
        public override string Text
        {
            get { return ControlButton.Text; }
            set { ControlButton.Text = value; }
        }

        /// <summary>
        /// This is a wrapper for the Text property which will actually show in the VS Designer.
        /// </summary>
        public string TextValue
        {
            get { return Text; }
            set { Text = value; }
        }

        public new event EventHandler Click
        {
            add { ControlButton.Click += value; }
            remove { ControlButton.Click -= value; }
        }

        public ButtonAccent()
        {
            InitializeComponent();
        }

        public void NotifyDefault(bool value)
        {
            ControlButton.NotifyDefault(value);
        }

        public void PerformClick()
        {
            ControlButton.PerformClick();
        }

        public DialogResult DialogResult { get; set; }
    }
}
