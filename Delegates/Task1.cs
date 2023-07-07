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
        static void OtherPrint()
        {
            Console.WriteLine("HelloWorld");
        }
    }

    public delegate void Print(string str);
}