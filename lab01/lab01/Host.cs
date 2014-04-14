namespace lab01
{
    using System;
    using System.Threading;

    public static class Host
    {
        public static void Enable(Object data)
        {
            var information = (HostParams) data;

            while (true)
            {
                var package = new Package(information.SourceAddress, information.DestinationAddress, information.Data);

                Thread.Sleep(Service.Random.Next(0, 1000));

                Service.PacketQueue.Add(package);
            }
        }
    }
}
