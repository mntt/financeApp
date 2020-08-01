namespace financeApp
{
    public class TempInfoOfSums
    {
        public double sum { get; set; }
        public int dateId { get; set; }
        public int accountNameId { get; set; }
        public int userId { get; set; }
        
        public TempInfoOfSums(double _sum, int _dateId, int _accountNameId, int _userId)
        {
            sum = _sum;
            dateId = _dateId;
            accountNameId = _accountNameId;
            userId = _userId;
        }
    }
}
