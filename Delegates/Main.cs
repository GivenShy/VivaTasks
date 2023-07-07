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
            //
            //OperationDelegate operationDelegate;
            //operationDelegate = delegate (int first, int second)
            //{
            //    int result = first + second;
            //    Console.WriteLine(result);
            //    return result;
            //};
            //operationDelegate += delegate (int first, int second)
            //{
            //    int result = first * second;
            //    Console.WriteLine(result);
            //    return result;

            //};

            //Console.WriteLine(operationDelegate.Invoke(3, 4));

            ComparisonDelegate comparison = (firstNumber, secondNumber) =>
            {
                if (firstNumber > secondNumber)
                    return 1;
                if (firstNumber == secondNumber)
                    return 0;
                return -1;
            };

            Console.WriteLine(comparison(1, 3));
            Console.ReadKey();
        }
    }

    public delegate int OperationDelegate(int first, int second);

    public delegate int ComparisonDelegate(int firstNumber, int secondNumber);
}

