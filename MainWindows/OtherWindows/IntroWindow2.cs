using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace financeApp
{
    public partial class IntroWindow2 : Form
    {
        private bool isNull = false;
        private bool exitEvent = true;
        private bool openedAtTheStart;

        public IntroWindow2(bool _openedAtTheStart)
        {
            InitializeComponent();
            SetStylesAndLooks();
            startingAccounts.TopLeftHeaderCell.Value = "Sąskaita";
            startingAccounts.RowHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            openedAtTheStart = _openedAtTheStart;     
        }

        private void IntroWindow2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(openedAtTheStart == true)
            {
                DialogResult result = MessageBox.Show("Jūsų įvesti duomenys bus prarasti ir neišsaugoti. " +
                                "Ar tikrai norite išeiti?", "Pranešimas", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteData();
                    this.FormClosing -= IntroWindow2_FormClosing;
                    Application.Exit();
                }

                e.Cancel = (result == DialogResult.No);
            }
            else if(openedAtTheStart == false)
            {
                DialogResult result = MessageBox.Show("Jūsų įvesti duomenys bus prarasti ir neišsaugoti. " +
                                "Ar tikrai norite išeiti?", "Pranešimas", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ExitToMainMenu(true);
                }

                e.Cancel = (result == DialogResult.No);
            }   
        }

        private void finishButton_Click(object sender, EventArgs e)
        {
            if (openedAtTheStart)
            {
                CallIfOpenedAtTheStart();
            }
            else if (!openedAtTheStart)
            {
                CallIfNotOpenedAtTheStart();
            }
            exitEvent = true;
        }

        private void CheckForNullValues()
        {
            if(startingAccounts.Rows.Count == 0)
            {
                DialogResult result = MessageBox.Show("Nepridėta nei viena sąskaita. " +
                    "Ar norite sąskaitas pridėti vėliau?"
                            , "Pranešimas", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    exitEvent = false;
                    ExitToMainMenu(true);
                }
                else if (result == DialogResult.No)
                {
                    exitEvent = false;
                }
            }
            else if(startingAccounts.Rows.Count > 0)
            {
                for (int i = 0; i < startingAccounts.Rows.Count; i++)
                {
                    if (startingAccounts.Rows[i].Cells[0].Value == null)
                    {
                        DialogResult result = MessageBox.Show("Viena ar daugiau eilučių yra neužpildytos. " +
                            "Ar tikrai norite baigti? Neužpildytos eilutės bus vertinamos kaip 0 EUR."
                            , "Pranešimas", MessageBoxButtons.YesNo);

                        if (result == DialogResult.Yes)
                        {
                            isNull = true;
                            break;
                        }
                        else if (result == DialogResult.No)
                        {
                            exitEvent = false;
                            break;
                        }
                    }
                }
            }            
        }

        private void CallIfOpenedAtTheStart()
        {
            CheckForNullValues();

            if (exitEvent)
            {
                if (!isNull)
                {
                    DeleteData();
                    Connection.iwdb.InsertDates(User.ID, startingAccounts.Columns[0].HeaderText.ToString());
                    CreatingDates cd = new CreatingDates();
                    cd.CreateDates(User.ID);
                    for(int i = 0; i < startingAccounts.Rows.Count; i++)
                    {
                        Connection.iwdb.InsertAccountNames(User.ID, startingAccounts.Rows[i].HeaderCell.Value.ToString());
                    }
                    Connection.iwdb.InsertSumsInIntroWindow(startingAccounts, User.ID);
                    Connection.iwdb.InsertStartingSums(startingAccounts, User.ID, true);
                }
                else if (isNull)
                {
                    DeleteData();
                    Connection.iwdb.InsertDates(User.ID, startingAccounts.Columns[0].HeaderText.ToString());
                    CreatingDates cd = new CreatingDates();
                    cd.CreateDates(User.ID);
                    for (int i = 0; i < startingAccounts.Rows.Count; i++)
                    {
                        Connection.iwdb.InsertAccountNames(User.ID, startingAccounts.Rows[i].HeaderCell.Value.ToString());
                    }
                    Connection.iwdb.InsertConditionalSumsInIntroWindow(startingAccounts, User.ID);
                    Connection.iwdb.InsertStartingSums(startingAccounts, User.ID, true);
                }

                MessageBox.Show("Duomenys išsaugoti sėkmingai!");
                ExitToMainMenu(false);
            }
        }

        private void CallIfNotOpenedAtTheStart()
        {
            CheckForNullValues();

            if (exitEvent)
            {
                if (!isNull)
                {
                    DeleteData();
                    Connection.iwdb.InsertDates(User.ID, startingAccounts.Columns[0].HeaderText.ToString());
                    CreatingDates cd = new CreatingDates();
                    cd.CreateDates(User.ID);
                    for (int i = 0; i < startingAccounts.Rows.Count; i++)
                    {
                        Connection.iwdb.InsertAccountNames(User.ID, startingAccounts.Rows[i].HeaderCell.Value.ToString());
                    }
                    Connection.iwdb.InsertSumsInIntroWindow(startingAccounts, User.ID);
                    Connection.iwdb.InsertStartingSums(startingAccounts, User.ID, true);
                }
                else if (isNull)
                {
                    DeleteData();
                    Connection.iwdb.InsertDates(User.ID, startingAccounts.Columns[0].HeaderText.ToString());
                    CreatingDates cd = new CreatingDates();
                    cd.CreateDates(User.ID);
                    for (int i = 0; i < startingAccounts.Rows.Count; i++)
                    {
                        Connection.iwdb.InsertAccountNames(User.ID, startingAccounts.Rows[i].HeaderCell.Value.ToString());
                    }
                    Connection.iwdb.InsertConditionalSumsInIntroWindow(startingAccounts, User.ID);
                    Connection.iwdb.InsertStartingSums(startingAccounts, User.ID, true);
                }

                MessageBox.Show("Duomenys išsaugoti sėkmingai!");
                ExitToAccounts();
            }
        }

        private void ExitToMainMenu(bool deleteData)
        {
            if (deleteData)
            {
                DeleteData();
            }
            
            HideAllForms();
            this.FormClosing -= IntroWindow2_FormClosing;
            Menu menuForm = new Menu();
            menuForm.Show();
            menuForm.Focus();
        }

        private void ExitToAccounts()
        {
            HideAllForms();
            this.FormClosing -= IntroWindow2_FormClosing;
            Menu menuForm = new Menu();
            Accounts accountsForm = new Accounts(menuForm);
            accountsForm.Show();
            accountsForm.Focus();
        }

        private void HideAllForms()
        {
            List<Form> openForms = new List<Form>();

            foreach(Form f in Application.OpenForms)
            {
                openForms.Add(f);
            }

            foreach(Form f in openForms)
            {
                f.Hide();
            }
        }

        private void DeleteData()
        {
            Connection.iwdb.DeleteData("Sums", User.ID);
            Connection.iwdb.DeleteData("Dates", User.ID);
            Connection.iwdb.DeleteData("AccountNames", User.ID);
            Connection.iwdb.DeleteData("StartingSums", User.ID);
        }

        private void addAccountButton_Click(object sender, EventArgs e)
        {
            Action reloadAccounts = ReloadAccountNames;
            AddAccountWindow addAcc = new AddAccountWindow(reloadAccounts);
            addAcc.Show();
        }

        private void ReloadAccountNames()
        {
            startingAccounts.Rows.Add();
            OverwriteAccountNames();           
        }

        private void OverwriteAccountNames()
        {
            var names = Connection.db.GetTable<AccountNames>()
                .Where(x => x.UserId == User.ID).Select(x => x.Name).ToList();

            for (int i = 0; i < startingAccounts.Rows.Count; i++)
            {
                startingAccounts.Rows[i].HeaderCell.Value = names[i];
            }
        }

        private void SetStylesAndLooks()
        {
            Connection.style.SetFormLooks(this);
            Connection.style.SetDataGridLooks(startingAccounts);
            Connection.style.SetColumnStyle(startingAccounts, DataGridViewAutoSizeColumnsMode.DisplayedCells, true);
            Connection.style.SetRowStyle(
                startingAccounts,
                DataGridViewAutoSizeRowsMode.DisplayedCells,
                DataGridViewRowHeadersWidthSizeMode.DisableResizing,
                100);
            Connection.style.SetCellStyle(startingAccounts);
            Connection.style.SetButtonStyle(addAccountButton);
            Connection.style.SetButtonStyle(finishButton);
        }

        private void StartingAccounts_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = startingAccounts.HitTest(e.X, e.Y);
            if (hitInfo.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                Connection.style.ClearSelection(startingAccounts, true, true);
            }
        }

        private void StartingAccounts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double value;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.Value != null && double.TryParse(e.Value.ToString(), out value))
                {
                    e.Value = value.ToString("C2");
                }
            }
        }

        private void StartingAccounts_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void StartingAccounts_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(StartingAccounts_KeyPress);

            TextBox tb = e.Control as TextBox;

            if (tb != null || tb == null)
            {
                tb.KeyPress += new KeyPressEventHandler(StartingAccounts_KeyPress);
            }
        }

        private void CheckForIllegalChars(int _rowIndex, int _columnIndex)
        {
            double tempSum;

            if (startingAccounts.Rows[_rowIndex].Cells[_columnIndex].Value != null)
            {
                try
                {
                    tempSum = double.Parse(startingAccounts.Rows[_rowIndex].Cells[_columnIndex].Value.ToString());
                }
                catch
                {
                    string tempValue = "";
                    var tempChars = startingAccounts.Rows[_rowIndex].Cells[_columnIndex].Value.ToString().ToCharArray().ToList();
                    if (tempChars.Count >= 6 && tempChars[tempChars.Count - 2] == ' ' && tempChars[tempChars.Count - 1] == '€')
                    {
                        tempChars.RemoveAt(tempChars.Count - 2);
                        tempChars.RemoveAt(tempChars.Count - 1);

                        foreach (var item in tempChars)
                        {
                            tempValue += item;
                        }

                        startingAccounts.Rows[_rowIndex].Cells[_columnIndex].Value = tempValue;
                    }
                    else
                    {
                        startingAccounts.Rows[_rowIndex].Cells[_columnIndex].Value = null;
                        MessageBox.Show("Įvesti blogi duomenys. Pataisykite laukelį.", "Klaida");
                    }
                }
            }
        }

        private void StartingAccounts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(startingAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (startingAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "€")
                {
                    MessageBox.Show("Įvesti blogi duomenys. Pataisykite laukelį.", "Klaida");
                    startingAccounts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
            }
            
            CheckForIllegalChars(e.RowIndex, e.ColumnIndex);
        }

        private void addAccountButton_MouseEnter(object sender, EventArgs e)
        {
            addAccountButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void addAccountButton_MouseLeave(object sender, EventArgs e)
        {
            addAccountButton.ForeColor = Color.White;
        }

        private void finishButton_MouseEnter(object sender, EventArgs e)
        {
            finishButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void finishButton_MouseLeave(object sender, EventArgs e)
        {
            finishButton.ForeColor = Color.White;
        }
    }
}
