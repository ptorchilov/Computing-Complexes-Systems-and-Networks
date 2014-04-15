namespace lab01
{
    using System;

    public class HostParams
    {
        public HostParams(byte sourceAddress)
        {
            SourceAddress = sourceAddress;
        }

        public byte SourceAddress { get; private set; }
        
    }
}
