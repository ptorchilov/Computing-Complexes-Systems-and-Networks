namespace UI
{
    using System;
    using System.Threading;
    using System.Windows.Forms;

    /// <summary>
    /// Main window.
    /// </summary>
    public partial class ApplicationForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationForm"/> class.
        /// </summary>
        public ApplicationForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Buttons the start click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonStartClick(object sender, System.EventArgs e)
        {
            var serviceThread = new Thread(Service.Enable);

            Service.Threads.Add(serviceThread);


            var host1 = new Host(new HostParams(1), this);
            var host2 = new Host(new HostParams(2), this);
            var host3 = new Host(new HostParams(3), this);

            Service.HostCollection.Add(host1);
            Service.HostCollection.Add(host2);
            Service.HostCollection.Add(host3);

            var sendThread1 = new Thread(host1.Send);
            var sendThread2 = new Thread(host2.Send);
            var sendThread3 = new Thread(host3.Send);

            Service.Threads.Add(sendThread1);
            Service.Threads.Add(sendThread2);
            Service.Threads.Add(sendThread3);

            var package1 = new Package(1, 2, textBoxHost1.Text);
            var package2 = new Package(2, 3, textBoxHost2.Text);
            var package3 = new Package(3, 1, textBoxHost3.Text);

            host1.Buffer = package1;
            host2.Buffer = package2;
            host3.Buffer = package3;

            serviceThread.Start();

            sendThread1.Start(package1);
            sendThread2.Start(package2);
            sendThread3.Start(package3);
        }

        /// <summary>
        /// Buttons the stop click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonStopClick(object sender, System.EventArgs e)
        {
            if (Service.Threads != null)
            {
                foreach (var thread in Service.Threads)
                {
                    thread.Abort();
                }
            }
        }

        private void ApplicationFormFormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }
    }
}
