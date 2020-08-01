namespace financeApp
{
    partial class Accounts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.accountsTable = new System.Windows.Forms.DataGridView();
            this.addAccountButton = new System.Windows.Forms.Button();
            this.saveDataButton = new System.Windows.Forms.Button();
            this.accountsBackButton = new System.Windows.Forms.Button();
            this.deleteAccount = new System.Windows.Forms.Button();
            this.waitingText = new System.Windows.Forms.Label();
            this.changeNameButton = new System.Windows.Forms.Button();
            this.totalSumTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.accountsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalSumTable)).BeginInit();
            this.SuspendLayout();
            // 
            // accountsTable
            // 
            this.accountsTable.AllowUserToAddRows = false;
            dataGridViewCellStyle1.NullValue = null;
            this.accountsTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.accountsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.accountsTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.accountsTable.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.accountsTable.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS Reference Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.accountsTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.accountsTable.ColumnHeadersHeight = 15;
            this.accountsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.accountsTable.EnableHeadersVisualStyles = false;
            this.accountsTable.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.accountsTable.Location = new System.Drawing.Point(12, 58);
            this.accountsTable.MultiSelect = false;
            this.accountsTable.Name = "accountsTable";
            this.accountsTable.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.accountsTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.accountsTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            dataGridViewCellStyle4.NullValue = null;
            this.accountsTable.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.accountsTable.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.accountsTable.Size = new System.Drawing.Size(776, 279);
            this.accountsTable.TabIndex = 1;
            this.accountsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AccountsTable_CellClick);
            this.accountsTable.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.AccountsTable_CellEndEdit);
            this.accountsTable.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.AccountsTable_CellEnter);
            this.accountsTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.AccountsTable_CellFormatting);
            this.accountsTable.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.AccountsTable_ColumnHeaderMouseClick);
            this.accountsTable.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.AccountsTable_EditingControlShowing);
            this.accountsTable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AccountsTable_KeyPress);
            this.accountsTable.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AccountsTable_MouseUp);
            // 
            // addAccountButton
            // 
            this.addAccountButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addAccountButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.addAccountButton.Location = new System.Drawing.Point(12, 15);
            this.addAccountButton.Name = "addAccountButton";
            this.addAccountButton.Size = new System.Drawing.Size(82, 38);
            this.addAccountButton.TabIndex = 6;
            this.addAccountButton.Text = "Pridėti sąskaitą";
            this.addAccountButton.UseVisualStyleBackColor = true;
            this.addAccountButton.Click += new System.EventHandler(this.addAccountButton_Click);
            this.addAccountButton.MouseEnter += new System.EventHandler(this.addAccountButton_MouseEnter);
            this.addAccountButton.MouseLeave += new System.EventHandler(this.addAccountButton_MouseLeave);
            // 
            // saveDataButton
            // 
            this.saveDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveDataButton.ForeColor = System.Drawing.Color.Black;
            this.saveDataButton.Location = new System.Drawing.Point(689, 5);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(99, 47);
            this.saveDataButton.TabIndex = 10;
            this.saveDataButton.Text = "Išsaugoti duomenis";
            this.saveDataButton.UseVisualStyleBackColor = true;
            this.saveDataButton.EnabledChanged += new System.EventHandler(this.saveDataButton_EnabledChanged);
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
            this.saveDataButton.MouseEnter += new System.EventHandler(this.saveDataButton_MouseEnter);
            this.saveDataButton.MouseLeave += new System.EventHandler(this.saveDataButton_MouseLeave);
            // 
            // accountsBackButton
            // 
            this.accountsBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accountsBackButton.Location = new System.Drawing.Point(12, 415);
            this.accountsBackButton.Name = "accountsBackButton";
            this.accountsBackButton.Size = new System.Drawing.Size(75, 23);
            this.accountsBackButton.TabIndex = 11;
            this.accountsBackButton.Text = "Atgal";
            this.accountsBackButton.UseVisualStyleBackColor = true;
            this.accountsBackButton.Click += new System.EventHandler(this.accountsBackButton_Click);
            this.accountsBackButton.MouseEnter += new System.EventHandler(this.accountsBackButton_MouseEnter);
            this.accountsBackButton.MouseLeave += new System.EventHandler(this.accountsBackButton_MouseLeave);
            // 
            // deleteAccount
            // 
            this.deleteAccount.Enabled = false;
            this.deleteAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteAccount.Location = new System.Drawing.Point(100, 15);
            this.deleteAccount.Name = "deleteAccount";
            this.deleteAccount.Size = new System.Drawing.Size(82, 38);
            this.deleteAccount.TabIndex = 16;
            this.deleteAccount.Text = "Ištrinti sąskaitą";
            this.deleteAccount.UseVisualStyleBackColor = true;
            this.deleteAccount.Click += new System.EventHandler(this.deleteAccount_Click);
            this.deleteAccount.MouseEnter += new System.EventHandler(this.deleteAccount_MouseEnter);
            this.deleteAccount.MouseLeave += new System.EventHandler(this.deleteAccount_MouseLeave);
            // 
            // waitingText
            // 
            this.waitingText.AutoSize = true;
            this.waitingText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.waitingText.Location = new System.Drawing.Point(262, 210);
            this.waitingText.Name = "waitingText";
            this.waitingText.Size = new System.Drawing.Size(84, 37);
            this.waitingText.TabIndex = 19;
            this.waitingText.Text = "label";
            this.waitingText.Visible = false;
            // 
            // changeNameButton
            // 
            this.changeNameButton.Enabled = false;
            this.changeNameButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.changeNameButton.Location = new System.Drawing.Point(188, 15);
            this.changeNameButton.Name = "changeNameButton";
            this.changeNameButton.Size = new System.Drawing.Size(82, 38);
            this.changeNameButton.TabIndex = 20;
            this.changeNameButton.Text = "Pakeisti pavadinimą";
            this.changeNameButton.UseVisualStyleBackColor = true;
            this.changeNameButton.Click += new System.EventHandler(this.changeNameButton_Click);
            this.changeNameButton.MouseEnter += new System.EventHandler(this.changeNameButton_MouseEnter);
            this.changeNameButton.MouseLeave += new System.EventHandler(this.changeNameButton_MouseLeave);
            // 
            // totalSumTable
            // 
            this.totalSumTable.AllowUserToAddRows = false;
            this.totalSumTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.totalSumTable.DefaultCellStyle = dataGridViewCellStyle5;
            this.totalSumTable.Location = new System.Drawing.Point(12, 334);
            this.totalSumTable.MultiSelect = false;
            this.totalSumTable.Name = "totalSumTable";
            this.totalSumTable.ReadOnly = true;
            this.totalSumTable.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.totalSumTable.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.totalSumTable.Size = new System.Drawing.Size(776, 75);
            this.totalSumTable.TabIndex = 21;
            this.totalSumTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TotalSumTable_CellClick);
            this.totalSumTable.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.TotalSumTable_CellEnter);
            this.totalSumTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.TotalSumTable_CellFormatting);
            this.totalSumTable.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TotalSumTable_MouseUp);
            // 
            // Accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.totalSumTable);
            this.Controls.Add(this.changeNameButton);
            this.Controls.Add(this.waitingText);
            this.Controls.Add(this.deleteAccount);
            this.Controls.Add(this.accountsBackButton);
            this.Controls.Add(this.saveDataButton);
            this.Controls.Add(this.addAccountButton);
            this.Controls.Add(this.accountsTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Accounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Accounts";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Accounts_FormClosing);
            this.Load += new System.EventHandler(this.Accounts_Load);
            this.Shown += new System.EventHandler(this.Accounts_Shown);
            this.Click += new System.EventHandler(this.Accounts_Click);
            ((System.ComponentModel.ISupportInitialize)(this.accountsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalSumTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView accountsTable;
        private System.Windows.Forms.Button addAccountButton;
        private System.Windows.Forms.Button saveDataButton;
        private System.Windows.Forms.Button accountsBackButton;
        private System.Windows.Forms.Button deleteAccount;
        private System.Windows.Forms.Label waitingText;
        private System.Windows.Forms.Button changeNameButton;
        private System.Windows.Forms.DataGridView totalSumTable;
    }
}