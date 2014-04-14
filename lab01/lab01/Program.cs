namespace lab01
{
    using System;
    using System.Threading;

    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceThread = new Thread(Service.Enable);

            var clientThread1 = new Thread(Host.Enable);

            var clientThread2 = new Thread(Host.Enable);

            serviceThread.Start();

            clientThread1.Start(new HostParams(1));
            clientThread2.Start(new HostParams(2));

            Console.ReadLine();
        }


    }
}
