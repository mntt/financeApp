using System;
using System.Collections.Generic;
using System.Linq;

namespace financeApp
{
    class CreatingDates
    {
        public void CreateDates(int userId)
        {
            var dates = Connection.db.GetTable<Dates>().Where(x => x.UserId == userId).Select(x => x.Date1).ToList();
            string today = DateTime.Today.ToString("yyyy-MM");

            Connection.iwdb.DeleteData("Dates", userId);

            bool isDateInList = false;
            foreach (var item in dates)
            {
                Connection.iwdb.InsertDates(User.ID, item);

                if (item.ToString() == today)
                {
                    isDateInList = true;
                }
            }

            //dates.Count daugiau už 1, nes turi būti startinis likutis ir pirmasis mėnuo
            if (dates.Count > 1 && !isDateInList)
            {
                ConstructDates(dates, today);
            }
            else if (dates.Count == 1 && !isDateInList)
            {
                Connection.iwdb.InsertDates(User.ID, today);
            }
        }

        private void ConstructDates(List<string> dates, string today)
        {
            bool continueLoop = true;
            string baseDate = dates.Last();

            while (continueLoop)
            {
                string[] tempArray = baseDate.Split('-');
                string constructedDate = "";

                if (tempArray[1] == "12")
                {
                    constructedDate += (int.Parse(tempArray[0]) + 1).ToString() + "-" + "01";
                }
                else if (tempArray[1] != "12")
                {
                    constructedDate += tempArray[0].ToString() + "-" + (int.Parse(tempArray[1]) + 1).ToString("00");
                }

                if (DateTime.Parse(constructedDate) < DateTime.Parse(today))
                {
                    Connection.iwdb.InsertDates(User.ID, constructedDate);
                    baseDate = constructedDate;
                }
                else if (DateTime.Parse(constructedDate) == DateTime.Parse(today))
                {
                    Connection.iwdb.InsertDates(User.ID, constructedDate);
                    continueLoop = false;
                    break;
                }
            }
        }


    }
}
