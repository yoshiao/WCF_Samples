using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace WCFServiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RunService();
        }

        static void RunService()
        {
            string svc_url = "http://localhost:8787/CalcService/";
            
            using (ServiceHost host = new ServiceHost(typeof(CalcService), new Uri(svc_url)))
            {
                
                host.AddServiceEndpoint(typeof(ICalcService), GetCustomBinding(), "");

                host.Open();
                Console.WriteLine("service started.....");
                Console.ReadLine();
            }


        }

        static Binding GetCustomBinding()
        {
            var cb = new CustomBinding(
                    new CustomLib.CustomEncoderBindingElement(new TextMessageEncodingBindingElement() ),
                    new HttpTransportBindingElement() { TransferMode = TransferMode.Buffered }
                    );
            return cb;
        }
    }
}
