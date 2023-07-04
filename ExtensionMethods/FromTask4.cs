using System;

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
}
