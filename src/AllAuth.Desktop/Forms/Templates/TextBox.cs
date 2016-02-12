using System;
using System.Drawing;

namespace AllAuth.Desktop.Forms.Templates
{
    internal partial class TextBox : BaseControl
    {
        public override string Text
        {
            get { return ControlTextBox.Text; }
            set { ControlTextBox.Text = value; }
        }
        
        /// <summary>
        /// This is a wrapper for the Text property which will actually show in the VS Designer.
        /// </summary>
        public string TextValue
        {
            get { return Text; }
            set { Text = value; }
        }

        public bool Readonly
        {
            get { return ControlTextBox.ReadOnly; }
            set
            {
                ControlTextBox.ReadOnly = value;

                // When Readonly is set to true, the BackColor automatically changes to gray.
                // Changing it back manually again seems to fix it.
                if (value)
                    ControlTextBox.BackColor = Color.White;
            }
        }

        public bool MultiLine
        {
            get { return ControlTextBox.Multiline; }
            set { ControlTextBox.Multiline = value; }
        }

        public new event EventHandler TextChanged
        {
            add { ControlTextBox.TextChanged += value; }
            remove { ControlTextBox.TextChanged -= value; }
        }

        public TextBox()
        {
            InitializeComponent();
        }
    }
}
