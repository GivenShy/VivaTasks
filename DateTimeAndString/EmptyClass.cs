using System;
namespace DateTimeAndString
{
    public static class LanguageInfo
    {
        public static string[] armenian = new string[]
        {
            "Երկուշաբթի","Երեքշաբթի","Չորեքշաբթի",
            "Հինգշաբթի","Ուրբաթ","Շաբաթ","Կիրակի"
        };
        public static string[] russian = new string[]
        {
            "Понедельник","Вторник","Среда",
            "Четверг","Пятница","Суббота","Воскресенье"
        };
        public static string[] english = new string[]
        {
            "Monday","Thuesday","Wednesday","Thursday",
            "Friday","Saturday","Sunday"
        };

    }

    public enum Language
    {
        Rusian, English, Armenian
    }

    public static class EmptyClass
    {
        public static string weekDay(this DateTime time, Language language)
        {

            int ordinal = (int)time.DayOfWeek;

            switch (language)
            {
                case Language.Armenian:
                    return LanguageInfo.armenian[ordinal];
                case Language.English:
                    return LanguageInfo.english[ordinal];
                case Language.Rusian:
                    return LanguageInfo.russian[ordinal];
                default:
                    return null;
            }
        }
    }
}

