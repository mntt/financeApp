using financeApp.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace financeApp
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            SetStylesAndLooks();
            StopAllTabs();
            ShowAdditionalInfo();
        }

        private void StopAllTabs()
        {
            StopTab(accountsButton);
            StopTab(operationsButton);
            StopTab(ongoingBalanceButton);
            StopTab(planBalancesButton);
        }

        private void ShowAdditionalInfo()
        {
            accountName.Text = "Paskyra: ";
            currentBalance.Text = "Pinigų likutis: ";

            Balances balances = new Balances();

            var user = Connection.db.GetTable<UsernameAndPassword>()
                .Where(x => x.Id == User.ID).Select(x => x.Username).ToList();
            accountName.Text += user[0];
            currentBalance.Text += balances.ReturnCurrentBalance().ToString("C2");
        }

        private void StopTab(Button button)
        {
            button.TabStop = false;
        }

        private void SetNotifications()
        {
            var uncheckedNotifications = Connection.db.GetTable<NotificationsTable>()
                .Where(x => x.IsChecked == 0 && x.UserId == User.ID).OrderByDescending(x => x.Date).ToList();

            if (uncheckedNotifications.Count > 0)
            {
                ExecuteIfNotificationsFound(uncheckedNotifications);
            }
            else if(uncheckedNotifications.Count == 0)
            {
                ExecuteIfZeroNotifications();      
            }
        }

        private void ExecuteIfNotificationsFound(List<NotificationsTable> uncheckedNotifications)
        {
            notificationsButton.BackgroundImage = Resources.bell_notification;
            numberOfNotifications.Visible = true;
            numberOfNotifications.Text = uncheckedNotifications.Count.ToString();

            foreach (var item in uncheckedNotifications)
            {
                notificationsBox.SelectionFont = new Font(notificationsBox.Font, FontStyle.Bold);
                notificationsBox.AppendText(item.Date.ToString("yyyy-MM-dd HH:mm"));
                notificationsBox.AppendText(Environment.NewLine);
                notificationsBox.SelectionFont = new Font(notificationsBox.Font, FontStyle.Bold);
                notificationsBox.AppendText(item.Notification + "\n");
                notificationsBox.AppendText(Environment.NewLine);
            }

            var checkedNotifications = Connection.db.GetTable<NotificationsTable>()
                .Where(x => x.IsChecked == 1 && x.UserId == User.ID).OrderByDescending(x => x.Date).ToList();

            foreach (var item in checkedNotifications)
            {
                notificationsBox.SelectionFont = new Font(notificationsBox.Font, FontStyle.Regular);
                notificationsBox.AppendText(item.Date.ToString("yyyy-MM-dd HH:mm"));
                notificationsBox.AppendText(Environment.NewLine);
                notificationsBox.AppendText(item.Notification + "\n");
                notificationsBox.AppendText(Environment.NewLine);
            }
        }

        private void ExecuteIfZeroNotifications()
        {
            notificationsButton.BackgroundImage = Resources.bell;
            numberOfNotifications.Visible = false;

            var checkedNotifications = Connection.db.GetTable<NotificationsTable>()
                .Where(x => x.IsChecked == 1 && x.UserId == User.ID).OrderByDescending(x => x.Date).ToList();

            if (checkedNotifications.Count == 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    notificationsBox.AppendText("");
                    notificationsBox.AppendText(Environment.NewLine);
                }
                notificationsBox.SelectionFont = new Font(notificationsBox.Font, FontStyle.Italic);
                notificationsBox.AppendText("Pranešimų nėra.");
                notificationsBox.ForeColor = Color.DarkGray;
                notificationsBox.SelectionAlignment = HorizontalAlignment.Center;
            }
            else if (checkedNotifications.Count > 0)
            {
                foreach (var item in checkedNotifications)
                {
                    notificationsBox.SelectionFont = new Font(notificationsBox.Font, FontStyle.Regular);
                    notificationsBox.AppendText(item.Date.ToString("yyyy-MM-dd HH:mm"));
                    notificationsBox.AppendText(Environment.NewLine);
                    notificationsBox.AppendText(item.Notification + "\n");
                    notificationsBox.AppendText(Environment.NewLine);
                }
            }
        }

        private void AccountsButton_Click(object sender, EventArgs e)
        {       
            if(Connection.CheckConnectivity() == true)
            {
                Accounts formAccounts = new Accounts(this);
                this.Hide();
                formAccounts.Show();
            }         
        }

        private void OperationsButton_Click(object sender, EventArgs e)
        {
            if(Connection.CheckConnectivity() == true)
            {
                var startingDate = Connection.db.GetTable<Dates>()
                                .Where(x => x.Date1 == "Startinis likutis" && x.UserId == User.ID)
                                .Select(x => x.Date1).ToList();

                if (startingDate.Count == 0)
                {
                    MessageBox.Show("Negalima pridėti nei vienos operacijos, kol nebus pridėtas startinis likutis. " +
                        "Pridėkite startinį likutį 'Sąskaitos ir pinigų likučiai' skiltyje.", "Pranešimas");
                }
                else if (startingDate.Count > 0)
                {
                    Operations formOperations = new Operations(this);
                    this.Hide();
                    formOperations.Show();
                }
            }            
        }

        private void OngoingBalanceButton_Click(object sender, EventArgs e)
        {
            if(Connection.CheckConnectivity() == true)
            {
                var startingDate = Connection.db.GetTable<Dates>()
                                .Where(x => x.Date1 == "Startinis likutis" && x.UserId == User.ID)
                                .Select(x => x.Date1).ToList();

                if (startingDate.Count == 0)
                {
                    MessageBox.Show("Negalima suformuoti lentelės, kol nėra sukurtas startinis likutis. " +
                        "Pridėkite startinį likutį 'Sąskaitos ir pinigų likučiai' skiltyje.", "Pranešimas");
                }
                else if (startingDate.Count > 0)
                {
                    OngoingBalance formOngoingBalance = new OngoingBalance(this);
                    this.Hide();
                    formOngoingBalance.Show();
                }
            }            
        }

        private void PlanBalancesButton_Click(object sender, EventArgs e)
        {
            if(Connection.CheckConnectivity() == true)
            {
                var startingDate = Connection.db.GetTable<Dates>()
                                .Where(x => x.Date1 == "Startinis likutis" && x.UserId == User.ID)
                                .Select(x => x.Date1).ToList();

                if (startingDate.Count == 0)
                {
                    MessageBox.Show("Negalima suformuoti lentelės, kol nėra sukurtas startinis likutis. " +
                        "Pridėkite startinį likutį 'Sąskaitos ir pinigų likučiai' skiltyje.", "Pranešimas");
                }
                else if (startingDate.Count > 0)
                {
                    BudgetPlanning formBudgetPlanning = new BudgetPlanning(this);
                    this.Hide();
                    formBudgetPlanning.Show();
                }
            }           
        }

        private void NotificationsButton_MouseDown(object sender, MouseEventArgs e)
        {
            userPanel.Visible = false;

            var notificationsNotChecked = Connection.db.GetTable<NotificationsTable>()
                .Where(x => x.IsChecked == 0 && x.UserId == User.ID).Select(x => x.Notification).ToList();

            if (notificationsBox.Visible == true)
            {
                notificationsBox.Visible = false;
            }
            else if(notificationsBox.Visible == false)
            {
                notificationsBox.Visible = true;
            }

            Connection.iwdb.UpdateNotifications(User.ID);

            if (notificationsNotChecked.Count > 0)
            {
                notificationsButton.BackgroundImage = Resources.bell_notification_pressed;
                numberOfNotifications.Location = new Point(39, 23);
            }
            else if(notificationsNotChecked.Count == 0)
            {
                notificationsBox.Font = new Font(notificationsBox.Font, FontStyle.Regular);
                notificationsButton.BackgroundImage = Resources.bell_pressed;
            } 
        }

        private void NotificationsButton_MouseUp(object sender, MouseEventArgs e)
        {
            var notificationsNotChecked = Connection.db.GetTable<NotificationsTable>()
                .Where(x => x.IsChecked == 0 && x.UserId == User.ID).Select(x => x.Notification).ToList();

            if (notificationsNotChecked.Count > 0)
            {
                notificationsButton.BackgroundImage = Resources.bell_notification;
                numberOfNotifications.Location = new Point(41, 23);
            }
            else if (notificationsNotChecked.Count == 0)
            { 
                notificationsButton.BackgroundImage = Resources.bell;
                numberOfNotifications.Visible = false;
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            SetNotifications();
        }

        private void SetStylesAndLooks()
        {
            Connection.style.SetFormLooks(this);
            Connection.style.SetButtonStyle(accountsButton);
            Connection.style.SetButtonStyle(operationsButton);
            Connection.style.SetButtonStyle(ongoingBalanceButton);
            Connection.style.SetButtonStyle(planBalancesButton);
            Connection.style.SetLabelStyle(name, 15);
            Connection.style.SetRichTextBoxStyle(notificationsBox);
            Connection.style.SetLabelStyle(accountName, 8);
            Connection.style.SetLabelStyle(currentBalance, 8);
            Connection.style.SetLabelStyle(changePassword, 8);
            Connection.style.SetLabelStyle(logOut, 8);
            Connection.style.SetPanelStyle(userPanel);
            notificationsButton.BackColor = Color.FromArgb(17, 17, 17);
            notificationsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(17, 17, 17);
            notificationsButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(17, 17, 17);
            notificationsButton.FlatAppearance.BorderColor = Color.FromArgb(17, 17, 17);
            numberOfNotifications.BackColor = Color.FromArgb(237, 7, 7);   
            userButton.BackColor = Color.FromArgb(17, 17, 17);
            userButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(17, 17, 17);
            userButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(17, 17, 17);
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            notificationsBox.Visible = false;
            userPanel.Visible = false;
        }

        private void userButton_MouseDown(object sender, MouseEventArgs e)
        {
            userButton.BackgroundImage = Resources.pressed_menu_icon;
        }

        private void userButton_MouseUp(object sender, MouseEventArgs e)
        {
            userButton.BackgroundImage = Resources.menu_icon;
        }

        private void userButton_Click(object sender, EventArgs e)
        {
            notificationsBox.Visible = false;

            if(userPanel.Visible == false)
            {
                userPanel.Visible = true;
            }
            else if(userPanel.Visible == true)
            {
                userPanel.Visible = false;
            }
        }

        private void logOut_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult result = MessageBox.Show("Ar tikrai norite atsijungti?", "Pranešimas", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void changePassword_MouseEnter(object sender, EventArgs e)
        {
            changePassword.ForeColor = Color.FromArgb(0, 174, 219);
        }

        private void changePassword_MouseLeave(object sender, EventArgs e)
        {
            changePassword.ForeColor = Color.White;
        }

        private void logOut_MouseEnter(object sender, EventArgs e)
        {
            logOut.ForeColor = Color.FromArgb(0, 174, 219);
        }

        private void logOut_MouseLeave(object sender, EventArgs e)
        {
            logOut.ForeColor = Color.White;
        }

        private void Menu_Paint(object sender, PaintEventArgs e)
        {
            if(userPanel.Visible == true)
            {
                ControlPaint.DrawBorder(e.Graphics, this.userPanel.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
            }

            if(notificationsBox.Visible == true)
            {
                ControlPaint.DrawBorder(e.Graphics, this.notificationsBox.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
            }
        }

        private void changePassword_MouseClick(object sender, MouseEventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.Show();
        }

        private void PlanBalancesButton_MouseEnter(object sender, EventArgs e)
        {
            planBalancesButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void PlanBalancesButton_MouseLeave(object sender, EventArgs e)
        {
            planBalancesButton.ForeColor = Color.White;
        }

        private void OngoingBalanceButton_MouseEnter(object sender, EventArgs e)
        {
            ongoingBalanceButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void OngoingBalanceButton_MouseLeave(object sender, EventArgs e)
        {
            ongoingBalanceButton.ForeColor = Color.White;
        }

        private void OperationsButton_MouseEnter(object sender, EventArgs e)
        {
            operationsButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void OperationsButton_MouseLeave(object sender, EventArgs e)
        {
            operationsButton.ForeColor = Color.White;
        }

        private void AccountsButton_MouseEnter(object sender, EventArgs e)
        {
            accountsButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void AccountsButton_MouseLeave(object sender, EventArgs e)
        {
            accountsButton.ForeColor = Color.White;
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Menu_VisibleChanged(object sender, EventArgs e)
        {
            ShowAdditionalInfo();
        }
    }
}
