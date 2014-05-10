using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cron.NET
{
    public class TestService : Service
    {
        public TestService()
        {

        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
        }

        protected override void OnStop()
        {
            base.OnStop();
        }

        protected override int Execute()
        {
            Console.WriteLine("Test");
            return 0;
        }
    }
}
