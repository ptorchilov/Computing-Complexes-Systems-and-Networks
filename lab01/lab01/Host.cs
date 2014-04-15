namespace lab01
{
    using System;
    using System.Threading;

    public class Host
    {
        private readonly HostParams hostParams;

        private int timeToWait;

        public Package Buffer { get; set; }

        public int CollisionCount { get; private set; }

        public Host(HostParams hostParams)
        {
            this.hostParams = hostParams;
            timeToWait = Service.Random.Next(0, 3000);
        }

        public void Send(Object data)
        {
            var package = data as Package;

            if (package != null)
            {
                Thread.Sleep(timeToWait);

                lock (Service.PacketQueue)
                {
                    Service.PacketQueue.Add(package);    
                }
            }
        }

        public void Receive(Object data)
        {
            var package = data as Package;

            if (package != null)
            {

                if (package.DestinationAddress == hostParams.SourceAddress)
                {
                    Console.WriteLine("Host " + hostParams.SourceAddress + ": " + package.Data);
                    timeToWait = Service.Random.Next(0, 3000);
                    CollisionCount = 0;
                    Send(Buffer);

                }
                else if (package.IsCollision)
                {
                    CollisionCount++;

                    if (CollisionCount == 10)
                    {
                        Console.WriteLine("Host " + hostParams.SourceAddress + ": dropped package" + package.Data + "collision count = " +
                                      CollisionCount);
                        timeToWait = Service.Random.Next(0, 3000);
                        CollisionCount = 0;
                        Send(Buffer);

                    }
                    else
                    {
                        Console.Write("Host " + hostParams.SourceAddress + ": " + package.Data + "Collision count = " +
                            CollisionCount);

                        double min = Math.Min(CollisionCount, 10);

                        timeToWait = Service.Random.Next(0, (int)Math.Pow(2, min)) * 1000;
                        Console.WriteLine(" Time to wait = " + (timeToWait / 1000));

                        Send(Buffer);
    
                    }                    
                }
            }
        }
    }
}
