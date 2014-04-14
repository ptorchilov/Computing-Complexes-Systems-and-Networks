namespace lab01
{
    using System;
    using System.Threading;
    using System.Collections.Generic;

    public static class Service
    {
        public static Random Random = new Random(DateTime.Now.Millisecond);

        public static List<Package> PacketQueue = new List<Package>();

        public static void Enable(Object data)
        {
            Thread.Sleep(100);
            
            if (PacketQueue.Count > 1)
            {
                
            }

        }
    }
}
