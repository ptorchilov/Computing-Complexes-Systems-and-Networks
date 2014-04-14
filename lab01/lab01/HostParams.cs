namespace lab01
{
    using System;

    public class HostParams
    {
        public HostParams(int sourceAddress)
        {
            SourceAddress = sourceAddress;
        }

        public int SourceAddress { get; private set; }

        public String Data { get; set; }

        public int DestinationAddress { get; set; }
    }
}
