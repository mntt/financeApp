namespace financeApp
{
    partial class ForgotPassword
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
            this.enterCodeLabel = new System.Windows.Forms.Label();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.generatePasswordButton = new System.Windows.Forms.Button();
            this.newPassword = new System.Windows.Forms.TextBox();
            this.showPassword = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // enterCodeLabel
            // 
            this.enterCodeLabel.AutoSize = true;
            this.enterCodeLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.enterCodeLabel.Location = new System.Drawing.Point(64, 26);
            this.enterCodeLabel.Name = "enterCodeLabel";
            this.enterCodeLabel.Size = new System.Drawing.Size(146, 15);
            this.enterCodeLabel.TabIndex = 1;
            this.enterCodeLabel.Text = "Įveskite paskyros kodą:";
            // 
            // codeBox
            // 
            this.codeBox.Location = new System.Drawing.Point(23, 54);
            this.codeBox.Name = "codeBox";
            this.codeBox.Size = new System.Drawing.Size(225, 20);
            this.codeBox.TabIndex = 2;
            // 
            // generatePasswordButton
            // 
            this.generatePasswordButton.Location = new System.Drawing.Point(39, 80);
            this.generatePasswordButton.Name = "generatePasswordButton";
            this.generatePasswordButton.Size = new System.Drawing.Size(194, 24);
            this.generatePasswordButton.TabIndex = 3;
            this.generatePasswordButton.Text = "Generuoti naują slaptažodį";
            this.generatePasswordButton.UseVisualStyleBackColor = true;
            this.generatePasswordButton.Click += new System.EventHandler(this.generatePasswordButton_Click);
            this.generatePasswordButton.MouseEnter += new System.EventHandler(this.generatePasswordButton_MouseEnter);
            this.generatePasswordButton.MouseLeave += new System.EventHandler(this.generatePasswordButton_MouseLeave);
            // 
            // newPassword
            // 
            this.newPassword.Enabled = false;
            this.newPassword.Location = new System.Drawing.Point(85, 110);
            this.newPassword.Name = "newPassword";
            this.newPassword.Size = new System.Drawing.Size(100, 20);
            this.newPassword.TabIndex = 4;
            this.newPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.newPassword.UseSystemPasswordChar = true;
            // 
            // showPassword
            // 
            this.showPassword.Enabled = false;
            this.showPassword.Location = new System.Drawing.Point(54, 136);
            this.showPassword.Name = "showPassword";
            this.showPassword.Size = new System.Drawing.Size(156, 24);
            this.showPassword.TabIndex = 5;
            this.showPassword.Text = "Rodyti slaptažodį";
            this.showPassword.UseVisualStyleBackColor = true;
            this.showPassword.Click += new System.EventHandler(this.showPassword_Click);
            this.showPassword.MouseEnter += new System.EventHandler(this.showPassword_MouseEnter);
            this.showPassword.MouseLeave += new System.EventHandler(this.showPassword_MouseLeave);
            // 
            // applyButton
            // 
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(54, 170);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(156, 24);
            this.applyButton.TabIndex = 6;
            this.applyButton.Text = "Patvirtinti";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            this.applyButton.MouseEnter += new System.EventHandler(this.applyButton_MouseEnter);
            this.applyButton.MouseLeave += new System.EventHandler(this.applyButton_MouseLeave);
            // 
            // ForgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(270, 206);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.showPassword);
            this.Controls.Add(this.newPassword);
            this.Controls.Add(this.generatePasswordButton);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.enterCodeLabel);
            this.MaximizeBox = false;
            this.Name = "ForgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ForgotPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label enterCodeLabel;
        private System.Windows.Forms.TextBox codeBox;
        private System.Windows.Forms.Button generatePasswordButton;
        private System.Windows.Forms.TextBox newPassword;
        private System.Windows.Forms.Button showPassword;
        private System.Windows.Forms.Button applyButton;
    }
}