namespace financeApp
{
    partial class BudgetPlanning
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
            this.budgetPlanningBackButton = new System.Windows.Forms.Button();
            this.budgetPlanningLog = new System.Windows.Forms.DataGridView();
            this.saveDataButton = new System.Windows.Forms.Button();
            this.text1 = new System.Windows.Forms.Label();
            this.text2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.budgetPlanningLog)).BeginInit();
            this.SuspendLayout();
            // 
            // budgetPlanningBackButton
            // 
            this.budgetPlanningBackButton.Location = new System.Drawing.Point(12, 415);
            this.budgetPlanningBackButton.Name = "budgetPlanningBackButton";
            this.budgetPlanningBackButton.Size = new System.Drawing.Size(75, 23);
            this.budgetPlanningBackButton.TabIndex = 1;
            this.budgetPlanningBackButton.Text = "Atgal";
            this.budgetPlanningBackButton.UseVisualStyleBackColor = true;
            this.budgetPlanningBackButton.Click += new System.EventHandler(this.BudgetPlanningBackButton_Click);
            this.budgetPlanningBackButton.MouseEnter += new System.EventHandler(this.BudgetPlanningBackButton_MouseEnter);
            this.budgetPlanningBackButton.MouseLeave += new System.EventHandler(this.BudgetPlanningBackButton_MouseLeave);
            // 
            // budgetPlanningLog
            // 
            this.budgetPlanningLog.AllowUserToAddRows = false;
            this.budgetPlanningLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.budgetPlanningLog.Location = new System.Drawing.Point(12, 82);
            this.budgetPlanningLog.Name = "budgetPlanningLog";
            this.budgetPlanningLog.Size = new System.Drawing.Size(776, 300);
            this.budgetPlanningLog.TabIndex = 2;
            this.budgetPlanningLog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BudgetPlanningLog_CellClick);
            this.budgetPlanningLog.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.BudgetPlanningLog_CellEndEdit);
            this.budgetPlanningLog.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.BudgetPlanningLog_CellEnter);
            this.budgetPlanningLog.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.BudgetPlanningLog_CellFormatting);
            this.budgetPlanningLog.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BudgetPlanningLog_ColumnHeaderMouseClick);
            this.budgetPlanningLog.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.BudgetPlanningLog_EditingControlShowing);
            this.budgetPlanningLog.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BudgetPlanningLog_KeyPress);
            this.budgetPlanningLog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BudgetPlanningLog_MouseUp);
            // 
            // saveDataButton
            // 
            this.saveDataButton.Enabled = false;
            this.saveDataButton.Location = new System.Drawing.Point(689, 12);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(99, 47);
            this.saveDataButton.TabIndex = 3;
            this.saveDataButton.Text = "Išsaugoti duomenis";
            this.saveDataButton.UseVisualStyleBackColor = true;
            this.saveDataButton.EnabledChanged += new System.EventHandler(this.saveDataButton_EnabledChanged);
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
            this.saveDataButton.MouseEnter += new System.EventHandler(this.saveDataButton_MouseEnter);
            this.saveDataButton.MouseLeave += new System.EventHandler(this.saveDataButton_MouseLeave);
            // 
            // text1
            // 
            this.text1.AutoSize = true;
            this.text1.Location = new System.Drawing.Point(252, 66);
            this.text1.Name = "text1";
            this.text1.Size = new System.Drawing.Size(90, 13);
            this.text1.TabIndex = 5;
            this.text1.Text = "Einamieji balansai";
            // 
            // text2
            // 
            this.text2.AutoSize = true;
            this.text2.Location = new System.Drawing.Point(358, 66);
            this.text2.Name = "text2";
            this.text2.Size = new System.Drawing.Size(256, 13);
            this.text2.TabIndex = 6;
            this.text2.Text = "--------------------------Planuojami balansai--------------------------";
            // 
            // BudgetPlanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.text2);
            this.Controls.Add(this.text1);
            this.Controls.Add(this.saveDataButton);
            this.Controls.Add(this.budgetPlanningLog);
            this.Controls.Add(this.budgetPlanningBackButton);
            this.MaximizeBox = false;
            this.Name = "BudgetPlanning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BudgetPlanning";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BudgetPlanning_FormClosing);
            this.Load += new System.EventHandler(this.BudgetPlanning_Load);
            this.Shown += new System.EventHandler(this.BudgetPlanning_Shown);
            this.Click += new System.EventHandler(this.BudgetPlanning_Click);
            ((System.ComponentModel.ISupportInitialize)(this.budgetPlanningLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button budgetPlanningBackButton;
        private System.Windows.Forms.DataGridView budgetPlanningLog;
        private System.Windows.Forms.Button saveDataButton;
        private System.Windows.Forms.Label text1;
        private System.Windows.Forms.Label text2;
    }
}