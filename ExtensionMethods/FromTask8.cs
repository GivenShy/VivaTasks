using System;

public enum Color
{
    Red, Yellow, White
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

    public static T toEnum<T>(this string str) where T:struct{
        T enu;
        Enum.TryParse<T>(str, true, out enu);
        return enu;
    }

    public static IEnumerable<T> filter<T>(this IEnumerable<T> values,bool condition,Func<T,bool> predicate)
    {
        if (condition)
        {
            return values.Where(predicate);
        }
        return values;
    }

    public static double CalculateTotalDuration(this IEnumerable<CallRecords> calls)
    {
        DateTime zero = new DateTime(1970, 1, 1);
        double totalDuration = 0;

        foreach(CallRecords call in calls)
        {
            TimeSpan time1 = call.startTime.Subtract(zero);
            TimeSpan time2 = call.endTime.Subtract(zero);
            totalDuration += time2.TotalMilliseconds - time2.TotalMilliseconds;
        }
        return totalDuration;
    }

}
