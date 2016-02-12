namespace AllAuth.Mobile.TestDevice.Forms
{
    partial class AddNewServer
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
            this.txtLinkCode = new System.Windows.Forms.TextBox();
            this.btnLink = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Link Code";
            // 
            // txtLinkCode
            // 
            this.txtLinkCode.Location = new System.Drawing.Point(74, 12);
            this.txtLinkCode.Name = "txtLinkCode";
            this.txtLinkCode.Size = new System.Drawing.Size(225, 20);
            this.txtLinkCode.TabIndex = 1;
            // 
            // btnLink
            // 
            this.btnLink.Location = new System.Drawing.Point(305, 10);
            this.btnLink.Name = "btnLink";
            this.btnLink.Size = new System.Drawing.Size(75, 23);
            this.btnLink.TabIndex = 2;
            this.btnLink.Text = "Link Device";
            this.btnLink.UseVisualStyleBackColor = true;
            this.btnLink.Click += new System.EventHandler(this.btnLink_Click);
            // 
            // LinkToClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 47);
            this.Controls.Add(this.btnLink);
            this.Controls.Add(this.txtLinkCode);
            this.Controls.Add(this.label1);
            this.Name = "LinkToClient";
            this.Text = "LinkToClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLinkCode;
        private System.Windows.Forms.Button btnLink;
    }
}