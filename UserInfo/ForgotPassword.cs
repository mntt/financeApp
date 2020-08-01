using System;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace financeApp
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
            SetStylesAndLooks();
        }

        private void SetStylesAndLooks()
        {
            Connection.style.SetFormLooks(this);
            Connection.style.SetButtonStyle(generatePasswordButton);
            Connection.style.SetLabelStyle(enterCodeLabel, 8);
            Connection.style.SetTextBoxStyle(codeBox);
            Connection.style.SetTextBoxStyle(newPassword);
            Connection.style.SetDisabledButtonStyle(showPassword);
            Connection.style.SetDisabledButtonStyle(applyButton);
        }

        private void generatePasswordButton_Click(object sender, EventArgs e)
        {
            var accounts = Connection.db.GetTable<UsernameAndPassword>().ToList();
            
            bool accountFound = false;

            foreach(var item in accounts)
            {
                if(UnhashPassword(item.AccountCode) == true)
                {
                    accountFound = true;
                    break;
                }
            }

            if (accountFound)
            {
                newPassword.Text = ReturnPassword();
                showPassword.Enabled = true;
                applyButton.Enabled = true;
                Connection.style.SetButtonStyle(showPassword);
                Connection.style.SetButtonStyle(applyButton);
            }
            else if (!accountFound)
            {
                MessageBox.Show("Tokia paskyra neegzistuoja arba įvestas blogas kodas.");
            }
        }

        private string ReturnPassword()
        {
            //6 digit password
            string password = "";
            Random rnd = new Random();
            
            for(int i = 0; i < 6; i++)
            {
                password += rnd.Next(0, 9).ToString();
            }
           
            return password;
        }

        private void showPassword_Click(object sender, EventArgs e)
        {
            if(newPassword.UseSystemPasswordChar == true)
            {
                newPassword.UseSystemPasswordChar = false;
            }
            else if(newPassword.UseSystemPasswordChar == false)
            {
                newPassword.UseSystemPasswordChar = true;
            }
        }

        private bool UnhashPassword(string _hashbytes)
        {
            bool isPasswordCorrect = false;

            byte[] hashbytes = Convert.FromBase64String(_hashbytes);

            byte[] salt = new byte[16];

            Array.Copy(hashbytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(codeBox.Text, salt, 1000);
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

        private void applyButton_Click(object sender, EventArgs e)
        {
            if(Connection.CheckConnectivity() == true)
            {
                DialogResult result = MessageBox.Show("Ar įsidėmėjote slaptažodį?", "Pranešimas", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var accounts = Connection.db.GetTable<UsernameAndPassword>().ToList();

                    foreach (var item in accounts)
                    {
                        if (UnhashPassword(item.AccountCode) == true)
                        {
                            string hashedPassword = HashPassword(newPassword.Text);
                            Connection.iwdb.UpdatePassword(hashedPassword, item.Id);
                            MessageBox.Show("Slaptažodis atnaujintas. Galite prisijungti.");
                            this.Close();
                            break;
                        }
                    }
                }
            }           
        }

        private string HashPassword(string password)
        {
            Byte[] salt;

            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 1000);

            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashbytes = new byte[36];
            Array.Copy(salt, 0, hashbytes, 0, 16);
            Array.Copy(hash, 0, hashbytes, 16, 20);

            return Convert.ToBase64String(hashbytes);
        }

        private void generatePasswordButton_MouseEnter(object sender, EventArgs e)
        {
            generatePasswordButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void generatePasswordButton_MouseLeave(object sender, EventArgs e)
        {
            generatePasswordButton.ForeColor = Color.White;
        }

        private void showPassword_MouseEnter(object sender, EventArgs e)
        {
            showPassword.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void showPassword_MouseLeave(object sender, EventArgs e)
        {
            showPassword.ForeColor = Color.White;
        }

        private void applyButton_MouseEnter(object sender, EventArgs e)
        {
            applyButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void applyButton_MouseLeave(object sender, EventArgs e)
        {
            applyButton.ForeColor = Color.White;
        }
    }
}
