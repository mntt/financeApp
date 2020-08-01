using System;

namespace financeApp
{
    public class TempOperationInfo
    {
        public DateTime date { get; set; }
        public string operationText { get; set; }
        public double operationSum { get; set; }
        public string operationType { get; set; }
        public int userId { get; set; }
        public TempOperationInfo(DateTime _date, string _operationText, double _operationSum, string _operationType, int _userId)
        {
            date = _date;
            operationText = _operationText;
            operationSum = _operationSum;
            operationType = _operationType;
            userId = _userId;
        }
    }
}
