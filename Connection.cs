using System.Data.Linq;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace financeApp
{
    public class Connection
    {
        public static string connectionString = @"connectionstring";

        public static DataContext db = new DataContext(connectionString);

        public static InteractionWithDatabase iwdb = new InteractionWithDatabase();

        public static StylesAndLooks style = new StylesAndLooks();

        public static bool CheckConnectivity()
        {
            using(SqlConnection sql = new SqlConnection(connectionString))
            {
                try
                {
                    sql.Open();
                    return true;
                }
                catch (SqlException)
                {
                    MessageBox.Show("Duomenų bazė nepasiekiama. Bandykite perkrauti programėlę.", "Klaida");
                    return false;
                }
            }           
        }


    }           
}
