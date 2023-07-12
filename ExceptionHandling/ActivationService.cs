using System;
namespace ExceptionHandling
{
    public class ActivationService
    {
        private object locker = new object();

        private void Activate(Subscriber subscriber)
        {
            int initialBalance = subscriber.balance;
            DateTime dateTime = subscriber.expirationDate;
            try
            {
                subscriber.isServiceActive = true;
                subscriber.balance -= subscriber.servicePrice;
                subscriber.expirationDate = subscriber.expirationDate.AddDays(30);
                Console.WriteLine($"The service is active until {subscriber.expirationDate}");
            }
            catch (Exception e)
            {
                subscriber.isServiceActive = false;
                subscriber.balance = initialBalance;
                subscriber.expirationDate = dateTime;
                Console.WriteLine("Something happend rollback is done" + e.Message);
            }

        }
        public void ActivateAll(List<Subscriber> subscribers)
        {
            List<Thread> threads = new List<Thread>();
            foreach (Subscriber i in subscribers)
            {
                Thread thread = new Thread(() => Activate(i));
                threads.Add(thread);
                thread.Start();
            }
            foreach (Thread thread1 in threads)
            {
                thread1.Join();
            }
        }

        public List<Subscriber> FilterList(List<Subscriber> subscribers)
        {
            List<Thread> threads = new List<Thread>();
            List<Subscriber> subscribers1 = new List<Subscriber>();
            foreach (Subscriber i in subscribers)
            {
                Thread thread = new Thread(() =>
                {
                    try
                    {
                        i.ActivateTheServiceCheck();
                        addToList(subscribers1, i);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                });
                threads.Add(thread);
                thread.Start();
            }

            foreach (Thread thread1 in threads)
            {
                thread1.Join();
            }
            return subscribers1;
        }

        private void addToList(List<Subscriber> subscribers, Subscriber subscriber)
        {
            lock (locker)
            {
                subscribers.Add(subscriber);
            }
        }
    }
}

