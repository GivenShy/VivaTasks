using System;
namespace Delegates
{
    public class Balance
    {
        public delegate void BalanceHandler(Object source, Client client);

        public event BalanceHandler? BalanceRefillEvent;

        public Balance()
        {
        }

        public void BalanceRefil(Client client)
        {
            if (BalanceRefillEvent != null)
            {
                Console.WriteLine("Added " + client.refilAmount + " for number " + client.phoneNumber);
                BalanceRefillEvent(this, client);
            }

        }

        public override string ToString()
        {
            return "Balance Manipulation ";
        }
    }

    public class Logger
    {
        public void log(Object source, Client client)
        {

            Console.WriteLine(source.ToString() + "number: " + client.phoneNumber
                + " amount: " + client.refilAmount);
        }
    }

    public class Client : EventArgs
    {
        public int phoneNumber { get; set; }
        public int refilAmount { get; set; }

    }
}

