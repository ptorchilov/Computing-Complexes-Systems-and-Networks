namespace lab01
{
    using System;

    public class Package
    {
        public Package(byte sourceAddress, byte destinationAddress, String data)
        {
            SourceAddress = sourceAddress;
            DestinationAddress = destinationAddress;
            Data = data;
        }

        public String Data { get; private set; }

        public byte DestinationAddress { get; private set; }

        public byte SourceAddress { get; set; }

        public bool IsCollision { get; set; }
    }
}
