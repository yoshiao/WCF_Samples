using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TestProxy.Service1Client client = new TestProxy.Service1Client();

            Console.WriteLine(client.GetData(11));
            
        }
    }
}
