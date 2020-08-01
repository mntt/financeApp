namespace financeApp
{
    partial class ChangingAccountName
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
            this.applyButton = new System.Windows.Forms.Button();
            this.text1 = new System.Windows.Forms.Label();
            this.text2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // accountName
            // 
            this.accountName.Location = new System.Drawing.Point(45, 77);
            this.accountName.MaxLength = 30;
            this.accountName.Name = "accountName";
            this.accountName.Size = new System.Drawing.Size(172, 20);
            this.accountName.TabIndex = 0;
            this.accountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(93, 114);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 2;
            this.applyButton.Text = "Taikyti";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // text1
            // 
            this.text1.AutoSize = true;
            this.text1.Location = new System.Drawing.Point(41, 24);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(156, 13);
            this.text1.TabIndex = 3;
            this.text1.Text = "Įveskite sąskaitos pavadinimą ir";
            // 
            // text2
            // 
            this.text2.AutoSize = true;
            this.text2.Location = new System.Drawing.Point(72, 46);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(96, 13);
            this.text2.TabIndex = 4;
            this.text2.Text = "spauskite \"Taikyti\"";
            // 
            // ChangingAccountName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(263, 161);
            this.Controls.Add(this.text2);
            this.Controls.Add(this.text1);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.accountName);
            this.MaximizeBox = false;
            this.Name = "ChangingAccountName";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangingAccountName";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox accountName;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label text1;
        private System.Windows.Forms.Label text2;
    }
}