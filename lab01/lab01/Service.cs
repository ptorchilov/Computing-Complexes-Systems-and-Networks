namespace lab01
{
    using System;
    using System.Text;
    using System.Threading;
    using System.Collections.Generic;

    public class Service
    {
        public static Random Random = new Random(DateTime.Now.Millisecond);

        public static List<Package> PacketQueue = new List<Package>();

        public static List<Host> HostCollection = new List<Host>();

        public static void Enable()
        {
            while (true)
            {
                Thread.Sleep(113);

                var localQueue = new List<Package>();

                lock (PacketQueue)
                {
                    localQueue.AddRange(PacketQueue);
                    PacketQueue.Clear();
                }
                 

                if (localQueue.Count > 1)
                {
                    if (HostCollection != null)
                    {
                        var collisionPackage = GenegateCollisionPackage(localQueue);

                        foreach (var host in HostCollection)
                        {
                            var worker = new Thread(host.Receive) {IsBackground = true};

                            worker.Start(collisionPackage);
                        }

                        localQueue.Clear();
                    }
                }
                else if (localQueue.Count == 1)
                {
                    if (HostCollection != null)
                    {
                        HostCollection[localQueue[0].DestinationAddress - 1].Receive(localQueue[0]);
                        localQueue.Clear();
                    }
                }
            }
        }

        private static Package GenegateCollisionPackage(IEnumerable<Package> localQueue)
        {
            var collisionPackage = new Package(255, 255, "addresses: " + GetCollisionAddresses(localQueue)) {IsCollision = true};

            return collisionPackage;
        }

        private static String GetCollisionAddresses(IEnumerable<Package> localQueue)
        {
            var addresses = new StringBuilder();

            if (PacketQueue != null)
            {
                foreach (var packet in localQueue)
                {
                    addresses.Append(packet.SourceAddress).Append(" ");
                }
            }

            return addresses.ToString();
        }
    }
}