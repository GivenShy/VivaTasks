using System;
namespace ExceptionHandling
{
    public class BalanceExcpetion : Exception
    {
        public BalanceExcpetion() : base()
        {

        }
        public BalanceExcpetion(string message) : base(message)
        {

        }
    }
}

