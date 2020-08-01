using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace financeApp
{
    public class Balances
    {
        private static int warningMessageType = 0;

        public void ReturnCategoryBalances(DataGridView dataGrid, List<string> _dateList, bool countForOneColumn)
        {
            List<string> dateList = _dateList;

            List<string> categories = Connection.db.GetTable<RowHeadersForBalances>()
                .Where(x => (x.AccountNameType == "pajamos" || x.AccountNameType == "išlaidos"))
                .Select(x => x.AccountName).ToList();

            List<int> indexOfCategories = Connection.db.GetTable<RowHeadersForBalances>()
                .Where(x => (x.AccountNameType == "pajamos" || x.AccountNameType == "išlaidos"))
                .Select(x => x.Id).ToList();

            if (!countForOneColumn)
            {
                for (int column = 0; column < dataGrid.Columns.Count; column++)
                {
                    for (int row = 0; row < categories.Count; row++)
                    {
                        DateTime beginning = DateTime.Parse(dateList[column].ToString() + "-01");

                        DateTime ending = DateTime.Parse(ReturningTheCorrectEnding(beginning, dateList, column));

                        int index = indexOfCategories[row] - 1;

                        dataGrid.Rows[index].Cells[column].Value =
                            CountBalanceOfSelectedCategory(categories[row], beginning, ending);
                    }
                }
            }
            else if (countForOneColumn)
            {
                for (int row = 0; row < categories.Count; row++)
                {
                    DateTime beginning = DateTime.Parse(dateList[0].ToString() + "-01");

                    DateTime ending = DateTime.Parse(ReturningTheCorrectEnding(beginning, dateList, 0));

                    int index = indexOfCategories[row] - 1;

                    dataGrid.Rows[index].Cells[0].Value =
                        CountBalanceOfSelectedCategory(categories[row], beginning, ending);
                }
            }
        }

        public void ReturnIncomeExpenditureBalances(DataGridView dataGrid, bool countForOneColumn)
        {
            List<string> incomeAndExpenditure = Connection.db.GetTable<RowHeadersForBalances>()
                .Where(x => x.AccountNameType == "paj" || x.AccountNameType == "išl")
                .Select(x => x.AccountName).ToList();

            List<int> indexesIncomeExpenditure = Connection.db.GetTable<RowHeadersForBalances>()
                .Where(x => x.AccountNameType == "paj" || x.AccountNameType == "išl")
                .Select(x => x.Id).ToList();

            if (!countForOneColumn)
            {
                for (int column = 0; column < dataGrid.Columns.Count; column++)
                {
                    for (int row = 0; row < incomeAndExpenditure.Count; row++)
                    {
                        int index = indexesIncomeExpenditure[row] - 1;

                        dataGrid.Rows[index].Cells[column].Value =
                            CountIncomeAndExpenditure(dataGrid, incomeAndExpenditure[row], column);
                    }
                }
            }
            else if (countForOneColumn)
            {
                for (int row = 0; row < incomeAndExpenditure.Count; row++)
                {
                    int index = indexesIncomeExpenditure[row] - 1;

                    dataGrid.Rows[index].Cells[0].Value =
                        CountIncomeAndExpenditure(dataGrid, incomeAndExpenditure[row], 0);
                }
            }
        }

        public void ReturnCashFlowBalances(DataGridView dataGrid, bool countForOneColumn)
        {
            if (!countForOneColumn)
            {
                for (int column = 0; column < dataGrid.Columns.Count; column++)
                {
                    int rowOfCashFlow = IndexOfCashFlow() - 1;
                    int rowOfIncome = IndexOfIncome() - 1;
                    int rowOfExpenditure = IndexOfExpenditure() - 1;

                    double incomeBalance = double.Parse(dataGrid.Rows[rowOfIncome].Cells[column].Value.ToString());
                    double expenditureBalance = double.Parse(dataGrid.Rows[rowOfExpenditure].Cells[column].Value.ToString());
                    var cashFlow = dataGrid.Rows[rowOfCashFlow].Cells[column];

                    cashFlow.Value = incomeBalance - expenditureBalance;
                }
            }
            else if (countForOneColumn)
            {
                int rowOfCashFlow = IndexOfCashFlow() - 1;
                int rowOfIncome = IndexOfIncome() - 1;
                int rowOfExpenditure = IndexOfExpenditure() - 1;

                double incomeBalance = double.Parse(dataGrid.Rows[rowOfIncome].Cells[0].Value.ToString());
                double expenditureBalance = double.Parse(dataGrid.Rows[rowOfExpenditure].Cells[0].Value.ToString());
                var cashFlow = dataGrid.Rows[rowOfCashFlow].Cells[0];

                cashFlow.Value = incomeBalance - expenditureBalance;
            }
        }

        public void ReturnMoneyLeftoverAndStartingBalances(DataGridView dataGrid, bool countForOneColumn)
        { 
            if (!countForOneColumn)
            {
                var allStartingSums = Connection.db.GetTable<StartingSums>()
                    .Where(x => x.UserId == User.ID).Select(x => x.Sum).ToList();
                
                if(allStartingSums.Count == dataGrid.Columns.Count)
                {
                    CountForMoreColumns(true, dataGrid);
                }
                else if(allStartingSums.Count != dataGrid.Columns.Count)
                {
                    CountForMoreColumns(false, dataGrid);
                }                
            }
            else if (countForOneColumn)
            {                                
                if(ReturnUniqueOperationDates() > 1)
                {
                    CountForOneColumn(true, dataGrid);
                } 
                else if(ReturnUniqueOperationDates() <= 1)
                {
                    CountForOneColumn(false, dataGrid);
                }
            }
        }

        private int IndexOfCashFlow()
        {
            List<int> indexOfCashFlow = Connection.db.GetTable<RowHeadersForBalances>()
                .Where(x => x.AccountNameType == "pns")
                .Select(x => x.Id).ToList();

            return indexOfCashFlow[0];
        }

        private int IndexOfIncome()
        {
            List<int> indexOfIncome = Connection.db.GetTable<RowHeadersForBalances>()
                .Where(x => x.AccountNameType == "paj")
                .Select(x => x.Id).ToList();

            return indexOfIncome[0];
        }

        private int IndexOfExpenditure()
        {
            List<int> indexOfExpenditure = Connection.db.GetTable<RowHeadersForBalances>()
                .Where(x => x.AccountNameType == "išl")
                .Select(x => x.Id).ToList();

            return indexOfExpenditure[0];
        }

        private int IndexOfMoneyLeftOver()
        {
            List<int> indexOfMoneyLeftOver = Connection.db.GetTable<RowHeadersForBalances>()
                .Where(x => x.AccountNameType == "pab")
                .Select(x => x.Id).ToList();

            return indexOfMoneyLeftOver[0];
        }

        private int IndexOfStartingMoney()
        {
            List<int> indexOfStartingMoney = Connection.db.GetTable<RowHeadersForBalances>()
                .Where(x => x.AccountNameType == "pra")
                .Select(x => x.Id).ToList();

            return indexOfStartingMoney[0];
        }

        private int ReturnUniqueOperationDates()
        {
            var allDates = Connection.db.GetTable<OperationInfo>()
                .Where(x => x.UserId == User.ID).Select(x => x.Date).ToList();

            List<string> dates = new List<string>();

            foreach (var item in allDates)
            {
                dates.Add(item.ToString("yyyy-MM"));
            }

            dates = dates.Distinct().ToList();

            return dates.Count;
        }

        private string ReturnRequiredDate()
        {
            var allDates = Connection.db.GetTable<Dates>().Where(x => x.UserId == User.ID).Select(x => x.Date1).ToList();
            var splitToday = DateTime.Today.ToString("yyyy-MM").Split('-').ToList();

            string requiredDate = "";

            if(allDates.Count > 2)
            {
                if (splitToday[1] == "01")
                {
                    requiredDate += ((int.Parse(splitToday[0]) - 1).ToString() + "-12");
                }
                else
                {
                    requiredDate += (splitToday[0] + "-" + (int.Parse(splitToday[1]) - 1).ToString("00"));
                }
            }
            else if(allDates.Count == 2)
            {
                requiredDate += "Startinis likutis";
            }
            
            return requiredDate;        
        }

        private void CountForMoreColumns(bool startingSumsEqualGridColumns, DataGridView dataGrid)
        {
            warningMessageType = 0;

            var startingSums = Connection.db.GetTable<StartingSums>()
                .Where(x => x.UserId == User.ID).Select(x => x.Sum).ToList();

            if (startingSumsEqualGridColumns)
            {
                for (int column = 0; column < dataGrid.Columns.Count; column++)
                {
                    dataGrid.Rows[IndexOfStartingMoney() - 1].Cells[column].Value = startingSums[column];
                    double startingSum = startingSums[column];
                    double cashFlow = double.Parse(dataGrid.Rows[IndexOfCashFlow() - 1].Cells[column].Value.ToString());
                    double moneyLeftOver = startingSum + cashFlow;
                    var cellOfMoneyLeftOver = dataGrid.Rows[IndexOfMoneyLeftOver() - 1].Cells[column];

                    cellOfMoneyLeftOver.Value = moneyLeftOver;
                }
            }
            else if (!startingSumsEqualGridColumns)
            {
                for (int column = 0; column < dataGrid.Columns.Count; column++)
                {
                    if (column >= startingSums.Count)
                    {
                        var cellOfStartingMoney = dataGrid.Rows[IndexOfStartingMoney() - 1].Cells[column];
                        var cellOfMoneyLeftOver = dataGrid.Rows[IndexOfMoneyLeftOver() - 1].Cells[column];

                        cellOfStartingMoney.Value = 0;
                        cellOfStartingMoney.Style.BackColor = Color.Red;
                        cellOfMoneyLeftOver.Value = 0;
                        cellOfMoneyLeftOver.Style.BackColor = Color.Red;
                        warningMessageType = 2;
                    }
                    else if (column < startingSums.Count)
                    {
                        var cellOfStartingMoney = dataGrid.Rows[IndexOfStartingMoney() - 1].Cells[column];
                        var cellOfMoneyLeftOver = dataGrid.Rows[IndexOfMoneyLeftOver() - 1].Cells[column];
                        var cellOfCashFlow = dataGrid.Rows[IndexOfCashFlow() - 1].Cells[column];

                        cellOfStartingMoney.Value = startingSums[column];
                        double cashFlow = double.Parse(cellOfCashFlow.Value.ToString());
                        double moneyLeftOver = startingSums[column] + cashFlow;
                        cellOfMoneyLeftOver.Value = moneyLeftOver;
                    }
                }                
            }
        }

        public static int ReturnWarningMessageType()
        {
            return warningMessageType;
        }

        private void CountForOneColumn(bool datesMoreThanOne, DataGridView dataGrid)
        {
            warningMessageType = 0;

            var theDate = Connection.db.GetTable<Dates>()
                .Where(x => x.Date1 == ReturnRequiredDate() && x.UserId == User.ID).Select(x => x.Date1).ToList();
            var startingDate = Connection.db.GetTable<Dates>()
                .Where(x => x.Date1 == "Startinis likutis" && x.UserId == User.ID).Select(x => x.Date1).ToList();
            var allDates = Connection.db.GetTable<Dates>().Where(x => x.UserId == User.ID).Select(x => x.Date1).ToList();
            
            List<int> theIndex = new List<int>();

            foreach(var item in allDates)
            {
                if(item == ReturnRequiredDate())
                {
                    theIndex.Add(allDates.IndexOf(item));
                    break;
                }
            }

            List<double> startingSum = ReturnStartingSumList(theIndex, startingDate, dataGrid);

            CountMoneyLeftOvers(datesMoreThanOne, startingSum, theDate, dataGrid);
        }

        private List<double> ReturnStartingSumList(List<int> theIndex, List<string> startingDate, DataGridView dataGrid)
        {
            List<double> startingSum = new List<double>();

            if (theIndex.Count > 0)
            {
                var allStartingSums = Connection.db.GetTable<StartingSums>()
                    .Where(x => x.UserId == User.ID).Select(x => x.Sum).ToList();

                try
                {
                    startingSum.Add(allStartingSums[theIndex[0]]);
                }
                catch
                {
                    var cellOfStartingMoney = dataGrid.Rows[IndexOfStartingMoney() - 1].Cells[0];
                    var cellOfMoneyLeftOver = dataGrid.Rows[IndexOfMoneyLeftOver() - 1].Cells[0];

                    cellOfStartingMoney.Value = 0;
                    cellOfMoneyLeftOver.Value = 0;
                    warningMessageType = 1;
                }
                
            }
            else if (theIndex.Count == 0 && startingDate.Count == 0)
            {
                var cellOfStartingMoney = dataGrid.Rows[IndexOfStartingMoney() - 1].Cells[0];
                var cellOfMoneyLeftOver = dataGrid.Rows[IndexOfMoneyLeftOver() - 1].Cells[0];

                cellOfStartingMoney.Value = "0";
                cellOfMoneyLeftOver.Value = "0";
                warningMessageType = 1;
            }

            return startingSum;
        }

        private void CountMoneyLeftOvers(bool datesMoreThanOne, List<double> startingSum, List<string> theDate, DataGridView dataGrid)
        {
            if (datesMoreThanOne && startingSum.Count > 0)
            {
                if (theDate.Count == 1)
                {
                    var cellOfStartingMoney = dataGrid.Rows[IndexOfStartingMoney() - 1].Cells[0];
                    var cellOfMoneyLeftOver = dataGrid.Rows[IndexOfMoneyLeftOver() - 1].Cells[0];
                    var cellOfCashFlow = dataGrid.Rows[IndexOfCashFlow() - 1].Cells[0];

                    cellOfStartingMoney.Value = startingSum[0];
                    double cashFlow = double.Parse(cellOfCashFlow.Value.ToString());
                    double moneyLeftOver = startingSum[0] + cashFlow;
                    cellOfMoneyLeftOver.Value = moneyLeftOver;
                }
                else if (theDate.Count == 0)
                {
                    dataGrid.Rows[IndexOfStartingMoney() - 1].Cells[0].Value = 0;
                    dataGrid.Rows[IndexOfMoneyLeftOver() - 1].Cells[0].Value = 0;
                    warningMessageType = 1;
                }
            }
            else if (!datesMoreThanOne && startingSum.Count > 0)
            {
                var cellOfStartingMoney = dataGrid.Rows[IndexOfStartingMoney() - 1].Cells[0];
                var cellOfMoneyLeftOver = dataGrid.Rows[IndexOfMoneyLeftOver() - 1].Cells[0];
                var cellOfCashFlow = dataGrid.Rows[IndexOfCashFlow() - 1].Cells[0];

                cellOfStartingMoney.Value = startingSum[0];
                double cashFlow = double.Parse(cellOfCashFlow.Value.ToString());
                double moneyLeftOver = startingSum[0] + cashFlow;
                cellOfMoneyLeftOver.Value = moneyLeftOver;
            }
            else if (startingSum.Count == 0)
            {
                var cellOfStartingMoney = dataGrid.Rows[IndexOfStartingMoney() - 1].Cells[0];
                var cellOfMoneyLeftOver = dataGrid.Rows[IndexOfMoneyLeftOver() - 1].Cells[0];

                cellOfStartingMoney.Style.BackColor = Color.Red;
                cellOfStartingMoney.Value = 0;
                cellOfMoneyLeftOver.Style.BackColor = Color.Red;
                cellOfMoneyLeftOver.Value = 0;
                warningMessageType = 1;
            }
        }

        private double CountIncomeAndExpenditure(DataGridView dataGrid, string nameOfRow, int column)
        {
            double totalSum = 0;

            List<string> dateList = new List<string>();

            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                dateList.Add(dataGrid.Columns[i].Name.ToString());
            }

            List<string> incomeCategories = Connection.db.GetTable<RowHeadersForBalances>()
                .Where(x => x.AccountNameType == "pajamos")
                .Select(x => x.AccountName).ToList();

            List<string> expenditureCategories = Connection.db.GetTable<RowHeadersForBalances>()
                .Where(x => x.AccountNameType == "išlaidos")
                .Select(x => x.AccountName).ToList();

            if (nameOfRow == "PAJAMOS")
            {
                for (int row = 0; row < incomeCategories.Count; row++)
                {
                    DateTime beginning = DateTime.Parse(dateList[column].ToString() + "-01");

                    DateTime ending = DateTime.Parse(ReturningTheCorrectEnding(beginning, dateList, column));

                    totalSum += CountBalanceOfSelectedCategory(incomeCategories[row], beginning, ending);
                }
            }
            else if (nameOfRow == "IŠLAIDOS")
            {
                for (int row = 0; row < expenditureCategories.Count; row++)
                {
                    DateTime beginning = DateTime.Parse(dateList[column].ToString() + "-01");

                    DateTime ending = DateTime.Parse(ReturningTheCorrectEnding(beginning, dateList, column));

                    totalSum += CountBalanceOfSelectedCategory(expenditureCategories[row], beginning, ending);
                }
            }

            return totalSum;
        }

        private double CountBalanceOfSelectedCategory(string category, DateTime beginning, DateTime ending)
        {
            var sums = Connection.db.GetTable<OperationInfo>()
                .Where(x => x.Date >= beginning && x.Date <= ending && x.SelectedType == category && x.UserId == User.ID)
                .Select(x => x.Sum).ToList();
            
            double totalSum = sums.Sum(x => x);

            return totalSum;
        }

        private string ReturningTheCorrectEnding(DateTime _beginning, List<string> _dateList, int _column)
        {
            string[] monthsWith30days = { "04", "06", "09", "11" };
            string[] monthsWith31days = { "01", "03", "05", "07", "08", "10", "12" };

            List<string> dateList = _dateList;
            int column = _column;
            DateTime beginning = _beginning;

            string ending = "";

            if (beginning.ToString("MM") == "02")
            {
                ending += dateList[column].ToString() + "-29";
            }
            else
            {
                foreach (var item in monthsWith30days)
                {
                    if (beginning.ToString("MM") == item)
                    {
                        ending += dateList[column].ToString() + "-30";
                        break;
                    }
                }

                foreach (var item in monthsWith31days)
                {
                    if (beginning.ToString("MM") == item)
                    {
                        ending += dateList[column].ToString() + "-31";
                        break;
                    }
                }
            }
            return ending;
        }

        public double ReturnCurrentBalance()
        {
            double currentBalance = 0;

            var dates = Connection.db.GetTable<Dates>().Where(x => x.UserId == User.ID).Select(x => x.Date1).ToList();
            
            var startingSums = Connection.db.GetTable<StartingSums>().Where(x => x.UserId == User.ID).Select(x => x.Sum).ToList();

            if(dates.Count > 1)
            {
                DateTime beginning = DateTime.Parse(dates[dates.Count - 1] + "-" + "01");
                string ending = ReturningTheCorrectEnding(beginning, dates, (dates.Count - 1));

                var operations = Connection.db.GetTable<OperationInfo>()
                    .Where(x => x.Date >= beginning && x.Date <= DateTime.Parse(ending) && x.UserId == User.ID).ToList();

                if (startingSums.Count > 0)
                {
                    double incomeSum = ReturnIncomeSum(operations);
                    double expenditureSum = ReturnExpenditureSum(operations);

                    try
                    {
                        currentBalance = startingSums[dates.Count - 2] + incomeSum - expenditureSum;
                    }
                    catch
                    {
                        currentBalance = 0;
                    }
                }        
            }

            return currentBalance;
        }

        private double ReturnIncomeSum(List<OperationInfo> operations)
        {
            double incomeSum = 0;

            var incomes = Connection.db.GetTable<RowHeadersForBalances>()
                        .Where(x => x.AccountNameType == "pajamos").Select(x => x.AccountName).ToList();

            for (int i = 0; i < incomes.Count; i++)
            {
                var sums = operations.Where(x => x.SelectedType == incomes[i]).Select(x => x.Sum).ToList();
                foreach (var sum in sums)
                {
                    incomeSum = incomeSum + sum;
                }
            }

            return incomeSum;
        }

        private double ReturnExpenditureSum(List<OperationInfo> operations)
        {
            double expenditureSum = 0;

            var expenditures = Connection.db.GetTable<RowHeadersForBalances>()
                        .Where(x => x.AccountNameType == "išlaidos").Select(x => x.AccountName).ToList();

            for (int j = 0; j < expenditures.Count; j++)
            {
                var sums = operations.Where(x => x.SelectedType == expenditures[j]).Select(x => x.Sum).ToList();
                foreach (var sum in sums)
                {
                    expenditureSum = expenditureSum + sum;
                }
            }

            return expenditureSum;
        }

    }
}
