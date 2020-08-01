namespace financeApp
{
    public class TempAccNamesInfo
    {
        public string name { get; set; }
        public string type { get; set; }
        public int userId { get; set; }
        public TempAccNamesInfo(string _name, string _type, int _userId)
        {
            name = _name;
            type = _type;
            userId = _userId;
        }
    }
}
