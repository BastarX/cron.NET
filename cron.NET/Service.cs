using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cron.NET
{
    public class Service : System.ServiceProcess.ServiceBase
    {
        protected Thread m_thread;
        protected ManualResetEvent m_shutdownEvent;
        protected TimeSpan m_delay;

        public Service()
        {
            m_delay = new TimeSpan(0, 0, 0, 10, 0);
        }

        /// <SUMMARY>
        /// Starting service.
        /// </SUMMARY>
        protected override void OnStart(string[] args)
        {
            ThreadStart ts = new ThreadStart(this.ServiceMain);

            // create the manual reset event and
            // set it to an initial state of unsignaled
            m_shutdownEvent = new ManualResetEvent(false);

            // create the worker thread
            m_thread = new Thread(ts);

            // go ahead and start the worker thread
            m_thread.Start();

            // call the base class so it has a chance
            // to perform any work it needs to
            base.OnStart(args);
        }
 
        /// <SUMMARY>
        /// Stop this service.
        /// </SUMMARY>
        protected override void OnStop()
        {
            m_shutdownEvent.Set();

            // wait for the thread to stop giving it 10 seconds
            m_thread.Join(10000);

            // call the base class 
            base.OnStop();
        }

        /// <SUMMARY>
        /// 
        /// </SUMMARY>
        protected void ServiceMain()
        {
            bool bSignaled = false;
            int nReturnCode = 0;

            while (true)
            {
                // wait for the event to be signaled
                // or for the configured delay
                bSignaled = m_shutdownEvent.WaitOne(m_delay, true);

                // if we were signaled to shutdow, exit the loop
                if (bSignaled == true)
                    break;

                // let's do some work
                nReturnCode = Execute();
            }
        }

        /// <SUMMARY>
        /// 
        /// </SUMMARY>
        /// <RETURNS></RETURNS>
        protected virtual int Execute()
        {
            return -1;
        }
    }
}
