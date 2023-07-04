using System;

Console.ReadKey();
public static class ThirdExtensionClass
{
    public static bool FileExists(this string str)
    {
        return File.Exists(str);
    }
}
