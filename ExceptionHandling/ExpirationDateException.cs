using System;
namespace ExceptionHandling
{
    public class ExpirationDateException : Exception
    {
        public ExpirationDateException(string message) : base(message)
        {

        }
        public ExpirationDateException() : base()
        {

        }
    }
}

