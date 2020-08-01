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
    public partial class BudgetPlanning : Form
    {
        private List<TempPlanningInfo> tempBudgetList = new List<TempPlanningInfo>();
        private int columnIndex { get; set; }
        private int dateIndex { get; set; }
        private Form menuForm;

        public BudgetPlanning(Form _menuForm)
        {
            InitializeComponent();
            budgetPlanningBackButton.TabStop = false;
            saveDataButton.TabStop = false;
            menuForm = _menuForm;
        }

        private void BudgetPlanningBackButton_Click(object sender, EventArgs e)
        {
            if (saveDataButton.Enabled == true)
            {
                DialogResult result = MessageBox.Show("Jūsų atlikti pakeitimai bus neišsaugoti. " +
                    "Ar tikrai norite grįžti į Meniu?", "Pranešimas", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.FormClosing -= BudgetPlanning_FormClosing;
                    this.Hide();
                    menuForm.Show();                    
                }
            }
            else if (saveDataButton.Enabled == false)
            {
                this.FormClosing -= BudgetPlanning_FormClosing;
                this.Hide();
                menuForm.Show();
            }
        }

        private void BudgetPlanning_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveDataButton.Enabled == true)
            {
                DialogResult result = MessageBox.Show("Jūsų atlikti pakeitimai bus neišsaugoti. " +
                    "Ar tikrai norite išeiti?", "Pranešimas", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.FormClosing -= BudgetPlanning_FormClosing;
                    Application.Exit();
                }

                e.Cancel = (result == DialogResult.No);
            }
        }

        private void BudgetPlanning_Load(object sender, EventArgs e)
        {
            AddTodaysDate();
            AddRemainingDates();
            FixRowNames();
            LoadOngoingBalance();
            LoadPlanningBalances();
            SetStylesAndLooks();

            if(Balances.ReturnWarningMessageType() == 0)
            {
                CompareCellsAndSetColours();
            }
            
            budgetPlanningLog.ClearSelection();
        }

        private void CompareIncomeCategories(List<int> _incomeCategories)
        {
            for (int i = 0; i < _incomeCategories.Count; i++)
            {
                int index = _incomeCategories[i] - 1;
                var currentBalanceCell = budgetPlanningLog.Rows[index].Cells[0];
                var planningBalanceCell = budgetPlanningLog.Rows[index].Cells[1];

                if (planningBalanceCell.Value != null)
                {
                    double currentBalance = double.Parse(currentBalanceCell.Value.ToString());
                    double planningBalance = double.Parse(planningBalanceCell.Value.ToString());

                    if (currentBalance > planningBalance)
                    {
                        currentBalanceCell.Style.BackColor = Color.FromArgb(0, 153, 51); //green
                    }
                    else if (currentBalance < planningBalance)
                    {
                        currentBalanceCell.Style.BackColor = Color.FromArgb(153, 0, 0); //red
                    }
                    else if(currentBalance == planningBalance)
                    {
                        currentBalanceCell.Style.BackColor = Color.FromArgb(17, 17, 17); //neutral
                    }
                }
                else if(planningBalanceCell.Value == null)
                {
                    currentBalanceCell.Style.BackColor = Color.FromArgb(17, 17, 17); //neutral             
                }
            }
        }

        private void CompareExpenditureCategories(List<int> _expenditureCategories)
        {
            for (int i = 0; i < _expenditureCategories.Count; i++)
            {
                int index = _expenditureCategories[i] - 1;
                var currentBalanceCell = budgetPlanningLog.Rows[index].Cells[0];
                var planningBalanceCell = budgetPlanningLog.Rows[index].Cells[1];

                if (planningBalanceCell.Value != null)
                {
                    double currentBalance = double.Parse(currentBalanceCell.Value.ToString());
                    double planningBalance = double.Parse(planningBalanceCell.Value.ToString());

                    if (currentBalance < planningBalance)
                    {
                        currentBalanceCell.Style.BackColor = Color.FromArgb(0, 153, 51); //green
                    }
                    else if (currentBalance > planningBalance)
                    {
                        currentBalanceCell.Style.BackColor = Color.FromArgb(153, 0, 0); //red
                    }
                    else if (currentBalance == planningBalance)
                    {
                        currentBalanceCell.Style.BackColor = Color.FromArgb(17, 17, 17); //neutral
                    }
                }
                else if (planningBalanceCell.Value == null)
                {
                    currentBalanceCell.Style.BackColor = Color.FromArgb(17, 17, 17); //neutral
                }
            }
        }

        private void CompareCellsAndSetColours()
        {
            var incomeCategories = Connection.db.GetTable<RowHeadersForBalances>()
                .Where
                (
                x => 
                (x.AccountNameType == "pajamos" || 
                x.AccountNameType == "paj" || 
                x.AccountNameType == "pns" || 
                x.AccountNameType == "pab") 
                )
                .Select(x => x.Id).ToList();

            var expenditureCategories = Connection.db.GetTable<RowHeadersForBalances>()
                .Where(x => (x.AccountNameType == "išlaidos" || x.AccountNameType == "išl"))
                .Select(x => x.Id).ToList();

            CompareIncomeCategories(incomeCategories);
            CompareExpenditureCategories(expenditureCategories);        
        }

        private void LoadPlanningBalances()
        {
            var balances = Connection.db.GetTable<BudgetPlanningInfo>().Where(x => x.UserId == User.ID).ToList();

            foreach(var item in balances)
            {      
                for (int i = 1; i < budgetPlanningLog.Columns.Count; i++)
                {
                    int existingDateIndex = int.Parse(DateTime.Parse(budgetPlanningLog.Columns[i].HeaderText).ToString("MM"));

                    if (item.DateIndex == existingDateIndex)
                    {
                        columnIndex = i;
                        budgetPlanningLog.Rows[item.CategoryIndex].Cells[columnIndex].Value = item.Sum;

                        TempPlanningInfo tpi = new TempPlanningInfo
                        (
                        item.Sum,
                        item.CategoryIndex,
                        item.DateIndex,
                        item.UserId
                        );
                        tempBudgetList.Add(tpi);
                    }
                }   
            }

            Connection.iwdb.DeleteData("BudgetPlanningInfo", User.ID);
            Connection.iwdb.InsertBudgetPlanningInfo(tempBudgetList); 
        }

        private void FixRowNames()
        {
            List<string> names = Connection.db.GetTable<RowHeadersForBalances>().Select(x => x.AccountName).ToList();

            for (int i = 0; i < names.Count; i++)
            {
                budgetPlanningLog.Rows.Add();
                budgetPlanningLog.Rows[i].HeaderCell.Value = names[i];
            }
        }

        private void AddTodaysDate()
        {
            var dates = Connection.db.GetTable<Dates>().Where(x => x.UserId == User.ID).Select(x => x.Date1).ToList();
            budgetPlanningLog.Columns.Add(dates.Last(), dates.Last());
            budgetPlanningLog.Columns[dates.Last()].ReadOnly = true;
        }

        private void AddRemainingDates()
        {
            string thisMonth = DateTime.Today.ToString("MM");
            string thisYear = DateTime.Today.ToString("yyyy");

            for (int i = int.Parse(thisMonth); i <= 12; i++)
            {
                string formedDate = thisYear + "-" + i.ToString("00");
                budgetPlanningLog.Columns.Add(formedDate, formedDate);
            }
        }

        private void LoadOngoingBalance()
        {
            List<string> dateList = new List<string>();
            dateList.Add(DateTime.Today.ToString("yyyy-MM"));

            Balances balances = new Balances();
            balances.ReturnCategoryBalances(budgetPlanningLog, dateList, true);
            balances.ReturnIncomeExpenditureBalances(budgetPlanningLog, true);
            balances.ReturnCashFlowBalances(budgetPlanningLog, true);
            balances.ReturnMoneyLeftoverAndStartingBalances(budgetPlanningLog, true);
            
            budgetPlanningLog.Columns[0].Width = 100;
            budgetPlanningLog.Columns[0].Frozen = true;
        }

        private void BudgetPlanningLog_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CheckForIllegalChars(e.RowIndex, e.ColumnIndex);

            int existingDateIndex = int.Parse(DateTime.Parse(budgetPlanningLog.Columns[e.ColumnIndex].HeaderText).ToString("MM"));

            if (budgetPlanningLog.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                //tikrinam liste ar yra toks duomuo keiciamoje celeje, jei randam ismetam is listo
                
                foreach (var item in tempBudgetList)
                {
                    if (item.categoryIndex == e.RowIndex && item.dateIndex == existingDateIndex)
                    {
                        tempBudgetList.Remove(item);
                        break;
                    }
                }

                //sukuriam nauja objekta (su nauja suma) ir idedam i lista

                TempPlanningInfo tpi = new TempPlanningInfo
                    (
                    double.Parse(budgetPlanningLog.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()),
                    e.RowIndex,
                    dateIndex,
                    User.ID
                    );

                tempBudgetList.Add(tpi);
                saveDataButton.Enabled = true;
                CompareCellsAndSetColours();
            }
            else if (budgetPlanningLog.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                //reikia ismesti is listo reiksme, kuri buvo pries istrynima irasyta sitoje celeje
                foreach (var item in tempBudgetList)
                {
                    if (item.categoryIndex == e.RowIndex && item.dateIndex == existingDateIndex)
                    {
                        tempBudgetList.Remove(item);
                        break;
                    }
                }
                saveDataButton.Enabled = true;
                CompareCellsAndSetColours();
            }
        }

        private void CheckForIllegalChars(int _rowIndex, int _columnIndex)
        {
            double tempSum;

            if (budgetPlanningLog.Rows[_rowIndex].Cells[_columnIndex].Value != null)
            {
                try
                {
                    tempSum = double.Parse(budgetPlanningLog.Rows[_rowIndex].Cells[_columnIndex].Value.ToString());
                }
                catch
                {
                    string tempValue = "";
                    var tempChars = budgetPlanningLog.Rows[_rowIndex].Cells[_columnIndex].Value.ToString().ToCharArray().ToList();
                    if (tempChars.Count >= 6 && tempChars[tempChars.Count - 2] == ' ' && tempChars[tempChars.Count - 1] == '€')
                    {
                        tempChars.RemoveAt(tempChars.Count - 2);
                        tempChars.RemoveAt(tempChars.Count - 1);

                        foreach (var item in tempChars)
                        {
                            tempValue += item;
                        }

                        budgetPlanningLog.Rows[_rowIndex].Cells[_columnIndex].Value = tempValue;
                    }
                    else
                    {
                        budgetPlanningLog.Rows[_rowIndex].Cells[_columnIndex].Value = null;
                        MessageBox.Show("Įvesti blogi duomenys. Pataisykite laukelį.", "Klaida");
                    }
                }
            }
        }

        private void BudgetPlanningLog_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            columnIndex = e.ColumnIndex;
            dateIndex = int.Parse(DateTime.Parse(budgetPlanningLog.Columns[e.ColumnIndex].HeaderText).ToString("MM"));
        }

        private void BudgetPlanningLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            columnIndex = budgetPlanningLog.CurrentCell.ColumnIndex;
            dateIndex = int.Parse(DateTime.Parse(budgetPlanningLog.Columns[columnIndex].HeaderText).ToString("MM"));
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

                Connection.iwdb.DeleteData("BudgetPlanningInfo", User.ID);

                if (tempBudgetList.Count > 0)
                {
                    Connection.iwdb.InsertBudgetPlanningInfo(tempBudgetList);
                }

                MessageBox.Show("Duomenys išsaugoti sėkmingai!");
                saveDataButton.Enabled = false;
            }     
        }

        private void BudgetPlanning_Shown(object sender, EventArgs e)
        {
            int message = Balances.ReturnWarningMessageType();

            if (message == 1)
            {
                MessageBox.Show("'Sąskaitos ir pinigų likučiai' skiltyje, " +
                    "nesate suvedę likučių už praėjusį mėnesį, todėl negalima " +
                    "suformuoti likučių mėnesio pradžioje ir mėnesio pabaigoje " +
                    "bei palyginti balansų su kitu mėnesiu. " +
                    "Įveskite praeito mėnesio likučius.", "Pranešimas");
            }
        }

        private void SetStylesAndLooks()
        {
            Connection.style.SetFormLooks(this);
            Connection.style.SetDataGridLooks(budgetPlanningLog);
            Connection.style.SetRowStyle(budgetPlanningLog, DataGridViewAutoSizeRowsMode.DisplayedCells, DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders, 0);
            Connection.style.SetColumnStyle(budgetPlanningLog, DataGridViewAutoSizeColumnsMode.DisplayedCells, true);
            Connection.style.SetCellStyle(budgetPlanningLog);
            Connection.style.SetLabelStyle(text1, 7);
            Connection.style.SetLabelStyle(text2, 7);
            Connection.style.SetDisabledButtonStyle(saveDataButton);
            Connection.style.SetButtonStyle(budgetPlanningBackButton);
        }

        private void saveDataButton_EnabledChanged(object sender, EventArgs e)
        {
            if (saveDataButton.Enabled == false)
            {
                Connection.style.SetDisabledButtonStyle(saveDataButton);
            }
            else if (saveDataButton.Enabled == true)
            {
                Connection.style.SetButtonStyle(saveDataButton);
            }
        }

        private void BudgetPlanningLog_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Connection.style.ClearSelection(budgetPlanningLog, true, true);
            CompareCellsAndSetColours();
            Connection.style.PaintColumnAsSelected(budgetPlanningLog, e.ColumnIndex);     
        }

        private void BudgetPlanningLog_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = budgetPlanningLog.HitTest(e.X, e.Y);
            if (hitInfo.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                CompareCellsAndSetColours();
                Connection.style.ClearSelection(budgetPlanningLog, true, true);
            }
        }

        private void BudgetPlanning_Click(object sender, EventArgs e)
        {
            CompareCellsAndSetColours();
            Connection.style.ClearSelection(budgetPlanningLog, true, true);
        }

        private void BudgetPlanningLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void BudgetPlanningLog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }
        }

        private void BudgetPlanningLog_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(BudgetPlanningLog_KeyPress);

            TextBox tb = e.Control as TextBox;

            if (tb != null || tb == null)
            {
                tb.KeyPress += new KeyPressEventHandler(BudgetPlanningLog_KeyPress);
            }
        }

        private void saveDataButton_MouseEnter(object sender, EventArgs e)
        {
            saveDataButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void saveDataButton_MouseLeave(object sender, EventArgs e)
        {
            saveDataButton.ForeColor = Color.White;
        }

        private void BudgetPlanningBackButton_MouseEnter(object sender, EventArgs e)
        {
            budgetPlanningBackButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void BudgetPlanningBackButton_MouseLeave(object sender, EventArgs e)
        {
            budgetPlanningBackButton.ForeColor = Color.White;
        }
    }
}
