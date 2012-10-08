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
            CallService();
        }

        static void CallService()
        {
            TestProxy.Service1Client proxy = new TestProxy.Service1Client();

            // Replace "localhost" with "ipv4.fiddler" when trying to capture messages via Fiddler tool
            proxy.Endpoint.Address = new EndpointAddress(
                "http://localhost:8799/Service1.svc"
                );

            string data = proxy.GetData(11);
        }
    }
}
