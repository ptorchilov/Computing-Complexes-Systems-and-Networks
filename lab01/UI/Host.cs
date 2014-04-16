namespace UI
{
    using System;
    using System.Threading;
    using System.Windows.Forms;

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

        /// <summary>
        /// The form
        /// </summary>
        private readonly ApplicationForm form;

        private static Object sync = new Object();

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
        /// Initializes a new instance of the <see cref="Host" /> class.
        /// </summary>
        /// <param name="hostParams">The host parameters.</param>
        /// <param name="form">The form.</param>
        public Host(HostParams hostParams, ApplicationForm form)
        {
            this.hostParams = hostParams;
            this.timeToWait = Service.Random.Next(0, 3019);
            this.form = form;
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
                Thread.Sleep(this.timeToWait);

                if (!Service.PacketQueue.Exists(p => p.SourceAddress == this.hostParams.SourceAddress))
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
                if (package.DestinationAddress == this.hostParams.SourceAddress)
                {
                    form.textBoxOutput.Text += @"Host " + this.hostParams.SourceAddress + @": " + package.Data
                                               + Environment.NewLine;
                    this.ScrollTextBox(form.textBoxOutput);

                    this.timeToWait = Service.Random.Next(0, 3019);
                    this.CollisionCount = 0;
                    this.Send(this.Buffer);
                }
                else if (package.IsCollision)
                {
                    this.CollisionCount++;

                    if (this.CollisionCount == 10)
                    {
                        form.textBoxStatistics.Text += @"Host " + this.hostParams.SourceAddress + @": dropped package "
                                                       + package.Data + @"; Collision count = " + this.CollisionCount
                                                       + Environment.NewLine;
                        this.ScrollTextBox(form.textBoxStatistics);

                        this.timeToWait = Service.Random.Next(0, 3019);
                        this.CollisionCount = 0;
                        this.Send(this.Buffer);
                    }
                    else
                    {
                        lock (sync)
                        {
                            form.textBoxStatistics.Text += @"Host " + this.hostParams.SourceAddress + @": "
                                                           + package.Data + @"; Collision count = " + this.CollisionCount;

                            double min = Math.Min(this.CollisionCount, 10);

                            this.timeToWait = Service.Random.Next(0, (int)Math.Pow(2, min)) * 1000;

                            form.textBoxStatistics.Text += @"; Time to wait = " + timeToWait / 1000 + Environment.NewLine;

                            this.ScrollTextBox(form.textBoxStatistics);
                        }

                        this.Send(this.Buffer);
                    }
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Scrolls the text box.
        /// </summary>
        /// <param name="textBox">The text box.</param>
        private void ScrollTextBox(TextBox textBox)
        {
            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToCaret();
            textBox.Refresh();
        }

        #endregion
    }
}