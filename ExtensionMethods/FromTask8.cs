using System;

public static class ThirdExtensionClass
{
    public static bool FileExists(this string str)
    {
        return File.Exists(str);
    }
}
