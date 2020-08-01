namespace financeApp
{
    partial class OngoingBalance
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
            this.ongoingBalanceBackButton = new System.Windows.Forms.Button();
            this.logOfBalances = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.logOfBalances)).BeginInit();
            this.SuspendLayout();
            // 
            // ongoingBalanceBackButton
            // 
            this.ongoingBalanceBackButton.Location = new System.Drawing.Point(12, 415);
            this.ongoingBalanceBackButton.Name = "ongoingBalanceBackButton";
            this.ongoingBalanceBackButton.Size = new System.Drawing.Size(75, 23);
            this.ongoingBalanceBackButton.TabIndex = 0;
            this.ongoingBalanceBackButton.Text = "Atgal";
            this.ongoingBalanceBackButton.UseVisualStyleBackColor = true;
            this.ongoingBalanceBackButton.Click += new System.EventHandler(this.OngoingBalanceBackButton_Click);
            this.ongoingBalanceBackButton.MouseEnter += new System.EventHandler(this.OngoingBalanceBackButton_MouseEnter);
            this.ongoingBalanceBackButton.MouseLeave += new System.EventHandler(this.OngoingBalanceBackButton_MouseLeave);
            // 
            // logOfBalances
            // 
            this.logOfBalances.AllowUserToAddRows = false;
            this.logOfBalances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.logOfBalances.Location = new System.Drawing.Point(12, 69);
            this.logOfBalances.Name = "logOfBalances";
            this.logOfBalances.ReadOnly = true;
            this.logOfBalances.Size = new System.Drawing.Size(776, 300);
            this.logOfBalances.TabIndex = 1;
            this.logOfBalances.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LogOfBalances_CellClick);
            this.logOfBalances.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LogOfBalances_MouseUp);
            // 
            // OngoingBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.logOfBalances);
            this.Controls.Add(this.ongoingBalanceBackButton);
            this.MaximizeBox = false;
            this.Name = "OngoingBalance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OngoingBalance";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OngoingBalance_FormClosing);
            this.Load += new System.EventHandler(this.OngoingBalance_Load);
            this.Shown += new System.EventHandler(this.OngoingBalance_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.logOfBalances)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ongoingBalanceBackButton;
        private System.Windows.Forms.DataGridView logOfBalances;
    }
}