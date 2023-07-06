using System;
using System.Text;
public enum Color
{
    Red, Yellow, White
}
public class SMS
{
    public SMS(string name)
    {
        sender = name;
    }
    public string sender { get; set; }
}

public class DataUsage
{
    public DateTime date { get; set; }

    public double dataInMB { get; set; }

}
public class CallRecords
{
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
}
public static class ThirdExtensionClass
{
    public static bool FileExists(this string str)
    {
        return File.Exists(str);
    }

    public static T toEnum<T>(this string str) where T : struct
    {
        T enu;
        Enum.TryParse<T>(str, true, out enu);
        return enu;
    }

    public static IEnumerable<T> filter<T>(this IEnumerable<T> values, Func<T, bool> predicate)
    {

        return values.Where(predicate);
    }

    public static double CalculateTotalDuration(this IEnumerable<CallRecords> calls,DateTime start, DateTime end)
    {
        DateTime zero = new DateTime(1970, 1, 1);
        double totalDuration = 0;

        foreach (CallRecords call in calls)
        {
            TimeSpan time1;
            TimeSpan time2;
            if (call.startTime >= end)
                continue;
            if (call.startTime >= start)
            {
                time1 = call.startTime.Subtract(zero);
                if (call.endTime < end)
                    time2 = call.endTime.Subtract(zero);
                else
                    time2 = end.Subtract(zero);
                totalDuration += time2.TotalMilliseconds - time2.TotalMilliseconds;

            }
            else
            {
                time1 = start.Subtract(zero);
                if (call.endTime < end)
                    time2 = call.endTime.Subtract(zero);
                else
                    time2 = end.Subtract(zero);
                totalDuration += time2.TotalMilliseconds - time2.TotalMilliseconds;
            }
        }
        return totalDuration;
    }

    public static IEnumerable<SMS> filterSMSBySender(this IEnumerable<SMS> messages, string sender)
    {
        return messages.Where<SMS>(arg => { return arg.sender.Equals(sender); });
    }

    public static string formatNumber(this string number) {

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("(+374)");
        stringBuilder.Append("-");
        stringBuilder.Append(number[3]);
        stringBuilder.Append(number[4]);
        int index = 5;
        for(int i = 0; i <2;i++)
        {
            stringBuilder.Append("-");
            for (int j = 0; j < 3; j++)
            {
                stringBuilder.Append(number[index++]);
            }
        }

        return stringBuilder.ToString();

    }

    public static double dataUsage(this IEnumerable<DataUsage> usages, DateTime startDate, DateTime endDate)
    {
        double totalData = 0;
        foreach(DataUsage data in usages)
        {
            if(data.date >=startDate && data.date <= endDate)
            {
                totalData += data.dataInMB;
            }
        }
        return totalData;
    }

    public static double calculateTheBill(this IEnumerable<DataUsage> usages,double plan) {
        double cost = 0;
        foreach(DataUsage data in usages)
        {
            cost += data.dataInMB * plan;
        }
        return cost;
    }

    public static double calculateTheBill(this IEnumerable<CallRecords> calls,double plan)
    {
        double cost = 0;
        foreach(CallRecords call in calls)
        {
            cost += (call.endTime - call.startTime).TotalMinutes * plan;
        }
        return cost;
    }

}