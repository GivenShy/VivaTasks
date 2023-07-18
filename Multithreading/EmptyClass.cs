List<Task> tasks = new List<Task>();
int j = 0;
object lockObj = new object();
for (int i = 0; i < 10; i++)
{
    tasks.Add(Task.Factory.StartNew(() =>
    {
        Random random = new Random();
        Console.WriteLine($"Running thread:{Thread.CurrentThread.ManagedThreadId}");
        Task.Delay(random.Next(1000, 3000));
        lock (lockObj)
        {

            throw new CustomException { Counter = j++ };

        }


        //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);

    }));
}

void addToJ()
{
    lock (lockObj)
    {
        j++;
    }
}
try
{
    Task.WaitAll(tasks.ToArray());
}
catch (CustomException ex)
{

}
catch (AggregateException agEx)
{
    foreach (var ex in agEx.InnerExceptions)
        if (ex is CustomException)
            Console.WriteLine((ex as CustomException).Counter);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.ReadKey();


internal class CustomException : Exception
{
    public int Counter { get; set; }
}
