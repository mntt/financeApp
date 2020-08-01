namespace financeApp
{
    partial class Registration
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.generatedCodeBox = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.Label();
            this.loginNameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.accountCodeLabel = new System.Windows.Forms.Label();
            this.generateCode = new System.Windows.Forms.Button();
            this.codeBox = new System.Windows.Forms.TextBox();
            this.finishRegistrationButton = new System.Windows.Forms.Button();
            this.enterCodeLabel = new System.Windows.Forms.Label();
            this.nameAlert = new System.Windows.Forms.Label();
            this.passwordAlert = new System.Windows.Forms.Label();
            this.showCode = new System.Windows.Forms.Button();
            this.repeatPasswordLabel = new System.Windows.Forms.Label();
            this.repeatPasswordBox = new System.Windows.Forms.TextBox();
            this.repeatPasswordAlert = new System.Windows.Forms.Label();
            this.infoButton = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(138, 46);
            this.nameBox.MaxLength = 30;
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(171, 20);
            this.nameBox.TabIndex = 0;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            this.nameBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nameBox_KeyPress);
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(138, 87);
            this.passwordBox.MaxLength = 30;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(171, 20);
            this.passwordBox.TabIndex = 1;
            this.passwordBox.UseSystemPasswordChar = true;
            this.passwordBox.TextChanged += new System.EventHandler(this.passwordBox_TextChanged);
            // 
            // generatedCodeBox
            // 
            this.generatedCodeBox.Location = new System.Drawing.Point(138, 173);
            this.generatedCodeBox.MaxLength = 15;
            this.generatedCodeBox.Name = "generatedCodeBox";
            this.generatedCodeBox.ReadOnly = true;
            this.generatedCodeBox.Size = new System.Drawing.Size(171, 20);
            this.generatedCodeBox.TabIndex = 3;
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.name.Location = new System.Drawing.Point(105, 9);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(133, 16);
            this.name.TabIndex = 3;
            this.name.Text = "Registracijos forma";
            // 
            // loginNameLabel
            // 
            this.loginNameLabel.AutoSize = true;
            this.loginNameLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.loginNameLabel.Location = new System.Drawing.Point(12, 49);
            this.loginNameLabel.Name = "loginNameLabel";
            this.loginNameLabel.Size = new System.Drawing.Size(120, 15);
            this.loginNameLabel.TabIndex = 4;
            this.loginNameLabel.Text = "Prisijungimo vardas";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.passwordLabel.Location = new System.Drawing.Point(60, 89);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(72, 15);
            this.passwordLabel.TabIndex = 5;
            this.passwordLabel.Text = "Slaptažodis";
            // 
            // accountCodeLabel
            // 
            this.accountCodeLabel.AutoSize = true;
            this.accountCodeLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.accountCodeLabel.Location = new System.Drawing.Point(35, 175);
            this.accountCodeLabel.Name = "accountCodeLabel";
            this.accountCodeLabel.Size = new System.Drawing.Size(97, 15);
            this.accountCodeLabel.TabIndex = 6;
            this.accountCodeLabel.Text = "Paskyros kodas";
            // 
            // generateCode
            // 
            this.generateCode.Enabled = false;
            this.generateCode.Location = new System.Drawing.Point(138, 199);
            this.generateCode.Name = "generateCode";
            this.generateCode.Size = new System.Drawing.Size(115, 21);
            this.generateCode.TabIndex = 4;
            this.generateCode.Text = "Generuoti kodą";
            this.generateCode.UseVisualStyleBackColor = true;
            this.generateCode.Click += new System.EventHandler(this.generateCode_Click);
            this.generateCode.MouseEnter += new System.EventHandler(this.generateCode_MouseEnter);
            this.generateCode.MouseLeave += new System.EventHandler(this.generateCode_MouseLeave);
            // 
            // codeBox
            // 
            this.codeBox.Location = new System.Drawing.Point(90, 289);
            this.codeBox.Name = "codeBox";
            this.codeBox.Size = new System.Drawing.Size(157, 20);
            this.codeBox.TabIndex = 6;
            // 
            // finishRegistrationButton
            // 
            this.finishRegistrationButton.Enabled = false;
            this.finishRegistrationButton.Location = new System.Drawing.Point(117, 315);
            this.finishRegistrationButton.Name = "finishRegistrationButton";
            this.finishRegistrationButton.Size = new System.Drawing.Size(100, 23);
            this.finishRegistrationButton.TabIndex = 7;
            this.finishRegistrationButton.Text = "Baigti registraciją";
            this.finishRegistrationButton.UseVisualStyleBackColor = true;
            this.finishRegistrationButton.Click += new System.EventHandler(this.finishRegistrationButton_Click);
            this.finishRegistrationButton.MouseEnter += new System.EventHandler(this.finishRegistrationButton_MouseEnter);
            this.finishRegistrationButton.MouseLeave += new System.EventHandler(this.finishRegistrationButton_MouseLeave);
            // 
            // enterCodeLabel
            // 
            this.enterCodeLabel.AutoSize = true;
            this.enterCodeLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.enterCodeLabel.Location = new System.Drawing.Point(88, 271);
            this.enterCodeLabel.Name = "enterCodeLabel";
            this.enterCodeLabel.Size = new System.Drawing.Size(160, 15);
            this.enterCodeLabel.TabIndex = 10;
            this.enterCodeLabel.Text = "Įveskite sugeneruotą kodą";
            // 
            // nameAlert
            // 
            this.nameAlert.AutoSize = true;
            this.nameAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.nameAlert.Location = new System.Drawing.Point(136, 69);
            this.nameAlert.Name = "nameAlert";
            this.nameAlert.Size = new System.Drawing.Size(29, 12);
            this.nameAlert.TabIndex = 11;
            this.nameAlert.Text = "label1";
            this.nameAlert.Visible = false;
            // 
            // passwordAlert
            // 
            this.passwordAlert.AutoSize = true;
            this.passwordAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.passwordAlert.Location = new System.Drawing.Point(136, 114);
            this.passwordAlert.Name = "passwordAlert";
            this.passwordAlert.Size = new System.Drawing.Size(29, 12);
            this.passwordAlert.TabIndex = 12;
            this.passwordAlert.Text = "label2";
            this.passwordAlert.Visible = false;
            // 
            // showCode
            // 
            this.showCode.Enabled = false;
            this.showCode.Location = new System.Drawing.Point(138, 226);
            this.showCode.Name = "showCode";
            this.showCode.Size = new System.Drawing.Size(115, 21);
            this.showCode.TabIndex = 5;
            this.showCode.Text = "Rodyti kodą";
            this.showCode.UseVisualStyleBackColor = true;
            this.showCode.Click += new System.EventHandler(this.showCode_Click);
            this.showCode.MouseEnter += new System.EventHandler(this.showCode_MouseEnter);
            this.showCode.MouseLeave += new System.EventHandler(this.showCode_MouseLeave);
            // 
            // repeatPasswordLabel
            // 
            this.repeatPasswordLabel.AutoSize = true;
            this.repeatPasswordLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.repeatPasswordLabel.Location = new System.Drawing.Point(13, 133);
            this.repeatPasswordLabel.Name = "repeatPasswordLabel";
            this.repeatPasswordLabel.Size = new System.Drawing.Size(119, 15);
            this.repeatPasswordLabel.TabIndex = 14;
            this.repeatPasswordLabel.Text = "Pakartoti slaptažodį";
            // 
            // repeatPasswordBox
            // 
            this.repeatPasswordBox.Location = new System.Drawing.Point(138, 131);
            this.repeatPasswordBox.MaxLength = 30;
            this.repeatPasswordBox.Name = "repeatPasswordBox";
            this.repeatPasswordBox.Size = new System.Drawing.Size(171, 20);
            this.repeatPasswordBox.TabIndex = 2;
            this.repeatPasswordBox.UseSystemPasswordChar = true;
            this.repeatPasswordBox.TextChanged += new System.EventHandler(this.repeatPasswordBox_TextChanged);
            // 
            // repeatPasswordAlert
            // 
            this.repeatPasswordAlert.AutoSize = true;
            this.repeatPasswordAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.repeatPasswordAlert.Location = new System.Drawing.Point(136, 154);
            this.repeatPasswordAlert.Name = "repeatPasswordAlert";
            this.repeatPasswordAlert.Size = new System.Drawing.Size(29, 12);
            this.repeatPasswordAlert.TabIndex = 16;
            this.repeatPasswordAlert.Text = "label3";
            this.repeatPasswordAlert.Visible = false;
            // 
            // infoButton
            // 
            this.infoButton.BackgroundImage = global::financeApp.Properties.Resources.info_icon;
            this.infoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.infoButton.FlatAppearance.BorderSize = 0;
            this.infoButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.infoButton.Location = new System.Drawing.Point(312, 173);
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(22, 20);
            this.infoButton.TabIndex = 17;
            this.infoButton.UseVisualStyleBackColor = true;
            this.infoButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.infoButton_MouseClick);
            this.infoButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.infoButton_MouseDown);
            this.infoButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.infoButton_MouseUp);
            // 
            // infoBox
            // 
            this.infoBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.infoBox.Location = new System.Drawing.Point(16, 184);
            this.infoBox.Multiline = true;
            this.infoBox.Name = "infoBox";
            this.infoBox.ReadOnly = true;
            this.infoBox.Size = new System.Drawing.Size(310, 53);
            this.infoBox.TabIndex = 18;
            this.infoBox.Text = "Paskyros kodas reikalingas norint atstatyti pamirštą slaptažodį. Išsisaugokite ar" +
    "ba užsirašykite šį kodą, užbaigus registraciją šis kodas niekada daugiau nebus r" +
    "odomas.";
            this.infoBox.Visible = false;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 350);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.infoButton);
            this.Controls.Add(this.repeatPasswordAlert);
            this.Controls.Add(this.repeatPasswordBox);
            this.Controls.Add(this.repeatPasswordLabel);
            this.Controls.Add(this.showCode);
            this.Controls.Add(this.passwordAlert);
            this.Controls.Add(this.nameAlert);
            this.Controls.Add(this.enterCodeLabel);
            this.Controls.Add(this.finishRegistrationButton);
            this.Controls.Add(this.codeBox);
            this.Controls.Add(this.generateCode);
            this.Controls.Add(this.accountCodeLabel);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.loginNameLabel);
            this.Controls.Add(this.name);
            this.Controls.Add(this.generatedCodeBox);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.nameBox);
            this.MaximizeBox = false;
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration";
            this.Click += new System.EventHandler(this.Registration_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Registration_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox generatedCodeBox;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label loginNameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label accountCodeLabel;
        private System.Windows.Forms.Button generateCode;
        private System.Windows.Forms.TextBox codeBox;
        private System.Windows.Forms.Button finishRegistrationButton;
        private System.Windows.Forms.Label enterCodeLabel;
        private System.Windows.Forms.Label nameAlert;
        private System.Windows.Forms.Label passwordAlert;
        private System.Windows.Forms.Button showCode;
        private System.Windows.Forms.Label repeatPasswordLabel;
        private System.Windows.Forms.TextBox repeatPasswordBox;
        private System.Windows.Forms.Label repeatPasswordAlert;
        private System.Windows.Forms.Button infoButton;
        private System.Windows.Forms.TextBox infoBox;
    }
}