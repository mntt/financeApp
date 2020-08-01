namespace financeApp
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.operationsButton = new System.Windows.Forms.Button();
            this.ongoingBalanceButton = new System.Windows.Forms.Button();
            this.planBalancesButton = new System.Windows.Forms.Button();
            this.accountsButton = new System.Windows.Forms.Button();
            this.name = new System.Windows.Forms.Label();
            this.numberOfNotifications = new System.Windows.Forms.Label();
            this.notificationsBox = new System.Windows.Forms.RichTextBox();
            this.accountName = new System.Windows.Forms.Label();
            this.currentBalance = new System.Windows.Forms.Label();
            this.userButton = new System.Windows.Forms.Button();
            this.notificationsButton = new System.Windows.Forms.Button();
            this.userPanel = new System.Windows.Forms.Panel();
            this.logOut = new System.Windows.Forms.Label();
            this.changePassword = new System.Windows.Forms.Label();
            this.userPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // operationsButton
            // 
            this.operationsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.operationsButton.Location = new System.Drawing.Point(104, 99);
            this.operationsButton.Name = "operationsButton";
            this.operationsButton.Size = new System.Drawing.Size(155, 38);
            this.operationsButton.TabIndex = 0;
            this.operationsButton.Text = "Operacijos";
            this.operationsButton.UseVisualStyleBackColor = true;
            this.operationsButton.Click += new System.EventHandler(this.OperationsButton_Click);
            this.operationsButton.MouseEnter += new System.EventHandler(this.OperationsButton_MouseEnter);
            this.operationsButton.MouseLeave += new System.EventHandler(this.OperationsButton_MouseLeave);
            // 
            // ongoingBalanceButton
            // 
            this.ongoingBalanceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ongoingBalanceButton.Location = new System.Drawing.Point(104, 143);
            this.ongoingBalanceButton.Name = "ongoingBalanceButton";
            this.ongoingBalanceButton.Size = new System.Drawing.Size(155, 38);
            this.ongoingBalanceButton.TabIndex = 1;
            this.ongoingBalanceButton.Text = "Einamojo mėnesio biudžetas";
            this.ongoingBalanceButton.UseVisualStyleBackColor = true;
            this.ongoingBalanceButton.Click += new System.EventHandler(this.OngoingBalanceButton_Click);
            this.ongoingBalanceButton.MouseEnter += new System.EventHandler(this.OngoingBalanceButton_MouseEnter);
            this.ongoingBalanceButton.MouseLeave += new System.EventHandler(this.OngoingBalanceButton_MouseLeave);
            // 
            // planBalancesButton
            // 
            this.planBalancesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.planBalancesButton.Location = new System.Drawing.Point(104, 187);
            this.planBalancesButton.Name = "planBalancesButton";
            this.planBalancesButton.Size = new System.Drawing.Size(155, 38);
            this.planBalancesButton.TabIndex = 2;
            this.planBalancesButton.Text = "Planuoti biudžetus";
            this.planBalancesButton.UseVisualStyleBackColor = true;
            this.planBalancesButton.Click += new System.EventHandler(this.PlanBalancesButton_Click);
            this.planBalancesButton.MouseEnter += new System.EventHandler(this.PlanBalancesButton_MouseEnter);
            this.planBalancesButton.MouseLeave += new System.EventHandler(this.PlanBalancesButton_MouseLeave);
            // 
            // accountsButton
            // 
            this.accountsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.accountsButton.Location = new System.Drawing.Point(104, 55);
            this.accountsButton.Name = "accountsButton";
            this.accountsButton.Size = new System.Drawing.Size(155, 38);
            this.accountsButton.TabIndex = 4;
            this.accountsButton.Text = "Sąskaitos ir pinigų likučiai";
            this.accountsButton.UseVisualStyleBackColor = true;
            this.accountsButton.Click += new System.EventHandler(this.AccountsButton_Click);
            this.accountsButton.MouseEnter += new System.EventHandler(this.AccountsButton_MouseEnter);
            this.accountsButton.MouseLeave += new System.EventHandler(this.AccountsButton_MouseLeave);
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Segoe UI Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.name.Location = new System.Drawing.Point(98, 9);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(166, 32);
            this.name.TabIndex = 5;
            this.name.Text = "Finansų appsas";
            // 
            // numberOfNotifications
            // 
            this.numberOfNotifications.AutoSize = true;
            this.numberOfNotifications.BackColor = System.Drawing.Color.Red;
            this.numberOfNotifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.numberOfNotifications.Location = new System.Drawing.Point(41, 20);
            this.numberOfNotifications.Name = "numberOfNotifications";
            this.numberOfNotifications.Size = new System.Drawing.Size(0, 9);
            this.numberOfNotifications.TabIndex = 8;
            // 
            // notificationsBox
            // 
            this.notificationsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.notificationsBox.Location = new System.Drawing.Point(32, 35);
            this.notificationsBox.Name = "notificationsBox";
            this.notificationsBox.ReadOnly = true;
            this.notificationsBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.notificationsBox.Size = new System.Drawing.Size(302, 91);
            this.notificationsBox.TabIndex = 10;
            this.notificationsBox.Text = "";
            this.notificationsBox.Visible = false;
            // 
            // accountName
            // 
            this.accountName.AutoSize = true;
            this.accountName.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.accountName.Location = new System.Drawing.Point(35, 11);
            this.accountName.Name = "accountName";
            this.accountName.Size = new System.Drawing.Size(62, 15);
            this.accountName.TabIndex = 11;
            this.accountName.Text = "Paskyra: ";
            // 
            // currentBalance
            // 
            this.currentBalance.AutoSize = true;
            this.currentBalance.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.currentBalance.Location = new System.Drawing.Point(10, 28);
            this.currentBalance.Name = "currentBalance";
            this.currentBalance.Size = new System.Drawing.Size(87, 15);
            this.currentBalance.TabIndex = 12;
            this.currentBalance.Text = "Pinigų likutis: ";
            // 
            // userButton
            // 
            this.userButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("userButton.BackgroundImage")));
            this.userButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userButton.FlatAppearance.BorderSize = 0;
            this.userButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.userButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.userButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.userButton.Location = new System.Drawing.Point(283, 12);
            this.userButton.Name = "userButton";
            this.userButton.Size = new System.Drawing.Size(66, 37);
            this.userButton.TabIndex = 14;
            this.userButton.UseVisualStyleBackColor = true;
            this.userButton.Click += new System.EventHandler(this.userButton_Click);
            this.userButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.userButton_MouseDown);
            this.userButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.userButton_MouseUp);
            // 
            // notificationsButton
            // 
            this.notificationsButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.notificationsButton.BackgroundImage = global::financeApp.Properties.Resources.bell;
            this.notificationsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.notificationsButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.notificationsButton.FlatAppearance.BorderSize = 0;
            this.notificationsButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.notificationsButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.notificationsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.notificationsButton.Location = new System.Drawing.Point(12, 12);
            this.notificationsButton.Name = "notificationsButton";
            this.notificationsButton.Size = new System.Drawing.Size(45, 37);
            this.notificationsButton.TabIndex = 7;
            this.notificationsButton.UseVisualStyleBackColor = false;
            this.notificationsButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NotificationsButton_MouseDown);
            this.notificationsButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.NotificationsButton_MouseUp);
            // 
            // userPanel
            // 
            this.userPanel.BackColor = System.Drawing.SystemColors.Control;
            this.userPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.userPanel.Controls.Add(this.logOut);
            this.userPanel.Controls.Add(this.changePassword);
            this.userPanel.Controls.Add(this.accountName);
            this.userPanel.Controls.Add(this.currentBalance);
            this.userPanel.Location = new System.Drawing.Point(149, 26);
            this.userPanel.Name = "userPanel";
            this.userPanel.Size = new System.Drawing.Size(172, 100);
            this.userPanel.TabIndex = 15;
            this.userPanel.Visible = false;
            // 
            // logOut
            // 
            this.logOut.AutoSize = true;
            this.logOut.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.logOut.Location = new System.Drawing.Point(56, 75);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(60, 15);
            this.logOut.TabIndex = 14;
            this.logOut.Text = "Atsijungti";
            this.logOut.MouseClick += new System.Windows.Forms.MouseEventHandler(this.logOut_MouseClick);
            this.logOut.MouseEnter += new System.EventHandler(this.logOut_MouseEnter);
            this.logOut.MouseLeave += new System.EventHandler(this.logOut_MouseLeave);
            // 
            // changePassword
            // 
            this.changePassword.AutoSize = true;
            this.changePassword.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.changePassword.Location = new System.Drawing.Point(28, 57);
            this.changePassword.Name = "changePassword";
            this.changePassword.Size = new System.Drawing.Size(112, 15);
            this.changePassword.TabIndex = 13;
            this.changePassword.Text = "Pakeisti slaptažodį";
            this.changePassword.MouseClick += new System.Windows.Forms.MouseEventHandler(this.changePassword_MouseClick);
            this.changePassword.MouseEnter += new System.EventHandler(this.changePassword_MouseEnter);
            this.changePassword.MouseLeave += new System.EventHandler(this.changePassword_MouseLeave);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(361, 284);
            this.Controls.Add(this.userPanel);
            this.Controls.Add(this.notificationsBox);
            this.Controls.Add(this.userButton);
            this.Controls.Add(this.numberOfNotifications);
            this.Controls.Add(this.name);
            this.Controls.Add(this.accountsButton);
            this.Controls.Add(this.planBalancesButton);
            this.Controls.Add(this.ongoingBalanceButton);
            this.Controls.Add(this.operationsButton);
            this.Controls.Add(this.notificationsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.VisibleChanged += new System.EventHandler(this.Menu_VisibleChanged);
            this.Click += new System.EventHandler(this.Menu_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Menu_Paint);
            this.userPanel.ResumeLayout(false);
            this.userPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button operationsButton;
        private System.Windows.Forms.Button ongoingBalanceButton;
        private System.Windows.Forms.Button planBalancesButton;
        private System.Windows.Forms.Button accountsButton;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Button notificationsButton;
        private System.Windows.Forms.Label numberOfNotifications;
        private System.Windows.Forms.RichTextBox notificationsBox;
        private System.Windows.Forms.Label accountName;
        private System.Windows.Forms.Label currentBalance;
        private System.Windows.Forms.Button userButton;
        private System.Windows.Forms.Panel userPanel;
        private System.Windows.Forms.Label changePassword;
        private System.Windows.Forms.Label logOut;
    }
}

