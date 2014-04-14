namespace lab01
{
    using System;

    public class Package
    {
        public Package(int sourceAddress, int destinationAddress, String data)
        {
            SourceAddress = sourceAddress;
            DestinationAddress = destinationAddress;
            Data = data;
            CollisionNumber = 0;
        }

        public String Data { get; private set; }

        public int CollisionNumber { get;  set; }

        public int DestinationAddress { get; private set; }

        public int SourceAddress { get; private set; }
    }
}
