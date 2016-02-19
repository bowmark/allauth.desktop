namespace AllAuth.Desktop.Forms.Templates
{
    partial class TextBox
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
            this.ControlTextBox = new System.Windows.Forms.TextBox();
            this.panelPadding = new System.Windows.Forms.Panel();
            this.panelBorder = new System.Windows.Forms.Panel();
            this.panelPadding.SuspendLayout();
            this.panelBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlTextBox
            // 
            this.ControlTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ControlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlTextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlTextBox.ForeColor = System.Drawing.Color.DimGray;
            this.ControlTextBox.Location = new System.Drawing.Point(6, 5);
            this.ControlTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.ControlTextBox.Name = "ControlTextBox";
            this.ControlTextBox.Size = new System.Drawing.Size(256, 20);
            this.ControlTextBox.TabIndex = 5;
            // 
            // panelPadding
            // 
            this.panelPadding.BackColor = System.Drawing.Color.White;
            this.panelPadding.Controls.Add(this.ControlTextBox);
            this.panelPadding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPadding.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelPadding.Location = new System.Drawing.Point(1, 1);
            this.panelPadding.Margin = new System.Windows.Forms.Padding(0);
            this.panelPadding.Name = "panelPadding";
            this.panelPadding.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panelPadding.Size = new System.Drawing.Size(268, 30);
            this.panelPadding.TabIndex = 6;
            // 
            // panelBorder
            // 
            this.panelBorder.BackColor = System.Drawing.Color.DarkGray;
            this.panelBorder.Controls.Add(this.panelPadding);
            this.panelBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBorder.Location = new System.Drawing.Point(6, 5);
            this.panelBorder.Name = "panelBorder";
            this.panelBorder.Padding = new System.Windows.Forms.Padding(1);
            this.panelBorder.Size = new System.Drawing.Size(270, 32);
            this.panelBorder.TabIndex = 7;
            // 
            // TextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panelBorder);
            this.Name = "TextBox";
            this.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Size = new System.Drawing.Size(282, 42);
            this.panelPadding.ResumeLayout(false);
            this.panelPadding.PerformLayout();
            this.panelBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelPadding;
        internal System.Windows.Forms.TextBox ControlTextBox;
        private System.Windows.Forms.Panel panelBorder;
    }
}
