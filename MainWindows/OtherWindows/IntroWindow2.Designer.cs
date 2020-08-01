namespace financeApp
{
    partial class IntroWindow2
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
            this.startingAccounts = new System.Windows.Forms.DataGridView();
            this.StartingAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finishButton = new System.Windows.Forms.Button();
            this.addAccountButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.startingAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // startingAccounts
            // 
            this.startingAccounts.AllowUserToAddRows = false;
            this.startingAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.startingAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StartingAccount});
            this.startingAccounts.Location = new System.Drawing.Point(24, 51);
            this.startingAccounts.MultiSelect = false;
            this.startingAccounts.Name = "startingAccounts";
            this.startingAccounts.Size = new System.Drawing.Size(250, 138);
            this.startingAccounts.TabIndex = 0;
            this.startingAccounts.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.StartingAccounts_CellEndEdit);
            this.startingAccounts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.StartingAccounts_CellFormatting);
            this.startingAccounts.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.StartingAccounts_EditingControlShowing);
            this.startingAccounts.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StartingAccounts_KeyPress);
            this.startingAccounts.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StartingAccounts_MouseUp);
            // 
            // StartingAccount
            // 
            this.StartingAccount.Frozen = true;
            this.StartingAccount.HeaderText = "Startinis likutis";
            this.StartingAccount.MaxInputLength = 1000;
            this.StartingAccount.Name = "StartingAccount";
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(113, 197);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.TabIndex = 4;
            this.finishButton.Text = "Baigti";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            this.finishButton.MouseEnter += new System.EventHandler(this.finishButton_MouseEnter);
            this.finishButton.MouseLeave += new System.EventHandler(this.finishButton_MouseLeave);
            // 
            // addAccountButton
            // 
            this.addAccountButton.Location = new System.Drawing.Point(104, 7);
            this.addAccountButton.Name = "addAccountButton";
            this.addAccountButton.Size = new System.Drawing.Size(94, 38);
            this.addAccountButton.TabIndex = 7;
            this.addAccountButton.Text = "Pridėti sąskaitą";
            this.addAccountButton.UseVisualStyleBackColor = true;
            this.addAccountButton.Click += new System.EventHandler(this.addAccountButton_Click);
            this.addAccountButton.MouseEnter += new System.EventHandler(this.addAccountButton_MouseEnter);
            this.addAccountButton.MouseLeave += new System.EventHandler(this.addAccountButton_MouseLeave);
            // 
            // IntroWindow2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(299, 232);
            this.Controls.Add(this.addAccountButton);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.startingAccounts);
            this.MaximizeBox = false;
            this.Name = "IntroWindow2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IntroWindow2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IntroWindow2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.startingAccounts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView startingAccounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartingAccount;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Button addAccountButton;
    }
}