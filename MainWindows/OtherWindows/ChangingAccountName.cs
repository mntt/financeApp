using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace financeApp
{
    public partial class ChangingAccountName : Form
    {
        private int accountNameId;
        private Action reloadAccountsForm; 
        
        public ChangingAccountName(int _accountNameId, Action _reloadAccountsForm)
        {
            InitializeComponent();
            SetStylesAndLooks();
            accountName.Select();
            accountNameId = _accountNameId;
            reloadAccountsForm = _reloadAccountsForm;
        }
 
        private void applyButton_Click(object sender, EventArgs e)
        {
            bool isNameInDatabase = checkDatabaseForEnteredName(accountName.Text);

            if (isNameInDatabase)
            {
                MessageBox.Show("Toks pavadinimas jau naudojamas. Sąskaitų pavadinimai negali kartotis. Pakeiskite pavadinimą.", "Klaida");
                accountName.Text = "";
                accountName.Select();
            }
            else if (!isNameInDatabase)
            {
                if(accountName.Text != "")
                {
                    Connection.iwdb.UpdateAccountName(accountName.Text, accountNameId, User.ID);
                    reloadAccountsForm();
                    this.Close();
                }
                else if(accountName.Text == "")
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
            var name = Connection.db.GetTable<AccountNames>()
                .Where(x => x.Name == _name && x.UserId == User.ID).Select(x => x.Name).ToList();

            if (name.Count > 0)
            {
                isNameAlreadyInDatabase = true;
            }

            return isNameAlreadyInDatabase;
        }

        private void SetStylesAndLooks()
        {
            Connection.style.SetFormLooks(this);
            Connection.style.SetButtonStyle(applyButton);
            Connection.style.SetLabelStyle(text1, 8);
            Connection.style.SetLabelStyle(text2, 8);
            Connection.style.SetTextBoxStyle(accountName);
        }

    }
}
