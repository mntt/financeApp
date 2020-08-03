using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace financeApp
{
    public partial class Accounts : Form
    {
        private int rowIndex { get; set; }
        private int columnIndex { get; set; }
        private List<TempInfoOfSums> sumsList = new List<TempInfoOfSums>();
        private bool isStartingDate = true;
        private bool isValueNull = true;
        private event EventHandler pressingBackButton;
        private Form menuForm;

        public Accounts(Form _menuForm)
        {
            InitializeComponent();
            menuForm = _menuForm;
        }
        
        private void Accounts_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveDataButton.Enabled == true)
            {
                DialogResult result = MessageBox.Show("Jūsų atlikti pakeitimai bus neišsaugoti. " +
                    "Ar tikrai norite išeiti?", "Pranešimas", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.FormClosing -= Accounts_FormClosing;
                    Application.Exit();
                }

                e.Cancel = (result == DialogResult.No);
            }
            else if (saveDataButton.Enabled == false)
            {
                Application.Exit();
            }
        }
        
        private void accountsBackButton_Click(object sender, EventArgs e)
        {
            if (saveDataButton.Enabled == true)
            {
                DialogResult result = MessageBox.Show("Jūsų atlikti pakeitimai bus neišsaugoti. " +
                    "Ar tikrai norite grįžti į Meniu?", "Pranešimas", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.FormClosing -= Accounts_FormClosing;
                    this.Close();
                    menuForm.Show();
                }
            }
            else if (saveDataButton.Enabled == false)
            {
                this.FormClosing -= Accounts_FormClosing;
                this.Close();
                menuForm.Show();
            }
        }

        private void addAccountButton_Click(object sender, EventArgs e)
        {
            Action reloadAccounts = ReloadAccountNames;
            reloadAccounts += SetTotalSumTableRowHeaderWidth;
            AddAccountWindow addAcc = new AddAccountWindow(reloadAccounts);
            addAcc.Show();
            Connection.style.ClearSelection(accountsTable, true, true);
            Connection.style.ClearSelection(totalSumTable, true, true);
        }

        private void SetTotalSumTableRowHeaderWidth()
        {
            Connection.style.SetRowHeaderWidths(accountsTable, totalSumTable);
        }

        private void ReloadAccountNames()
        {
            accountsTable.Rows.Add();
            OverwriteAccountNames();
        }

        private void LoadDates()
        {
            var dates = Connection.db.GetTable<Dates>()
                .Where(x => x.UserId == User.ID).Select(x => x.Date1).ToList();

            foreach(var item in dates)
            {
                accountsTable.Columns.Add(item.ToString(), item.ToString());
            }
        }

        private void LoadAccounts()
        {
            var names = Connection.db.GetTable<AccountNames>()
                .Where(x => x.UserId == User.ID).Select(x => x.Name).ToList();

            int counter = 0;

            foreach (var item in names)
            {
                accountsTable.Rows.Add();
                accountsTable.Rows[counter].HeaderCell.Value = item.ToString();
                counter++;
            }

            if(names.Count > 0)
            {
                deleteAccount.Enabled = true;
            }
        }

        private void AccountsTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            changeNameButton.Enabled = false;
            Connection.style.SetDisabledButtonStyle(changeNameButton);
            Connection.style.ClearSelection(accountsTable, true, false);
            Connection.style.ClearSelection(totalSumTable, true, true);

            rowIndex = accountsTable.CurrentCell.RowIndex;
            columnIndex = accountsTable.CurrentCell.ColumnIndex;

            if (accountsTable.Rows[rowIndex].Cells[columnIndex].Value == null)
            {
                isValueNull = true;
            }

            if(accountsTable.Rows[rowIndex].Cells[columnIndex].Value != null)
            {
                isValueNull = false;
            }
        }

        async Task LoadingImage()
        {
            await Task.Run(() =>
            {
                LoadingScreen.ShowLoadingScreen(1000);
            });
        }

        private async void WaitForLoadingImageEnd()
        {
            await LoadingImage();
        }

        private void saveDataButton_Click(object sender, EventArgs e)
        {
            if(Connection.CheckConnectivity() == true)
            {
                WaitForLoadingImageEnd();
                Thread.Sleep(1000);

                Connection.iwdb.DeleteData("Sums", User.ID);
                Connection.iwdb.DeleteData("StartingSums", User.ID);
                Connection.iwdb.InsertSums(sumsList);
                Connection.iwdb.InsertStartingSums(accountsTable, User.ID, false);

                MessageBox.Show("Duomenys išsaugoti sėkmingai!");
                OverwriteTotalSumTable();
                saveDataButton.Enabled = false;
            }           
        }
        
        private void AccountsTable_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Connection.style.ClearSelection(accountsTable, true, false);
            Connection.style.ClearSelection(totalSumTable, true, true);

            rowIndex = e.RowIndex;
            columnIndex = e.ColumnIndex;

            if (accountsTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                isValueNull = true;
            }

            if (accountsTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                isValueNull = false;
            }
        }

        private void Accounts_Load(object sender, EventArgs e)
        {           
            var startingDate = Connection.db.GetTable<Dates>()
                .Where(x => x.Date1 == "Startinis likutis" && x.UserId == User.ID).ToList();

            var startingAccounts = Connection.db.GetTable<AccountNames>()
                .Where(x => x.UserId == User.ID).Select(x => x.Name).ToList();

            if (startingDate.Count > 0)
            {
                isStartingDate = true;
                LoadDates();
  
                if (startingAccounts.Count > 0)
                {
                    LoadAccounts();
                    LoadSums();
                    AddDataToTotalSumTable();
                }
            }
            else if (startingDate.Count == 0)
            {
                isStartingDate = false;
            }

            totalSumTable.ClearSelection();
            accountsTable.ClearSelection();
            saveDataButton.Enabled = false;
        }

        private void HighlightThisMonth()
        {
            if(accountsTable.Columns.Count == 1)
            {
                Connection.style.PaintColumnAsSelected(accountsTable, 0);
                Connection.style.PaintColumnAsSelected(totalSumTable, 0);
            }
            else if(accountsTable.Columns.Count > 1)
            {
                string today = DateTime.Today.ToString("yyyy-MM");

                for(int column = 0; column < accountsTable.Columns.Count; column++)
                {
                    if(accountsTable.Columns[column].HeaderText == today)
                    {
                        Connection.style.PaintColumnAsSelected(accountsTable, column);
                        Connection.style.PaintColumnAsSelected(totalSumTable, column);
                    }
                }
            }
        }

        private void Accounts_Shown(object sender, EventArgs e)
        {
            if (!isStartingDate)
            {
                SetStylesAndLooksForIncompleteForm();

                DialogResult result = MessageBox.Show("Norint pradėti naudotis Finansų app'su " +
                    "turite pridėti startinius likučius. Ar norite pridėti juos dabar?", 
                    "Pranešimas", MessageBoxButtons.YesNo);

                if(result == DialogResult.Yes)
                {
                    IntroWindow2 intro2 = new IntroWindow2(false);
                    intro2.Show();
                    intro2.Focus();     
                } 
                else if (result == DialogResult.No)
                {
                    pressingBackButton += accountsBackButton_Click;
                    pressingBackButton(this, e);
                }      
            }
            else if (isStartingDate)
            {
                SetStylesAndLooks();
                HighlightThisMonth();
            }
        }

        private void AccountsTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(accountsTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                if (accountsTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
                {
                    accountsTable.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = null;
                }
            }
                      
            CheckForIllegalChars(e.RowIndex, e.ColumnIndex);

            if (isValueNull)
            {
                ExecuteIfValueIsNull(e.RowIndex, e.ColumnIndex);
            }
            else if (!isValueNull)
            {
                ExecuteIfValueIsNotNull(e.RowIndex, e.ColumnIndex);
            }
        }

        private void CheckForIllegalChars(int _rowIndex, int _columnIndex)
        {
            double tempSum;

            if (accountsTable.Rows[_rowIndex].Cells[_columnIndex].Value != null)
            {
                try
                {
                    tempSum = double.Parse(accountsTable.Rows[_rowIndex].Cells[_columnIndex].Value.ToString());
                }
                catch
                {
                    string tempValue = "";
                    var tempChars = accountsTable.Rows[_rowIndex].Cells[_columnIndex].Value.ToString().ToCharArray().ToList();
                    if(tempChars.Count >= 6 && tempChars[tempChars.Count-2] == ' ' && tempChars[tempChars.Count - 1] == '€')
                    {
                        tempChars.RemoveAt(tempChars.Count - 2);
                        tempChars.RemoveAt(tempChars.Count - 1);

                        foreach (var item in tempChars)
                        {
                            tempValue += item;
                        }

                        accountsTable.Rows[_rowIndex].Cells[_columnIndex].Value = tempValue;
                    }
                    else
                    {
                        accountsTable.Rows[_rowIndex].Cells[_columnIndex].Value = null;
                        MessageBox.Show("Įvesti blogi duomenys. Pataisykite laukelį.", "Klaida");
                        isValueNull = true;
                    }   
                }
            }
        }


        private void ExecuteIfValueIsNotNull(int _rowIndex, int _columnIndex)
        {
            var tempValue = sumsList
                .Where(x => x.accountNameId == _rowIndex && x.dateId == _columnIndex && x.userId == User.ID)
                    .Select(x => x.sum).ToList();

            if (tempValue.Count > 0)
            {
                if (accountsTable.Rows[_rowIndex].Cells[_columnIndex].Value == null)
                {
                    DialogResult result = MessageBox.Show("Ar tikrai norite ištrinti įrašą?", "Pranešimas", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        RefreshSumsList();
                    }
                    else if (result == DialogResult.No)
                    {
                        accountsTable.Rows[_rowIndex].Cells[_columnIndex].Value = tempValue[0].ToString();
                    }
                }
            }

            if (accountsTable.Rows[_rowIndex].Cells[_columnIndex].Value != null)
            {
                RefreshSumsList();               
            }
        }

        private void ExecuteIfValueIsNull(int _rowIndex, int _columnIndex)
        {
            bool dateCondition = false;
            DateTime today = DateTime.Parse(DateTime.Today.ToString("yyyy-MM"));

            if (accountsTable.Columns[_columnIndex].HeaderText != "Startinis likutis")
            {
                DateTime selectedMonth = DateTime.Parse(accountsTable.Columns[_columnIndex].HeaderText.ToString());

                if (selectedMonth <= today)
                {
                    dateCondition = false;
                }
                else if (selectedMonth > today)
                {
                    dateCondition = true;
                }
            }
            else if (accountsTable.Columns[_columnIndex].HeaderText == "Startinis likutis")
            {
                dateCondition = false;
            }

            if (accountsTable.Rows[_rowIndex].Cells[_columnIndex].Value != null && !dateCondition)
            {
                RefreshSumsList();
            }
            else if (accountsTable.Rows[_rowIndex].Cells[_columnIndex].Value != null && dateCondition)
            {
                MonthConverter mc = new MonthConverter();

                MessageBox.Show("Negalima įvesti sumų šiame stulpelyje, nes dar nesibaigė " + today.ToString("yyyy") +
                            " m. " + mc.ReturnRequiredMonth(today) + " mėn. Likučius už kitą mėnesį galima įvesti tik pasibaigus " +
                            "einamąjam mėnesiui.", "Klaida");

                accountsTable.Rows[_rowIndex].Cells[_columnIndex].Value = null;
            }
        }

        private void RefreshSumsList()
        {
            sumsList.Clear();
            for (int column = 0; column < accountsTable.Columns.Count; column++)
            {
                for (int row = 0; row < accountsTable.Rows.Count; row++)
                {
                    if (accountsTable.Rows[row].Cells[column].Value != null)
                    {
                        TempInfoOfSums info = new TempInfoOfSums
                            (
                            double.Parse(accountsTable.Rows[row].Cells[column].Value.ToString()),
                            column,
                            row,
                            User.ID
                            );
                        sumsList.Add(info);
                    }
                }
            }
            saveDataButton.Enabled = true;
        }

        private void OverwriteAccountNames()
        {
            var names = Connection.db.GetTable<AccountNames>().Where(x => x.UserId == User.ID).Select(x => x.Name).ToList();

            for(int i = 0; i < accountsTable.Rows.Count; i++)
            {
                accountsTable.Rows[i].HeaderCell.Value = names[i].ToString();
            }
        }

        private void InsertAccountNames()
        {
            for (int i = 0; i < accountsTable.Rows.Count; i++)
            {
                Connection.iwdb.InsertAccountNames(User.ID, accountsTable.Rows[i].HeaderCell.Value.ToString());
            }
        }

        private void deleteAccount_Click(object sender, EventArgs e)
        {
            bool isCellsEmpty = true;

            for(int i = 0; i < accountsTable.Columns.Count; i++)
            {
                if(accountsTable.Rows[rowIndex].Cells[i].Value != null)
                {
                    isCellsEmpty = false;
                    break;
                }
            }

            if (accountsTable.SelectedRows.Count == 1)
            {
                if (!isCellsEmpty)
                {
                    ExecuteIfCellIsNotEmpty();
                }
                else if (isCellsEmpty)
                {
                    ExecuteIfCellIsEmpty();
                }
            }
            else if (accountsTable.SelectedRows.Count > 1)
            {
                MessageBox.Show("Galima trinti tik po vieną sąskaitą. Pažymėkite kurią sąskaitą norite ištrinti.", "Pranešimas");
            }
            else if(accountsTable.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nepažymėjote kurią sąskaitą norite ištrinti.", "Klaida");
            }
        }

        private void ExecuteIfCellIsNotEmpty()
        {
            DialogResult result = MessageBox.Show("Šioje eilutėje yra duomenų, " +
                                    "kurie gali būti susiję su kitomis lentelėmis. " +
                                    "Ištrynus pažymėtą sąskaitą išsitrins ir šioje eilutėje esantys duomenys. " +
                                    "Ar tikrai norite trinti pažymėtą sąskaitą?", "Pranešimas", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Connection.iwdb.DeleteData("AccountNames", User.ID);
                Connection.iwdb.DeleteSumsInAffectedRowDb(rowIndex, User.ID);
                DeleteSumsInAffectedRowList();
                accountsTable.Rows.RemoveAt(rowIndex);
                MessageBox.Show("Duomenys ištrinti sėkmingai!", "Pranešimas");
                InsertAccountNames();
                FixSums();
                OverwriteTotalSumTable();
                SetTotalSumTableRowHeaderWidth();
            }
        }

        private void ExecuteIfCellIsEmpty()
        {
            DialogResult result = MessageBox.Show("Ar tikrai norite trinti pažymėtą sąskaitą?",
                        "Pranešimas", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Connection.iwdb.DeleteData("AccountNames", User.ID);
                DeleteSumsInAffectedRowList();
                accountsTable.Rows.RemoveAt(rowIndex);
                InsertAccountNames();
                FixSums();
                OverwriteTotalSumTable();
                SetTotalSumTableRowHeaderWidth();
            }
        }

        private void DeleteSumsInAffectedRowList()
        {
            sumsList.RemoveAll(x => x.accountNameId == rowIndex);
        }

        private void FixSums()
        {
            RefreshSumsList();
            saveDataButton.Enabled = false;
            Connection.iwdb.DeleteData("Sums", User.ID);
            Connection.iwdb.DeleteData("StartingSums", User.ID);
            Connection.iwdb.InsertSums(sumsList);
            Connection.iwdb.InsertStartingSums(accountsTable, User.ID, false);

            foreach (var item in sumsList)
            {
                accountsTable.Rows[item.accountNameId].Cells[item.dateId].Value = item.sum;
            }
        }

        private void LoadSums()
        {
            var sums = Connection.db.GetTable<Sums>().Where(x => x.UserId == User.ID).ToList();

            sumsList.Clear();

            foreach (var item in sums)
            {
                accountsTable.Rows[item.AccountNameId].Cells[item.DateId].Value = item.Sum1;

                TempInfoOfSums info = new TempInfoOfSums
                    (
                    item.Sum1, 
                    item.DateId, 
                    item.AccountNameId, 
                    int.Parse(item.UserId.ToString())
                    );

                sumsList.Add(info);
            }   
        }

        private void SetStylesAndLooks()
        {
            Connection.style.SetFormLooks(this);
            Connection.style.SetDataGridLooks(accountsTable);
            Connection.style.SetDataGridLooks(totalSumTable);
            Connection.style.SetColumnStyle(accountsTable, DataGridViewAutoSizeColumnsMode.None, true);
            Connection.style.SetColumnStyle(totalSumTable, DataGridViewAutoSizeColumnsMode.None, false);
            Connection.style.SetRowStyle(
                accountsTable, 
                DataGridViewAutoSizeRowsMode.DisplayedCells, 
                DataGridViewRowHeadersWidthSizeMode.DisableResizing, 
                115);
            Connection.style.SetRowStyle(totalSumTable, 
                DataGridViewAutoSizeRowsMode.DisplayedCells, 
                DataGridViewRowHeadersWidthSizeMode.DisableResizing,
                115);
            Connection.style.SetRowHeaderWidths(accountsTable, totalSumTable);
            Connection.style.SetCellStyle(accountsTable);
            Connection.style.SetCellStyle(totalSumTable);
            Connection.style.SetButtonStyle(addAccountButton);
            Connection.style.SetButtonStyle(deleteAccount);
            Connection.style.SetButtonStyle(accountsBackButton);
            Connection.style.SetDisabledButtonStyle(saveDataButton);
            Connection.style.SetDisabledButtonStyle(changeNameButton);
        }

        private void SetStylesAndLooksForIncompleteForm()
        {
            Connection.style.SetFormLooks(this);
            Connection.style.SetDataGridLooks(accountsTable);
            Connection.style.SetDataGridLooks(totalSumTable);
            Connection.style.SetButtonStyle(addAccountButton);
            Connection.style.SetDisabledButtonStyle(deleteAccount);
            Connection.style.SetButtonStyle(accountsBackButton);
            Connection.style.SetDisabledButtonStyle(saveDataButton);
            Connection.style.SetDisabledButtonStyle(changeNameButton);
        }

        private void AccountsTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            changeNameButton.Enabled = false;
            Connection.style.SetDisabledButtonStyle(changeNameButton);
            accountsTable.ClearSelection();
            totalSumTable.ClearSelection();
            Connection.style.PaintColumnAsSelected(accountsTable, e.ColumnIndex);
            Connection.style.PaintColumnAsSelected(totalSumTable, e.ColumnIndex);
            Connection.style.ChangeSelectedColumn(accountsTable, e.ColumnIndex);
            Connection.style.ChangeSelectedColumn(totalSumTable, e.ColumnIndex);
        }

        private void addAccountButton_MouseEnter(object sender, EventArgs e)
        {
            addAccountButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void addAccountButton_MouseLeave(object sender, EventArgs e)
        {
            addAccountButton.ForeColor = Color.White;
        }

        private void saveDataButton_EnabledChanged(object sender, EventArgs e)
        {
            if(saveDataButton.Enabled == false)
            {
                Connection.style.SetDisabledButtonStyle(saveDataButton);
            }
            else if (saveDataButton.Enabled == true)
            {
                Connection.style.SetButtonStyle(saveDataButton);
            }            
        }

        private void deleteAccount_MouseEnter(object sender, EventArgs e)
        {
            deleteAccount.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void deleteAccount_MouseLeave(object sender, EventArgs e)
        {
            deleteAccount.ForeColor = Color.White;
        }

        private void accountsBackButton_MouseEnter(object sender, EventArgs e)
        {
            accountsBackButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void accountsBackButton_MouseLeave(object sender, EventArgs e)
        {
            accountsBackButton.ForeColor = Color.White;
        }

        private void saveDataButton_MouseEnter(object sender, EventArgs e)
        {
            saveDataButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void saveDataButton_MouseLeave(object sender, EventArgs e)
        {
            saveDataButton.ForeColor = Color.White;
        }

        private void Accounts_Click(object sender, EventArgs e)
        {
            changeNameButton.Enabled = false;
            Connection.style.SetDisabledButtonStyle(changeNameButton);
            Connection.style.ClearSelection(accountsTable, true, true);
            Connection.style.ClearSelection(totalSumTable, true, true);
        }

        private void AccountsTable_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = accountsTable.HitTest(e.X, e.Y);
            if (hitInfo.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                Connection.style.ClearSelection(accountsTable, true, true);
                Connection.style.ClearSelection(totalSumTable, true, true);
            }

            if(hitInfo.Type == DataGridViewHitTestType.RowHeader)
            {
                if(changeNameButton.Enabled == false)
                {
                    changeNameButton.Enabled = true;
                    Connection.style.SetButtonStyle(changeNameButton);
                }              
            }
        }

        private void changeNameButton_MouseEnter(object sender, EventArgs e)
        {
            changeNameButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void changeNameButton_MouseLeave(object sender, EventArgs e)
        {
            changeNameButton.ForeColor = Color.White;
        }

        private void changeNameButton_Click(object sender, EventArgs e)
        {
            var accountId = Connection.db.GetTable<AccountNames>()
                .Where(x => x.UserId == User.ID && x.Name == accountsTable.Rows[rowIndex].HeaderCell.Value.ToString())
                .Select(x => x.Id).ToList();

            Action reloadAccounts = OverwriteAccountNames;
            reloadAccounts += SetTotalSumTableRowHeaderWidth;
            ChangingAccountName can = new ChangingAccountName(accountId[0], reloadAccounts);
            can.Show();
        }

        private void AddDataToTotalSumTable()
        {     
            var dates = Connection.db.GetTable<Dates>()
                .Where(x => x.UserId == User.ID).Select(x => x.Date1).ToList();

            if(dates.Count > 0)
            {
                for(int i = 0; i < dates.Count; i++)
                {
                    totalSumTable.Columns.Add("column", i.ToString());
                }

                totalSumTable.Rows.Add();
                totalSumTable.Rows[0].HeaderCell.Value = "Pinigų likutis";

                for(int column = 0; column < totalSumTable.Columns.Count; column++)
                {
                    var totalSums = Connection.db.GetTable<StartingSums>()
                    .Where(x => x.UserId == User.ID).ToList();

                    if (totalSums.Count > 0)
                    {
                        foreach (var item in totalSums)
                        {
                            totalSumTable.Rows[0].Cells[item.DateId].Value = item.Sum;
                        }
                    }               
                }                
            }
        }

        private void OverwriteTotalSumTable()
        {
            for(int column = 0; column < totalSumTable.Columns.Count; column++)
            {
                var sums = Connection.db.GetTable<Sums>()
                    .Where(x => x.DateId == column && x.UserId == User.ID).Select(x => x.Sum1).ToList();
                var startingSum = sums.Sum(x => x);

                if (sums.Count > 0)
                {
                    totalSumTable.Rows[0].Cells[column].Value = startingSum;
                }
                else if (sums.Count == 0 && startingSum == 0)
                {
                    totalSumTable.Rows[0].Cells[column].Value = null;
                }
            }
        }

        private void AccountsTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void AccountsTable_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if((e.KeyChar != (char)Keys.Back) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void AccountsTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(AccountsTable_KeyPress);

            TextBox tb = e.Control as TextBox;

            if (tb != null || tb == null)
            {
                tb.KeyPress += new KeyPressEventHandler(AccountsTable_KeyPress);
            }                       
        }

        private void TotalSumTable_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = totalSumTable.HitTest(e.X, e.Y);
            if (hitInfo.Type == DataGridViewHitTestType.RowHeader)
            {
                Connection.style.ClearSelection(accountsTable, true, true);
                Connection.style.ClearSelection(totalSumTable, true, false);
            }

            if(hitInfo.Type == DataGridViewHitTestType.Cell)
            {
                Connection.style.ClearSelection(accountsTable, false, true);
                Connection.style.ClearSelection(totalSumTable, false, false);
                Connection.style.PaintColumnAsSelected(accountsTable, columnIndex);
                Connection.style.PaintColumnAsSelected(totalSumTable, columnIndex);
                Connection.style.ChangeSelectedColumn(accountsTable, columnIndex);
                Connection.style.ChangeSelectedColumn(totalSumTable, columnIndex);
            }
        }

        private void TotalSumTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            changeNameButton.Enabled = false;
            Connection.style.SetDisabledButtonStyle(changeNameButton);

            if (e.ColumnIndex >= 0)
            {
                columnIndex = e.ColumnIndex;
            }                 
        }

        private void TotalSumTable_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                columnIndex = e.ColumnIndex;
                Connection.style.PaintColumnAsSelected(accountsTable, e.ColumnIndex);
                Connection.style.PaintColumnAsSelected(totalSumTable, e.ColumnIndex);
                Connection.style.ChangeSelectedColumn(accountsTable, e.ColumnIndex);
                Connection.style.ChangeSelectedColumn(totalSumTable, e.ColumnIndex);
            }
        }

        private void TotalSumTable_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            double value;
            if (rowIndex >= 0 && columnIndex >= 0)
            {
                if (e.Value != null && double.TryParse(e.Value.ToString(), out value))
                {
                    e.Value = value.ToString("C2");
                }
            }
        }


    }
}
