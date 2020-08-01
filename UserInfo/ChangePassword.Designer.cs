namespace financeApp
{
    partial class ChangePassword
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
            this.oldPasswordLabel = new System.Windows.Forms.Label();
            this.newPasswordLabel = new System.Windows.Forms.Label();
            this.oldPasswordBox = new System.Windows.Forms.TextBox();
            this.newPasswordBox = new System.Windows.Forms.TextBox();
            this.applyButton = new System.Windows.Forms.Button();
            this.newPasswordAlert = new System.Windows.Forms.Label();
            this.repeatPasswordLabel = new System.Windows.Forms.Label();
            this.repeatPasswordBox = new System.Windows.Forms.TextBox();
            this.repeatPasswordAlert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // oldPasswordLabel
            // 
            this.oldPasswordLabel.AutoSize = true;
            this.oldPasswordLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.oldPasswordLabel.Location = new System.Drawing.Point(15, 14);
            this.oldPasswordLabel.Name = "oldPasswordLabel";
            this.oldPasswordLabel.Size = new System.Drawing.Size(109, 15);
            this.oldPasswordLabel.TabIndex = 0;
            this.oldPasswordLabel.Text = "Senas slaptažodis";
            // 
            // newPasswordLabel
            // 
            this.newPasswordLabel.AutoSize = true;
            this.newPasswordLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.newPasswordLabel.Location = new System.Drawing.Point(11, 54);
            this.newPasswordLabel.Name = "newPasswordLabel";
            this.newPasswordLabel.Size = new System.Drawing.Size(113, 15);
            this.newPasswordLabel.TabIndex = 1;
            this.newPasswordLabel.Text = "Naujas slaptažodis";
            // 
            // oldPasswordBox
            // 
            this.oldPasswordBox.Location = new System.Drawing.Point(130, 12);
            this.oldPasswordBox.MaxLength = 30;
            this.oldPasswordBox.Name = "oldPasswordBox";
            this.oldPasswordBox.Size = new System.Drawing.Size(100, 20);
            this.oldPasswordBox.TabIndex = 3;
            this.oldPasswordBox.UseSystemPasswordChar = true;
            this.oldPasswordBox.TextChanged += new System.EventHandler(this.oldPasswordBox_TextChanged);
            // 
            // newPasswordBox
            // 
            this.newPasswordBox.Location = new System.Drawing.Point(130, 52);
            this.newPasswordBox.MaxLength = 30;
            this.newPasswordBox.Name = "newPasswordBox";
            this.newPasswordBox.Size = new System.Drawing.Size(100, 20);
            this.newPasswordBox.TabIndex = 4;
            this.newPasswordBox.UseSystemPasswordChar = true;
            this.newPasswordBox.TextChanged += new System.EventHandler(this.newPasswordBox_TextChanged);
            // 
            // applyButton
            // 
            this.applyButton.Enabled = false;
            this.applyButton.Location = new System.Drawing.Point(85, 144);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 5;
            this.applyButton.Text = "Patvirtinti";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            this.applyButton.MouseEnter += new System.EventHandler(this.applyButton_MouseEnter);
            this.applyButton.MouseLeave += new System.EventHandler(this.applyButton_MouseLeave);
            // 
            // newPasswordAlert
            // 
            this.newPasswordAlert.AutoSize = true;
            this.newPasswordAlert.Font = new System.Drawing.Font("MS Reference Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.newPasswordAlert.Location = new System.Drawing.Point(124, 75);
            this.newPasswordAlert.Name = "newPasswordAlert";
            this.newPasswordAlert.Size = new System.Drawing.Size(36, 12);
            this.newPasswordAlert.TabIndex = 7;
            this.newPasswordAlert.Text = "label1";
            this.newPasswordAlert.Visible = false;
            // 
            // repeatPasswordLabel
            // 
            this.repeatPasswordLabel.AutoSize = true;
            this.repeatPasswordLabel.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.repeatPasswordLabel.Location = new System.Drawing.Point(5, 92);
            this.repeatPasswordLabel.Name = "repeatPasswordLabel";
            this.repeatPasswordLabel.Size = new System.Drawing.Size(119, 15);
            this.repeatPasswordLabel.TabIndex = 8;
            this.repeatPasswordLabel.Text = "Pakartoti slaptažodį";
            // 
            // repeatPasswordBox
            // 
            this.repeatPasswordBox.Location = new System.Drawing.Point(130, 90);
            this.repeatPasswordBox.MaxLength = 30;
            this.repeatPasswordBox.Name = "repeatPasswordBox";
            this.repeatPasswordBox.Size = new System.Drawing.Size(100, 20);
            this.repeatPasswordBox.TabIndex = 9;
            this.repeatPasswordBox.UseSystemPasswordChar = true;
            this.repeatPasswordBox.TextChanged += new System.EventHandler(this.repeatPasswordBox_TextChanged);
            // 
            // repeatPasswordAlert
            // 
            this.repeatPasswordAlert.AutoSize = true;
            this.repeatPasswordAlert.Font = new System.Drawing.Font("MS Reference Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.repeatPasswordAlert.Location = new System.Drawing.Point(124, 113);
            this.repeatPasswordAlert.Name = "repeatPasswordAlert";
            this.repeatPasswordAlert.Size = new System.Drawing.Size(36, 12);
            this.repeatPasswordAlert.TabIndex = 10;
            this.repeatPasswordAlert.Text = "label2";
            this.repeatPasswordAlert.Visible = false;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 179);
            this.Controls.Add(this.repeatPasswordAlert);
            this.Controls.Add(this.repeatPasswordBox);
            this.Controls.Add(this.repeatPasswordLabel);
            this.Controls.Add(this.newPasswordAlert);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.newPasswordBox);
            this.Controls.Add(this.oldPasswordBox);
            this.Controls.Add(this.newPasswordLabel);
            this.Controls.Add(this.oldPasswordLabel);
            this.MaximizeBox = false;
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label oldPasswordLabel;
        private System.Windows.Forms.Label newPasswordLabel;
        private System.Windows.Forms.TextBox oldPasswordBox;
        private System.Windows.Forms.TextBox newPasswordBox;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label newPasswordAlert;
        private System.Windows.Forms.Label repeatPasswordLabel;
        private System.Windows.Forms.TextBox repeatPasswordBox;
        private System.Windows.Forms.Label repeatPasswordAlert;
    }
}