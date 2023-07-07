using System;
namespace Delegates
{
    public class MainClass
    {
        public static void Main()
        {
            //Button button = new Button();
            //button.ConsoleReadEvent += () => Console.WriteLine("The button that I created was clicked");
            //button.Click();
            OperationDelegate operationDelegate;
            operationDelegate = delegate (int first, int second)
            {
                int result = first + second;
                Console.WriteLine(result);
                return result;
            };
            operationDelegate += delegate (int first, int second)
            {
                int result = first * second;
                Console.WriteLine(result);
                return result;

            };

            Console.WriteLine(operationDelegate.Invoke(3, 4));
            Console.ReadKey();
        }
    }

    public delegate int OperationDelegate(int first, int second);
}

