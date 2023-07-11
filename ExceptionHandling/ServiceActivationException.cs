using System;
namespace ExceptionHandling
{
    public class ServiceActivationException : Exception
    {
        public ServiceActivationException(string message) : base(message)
        {
        }

        public ServiceActivationException() : base()
        {

        }
    }
}

