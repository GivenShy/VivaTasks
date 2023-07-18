using System;

public class MyPlanner : IDisposable
{


    CancellationTokenSource cancelTokenSource;
    CancellationToken token;
    List<Task> tasks = new List<Task>();

    public MyPlanner()
    {
        cancelTokenSource = new CancellationTokenSource();
        token = cancelTokenSource.Token;

    }
    public async void anotherTimer(TimeSpan interval, Action action)
    {
        await Task.Delay(interval);
    }

    public void timer(TimeSpan interval, Action action)
    {
        Task task = Task.Run(() =>
        {

            DateTime time = DateTime.Now;
            while (!token.IsCancellationRequested)
            {
                if (DateTime.Now - time >= interval)
                {
                    time = DateTime.Now;
                    Task.Run(() =>
                   {
                       action();
                   }, token);

                }
            }
            Console.WriteLine("Exited");

        });
        tasks.Add(task);
    }

    public void doAtDate(DateTime time, Action action)
    {

        Task.Factory.StartNew(() =>
        {
            while (!token.IsCancellationRequested)
            {
                if (DateTime.Now >= time)
                {
                    time = DateTime.Now;
                    Task tas = new Task(() =>
                    {
                        if (token.IsCancellationRequested)
                            return;

                        action();
                    }, token);
                }
            }
            Console.WriteLine("Exited");

        });

    }

    public void Dispose()
    {
        cancelTokenSource.Cancel();
    }
}