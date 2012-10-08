using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CallService();

            Console.ReadLine();
        }

        private static void CallService()
        {

            for (int i = 0; i < 10; ++i)
            {
                TestProxy.TimeServiceClient client = new TestProxy.TimeServiceClient();
                Console.WriteLine(client.GetCurrentTime());
                client.Close();
                
            }
        }

    
    }
}
