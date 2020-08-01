using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace financeApp
{
    public partial class AddAccountWindow : Form
    {
        private Action ReloadAccounts;

        public AddAccountWindow(Action _reloadAccounts)
        {
            InitializeComponent();
            SetStylesAndLooks();
            ReloadAccounts = _reloadAccounts;
            accountName.Select();
        }

        private void addAccountButton_Click(object sender, EventArgs e)
        {
            bool isNameAlreadyInDatabase = checkDatabaseForEnteredName(accountName.Text);

            if (isNameAlreadyInDatabase)
            {
                MessageBox.Show("Toks pavadinimas jau naudojamas. Sąskaitų pavadinimai negali kartotis. Pakeiskite pavadinimą.", "Klaida");
                accountName.Text = "";
                accountName.Select();
            }
            else if (!isNameAlreadyInDatabase)
            {
                if (accountName.Text != "")
                {
                    Connection.iwdb.InsertAccountNames(User.ID, accountName.Text);
                    accountName.Text = "";
                    ReloadAccounts();
                    this.Hide();
                }
                else if (accountName.Text == "")
                {
                    MessageBox.Show("Įrašykite sąskaitos pavadinimą.", "Klaida");
                    accountName.Text = "";
                    accountName.Select();
                }
            }
        }

        private bool checkDatabaseForEnteredName(string _name)
        {
            bool isNameAlreadyInDatabase = false;
            var name = Connection.db.GetTable<AccountNames>().Where(x => x.Name == _name && x.UserId == User.ID).Select(x => x.Name).ToList();

            if (name.Count > 0)
            {
                isNameAlreadyInDatabase = true;
            }

            return isNameAlreadyInDatabase;
        }


        private void SetStylesAndLooks()
        {
            Connection.style.SetFormLooks(this);
            Connection.style.SetButtonStyle(addAccountButton);
            Connection.style.SetLabelStyle(text, 8);
            Connection.style.SetLabelStyle(text2, 8);
            Connection.style.SetTextBoxStyle(accountName);
        }

        private void addAccountButton_MouseEnter(object sender, EventArgs e)
        {
            addAccountButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void addAccountButton_MouseLeave(object sender, EventArgs e)
        {
            addAccountButton.ForeColor = Color.White;
        }
    }
}
