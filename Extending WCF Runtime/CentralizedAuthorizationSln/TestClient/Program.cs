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
            try
            {
                CallService();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void CallService()
        {
            TestProxy.Service1Client client = new TestProxy.Service1Client();
            using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
            {
                HttpRequestMessageProperty httpProps = new HttpRequestMessageProperty();
                httpProps.Headers["User-Agent"] = "Test Client";

                OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpProps;
                
                Console.WriteLine(client.GetData(11));

            }
        }
    }
}
