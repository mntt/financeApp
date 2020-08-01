namespace financeApp
{
    public class User
    {
        private static int userID { get; set; }

        public static int ID
        {
            get { return userID; }
            set { userID = value; }
        }
    }
}
