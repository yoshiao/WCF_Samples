using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace SimpleWCFService
{
    class Program
    {
        static void Main(string[] args)
        {
            RunService();
        }

        private static void RunService()
        {
            using (ServiceHost host = new ServiceHost(typeof(Service1)))
            {
                host.Open();

                Console.WriteLine("service started.......");
                Console.ReadLine();

            }
        }
    }
}
