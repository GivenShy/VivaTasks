using System;

public enum Color
{
    Red, Yellow, White
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


}
