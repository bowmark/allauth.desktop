using System;
using System.Windows.Forms;

namespace AllAuth.Desktop.Forms.Templates
{
    public partial class DropDownList : UserControl
    {
        public new bool Enabled { get { return comboBox1.Enabled; } set { comboBox1.Enabled = value; } }
        public ComboBox.ObjectCollection Items => comboBox1.Items;
        public object DataSource { get { return comboBox1.DataSource; } set { comboBox1.DataSource = value; } }
        public int SelectedIndex => comboBox1.SelectedIndex;
        
        public event EventHandler DropDownClosed
        {
            add { comboBox1.DropDownClosed += value; }
            remove { comboBox1.DropDownClosed -= value; }
        }

        public DropDownList()
        {
            InitializeComponent();
        }
    }
}
