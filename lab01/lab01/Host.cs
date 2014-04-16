namespace lab01
{
    using System;
    using System.Threading;

    /// <summary>
    /// Class represented host station.
    /// </summary>
    public class Host
    {
        #region Private Fields

        /// <summary>
        /// The host parameters
        /// </summary>
        private readonly HostParams hostParams;

        /// <summary>
        /// The time automatic wait
        /// </summary>
        private int timeToWait; 

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the buffer.
        /// </summary>
        /// <value>
        /// The buffer.
        /// </value>
        public Package Buffer { get; set; }

        /// <summary>
        /// Gets the collision count.
        /// </summary>
        /// <value>
        /// The collision count.
        /// </value>
        public int CollisionCount { get; private set; } 

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Host"/> class.
        /// </summary>
        /// <param name="hostParams">The host parameters.</param>
        public Host(HostParams hostParams)
        {
            this.hostParams = hostParams;
            timeToWait = Service.Random.Next(0, 3019);
        } 

        #endregion

        #region Public Methods

        /// <summary>
        /// Sends the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Send(Object data)
        {
            var package = data as Package;

            if (package != null)
            {
                Thread.Sleep(timeToWait);

                if (!Service.PacketQueue.Exists(p => p.SourceAddress == hostParams.SourceAddress))
                {
                    lock (Service.PacketQueue)
                    {
                        Service.PacketQueue.Add(package);
                    }
                }
            }
        }

        /// <summary>
        /// Receives the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        public void Receive(Object data)
        {
            var package = data as Package;

            if (package != null)
            {
                if (package.DestinationAddress == hostParams.SourceAddress)
                {
                    Console.WriteLine("Host " + hostParams.SourceAddress + ": " + package.Data);
                    timeToWait = Service.Random.Next(0, 3019);
                    CollisionCount = 0;
                    Send(Buffer);
                }
                else if (package.IsCollision)
                {
                    CollisionCount++;

                    if (CollisionCount == 10)
                    {
                        Console.WriteLine(
                            "Host " + hostParams.SourceAddress + ": dropped package" + package.Data
                            + "collision count = " + CollisionCount);
                        timeToWait = Service.Random.Next(0, 3019);
                        CollisionCount = 0;
                        Send(Buffer);
                    }
                    else
                    {
                        Console.Write(
                            "Host " + hostParams.SourceAddress + ": " + package.Data + "Collision count = "
                            + CollisionCount);

                        double min = Math.Min(CollisionCount, 10);

                        timeToWait = Service.Random.Next(0, (int)Math.Pow(2, min)) * 1000;
                        Console.WriteLine(" Time to wait = " + (timeToWait / 1000));

                        Send(Buffer);
                    }
                }
            }
        }

        #endregion
    }
}