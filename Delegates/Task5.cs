using System;
namespace Delegates
{
    public class Balance
    {
        public delegate void BalanceHandler(Client client);

        public event BalanceHandler BalanceRefillEvent;

        public Balance()
        {
        }

        public void BalanceRefil(Client client)
        {
            if (BalanceRefillEvent != null)
            {
                Console.WriteLine("Added " + client.refilAmount + " for number " + client.phoneNumber);
                BalanceRefillEvent(client);
            }

        }

    }

    public class Client : EventArgs
    {
        public int phoneNumber { get; set; }
        public int refilAmount { get; set; }

    }
}

