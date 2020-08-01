namespace financeApp
{
    public class TempPlanningInfo
    {
        public double sum { get; set; }
        public int categoryIndex { get; set; }
        public int dateIndex { get; set; }
        public int userId { get; set; }
        public TempPlanningInfo(double _sum, int _categoryIndex, int _dateIndex, int _userId)
        {
            sum = _sum;
            categoryIndex = _categoryIndex;
            dateIndex = _dateIndex;
            userId = _userId;
        }
    }
}
