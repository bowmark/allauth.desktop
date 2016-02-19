namespace AllAuth.Desktop.Forms.Templates
{
    partial class ButtonAccent
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
            this.ControlButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ControlButton
            // 
            this.ControlButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(172)))), ((int)(((byte)(57)))));
            this.ControlButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ControlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ControlButton.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ControlButton.ForeColor = System.Drawing.Color.White;
            this.ControlButton.Location = new System.Drawing.Point(4, 5);
            this.ControlButton.Margin = new System.Windows.Forms.Padding(0);
            this.ControlButton.Name = "ControlButton";
            this.ControlButton.Size = new System.Drawing.Size(200, 33);
            this.ControlButton.TabIndex = 0;
            this.ControlButton.Text = "ButtonTemplate";
            this.ControlButton.UseVisualStyleBackColor = false;
            // 
            // ButtonAccent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ControlButton);
            this.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ButtonAccent";
            this.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Size = new System.Drawing.Size(208, 43);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ControlButton;
    }
}
