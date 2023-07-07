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

            //ComparisonDelegate comparison = (firstNumber, secondNumber) =>
            //{
            //    if (firstNumber > secondNumber)
            //        return 1;
            //    if (firstNumber == secondNumber)
            //        return 0;
            //    return -1;
            //};

            //Console.WriteLine(comparison(1, 3));

            Balance balance = new Balance();
            Client client = new Client();
            client.phoneNumber = 32423442;
            client.refilAmount = 1000;
            Logger logger = new Logger();
            balance.BalanceRefillEvent += logger.log;

            balance.BalanceRefil(client);
            Console.ReadKey();
        }
    }

    public delegate int OperationDelegate(int first, int second);

    public delegate int ComparisonDelegate(int firstNumber, int secondNumber);
}

