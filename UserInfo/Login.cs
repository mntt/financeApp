using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Threading;

namespace financeApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            SetStylesAndLooks();
        }
        
        private void SetStylesAndLooks()
        {
            Connection.style.SetFormLooks(this);
            Connection.style.SetLabelStyle(usernameLabel, 8);
            Connection.style.SetLabelStyle(passwordLabel, 8);
            Connection.style.SetTextBoxStyle(usernameBox);
            Connection.style.SetTextBoxStyle(passwordBox);
            Connection.style.SetButtonStyle(loginButton);
            Connection.style.SetButtonStyle(signupButton);
            Connection.style.SetLabelStyle(forgotPassword, 7);
        }

        async Task LoadingImage()
        {
            await Task.Run(() =>
            {
                LoadingScreen.ShowLoadingScreen(3000);
            });
        }

        private async void WaitForLoadingImageEnd()
        {
            await LoadingImage();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(Connection.CheckConnectivity() == true)
            {
                if (usernameBox.Text != "" && passwordBox.Text != "")
                {
                    if (CheckDatabaseForEnteredUsername(usernameBox.Text) == true)
                    {
                        var id = Connection.db.GetTable<UsernameAndPassword>()
                            .Where(x => x.Username == usernameBox.Text).Select(x => x.Id).ToList();
                        var password = Connection.db.GetTable<UsernameAndPassword>()
                            .Where(x => x.Username == usernameBox.Text).Select(x => x.Password).ToList();

                        if (UnhashPassword(password[0]) == true)
                        {
                            User.ID = id[0];

                            var startingAccount = Connection.db.GetTable<Dates>()
                                .Where(x => x.UserId == id[0])
                                .Select(x => x.Date1 == "Startinis likutis").ToList();

                            if (startingAccount.Count > 0)
                            {
                                WaitForLoadingImageEnd();
                                CreatingDates cd = new CreatingDates();
                                Notifications noti = new Notifications();

                                cd.CreateDates(id[0]);
                                noti.CreateNotifications(noti.NotificationsDateList());

                                Thread.Sleep(2000);

                                Menu menuForm = new Menu();
                                this.Hide();
                                menuForm.Show();
                                menuForm.Focus();
                            }
                            else if (startingAccount.Count == 0)
                            {
                                IntroWindow intro = new IntroWindow();
                                this.Hide();
                                intro.Show();
                                intro.Focus();
                            }
                        }
                        else if (UnhashPassword(password[0]) == false)
                        {
                            MessageBox.Show("Blogas prisijungimo vardas arba slaptažodis. " +
                            "Pasitikrinkite ar teisingai įvedėte duomenis ir bandykite dar kartą.");
                        }
                    }
                    else if (CheckDatabaseForEnteredUsername(usernameBox.Text) == false)
                    {
                        MessageBox.Show("Blogas prisijungimo vardas arba slaptažodis. " +
                            "Pasitikrinkite ar teisingai įvedėte duomenis ir bandykite dar kartą.");
                    }

                }
                else if (usernameBox.Text == "")
                {
                    MessageBox.Show("Neįvestas prisijungimo vardas.", "Klaida");
                    passwordBox.Text = "";
                }
                else if (passwordBox.Text == "")
                {
                    MessageBox.Show("Neįvestas slaptažodis.", "Klaida");
                    usernameBox.Text = "";
                }
            }            
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
        }

        private bool CheckDatabaseForEnteredUsername(string newUsername)
        {
            bool isUsernameInDatabase = false;
            var database = Connection.db.GetTable<UsernameAndPassword>().Select(x => x.Username).ToList();

            foreach(var username in database)
            {
                if(username == newUsername)
                {
                    isUsernameInDatabase = true;
                    break;
                }
            }

            return isUsernameInDatabase;
        }

        private bool UnhashPassword(string _hashbytes)
        {
            bool isPasswordCorrect = false;

            byte[] hashbytes = Convert.FromBase64String(_hashbytes);

            byte[] salt = new byte[16];

            Array.Copy(hashbytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(passwordBox.Text, salt, 1000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashbytes[i + 16] != hash[i])
                {
                    isPasswordCorrect = false;
                    break;
                }
                else if (hashbytes[i + 16] == hash[i])
                {
                    isPasswordCorrect = true;
                    break;
                }
            }

            return isPasswordCorrect;
        }

        private void forgotPassword_MouseEnter(object sender, EventArgs e)
        {
            forgotPassword.ForeColor = Color.FromArgb(0, 174, 219);
        }

        private void forgotPassword_MouseLeave(object sender, EventArgs e)
        {
            forgotPassword.ForeColor = Color.White;
        }

        private void forgotPassword_MouseClick(object sender, MouseEventArgs e)
        {
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.Show();
        }

        private void loginButton_MouseEnter(object sender, EventArgs e)
        {
            loginButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void signupButton_MouseLeave(object sender, EventArgs e)
        {
            signupButton.ForeColor = Color.White;
        }

        private void loginButton_MouseLeave(object sender, EventArgs e)
        {
            loginButton.ForeColor = Color.White;
        }

        private void signupButton_MouseEnter(object sender, EventArgs e)
        {
            signupButton.ForeColor = Color.FromArgb(17, 17, 17);
        }
    }
}
