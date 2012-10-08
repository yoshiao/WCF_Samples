using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CallService();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void CallService()
        {
            string svc_url = "http://localhost:30118/DataService.svc";
            var binding = new BasicHttpBinding();
            ChannelFactory<WCFServiceApp.IDataService> cf = 
                new ChannelFactory<WCFServiceApp.IDataService>(
                    binding,
                    svc_url);

            cf.Endpoint.Behaviors.Add(
                new CustomLib.SumInspectorBehavior()
                );
            
            WCFServiceApp.IDataService dataproxy = cf.CreateChannel();

            foreach (var item in dataproxy.GetProductList())
            {
                Console.WriteLine("Name: {0}, Amount: {1}", item.Name, item.Amount);
            }

        }
    }
}
