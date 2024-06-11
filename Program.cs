class Program
{
    static AutoResetEvent events = new AutoResetEvent(false);
    //static ManualResetEvent events = new ManualResetEvent(false);

    static void Main()
    {
        Thread thread1 = new Thread(ThreadWork);
        thread1.Start();

        Console.WriteLine("Main thread does some work, then signals.");
        //Thread.Sleep(1000);

        events.Set();

        Console.WriteLine("Main thread waits for thread to complete.");
        thread1.Join();

        Console.WriteLine("Main thread exits.");
    }

    static void ThreadWork()
    {
        Console.WriteLine("Thread waits for signal.");
        events.WaitOne();
        Console.WriteLine("Thread received signal and continues.");
    }
}
