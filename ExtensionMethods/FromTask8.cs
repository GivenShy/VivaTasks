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

    public static double CalculateTotalDuration(this IEnumerable<CallRecords> calls)
    {
        DateTime zero = new DateTime(1970, 1, 1);
        double totalDuration = 0;

        foreach (CallRecords call in calls)
        {
            TimeSpan time1 = call.startTime.Subtract(zero);
            TimeSpan time2 = call.endTime.Subtract(zero);
            totalDuration += time2.TotalMilliseconds - time2.TotalMilliseconds;
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

}