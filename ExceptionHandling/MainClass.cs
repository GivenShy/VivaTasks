using System;
namespace ExceptionHandling
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
            //Console.ReadKey();
            //
            //---Task2
            //try
            //{
            //    int age = ReadTheAgeFromConsole();
            //}
            //catch (FormatException e)
            //{
            //    Console.WriteLine(e);
            //}
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine(e);
            //}
            //---Task3
            //---Task4
            //Subscriber subscriber = new Subscriber();
            //subscriber.phoneNum = 55221819;
            //subscriber.balance = 3000;
            //subscriber.isInRoaming = false;
            //subscriber.isServiceActive = false;
            //subscriber.servicePrice = 1500;
            //subscriber.expirationDate = DateTime.Now.AddDays(12);
            //subscriber.activateTheService();
            //Console.ReadKey();

        }

        public static void WriteToAnotherFile(string path1, string path2)
        {
            string str = "";
            try
            {
                str = File.ReadAllText(path1);
                str = str.ToUpper();
                File.WriteAllText(path2, str);

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"There is no file {path1}");
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("The arguments are not valid");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public static int ReadTheAgeFromConsole()
        {
            string? s = Console.ReadLine();
            int age = 0;
            try
            {
                age = int.Parse(s ?? throw new NullReferenceException());

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

