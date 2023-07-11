using System;
namespace ExceptioHandling
{
    public class MainClass
    {
        public MainClass()
        {
        }
        public static void Main()
        {
            //----Task1
            //writeToAnotherFile("/Users/jivanshmavonyan/Desktop/Tasks/ExceptionHandling/text.txt", "");
            //Console.WriteLine("Hello");
            //Console.ReadKey();
            //
            //---Task2
            int age = ReadFromConsoleTheAge();
        }

        public static void writeToAnotherFile(string path1, string path2)
        {
            string str = "";
            try
            {
                str = File.ReadAllText(path1);
                File.WriteAllText(path2, str);

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"There is no file {path1}");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The arguments are not valid");
            }

        }
        public static int ReadFromConsoleTheAge()
        {
            string s = Console.ReadLine();
            int age = 0;
            try
            {
                age = int.Parse(s);

            }
            catch (FormatException e)
            {
                throw new FormatException("This is not a number", e);
            }
            if (age < 18 || age > 40)
            {
                throw new ArgumentException("The age is not correct");
            }
            return age;
        }
    }

}

