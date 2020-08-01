namespace financeApp
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.usernameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.signupButton = new System.Windows.Forms.Button();
            this.forgotPassword = new System.Windows.Forms.Label();
            this.picture1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.usernameLabel.Location = new System.Drawing.Point(46, 185);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(120, 15);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Prisijungimo vardas";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.passwordLabel.Location = new System.Drawing.Point(94, 211);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(72, 15);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "Slaptažodis";
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(187, 183);
            this.usernameBox.MaxLength = 30;
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(128, 20);
            this.usernameBox.TabIndex = 2;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(187, 209);
            this.passwordBox.MaxLength = 30;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(128, 20);
            this.passwordBox.TabIndex = 3;
            this.passwordBox.UseSystemPasswordChar = true;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(156, 257);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(84, 30);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Prisijungti";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            this.loginButton.MouseEnter += new System.EventHandler(this.loginButton_MouseEnter);
            this.loginButton.MouseLeave += new System.EventHandler(this.loginButton_MouseLeave);
            // 
            // signupButton
            // 
            this.signupButton.Location = new System.Drawing.Point(246, 257);
            this.signupButton.Name = "signupButton";
            this.signupButton.Size = new System.Drawing.Size(84, 30);
            this.signupButton.TabIndex = 5;
            this.signupButton.Text = "Registruotis";
            this.signupButton.UseVisualStyleBackColor = true;
            this.signupButton.Click += new System.EventHandler(this.signupButton_Click);
            this.signupButton.MouseEnter += new System.EventHandler(this.signupButton_MouseEnter);
            this.signupButton.MouseLeave += new System.EventHandler(this.signupButton_MouseLeave);
            // 
            // forgotPassword
            // 
            this.forgotPassword.AutoSize = true;
            this.forgotPassword.Font = new System.Drawing.Font("MS Reference Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.forgotPassword.Location = new System.Drawing.Point(190, 232);
            this.forgotPassword.Name = "forgotPassword";
            this.forgotPassword.Size = new System.Drawing.Size(106, 12);
            this.forgotPassword.TabIndex = 6;
            this.forgotPassword.Text = "Pamiršau slaptažodį";
            this.forgotPassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.forgotPassword_MouseClick);
            this.forgotPassword.MouseEnter += new System.EventHandler(this.forgotPassword_MouseEnter);
            this.forgotPassword.MouseLeave += new System.EventHandler(this.forgotPassword_MouseLeave);
            // 
            // picture1
            // 
            this.picture1.BackgroundImage = global::financeApp.Properties.Resources.finance;
            this.picture1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture1.Location = new System.Drawing.Point(12, 12);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(363, 157);
            this.picture1.TabIndex = 7;
            this.picture1.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 308);
            this.Controls.Add(this.picture1);
            this.Controls.Add(this.forgotPassword);
            this.Controls.Add(this.signupButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.usernameBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button signupButton;
        private System.Windows.Forms.Label forgotPassword;
        private System.Windows.Forms.PictureBox picture1;
    }
}