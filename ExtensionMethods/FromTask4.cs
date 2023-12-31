﻿using System;
using System.Text;
using System.Text.Json;


public static class SecondExtentionClass
{
    public static bool IsValidEmail(this string str)
    {
        string[] strings = str.Split("@");
        if (strings.Length != 2)
        {
            return false;
        }
        string s = strings[0];
        for (int i = 0; i < s.Length; i++)
        {
            if (!Char.IsLetterOrDigit(s[i])){
                if (s[i]!='-' || s[i] != '_' || s[i] != '.' || s[i] != '-')
                {
                    return false;
                }
            }
        }
        string[] st = strings[1].Split(".");
        if (st.Length < 2)
        {
            return false;
        }
        for(int i = 0; i < st.Length; i++)
        {
            for(int j = 0; j < st[i].Length; j++)
            {
                if (!Char.IsLetterOrDigit(s[i]))
                {
                    if (s[i] != '-' || s[i] != '_' || s[i] != '-')
                    {
                        return false;
                    }
                }
            }
        }
        return true;

    }

    public static string MyTrim(this string str)
    {
        StringBuilder stringBuilder = new StringBuilder();
        int i = 0;
        for(; i < str.Length; i++)
        {
            if (str[i]!=' ')
            {
                break;
            }
        }
        int j = str.Length - 1;
        for (; j >= 0; j--)
        {
            if (str[j]!=' ')
            {
                break;
            }
        }
        while (i <= j)
        {
            stringBuilder.Append(str[i]);
            i++;
        }
        return stringBuilder.ToString();
    }
    public static string SerializeToJson<T>(this T obj)
    {
        return JsonSerializer.Serialize<T>(obj, new JsonSerializerOptions() { WriteIndented = true });
    }
    public static double Round(this double number, int i)
    {
        double num = Math.Truncate(number);
        double dec = number - num;
        string str = dec.ToString().Split(".")[1];
        string t="";
        if (str[i] - '0' < 5)
        {
            if (i == 0)
            {
                return num;
            }
            t = "0." + str.Substring(0, i);
            return num + Double.Parse(t);
        }
        else
        {
            if (i == 0)
                return num + 1;
            t = "0." + str.Substring(0, i - 1) + (char)(str[i-1] + 1);
            return num + Double.Parse(t);
        }
    }
    
}


