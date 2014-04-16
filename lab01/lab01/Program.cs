namespace lab01
{
    using System.Threading;

    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceThread = new Thread(Service.Enable);


            var host1 = new Host(new HostParams(1));
            var host2 = new Host(new HostParams(2));
            var host3 = new Host(new HostParams(3));

            Service.HostCollection.Add(host1);
            Service.HostCollection.Add(host2);
            Service.HostCollection.Add(host3);

            var sendThread1 = new Thread(host1.Send);
            var sendThread2 = new Thread(host2.Send);
            var sendThread3 = new Thread(host3.Send);

            var package1 = new Package(1, 2, "1111111");
            var package2 = new Package(2, 3, "2222222");
            var package3 = new Package(3, 1, "3333333");

            host1.Buffer = package1;
            host2.Buffer = package2;
            host3.Buffer = package3;

            serviceThread.Start();

            sendThread1.Start(package1);
            sendThread2.Start(package2);
            sendThread3.Start(package3);
            
        }
    }
}
