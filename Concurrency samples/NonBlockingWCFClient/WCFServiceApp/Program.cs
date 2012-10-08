using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WCFServiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RunService();
        }

        private static void RunService()
        {
            using(ServiceHost host = new ServiceHost(typeof(DataService)))
            {
                host.Open();
                Console.WriteLine("service started at {0}", host.BaseAddresses[0]);
                Console.ReadLine();
            }
        }
    }
}
