using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TestProxy.Service1Client client = new TestProxy.Service1Client();

                using (OperationContextScope scope = new OperationContextScope(client.InnerChannel))
                {
                    MessageHeader<string> cultureHeader = new MessageHeader<string>("en-US");

                    // Add the culture header into request 
                    OperationContext.Current.OutgoingMessageHeaders.Add(
                        cultureHeader.GetUntypedHeader("culture", "urn:wcf:extension")
                        );

                    client.GetData(11);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
