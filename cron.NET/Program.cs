using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace cron.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Parse("123-56/2");
            //ServiceBase.Run(new TestService());
            Console.ReadKey();
        }
    }
}
