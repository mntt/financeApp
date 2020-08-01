using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace financeApp
{
    public partial class Registration : Form
    {
        private string generatedAccountCode { get; set; }

        public Registration()
        {
            InitializeComponent();
            SetStylesAndLooks();
        }

        private void SetStylesAndLooks()
        {
            Connection.style.SetFormLooks(this);
            Connection.style.SetLabelStyle(name, 10);
            Connection.style.SetLabelStyle(loginNameLabel, 8);
            Connection.style.SetLabelStyle(passwordLabel, 8);
            Connection.style.SetLabelStyle(accountCodeLabel, 8);
            Connection.style.SetLabelStyle(name, 10);
            Connection.style.SetLabelStyle(enterCodeLabel, 8);
            Connection.style.SetLabelStyle(repeatPasswordLabel, 8);
            Connection.style.SetTextBoxStyle(nameBox);
            Connection.style.SetTextBoxStyle(passwordBox);
            Connection.style.SetTextBoxStyle(generatedCodeBox);
            Connection.style.SetTextBoxStyle(codeBox);
            Connection.style.SetDisabledButtonStyle(generateCode);
            Connection.style.SetDisabledButtonStyle(finishRegistrationButton);
            Connection.style.SetDisabledButtonStyle(showCode);
            infoButton.BackColor = Color.FromArgb(17, 17, 17);
            infoButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(17, 17, 17);
            infoButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(17, 17, 17);
            infoBox.Font = new Font("MS Reference Sans Serif", 7);
            infoBox.ForeColor = Color.White;
            infoBox.BackColor = Color.FromArgb(17, 17, 17);
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {
            var usernameChars = nameBox.Text.ToCharArray().ToList();

            if (usernameChars.Count >= 1)
            {
                if (CheckDatabaseForEnteredUsername(nameBox.Text) == false)
                {
                    nameAlert.Visible = false;
                }
                else if (CheckDatabaseForEnteredUsername(nameBox.Text) == true)
                {
                    nameAlert.Visible = true;
                    nameAlert.Location = new Point(136, 69);
                    nameAlert.Text = "Toks vartotojas jau egzistuoja";
                    nameAlert.ForeColor = Color.FromArgb(153, 0, 0);
                }
            }
            else if (usernameChars.Count < 1)
            {
                nameAlert.Visible = true;
                nameAlert.Location = new Point(136, 69);
                nameAlert.Text = "Įveskite vartotojo vardą";
                nameAlert.ForeColor = Color.FromArgb(153, 0, 0);
            }

            ToggleGenerateCodeButton();
        }

        private bool CheckDatabaseForEnteredUsername(string newUsername)
        {
            bool isUsernameInDatabase = false;
            var database = Connection.db.GetTable<UsernameAndPassword>().Select(x => x.Username).ToList();

            foreach (var username in database)
            {
                if (username == newUsername)
                {
                    isUsernameInDatabase = true;
                    break;
                }
            }

            return isUsernameInDatabase;
        }

        private void nameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"[^a-zA-Z0-9\s\b]");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
            }
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            var passwordChars = passwordBox.Text.ToCharArray().ToList();

            if (passwordChars.Count >= 6)
            {
                passwordAlert.Visible = false;
            }
            else if (passwordChars.Count < 6)
            {
                passwordAlert.Visible = true;
                passwordAlert.Location = new Point(136, 108);
                passwordAlert.Text = "Slaptažodis per trumpas";
                passwordAlert.ForeColor = Color.FromArgb(153, 0, 0);
            }

            ToggleGenerateCodeButton();
        }

        private void ToggleGenerateCodeButton()
        {
            if (nameBox.Text != "" && passwordBox.Text != "" && repeatPasswordBox.Text != "" 
                && nameAlert.Visible == false && passwordAlert.Visible == false && repeatPasswordAlert.Visible == false)
            {
                generateCode.Enabled = true;
                Connection.style.SetButtonStyle(generateCode);
                showCode.Enabled = true;
                Connection.style.SetButtonStyle(showCode);
            }
            else if (nameBox.Text == "" || passwordBox.Text == "" || repeatPasswordBox.Text == "" 
                || nameAlert.Visible == true || passwordAlert.Visible == true || repeatPasswordAlert.Visible == true)
            {
                generateCode.Enabled = false;
                Connection.style.SetDisabledButtonStyle(generateCode);
                showCode.Enabled = false;
                Connection.style.SetDisabledButtonStyle(showCode);
                finishRegistrationButton.Enabled = false;
                Connection.style.SetDisabledButtonStyle(finishRegistrationButton);
            }
        }

        private void finishRegistrationButton_Click(object sender, EventArgs e)
        {
            if(Connection.CheckConnectivity() == true)
            {
                if (codeBox.Text == generatedAccountCode)
                {
                    DialogResult result = MessageBox.Show("Ar išsisaugojote paskyros kodą?", "Pranešimas", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        string hashedPassword = HashPassword(passwordBox.Text);
                        string hashedCode = HashPassword(generatedCodeBox.Text);
                        Connection.iwdb.InsertUsernamesAndPassword(nameBox.Text, hashedPassword, hashedCode);
                        MessageBox.Show("Registracija sėkminga!");
                        Application.Restart();
                    }
                }
                else if (codeBox.Text != generatedAccountCode)
                {
                    MessageBox.Show("Blogas kodas. Bandykite dar kartą.", "Klaida");
                    codeBox.Text = "";
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

        private void generateCode_Click(object sender, EventArgs e)
        {
            string accountString = nameBox.Text + passwordBox.Text;
            generatedAccountCode = HashPassword(accountString);
            generatedCodeBox.UseSystemPasswordChar = true;
            generatedCodeBox.Text = generatedAccountCode;
            finishRegistrationButton.Enabled = true;
            Connection.style.SetButtonStyle(finishRegistrationButton);
        }

        private void showCode_Click(object sender, EventArgs e)
        {
            if(generatedCodeBox.UseSystemPasswordChar == false)
            {
                generatedCodeBox.UseSystemPasswordChar = true;
            }
            else if(generatedCodeBox.UseSystemPasswordChar == true)
            {
                generatedCodeBox.UseSystemPasswordChar = false;
            }   
        }

        private void repeatPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordBox.Text != repeatPasswordBox.Text)
            {
                repeatPasswordAlert.Visible = true;
                repeatPasswordAlert.Location = new Point(136, 154);
                repeatPasswordAlert.Text = "Slaptažodžiai nesutampa";
                repeatPasswordAlert.ForeColor = Color.FromArgb(153, 0, 0);
            }
            else if (passwordBox.Text == repeatPasswordBox.Text)
            {
                repeatPasswordAlert.Visible = false;
            }

            ToggleGenerateCodeButton();
        }

        private void infoButton_MouseDown(object sender, MouseEventArgs e)
        {
            infoButton.Size = new Size(17, 15);
        }

        private void infoButton_MouseUp(object sender, MouseEventArgs e)
        {
            infoButton.Size = new Size(22, 20);
        }

        private void Registration_Paint(object sender, PaintEventArgs e)
        {
            if (infoBox.Visible == true)
            {
                ControlPaint.DrawBorder(e.Graphics, this.infoBox.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
            }
        }

        private void infoButton_MouseClick(object sender, MouseEventArgs e)
        {
            if(infoBox.Visible == false)
            {
                infoBox.Visible = true;
            }
            else if(infoBox.Visible == true)
            {
                infoBox.Visible = false;
            }            
        }

        private void Registration_Click(object sender, EventArgs e)
        {
            infoBox.Visible = false;
        }

        private void generateCode_MouseEnter(object sender, EventArgs e)
        {
            generateCode.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void generateCode_MouseLeave(object sender, EventArgs e)
        {
            generateCode.ForeColor = Color.White;
        }

        private void showCode_MouseEnter(object sender, EventArgs e)
        {
            showCode.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void showCode_MouseLeave(object sender, EventArgs e)
        {
            showCode.ForeColor = Color.White;
        }

        private void finishRegistrationButton_MouseEnter(object sender, EventArgs e)
        {
            finishRegistrationButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void finishRegistrationButton_MouseLeave(object sender, EventArgs e)
        {
            finishRegistrationButton.ForeColor = Color.White;
        }
    }
}
