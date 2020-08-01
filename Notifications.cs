using System;
using System.Collections.Generic;
using System.Linq;

namespace financeApp
{
    public class Notifications
    {
        public List<string> NotificationsDateList()
        {
            List<string> dateList = new List<string>();

            var dates = Connection.db.GetTable<Dates>()
                .Where(x => x.UserId == User.ID).Select(x => x.Date1).ToList();

            if(dates.Count > 1)
            {
                for(int i = 1; i < dates.Count; i++)
                {
                    var sums = Connection.db.GetTable<Sums>()
                        .Where(x => x.UserId == User.ID).Where(x => x.DateId == (i-1))
                        .Select(x => x.DateId).Distinct().ToList();

                    bool sumFound = false;

                    if(sums.Count > 0)
                    {
                        sumFound = true;
                    }

                    if (!sumFound)
                    {
                        dateList.Add(dates[i-1]);
                    }
                }
            }

            return dateList;
        }

        public void CreateNotifications(List<string> notificationsDateList)
        {
            string date = "";
            string today = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            foreach (var item in notificationsDateList)
            {
                if(item != "Startinis likutis")
                {
                    var tempArray = item.Split('-');
                    string year = tempArray[0];
                    MonthConverter mc = new MonthConverter();
                    string month = mc.ReturnRequiredMonth(DateTime.Parse(item));

                    date = year + " m." + " " + month;
                    string notification = "Atėjo naujas mėnuo! Esate dar nesuvedę likučių už " + date + " mėn.";

                    Connection.iwdb.InsertNotifications(today, notification);
                }
                else if(item == "Startinis likutis")
                {
                    string notification2 = "Esate nesuvedę startinio likučio!";
                    Connection.iwdb.InsertNotifications(today, notification2);
                }
            }
        }

    }
}
