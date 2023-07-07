using System;
namespace delegates
{
    class Program
    {
        public static void Main(string[] args)
        {
            Print print;
            print = ConsolePrint;
            print += delegate
            {
                Console.WriteLine("Hello from anonymous class");
            };
            print("Hello");
            Console.ReadKey();
           
        }
        static void ConsolePrint(string str)
        {
            Console.WriteLine(str);
        }
        
        
    }

    public delegate void Print(string str);
}