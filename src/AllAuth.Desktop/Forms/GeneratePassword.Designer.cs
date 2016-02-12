using AllAuth.Desktop.Forms.Templates;

namespace AllAuth.Desktop.Forms
{
    partial class GeneratePassword
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneratePassword));
            this.txtLength = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUppercase = new System.Windows.Forms.CheckBox();
            this.cbLowercase = new System.Windows.Forms.CheckBox();
            this.cbDigits = new System.Windows.Forms.CheckBox();
            this.cbSymbols = new System.Windows.Forms.CheckBox();
            this.txtGeneratedString = new TextBox();
            this.btnUsePassword = new ButtonAccent();
            this.lblGenerate = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelFormContainer.SuspendLayout();
            this.panelContentContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLength)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(335, 39);
            this.lblTitle.Text = "Generate new password";
            // 
            // panelFormContainer
            // 
            this.panelFormContainer.Size = new System.Drawing.Size(428, 261);
            // 
            // panelContentContainer
            // 
            this.panelContentContainer.Controls.Add(this.lblGenerate);
            this.panelContentContainer.Controls.Add(this.btnUsePassword);
            this.panelContentContainer.Controls.Add(this.txtGeneratedString);
            this.panelContentContainer.Controls.Add(this.cbSymbols);
            this.panelContentContainer.Controls.Add(this.cbDigits);
            this.panelContentContainer.Controls.Add(this.cbLowercase);
            this.panelContentContainer.Controls.Add(this.cbUppercase);
            this.panelContentContainer.Controls.Add(this.label1);
            this.panelContentContainer.Controls.Add(this.txtLength);
            this.panelContentContainer.Size = new System.Drawing.Size(416, 199);
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(74, 31);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(47, 28);
            this.txtLength.TabIndex = 1;
            this.txtLength.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtLength.ValueChanged += new System.EventHandler(this.txtLength_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Length";
            // 
            // cbUppercase
            // 
            this.cbUppercase.AutoSize = true;
            this.cbUppercase.Checked = true;
            this.cbUppercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUppercase.Location = new System.Drawing.Point(161, 22);
            this.cbUppercase.Name = "cbUppercase";
            this.cbUppercase.Size = new System.Drawing.Size(101, 24);
            this.cbUppercase.TabIndex = 3;
            this.cbUppercase.Text = "Uppercase";
            this.cbUppercase.UseVisualStyleBackColor = true;
            this.cbUppercase.CheckedChanged += new System.EventHandler(this.cbUppercase_CheckedChanged);
            // 
            // cbLowercase
            // 
            this.cbLowercase.AutoSize = true;
            this.cbLowercase.Checked = true;
            this.cbLowercase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLowercase.Location = new System.Drawing.Point(161, 52);
            this.cbLowercase.Name = "cbLowercase";
            this.cbLowercase.Size = new System.Drawing.Size(101, 24);
            this.cbLowercase.TabIndex = 4;
            this.cbLowercase.Text = "Lowercase";
            this.cbLowercase.UseVisualStyleBackColor = true;
            this.cbLowercase.CheckedChanged += new System.EventHandler(this.cbLowercase_CheckedChanged);
            // 
            // cbDigits
            // 
            this.cbDigits.AutoSize = true;
            this.cbDigits.Checked = true;
            this.cbDigits.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDigits.Location = new System.Drawing.Point(302, 22);
            this.cbDigits.Name = "cbDigits";
            this.cbDigits.Size = new System.Drawing.Size(67, 24);
            this.cbDigits.TabIndex = 5;
            this.cbDigits.Text = "Digits";
            this.cbDigits.UseVisualStyleBackColor = true;
            this.cbDigits.CheckedChanged += new System.EventHandler(this.cbDigits_CheckedChanged);
            // 
            // cbSymbols
            // 
            this.cbSymbols.AutoSize = true;
            this.cbSymbols.Checked = true;
            this.cbSymbols.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSymbols.Location = new System.Drawing.Point(302, 52);
            this.cbSymbols.Name = "cbSymbols";
            this.cbSymbols.Size = new System.Drawing.Size(87, 24);
            this.cbSymbols.TabIndex = 6;
            this.cbSymbols.Text = "Symbols";
            this.cbSymbols.UseVisualStyleBackColor = true;
            this.cbSymbols.CheckedChanged += new System.EventHandler(this.cbSymbols_CheckedChanged);
            // 
            // txtGeneratedString
            // 
            this.txtGeneratedString.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.txtGeneratedString.BackColor = System.Drawing.Color.Transparent;
            this.txtGeneratedString.Font = new System.Drawing.Font("Open Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGeneratedString.Location = new System.Drawing.Point(16, 93);
            this.txtGeneratedString.Margin = new System.Windows.Forms.Padding(0);
            this.txtGeneratedString.MultiLine = false;
            this.txtGeneratedString.Name = "txtGeneratedString";
            this.txtGeneratedString.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txtGeneratedString.Readonly = false;
            this.txtGeneratedString.Size = new System.Drawing.Size(347, 42);
            this.txtGeneratedString.TabIndex = 7;
            this.txtGeneratedString.TextValue = "";
            // 
            // btnUsePassword
            // 
            this.btnUsePassword.BackColor = System.Drawing.Color.Transparent;
            this.btnUsePassword.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnUsePassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsePassword.Location = new System.Drawing.Point(16, 144);
            this.btnUsePassword.Margin = new System.Windows.Forms.Padding(0);
            this.btnUsePassword.Name = "btnUsePassword";
            this.btnUsePassword.Padding = new System.Windows.Forms.Padding(5);
            this.btnUsePassword.Size = new System.Drawing.Size(382, 45);
            this.btnUsePassword.TabIndex = 8;
            this.btnUsePassword.TextValue = "Use password";
            this.btnUsePassword.Click += new System.EventHandler(this.btnUsePassword_Click);
            // 
            // lblGenerate
            // 
            this.lblGenerate.Image = ((System.Drawing.Image)(resources.GetObject("lblGenerate.Image")));
            this.lblGenerate.Location = new System.Drawing.Point(363, 98);
            this.lblGenerate.Name = "lblGenerate";
            this.lblGenerate.Size = new System.Drawing.Size(35, 31);
            this.lblGenerate.TabIndex = 9;
            this.toolTip1.SetToolTip(this.lblGenerate, "Re-generate password");
            this.lblGenerate.Click += new System.EventHandler(this.lblGenerate_Click);
            // 
            // GeneratePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 261);
            this.Name = "GeneratePassword";
            this.Text = "Generate New Password";
            this.Load += new System.EventHandler(this.GeneratePassword_Load);
            this.panelFormContainer.ResumeLayout(false);
            this.panelContentContainer.ResumeLayout(false);
            this.panelContentContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Templates.TextBox txtGeneratedString;
        private System.Windows.Forms.CheckBox cbSymbols;
        private System.Windows.Forms.CheckBox cbDigits;
        private System.Windows.Forms.CheckBox cbLowercase;
        private System.Windows.Forms.CheckBox cbUppercase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtLength;
        private System.Windows.Forms.Label lblGenerate;
        private Templates.ButtonAccent btnUsePassword;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}