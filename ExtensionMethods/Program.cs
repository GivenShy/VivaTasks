using System.Text;

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
        string s = stringBuilder.ToString();
        s = s.Trim();
        return s;
    }
}

