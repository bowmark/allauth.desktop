namespace AllAuth.Desktop.Forms.Dialogs
{
    partial class VerifyKeyOnSecondDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VerifyKeyOnSecondDevice));
            this.label2 = new System.Windows.Forms.Label();
            this.lblKeyCode = new System.Windows.Forms.Label();
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(7, 4);
            this.lblTitle.Size = new System.Drawing.Size(237, 41);
            this.lblTitle.Text = "Verify device keys";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panelFormContainer.Size = new System.Drawing.Size(699, 266);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.label2);
            this.panelContentContainer.Controls.Add(this.lblKeyCode);
            this.panelContentContainer.Location = new System.Drawing.Point(5, 57);
            this.panelContentContainer.Size = new System.Drawing.Size(689, 204);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(20);
            this.label2.Size = new System.Drawing.Size(437, 204);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // lblKeyCode
            // 
            this.lblKeyCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblKeyCode.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyCode.ForeColor = System.Drawing.Color.Gray;
            this.lblKeyCode.Location = new System.Drawing.Point(437, 0);
            this.lblKeyCode.Name = "lblKeyCode";
            this.lblKeyCode.Size = new System.Drawing.Size(252, 204);
            this.lblKeyCode.TabIndex = 3;
            this.lblKeyCode.Text = "{{key_code}}";
            this.lblKeyCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VerifyKeyOnSecondDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 266);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "VerifyKeyOnSecondDevice";
            this.Text = "Verify Device Keys";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VerifyKeyOnSecondDevice_FormClosing);
            this.Load += new System.EventHandler(this.VerifyKeyOnSecondDevice_Load);
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblKeyCode;
    }
}