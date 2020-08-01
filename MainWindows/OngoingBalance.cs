using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace financeApp
{
    public partial class OngoingBalance : Form
    {   
        private Form menuForm;

        public OngoingBalance(Form _menuForm)
        {
            InitializeComponent();
            ongoingBalanceBackButton.TabStop = false;
            menuForm = _menuForm;
        }

        private void OngoingBalanceBackButton_Click(object sender, EventArgs e)
        {
            Hide();
            menuForm.Show();
        }

        private void OngoingBalance_Load(object sender, EventArgs e)
        {
            AddRowsAndColumns();
            ReturnBalances();
            SetStylesAndLooks();
        }

        private void ReturnBalances()
        {
            List<string> dateList = new List<string>();

            for (int i = 0; i < logOfBalances.Columns.Count; i++)
            {
                dateList.Add(logOfBalances.Columns[i].Name.ToString());
            }

            Balances balances = new Balances();
            balances.ReturnCategoryBalances(logOfBalances, dateList, false);
            balances.ReturnIncomeExpenditureBalances(logOfBalances, false);
            balances.ReturnCashFlowBalances(logOfBalances, false);
            balances.ReturnMoneyLeftoverAndStartingBalances(logOfBalances, false);     
        }

        private void AddRowsAndColumns()
        {
            FixColumnNames();
            FixRowNames();
        }

        private void FixColumnNames()
        {
            var dates = Connection.db.GetTable<Dates>().Where(x => x.UserId == User.ID).Select(x => x.Date1).ToList();

            for(int i = 1; i < dates.Count; i++)
            {
                logOfBalances.Columns.Add(dates[i], dates[i]);
            }
        }

        private void FixRowNames()
        {
            List<string> names = Connection.db.GetTable<RowHeadersForBalances>().Select(x => x.AccountName).ToList();

            for(int i = 0; i < names.Count; i++)
            {
                logOfBalances.Rows.Add();
                logOfBalances.Rows[i].HeaderCell.Value = names[i];
            }           
        }

        private void OngoingBalance_Shown(object sender, EventArgs e)
        {
            if (Balances.ReturnWarningMessageType() == 2)
            {
                MessageBox.Show("'Sąskaitos ir pinigų likučiai' skiltyje, " +
                    "nesate suvedę likučių už vieną ar daugiau mėnesių, todėl negalima suformuoti vieno ar daugiau balansų. " +
                    "Įveskite visų reikalingų mėnesių likučius.", "Pranešimas");
            }
        }

        private void SetStylesAndLooks()
        {
            Connection.style.SetFormLooks(this);
            Connection.style.SetDataGridLooks(logOfBalances);
            Connection.style.SetColumnStyle(logOfBalances, DataGridViewAutoSizeColumnsMode.DisplayedCells, true);
            Connection.style.SetRowStyle(
                logOfBalances,
                DataGridViewAutoSizeRowsMode.DisplayedCells,
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders,
                0);
            Connection.style.SetCellStyle(logOfBalances);
            Connection.style.SetButtonStyle(ongoingBalanceBackButton);

            if(Balances.ReturnWarningMessageType() != 2)
            {
                string today = DateTime.Today.ToString("yyyy-MM");

                for (int column = 0; column < logOfBalances.Columns.Count; column++)
                {
                    if (logOfBalances.Columns[column].HeaderText == today)
                    {
                        Connection.style.PaintColumnAsSelected(logOfBalances, column);
                    }
                }
            }

            logOfBalances.ClearSelection();
        }

        private void LogOfBalances_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitInfo = logOfBalances.HitTest(e.X, e.Y);
            if (hitInfo.Type == DataGridViewHitTestType.TopLeftHeader)
            {
                Connection.style.ClearSelection(logOfBalances, false, true);
            }
        }

        private void LogOfBalances_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > 0 && e.ColumnIndex > 0)
            {
                logOfBalances.ClearSelection();
            }
        }

        private void OngoingBalanceBackButton_MouseEnter(object sender, EventArgs e)
        {
            ongoingBalanceBackButton.ForeColor = Color.FromArgb(17, 17, 17);
        }

        private void OngoingBalanceBackButton_MouseLeave(object sender, EventArgs e)
        {
            ongoingBalanceBackButton.ForeColor = Color.White;
        }

        private void OngoingBalance_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
