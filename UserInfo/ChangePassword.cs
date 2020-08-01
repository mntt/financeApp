using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace financeApp
{   
    public partial class ChangePassword : Form
    {
        private bool isPasswordCorrect = false;

        public ChangePassword()
        {
            InitializeComponent();
            SetStylesAndLooks();
        }

        private void SetStylesAndLooks()
        {
            Connection.style.SetFormLooks(this);
            Connection.style.SetLabelStyle(oldPasswordLabel, 8);
            Connection.style.SetLabelStyle(newPasswordLabel, 8);
            Connection.style.SetLabelStyle(repeatPasswordLabel, 8);
            Connection.style.SetTextBoxStyle(oldPasswordBox);
            Connection.style.SetTextBoxStyle(newPasswordBox);
            Connection.style.SetTextBoxStyle(repeatPasswordBox);
            Connection.style.SetDisabledButtonStyle(applyButton);
        }

        private void oldPasswordBox_TextChanged(object sender, EventArgs e)
        {
            var password = Connection.db.GetTable<UsernameAndPassword>()
                .Where(x => x.Id == User.ID).Select(x => x.Password).ToList();

            if(UnhashPassword(password[0]) == false)
            {
                isPasswordCorrect = false;
            }
            else if(UnhashPassword(password[0]) == true)
            {
                isPasswordCorrect = true;
            }
        }

        private bool UnhashPassword(string _hashbytes)
        {
            bool isPasswordCorrect = false;

            byte[] hashbytes = Convert.FromBase64String(_hashbytes);

            byte[] salt = new byte[16];

            Array.Copy(hashbytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(oldPasswordBox.Text, salt, 1000);
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

        private void newPasswordBox_TextChanged(object sender, EventArgs e)
        {
            var passwordChars = newPasswordBox.Text.ToCharArray().ToList();

            if (passwordChars.Count < 6)
            {
                newPasswordAlert.Visible = true;
                newPasswordAlert.Location = new Point(118, 70);
                newPasswordAlert.Text = "Slaptažodis per trumpas";
                newPasswordAlert.ForeColor = Color.FromArgb(153, 0, 0);    
            }            
            else if (passwordChars.Count >= 6)
            {
                if(newPasswordBox.Text != oldPasswordBox.Text)
                {
                    newPasswordAlert.Visible = false;
                }
                else if(newPasswordBox.Text == oldPasswordBox.Text)
                {
                    newPasswordAlert.Visible = true;
                    newPasswordAlert.Location = new Point(109, 70);
                    newPasswordAlert.Text = "Įvedėte tokį patį slaptažodį";
                    newPasswordAlert.ForeColor = Color.FromArgb(153, 0, 0);
                }
            }

            if(repeatPasswordBox.Text != "" && repeatPasswordBox.Text != newPasswordBox.Text)
            {
                repeatPasswordAlert.Visible = true;
                repeatPasswordAlert.Location = new Point(120, 108);
                repeatPasswordAlert.Text = "Slaptažodžiai nesutampa";
                repeatPasswordAlert.ForeColor = Color.FromArgb(153, 0, 0);
            }
            else if(repeatPasswordBox.Text != "" && repeatPasswordBox.Text == newPasswordBox.Text)
            {
                repeatPasswordAlert.Visible = false;
            }

            ToggleApplyButton();
        }

        private void repeatPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (newPasswordBox.Text != repeatPasswordBox.Text)
            {
                repeatPasswordAlert.Visible = true;
                repeatPasswordAlert.Location = new Point(118, 108);
                repeatPasswordAlert.Text = "Slaptažodžiai nesutampa";
                repeatPasswordAlert.ForeColor = Color.FromArgb(153, 0, 0);
            }
            else if (newPasswordBox.Text == repeatPasswordBox.Text)
            {
                repeatPasswordAlert.Visible = false;
            }

            ToggleApplyButton();
        }

        private void ToggleApplyButton()
        {
            if (newPasswordAlert.Visible == false && repeatPasswordAlert.Visible == false 
                && newPasswordBox.Text != "" && repeatPasswordBox.Text != "")
            {
                applyButton.Enabled = true;
                Connection.style.SetButtonStyle(applyButton);
            }
            else if (newPasswordAlert.Visible == true || repeatPasswordAlert.Visible == true 
                || newPasswordBox.Text == "" || repeatPasswordBox.Text == "")
            {
                applyButton.Enabled = false;
                Connection.style.SetDisabledButtonStyle(applyButton);
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

        private void applyButton_Click(object sender, EventArgs e)
        {
            if(Connection.CheckConnectivity() == true)
            {
                if (isPasswordCorrect)
                {
                    string hashedPassword = HashPassword(newPasswordBox.Text);
                    Connection.iwdb.UpdatePassword(hashedPassword, User.ID);
                    MessageBox.Show("Slaptažodis sėkmingai pakeistas!");
                    this.Close();
                }
                else if (!isPasswordCorrect)
                {
                    MessageBox.Show("Neteisingai įvedėte seną slaptažodį. Bandykite iš naujo.");
                }
            }     
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
