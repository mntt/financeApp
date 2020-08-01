using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace financeApp
{
    public class InteractionWithDatabase
    {
        private SqlConnection sql = new SqlConnection(Connection.connectionString);

        public void DeleteData(string nameOfTable, int userId)
        {
            sql.Open();
            string querryDelete = "DELETE FROM " + nameOfTable + " WHERE UserId = "+ userId +"";
            SqlCommand commandDelete = new SqlCommand(querryDelete, sql);
            commandDelete.ExecuteNonQuery();
            sql.Close();
        }

        public void InsertDates(int userId, string date)
        {
            sql.Open();
            string querry = "INSERT INTO Dates(UserId, Date) VALUES (@UserId, @Date)";
            SqlCommand command = new SqlCommand(querry, sql);
            command.Parameters.AddWithValue("@UserId", userId);
            command.Parameters.AddWithValue("@Date", date);
            command.ExecuteNonQuery();
            sql.Close();
        }

        public void InsertSums(List<TempInfoOfSums> sums)
        {
            foreach (var item in sums)
            {
                sql.Open();
                string querry = "INSERT INTO Sums(UserId, Sum, DateId, AccountNameId) " +
                    "VALUES (@UserId, @Sum, @DateId, @AccountNameId)";
                SqlCommand command = new SqlCommand(querry, sql);
                command.Parameters.AddWithValue("@UserId", item.userId);
                command.Parameters.AddWithValue("@Sum", item.sum);
                command.Parameters.AddWithValue("@DateId", item.dateId);
                command.Parameters.AddWithValue("@AccountNameId", item.accountNameId);
                command.ExecuteNonQuery();
                sql.Close();
            }
        }

        public void InsertAccountNames(int userId, string name)
        {
            sql.Open();
            string querry = "INSERT INTO AccountNames(UserId, Name) VALUES (@UserId, @Name)";
            SqlCommand command = new SqlCommand(querry, sql);
            command.Parameters.AddWithValue("@UserId", userId);
            command.Parameters.AddWithValue("@Name", name);
            command.ExecuteNonQuery();
            sql.Close();
        }

        public void InsertStartingSums(DataGridView dataGrid, int userId, bool newAccount)
        {
            for (int column = 0; column < dataGrid.Columns.Count; column++)
            {
                bool IsColumnEmpty = true;

                for (int row = 0; row < dataGrid.Rows.Count; row++)
                {
                    if (dataGrid.Rows[row].Cells[column].Value != null)
                    {
                        IsColumnEmpty = false;
                        break;
                    }
                }

                if (!IsColumnEmpty)
                {
                    StartingSumsQuerry(column, userId);
                }

                if (newAccount)
                {
                    StartingSumsQuerry(column, userId);
                }
            }
        }

        private void StartingSumsQuerry(int column, int userId)
        {
            var sums = Connection.db.GetTable<Sums>()
                .Where(x => x.DateId == column && x.UserId == userId).Select(x => x.Sum1).ToList();
            var startingSum = sums.Sum(x => x);
            sql.Open();
            string querry = "INSERT INTO StartingSums(UserId, Sum, DateId) VALUES (@UserId, @Sum, @DateId)";
            SqlCommand command = new SqlCommand(querry, sql);
            command.Parameters.AddWithValue("@UserId", userId);
            command.Parameters.AddWithValue("@Sum", startingSum);
            command.Parameters.AddWithValue("@DateId", column);
            command.ExecuteNonQuery();
            sql.Close();
        }

        public void InsertBudgetPlanningInfo(List<TempPlanningInfo> info)
        {
            foreach (var item in info)
            {
                sql.Open();
                string querry = "INSERT INTO BudgetPlanningInfo(UserId, Sum, CategoryIndex, DateIndex) " +
                    "VALUES (@UserId, @Sum, @CategoryIndex, @DateIndex)";
                SqlCommand command = new SqlCommand(querry, sql);
                command.Parameters.AddWithValue("@UserId", item.userId);
                command.Parameters.AddWithValue("@Sum", item.sum);
                command.Parameters.AddWithValue("@CategoryIndex", item.categoryIndex);
                command.Parameters.AddWithValue("@DateIndex", item.dateIndex);
                command.ExecuteNonQuery();
                sql.Close();
            }
        }

        public void UpdateAccountName(string name, int accountNameId, int userId)
        {
            sql.Open();
            string querry = "UPDATE AccountNames SET Name = '" + name + "' WHERE AccountNames.Id = " + accountNameId + " AND AccountNames.UserId = " + userId + "";
            SqlCommand command = new SqlCommand(querry, sql);
            command.ExecuteNonQuery();
            sql.Close();
        }

        public void InsertSumsInIntroWindow(DataGridView dataGrid, int userId)
        {
            sql.Open();
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                string querry = "INSERT INTO Sums(UserId, Sum, DateId, AccountNameId) " +
                    "VALUES (@UserId, @Sum, @DateId, @AccountNameId)";
                SqlCommand command = new SqlCommand(querry, sql);
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@Sum", double.Parse(dataGrid.Rows[i].Cells[0].Value.ToString()));
                command.Parameters.AddWithValue("@DateId", 0);
                command.Parameters.AddWithValue("@AccountNameId", i);
                command.ExecuteNonQuery();
            }
            sql.Close();
        }

        public void InsertConditionalSumsInIntroWindow(DataGridView dataGrid, int userId)
        {
            sql.Open();
            for (int i = 0; i < dataGrid.Rows.Count; i++)
            {
                string querry = "INSERT INTO Sums(UserId, Sum, DateId, AccountNameId) " +
                    "VALUES (@UserId, @Sum, @DateId, @AccountNameId)";
                SqlCommand command = new SqlCommand(querry, sql);

                if (dataGrid.Rows[i].Cells[0].Value == null)
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Sum", 0);
                    command.Parameters.AddWithValue("@DateId", 0);
                    command.Parameters.AddWithValue("@AccountNameId", i);
                    command.ExecuteNonQuery();
                }
                else if (dataGrid.Rows[i].Cells[0].Value != null)
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@Sum", double.Parse(dataGrid.Rows[i].Cells[0].Value.ToString()));
                    command.Parameters.AddWithValue("@DateId", 0);
                    command.Parameters.AddWithValue("@AccountNameId", i);
                    command.ExecuteNonQuery();
                }
            }
            sql.Close();
        }

        public void InsertOperationInfo(List<TempOperationInfo> info)
        {
            foreach (var item in info)
            {
                sql.Open();
                string querry = "INSERT INTO OperationInfo(UserId, Date, OperationText, Sum, SelectedType) " +
                    "VALUES (@UserId, @Date, @OperationText, @Sum, @SelectedType)";
                SqlCommand command = new SqlCommand(querry, sql);
                command.Parameters.AddWithValue("@UserId", item.userId);
                command.Parameters.AddWithValue("@Date", item.date);
                command.Parameters.AddWithValue("@OperationText", item.operationText);
                command.Parameters.AddWithValue("@Sum", item.operationSum);
                command.Parameters.AddWithValue("@SelectedType", item.operationType);
                command.ExecuteNonQuery();
                sql.Close();
            }
        }

        public void InsertUsernamesAndPassword(string username, string password, string code)
        {
            sql.Open();
            string querry = "INSERT INTO UsernameAndPassword(username, password, accountCode) VALUES (@username, @password, @accountCode)";
            SqlCommand command = new SqlCommand(querry, sql);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@accountCode", code);
            command.ExecuteNonQuery();
            sql.Close();
        }

        public void UpdatePassword(string password, int userId)
        {
            sql.Open();
            string querry = "UPDATE UsernameAndPassword SET Password = '" + password + "' WHERE UsernameAndPassword.Id = " + userId + "";
            SqlCommand command = new SqlCommand(querry, sql);
            command.ExecuteNonQuery();
            sql.Close();
        }

        public void DeleteSumsInAffectedRowDb(int rowIndex, int userId)
        {
            sql.Open();
            string querryDeleteSums = "DELETE FROM Sums WHERE AccountNameId = " + rowIndex + " AND UserId = " + userId + "";
            SqlCommand commandDeleteSums = new SqlCommand(querryDeleteSums, sql);
            commandDeleteSums.ExecuteNonQuery();
            sql.Close();
        }

        public void UpdateNotifications(int userId)
        {
            sql.Open();
            string querry = "UPDATE NotificationsTable SET IsChecked = 1 WHERE NotificationsTable.IsChecked = 0 AND NotificationsTable.UserId = '" + userId + "'";
            SqlCommand command = new SqlCommand(querry, sql);
            command.ExecuteNonQuery();
            sql.Close();
        }

        public void InsertNotifications(string today, string notification)
        {
            sql.Open();
            string querry = "INSERT INTO NotificationsTable(UserId, Date, Notification, IsChecked) " +
                "VALUES (@UserId, @Date, @Notification, @IsChecked)";
            SqlCommand command = new SqlCommand(querry, sql);
            command.Parameters.AddWithValue("@UserId", User.ID);
            command.Parameters.AddWithValue("@Date", today);
            command.Parameters.AddWithValue("@Notification", notification);
            command.Parameters.AddWithValue("@IsChecked", 0);
            command.ExecuteNonQuery();
            sql.Close();
        }

    }
}
