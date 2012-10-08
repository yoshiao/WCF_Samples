using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace RESTServiceConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RunService();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void RunService()
        {
            using (WebServiceHost host = new WebServiceHost(typeof(DataService)))
            {
                host.Open();
                Console.WriteLine("REST service started...");
                Console.ReadLine();
            }
        }
    }
}
