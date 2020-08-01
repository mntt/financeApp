using System;

namespace financeApp
{
    class MonthConverter
    {
        public string ReturnRequiredMonth(DateTime date)
        {
            string formattedDate = date.ToString("yyyy-MM");

            string[] month = formattedDate.Split('-');

            string[] arrayOfMonthNames = {"Sausio", "Vasario", "Kovo", "Balandžio", "Gegužės", "Birželio", 
                "Liepos", "Rugpjūčio", "Rugsėjo", "Spalio", "Lapkričio", "Gruodžio"};

            string requiredMonth = "";

            if(month.Length > 1)
            {
                for (int i = 0; i < arrayOfMonthNames.Length; i++)
                {
                    if (int.Parse(month[1]) == (int.Parse(i.ToString("00")) + 1))
                    {
                        requiredMonth += arrayOfMonthNames[i];
                        break;
                    }
                }
            }
            
            return requiredMonth;
        }
    }

}
