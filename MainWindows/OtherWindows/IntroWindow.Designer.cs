namespace financeApp
{
    partial class IntroWindow
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
            this.greetings = new System.Windows.Forms.Label();
            this.introNextButton = new System.Windows.Forms.Button();
            this.text1 = new System.Windows.Forms.Label();
            this.text2 = new System.Windows.Forms.Label();
            this.text3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // greetings
            // 
            this.greetings.AutoSize = true;
            this.greetings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.greetings.Location = new System.Drawing.Point(33, 38);
            this.greetings.Name = "greetings";
            this.greetings.Size = new System.Drawing.Size(241, 17);
            this.greetings.TabIndex = 0;
            this.greetings.Text = "Sveiki prisijungę prie Finansų app\'so!";
            // 
            // introNextButton
            // 
            this.introNextButton.Location = new System.Drawing.Point(110, 156);
            this.introNextButton.Name = "introNextButton";
            this.introNextButton.Size = new System.Drawing.Size(75, 23);
            this.introNextButton.TabIndex = 6;
            this.introNextButton.Text = "Toliau";
            this.introNextButton.UseVisualStyleBackColor = true;
            this.introNextButton.Click += new System.EventHandler(this.introNextButton_Click);
            this.introNextButton.MouseEnter += new System.EventHandler(this.introNextButton_MouseEnter);
            this.introNextButton.MouseLeave += new System.EventHandler(this.introNextButton_MouseLeave);
            // 
            // text1
            // 
            this.text1.AutoSize = true;
            this.text1.Location = new System.Drawing.Point(27, 66);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(209, 13);
            this.text1.TabIndex = 7;
            this.text1.Text = "Norint pradėti naudotis app\'su, reikia pridėti";
            // 
            // text2
            // 
            this.text2.AutoSize = true;
            this.text2.Location = new System.Drawing.Point(30, 88);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(196, 13);
            this.text2.TabIndex = 8;
            this.text2.Text = "savo turimas sąskaitas ir startinius pinigų";
            // 
            // text3
            // 
            this.text3.AutoSize = true;
            this.text3.Location = new System.Drawing.Point(123, 111);
            this.text3.Name = "text3";
            this.text3.Size = new System.Drawing.Size(45, 13);
            this.text3.TabIndex = 9;
            this.text3.Text = "likučius.";
            // 
            // IntroWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(305, 232);
            this.Controls.Add(this.text3);
            this.Controls.Add(this.text2);
            this.Controls.Add(this.text1);
            this.Controls.Add(this.introNextButton);
            this.Controls.Add(this.greetings);
            this.MaximizeBox = false;
            this.Name = "IntroWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IntroWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label greetings;
        private System.Windows.Forms.Button introNextButton;
        private System.Windows.Forms.Label text1;
        private System.Windows.Forms.Label text2;
        private System.Windows.Forms.Label text3;
    }
}