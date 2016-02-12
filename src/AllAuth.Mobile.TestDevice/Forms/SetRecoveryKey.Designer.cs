namespace AllAuth.Mobile.TestDevice.Forms
{
    partial class SetRecoveryKey
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecoveryKey = new System.Windows.Forms.TextBox();
            this.btnRecoveryKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "New Recovery Key:";
            // 
            // txtRecoveryKey
            // 
            this.txtRecoveryKey.Location = new System.Drawing.Point(121, 10);
            this.txtRecoveryKey.Name = "txtRecoveryKey";
            this.txtRecoveryKey.Size = new System.Drawing.Size(194, 20);
            this.txtRecoveryKey.TabIndex = 1;
            // 
            // btnRecoveryKey
            // 
            this.btnRecoveryKey.Location = new System.Drawing.Point(321, 8);
            this.btnRecoveryKey.Name = "btnRecoveryKey";
            this.btnRecoveryKey.Size = new System.Drawing.Size(75, 23);
            this.btnRecoveryKey.TabIndex = 2;
            this.btnRecoveryKey.Text = "Save";
            this.btnRecoveryKey.UseVisualStyleBackColor = true;
            this.btnRecoveryKey.Click += new System.EventHandler(this.btnRecoveryKey_Click);
            // 
            // SetRecoveryKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 42);
            this.Controls.Add(this.btnRecoveryKey);
            this.Controls.Add(this.txtRecoveryKey);
            this.Controls.Add(this.label1);
            this.Name = "SetRecoveryKey";
            this.Text = "SetRecoveryKey";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecoveryKey;
        private System.Windows.Forms.Button btnRecoveryKey;
    }
}