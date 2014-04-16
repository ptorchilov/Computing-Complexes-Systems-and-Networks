namespace lab01
{
    /// <summary>
    /// Class represented host address.
    /// </summary>
    public class HostParams
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HostParams"/> class.
        /// </summary>
        /// <param name="sourceAddress">The source address.</param>
        public HostParams(byte sourceAddress)
        {
            SourceAddress = sourceAddress;
        } 

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the source address.
        /// </summary>
        /// <value>
        /// The source address.
        /// </value>
        public byte SourceAddress { get; private set; } 

        #endregion
        
    }
}
