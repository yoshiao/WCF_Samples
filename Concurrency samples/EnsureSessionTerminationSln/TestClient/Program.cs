using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ServiceModel;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 4; ++i)
                {
                    CallService();

                    //CallServiceWithExceptionHandling();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void CallService()
        {
            TestProxy.DataServiceClient client = new TestProxy.DataServiceClient();
            
            try
            {
                Console.WriteLine(client.GetData());
            }
            finally
            {
                // Close the proxy
                client.Close();
            }
        }

        static void CallServiceWithExceptionHandling()
        {
            TestProxy.DataServiceClient client = new TestProxy.DataServiceClient();
            try
            {
                // Making calls
                Console.WriteLine(client.GetData());

                // Close the proxy
                client.Close(); 
            }
            catch (TimeoutException timeEx)
            {
                client.Abort();
            }
            catch (FaultException faultEx)
            {
                client.Abort();
            }
            catch (CommunicationException commProblem)
            {
                client.Abort();
            }

        }

    }
}
