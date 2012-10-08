using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.ServiceModel;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CallService();
        }

        static void CallService()
        {
            // Replace "localhost" with "ipv4.fiddler" when using fiddler to capture message
            string svc_url = "http://localhost:8787/CalcService/";

             
            ChannelFactory<WCFServiceApp.ICalcService> cf = 
                new ChannelFactory<WCFServiceApp.ICalcService>(
                    GetCustomBinding(),
                    svc_url
                );

            WCFServiceApp.ICalcService calcproxy = cf.CreateChannel();

            Console.WriteLine("3+5={0}", calcproxy.Add(3, 5));
        }

        static Binding GetCustomBinding()
        {
            var cb = new CustomBinding(
                    new CustomLib.CustomEncoderBindingElement(new TextMessageEncodingBindingElement()),
                    new HttpTransportBindingElement() { TransferMode = TransferMode.Buffered }
                    );
            return cb;
        }
    }


}
