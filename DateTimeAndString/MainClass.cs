using System;
using System.Text;

namespace DateTimeAndString
{
    public class MainClass
    {
        public MainClass()
        {
        }

        public static void Main()
        {
            Console.WriteLine(DateTime.Now.weekDay(Language.Rusian));
            Console.ReadKey();
        }

        public static string getDateMonthLater()
        {
            DateTime date = DateTime.Now;
            TimeSpan time = TimeSpan.FromMilliseconds(2592000000);
            DateTime currentTime = date + time;
            StringBuilder stringBuilder = new StringBuilder();
            int day = currentTime.Day;
            int month = currentTime.Month;
            int year = currentTime.Year;
            if (day > 9)
                stringBuilder.Append(day);
            else
            {
                stringBuilder.Append("0" + day);
            }
            stringBuilder.Append("/");
            if (month > 9)
            {
                stringBuilder.Append(month);
            }
            else
            {
                stringBuilder.Append("0" + month);
            }
            stringBuilder.Append("/");
            stringBuilder.Append(year + " ");
            stringBuilder.Append(currentTime.Hour + ":" + currentTime.Minute + ":" + currentTime.Second);
            return stringBuilder.ToString();
        }

        public static string CurentTimeIn(string str)
        {
            return str.Replace("@expDate@", getDateMonthLater());
        }
        public static string LastMilisecondInMonth(string str)
        {
            DateTime now = DateTime.Now;
            DateTime dateTime = new DateTime(now.Year, now.Month, 1);
            dateTime = dateTime.AddMonths(1);
            dateTime = dateTime.AddMilliseconds(-1);
            string date = dateTime.ToString("dd/MM/yyyy HH:mm:ss.fff");
            return str.Replace("@expDate@", date);
        }

        public static double daysPassed(DateTime dateTime1, DateTime dateTime2)
        {
            TimeSpan timeSpan = dateTime2 - dateTime1;
            double days = timeSpan.TotalDays;
            return Math.Abs(days);
        }
    }
}

