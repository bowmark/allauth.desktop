namespace AllAuth.Desktop.Forms.Templates
{
    partial class DropDownList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.panelPadding = new System.Windows.Forms.Panel();
            this.panelBorder.SuspendLayout();
            this.panelPadding.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.White;
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.comboBox1.ForeColor = System.Drawing.Color.DimGray;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ItemHeight = 20;
            this.comboBox1.Location = new System.Drawing.Point(1, 1);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(236, 28);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.TabStop = false;
            // 
            // panelBorder
            // 
            this.panelBorder.BackColor = System.Drawing.Color.DarkGray;
            this.panelBorder.Controls.Add(this.panelPadding);
            this.panelBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorder.Location = new System.Drawing.Point(5, 5);
            this.panelBorder.Margin = new System.Windows.Forms.Padding(0);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Padding = new System.Windows.Forms.Padding(1);
            this.panelBorder.Size = new System.Drawing.Size(240, 32);
            this.panelBorder.TabIndex = 1;
            // 
            // panelPadding
            // 
            this.panelPadding.BackColor = System.Drawing.Color.White;
            this.panelPadding.Controls.Add(this.comboBox1);
            this.panelPadding.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelPadding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPadding.Location = new System.Drawing.Point(1, 1);
            this.panelPadding.Margin = new System.Windows.Forms.Padding(0);
            this.panelPadding.Name = "panelPadding";
            this.panelPadding.Padding = new System.Windows.Forms.Padding(1);
            this.panelPadding.Size = new System.Drawing.Size(238, 30);
            this.panelPadding.TabIndex = 0;
            // 
            // DropDownList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelBorder);
            this.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "DropDownList";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(250, 42);
            this.panelBorder.ResumeLayout(false);
            this.panelPadding.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelBorder;
        private System.Windows.Forms.Panel panelPadding;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}
