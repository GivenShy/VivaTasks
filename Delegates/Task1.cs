using System;
namespace delegates
{
    class Program
    {
        
        static void ConsolePrint(string str)
        {
            Console.WriteLine(str);
        }
        
        
    }

    public delegate void Print(string str);
}