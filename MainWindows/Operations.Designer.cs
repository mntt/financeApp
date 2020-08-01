namespace financeApp
{
    partial class Operations
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
            this.components = new System.ComponentModel.Container();
            this.operationsBackButton = new System.Windows.Forms.Button();
            this.operationLog = new System.Windows.Forms.DataGridView();
            this.addOperation = new System.Windows.Forms.Button();
            this.saveOperations = new System.Windows.Forms.Button();
            this.operationTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deleteRows = new System.Windows.Forms.Button();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operacija = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Suma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.operationLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operationTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // operationsBackButton
            // 
            this.operationsBackButton.Location = new System.Drawing.Point(12, 415);
            this.operationsBackButton.Name = "operationsBackButton";
            this.operationsBackButton.Size = new System.Drawing.Size(75, 23);
            this.operationsBackButton.TabIndex = 0;
            this.operationsBackButton.Text = "Atgal";
            this.operationsBackButton.UseVisualStyleBackColor = true;
            this.operationsBackButton.Click += new System.EventHandler(this.operationsBackButton_Click);
            this.operationsBackButton.MouseEnter += new System.EventHandler(this.operationsBackButton_MouseEnter);
            this.operationsBackButton.MouseLeave += new System.EventHandler(this.operationsBackButton_MouseLeave);
            // 
            // operationLog
            // 
            this.operationLog.AllowUserToAddRows = false;
            this.operationLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.operationLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data,
            this.Operacija,
            this.Suma,
            this.operationType});
            this.operationLog.Location = new System.Drawing.Point(12, 58);
            this.operationLog.Name = "operationLog";
            this.operationLog.Size = new System.Drawing.Size(776, 351);
            this.operationLog.TabIndex = 1;
            this.operationLog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OperationLog_CellClick);
            this.operationLog.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.OperationLog_CellEndEdit);
            this.operationLog.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.OperationLog_CellEnter);
            this.operationLog.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.OperationLog_CellFormatting);
            this.operationLog.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.OperationLog_EditingControlShowing);
            this.operationLog.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OperationLog_KeyPress);
            this.operationLog.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OperationLog_MouseUp);
            // 
            // addOperation
            // 
            this.addOperation.Location = new System.Drawing.Point(12, 12);
            this.addOperation.Name = "addOperation";
            this.addOperation.Size = new System.Drawing.Size(122, 40);
            this.addOperation.TabIndex = 2;
            this.addOperation.Text = "Pridėti operaciją";
            this.addOperation.UseVisualStyleBackColor = true;
            this.addOperation.Click += new System.EventHandler(this.addOperation_Click);
            this.addOperation.MouseEnter += new System.EventHandler(this.addOperation_MouseEnter);
            this.addOperation.MouseLeave += new System.EventHandler(this.addOperation_MouseLeave);
            // 
            // saveOperations
            // 
            this.saveOperations.Enabled = false;
            this.saveOperations.Location = new System.Drawing.Point(645, 12);
            this.saveOperations.Name = "saveOperations";
            this.saveOperations.Size = new System.Drawing.Size(122, 40);
            this.saveOperations.TabIndex = 3;
            this.saveOperations.Text = "Išsaugoti duomenis";
            this.saveOperations.UseVisualStyleBackColor = true;
            this.saveOperations.Click += new System.EventHandler(this.saveOperations_Click);
            this.saveOperations.MouseEnter += new System.EventHandler(this.saveOperations_MouseEnter);
            this.saveOperations.MouseLeave += new System.EventHandler(this.saveOperations_MouseLeave);
            // 
            // operationTypesBindingSource
            // 
            this.operationTypesBindingSource.DataSource = typeof(financeApp.OperationTypes);
            // 
            // deleteRows
            // 
            this.deleteRows.Enabled = false;
            this.deleteRows.Location = new System.Drawing.Point(140, 12);
            this.deleteRows.Name = "deleteRows";
            this.deleteRows.Size = new System.Drawing.Size(122, 40);
            this.deleteRows.TabIndex = 8;
            this.deleteRows.Text = "Ištrinti eilute(s)";
            this.deleteRows.UseVisualStyleBackColor = true;
            this.deleteRows.Click += new System.EventHandler(this.deleteRows_Click);
            this.deleteRows.MouseEnter += new System.EventHandler(this.deleteRows_MouseEnter);
            this.deleteRows.MouseLeave += new System.EventHandler(this.deleteRows_MouseLeave);
            // 
            // Data
            // 
            this.Data.Frozen = true;
            this.Data.HeaderText = "Data";
            this.Data.MaxInputLength = 10;
            this.Data.Name = "Data";
            this.Data.Width = 90;
            // 
            // Operacija
            // 
            this.Operacija.Frozen = true;
            this.Operacija.HeaderText = "Operacija";
            this.Operacija.MaxInputLength = 1000;
            this.Operacija.Name = "Operacija";
            this.Operacija.Width = 395;
            // 
            // Suma
            // 
            this.Suma.Frozen = true;
            this.Suma.HeaderText = "Suma";
            this.Suma.MaxInputLength = 1000;
            this.Suma.Name = "Suma";
            // 
            // operationType
            // 
            this.operationType.DisplayStyleForCurrentCellOnly = true;
            this.operationType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.operationType.Frozen = true;
            this.operationType.HeaderText = "Tipas";
            this.operationType.MaxDropDownItems = 10;
            this.operationType.Name = "operationType";
            this.operationType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.operationType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.operationType.Width = 150;
            // 
            // Operations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.deleteRows);
            this.Controls.Add(this.saveOperations);
            this.Controls.Add(this.addOperation);
            this.Controls.Add(this.operationLog);
            this.Controls.Add(this.operationsBackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Operations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Operations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Operations_FormClosing);
            this.Load += new System.EventHandler(this.Operations_Load);
            ((System.ComponentModel.ISupportInitialize)(this.operationLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operationTypesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button operationsBackButton;
        private System.Windows.Forms.DataGridView operationLog;
        private System.Windows.Forms.Button addOperation;
        private System.Windows.Forms.Button saveOperations;
        private System.Windows.Forms.BindingSource operationTypesBindingSource;
        private System.Windows.Forms.Button deleteRows;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operacija;
        private System.Windows.Forms.DataGridViewTextBoxColumn Suma;
        private System.Windows.Forms.DataGridViewComboBoxColumn operationType;
    }
}