using System;
using System.Text;

public class Person
{
    public Person(int a)
    {
        age = a;
    }
    private int age;
    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            age = value;
        }
    }
    public override string ToString()
    {
        return age.ToString();
    }
}

public static class ExtensionClass
{
    public static string ToTitleCase(this string str)
    {
        string[] newString = str.Split(' ');
        StringBuilder stringBuilder = new StringBuilder();
        foreach (string s in newString)
        {
            stringBuilder.Append(s[0].ToString().ToUpper());
            stringBuilder.Append(s.Substring(1));
            stringBuilder.Append(" ");
        }
        string st = stringBuilder.ToString();
        st = st.Trim();
        return st;
    }

    public static List<T> SortByProperty<T>(this List<T> list, Func<T, IComparable> func)
    {
        List<T> newList = new List<T>(list);
        sortByQuickSort(newList, func, 0, newList.Count()-1);
        return newList;

    }

    private static void sortByQuickSort<T>(List<T> list, Func<T,IComparable> func,int left, int right)
    {
        if (left >= right)
        {
            return;
        }
        var i = left;
        var j = right-1;
        var pivot = list[right];
        T temp;
        while (i < j)
        {
            while (i<=j && func(list[i]).CompareTo(func(pivot))<0)
            {
                i++;

            }

            while (j>left & i<right-1 && i<=j && func(list[j]).CompareTo(func(pivot)) > 0)
            {
                j--;
            }
            if (i < j)
            {
                
                temp = list[i];
                list[i] = list[j];
                list[j] = temp;
                i++;
                j--;

            }
        }
        temp = list[i];
        list[i] = pivot;
        list[right] = temp;
        sortByQuickSort(list, func, left, i - 1);
        sortByQuickSort(list, func, i + 1, right);
    }
}

