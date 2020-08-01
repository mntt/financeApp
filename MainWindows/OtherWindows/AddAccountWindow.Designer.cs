namespace financeApp
{
    partial class AddAccountWindow
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
            this.accountName = new System.Windows.Forms.TextBox();
            this.addAccountButton = new System.Windows.Forms.Button();
            this.text = new System.Windows.Forms.Label();
            this.text2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accountName
            // 
            this.accountName.Location = new System.Drawing.Point(46, 79);
            this.accountName.MaxLength = 30;
            this.accountName.Name = "accountName";
            this.accountName.Size = new System.Drawing.Size(172, 20);
            this.accountName.TabIndex = 3;
            this.accountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // addAccountButton
            // 
            this.addAccountButton.Location = new System.Drawing.Point(94, 126);
            this.addAccountButton.Name = "addAccountButton";
            this.addAccountButton.Size = new System.Drawing.Size(75, 23);
            this.addAccountButton.TabIndex = 4;
            this.addAccountButton.Text = "Pridėti";
            this.addAccountButton.UseVisualStyleBackColor = true;
            this.addAccountButton.Click += new System.EventHandler(this.addAccountButton_Click);
            this.addAccountButton.MouseEnter += new System.EventHandler(this.addAccountButton_MouseEnter);
            this.addAccountButton.MouseLeave += new System.EventHandler(this.addAccountButton_MouseLeave);
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Location = new System.Drawing.Point(41, 24);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(150, 13);
            this.text.TabIndex = 5;
            this.text.Text = "Įrašykite sąskaitos pavadinimą";
            // 
            // text2
            // 
            this.text2.AutoSize = true;
            this.text2.Location = new System.Drawing.Point(72, 46);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(101, 13);
            this.text2.TabIndex = 6;
            this.text2.Text = "ir spauskite \"pridėti\"";
            // 
            // AddAccountWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(263, 161);
            this.Controls.Add(this.text2);
            this.Controls.Add(this.text);
            this.Controls.Add(this.addAccountButton);
            this.Controls.Add(this.accountName);
            this.MaximizeBox = false;
            this.Name = "AddAccountWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddAccountWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox accountName;
        private System.Windows.Forms.Button addAccountButton;
        private System.Windows.Forms.Label text;
        private System.Windows.Forms.Label text2;
    }
}