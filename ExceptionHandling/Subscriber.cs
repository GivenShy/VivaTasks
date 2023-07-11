using System;
namespace ExceptionHandling
{
    public class Subscriber
    {
        public Subscriber()
        {
        }

        public int phoneNum { get; set; }
        public int balance { get; set; }
        public bool isInRoaming { get; set; }
        public DateTime expirationDate { get; set; }
        public bool isServiceActive { get; set; }
        public int servicePrice { get; set; }

        public void activateTheService()
        {

            if (isInRoaming)
            {
                throw new RoamingException("The service cannot activated because" +
                    "user is in the roaming");
            }
            if (isServiceActive)
            {
                throw new ServiceActivationException("The service is already activated");

            }
            if (expirationDate - DateTime.Now < TimeSpan.FromDays(10))
            {
                throw new ExpirationDateException("It is to late to activate the service");
            }
            if (balance < servicePrice)
            {
                throw new BalanceExcpetion("There is no enough money");
            }

        }


    }
}

