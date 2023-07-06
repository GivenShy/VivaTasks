using System;
using System.Text;
using System.Linq;

public enum Color
{
    Red, Yellow, White
}

public class GeoLocation
{
    public GeoLocation(double x, double y)
    {
        X = x;
        Y = y;
    }

    public double X { get; set; }
    public double Y { get; set; }
}

public class CellTower
{
    public GeoLocation geoLocation { get; set; }
}

public class TarifPlan
{
    public TarifPlan(string name, int price, int callMinutes, int mB)
    {
        Name = name;
        Price = price;
        this.callMinutes = callMinutes;
        MB = mB;
    }

    public string Name { get; set; }
    public int Price { get; set; }
    public int callMinutes { get; set; }
    public int MB { get; set; }
}
public class NetworkSpeed
{
    public double Speed { get; set; }

    public DateTime date { get; set; }
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
public class CallRecord
{
    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }

    public int MCC { get; set; }
    public int MNC { get; set; }
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

    public static double CalculateTotalDuration(this IEnumerable<CallRecord> calls,DateTime start, DateTime end)
    {
        DateTime zero = new DateTime(1970, 1, 1);
        double totalDuration = 0;

        foreach (CallRecord call in calls)
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

    public static double calculateTheBill(this IEnumerable<CallRecord> calls,double plan)
    {
        double cost = 0;
        foreach(CallRecord call in calls)
        {
            cost += (call.endTime - call.startTime).TotalMinutes * plan;
        }
        return cost;
    }

    public static double avarageSpeed(this IEnumerable<NetworkSpeed> networkSpeeds,DateTime start, DateTime end)
    {
        double sumOfSpeeds = 0;
        double counter = 0;

        foreach(NetworkSpeed speed in networkSpeeds)
        {
            if(speed.date>start && speed.date < end)
            {
                sumOfSpeeds += speed.Speed;
                counter++;
            }
        }
        return sumOfSpeeds / counter;
    }

   public static IEnumerable<CallRecord> findRoamings(this IEnumerable<CallRecord> callRecords,int oper)
    {
        foreach(CallRecord call in callRecords)
        {
            if (call.MCC != oper)
            {
                yield return call;
            }
        }
    }

    public static TarifPlan recommend(this IEnumerable<CallRecord> callRecords, IEnumerable<DataUsage> dataUsages, List<TarifPlan> tarifs) {
        IEnumerable<TarifPlan> tarifPlans = tarifs.OrderBy<TarifPlan, int>(t => t.Price);
        double minutes = callRecords.CalculateTotalDuration(DateTime.MinValue,DateTime.MaxValue)/60000;
        double MB = dataUsages.dataUsage(DateTime.MinValue, DateTime.MaxValue);
        TarifPlan t = tarifPlans.First();
        foreach(TarifPlan tarif in tarifs)
        {
            if(tarif.callMinutes>minutes && tarif.MB > MB)
            {
                return tarif;
                t = tarif;
            }
        }

        return t;
    }

    public static CellTower closestCellTower(this GeoLocation myLocation,IEnumerable<CellTower> cellTowers)
    {
        CellTower cellTower = cellTowers.First();
        double minDistance = double.MaxValue;
        foreach(CellTower tower in cellTowers)
        {
            double dist = Math.Sqrt(Math.Pow(tower.geoLocation.X - myLocation.X, 2) + Math.Pow(tower.geoLocation.Y - myLocation.Y, 2));
            if (dist < minDistance)
            {
                minDistance = dist;
                cellTower = tower;
            }
        }
        return cellTower;
    }

}