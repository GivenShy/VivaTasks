using System;
namespace ExceptionHandling
{
    public class RoamingException : Exception
    {
        public RoamingException(string message) : base(message)
        {

        }

        public RoamingException() : base()
        {

        }
    }
}

