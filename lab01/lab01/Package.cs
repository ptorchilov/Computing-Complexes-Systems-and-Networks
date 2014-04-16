namespace lab01
{
    using System;

    /// <summary>
    /// Class represented package.
    /// </summary>
    public class Package
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Package"/> class.
        /// </summary>
        /// <param name="sourceAddress">The source address.</param>
        /// <param name="destinationAddress">The destination address.</param>
        /// <param name="data">The data.</param>
        public Package(byte sourceAddress, byte destinationAddress, String data)
        {
            SourceAddress = sourceAddress;
            DestinationAddress = destinationAddress;
            Data = data;
        } 

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public String Data { get; private set; }

        /// <summary>
        /// Gets the destination address.
        /// </summary>
        /// <value>
        /// The destination address.
        /// </value>
        public byte DestinationAddress { get; private set; }

        /// <summary>
        /// Gets or sets the source address.
        /// </summary>
        /// <value>
        /// The source address.
        /// </value>
        public byte SourceAddress { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is collision].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is collision]; otherwise, <c>false</c>.
        /// </value>
        public bool IsCollision { get; set; } 

        #endregion
    }
}
