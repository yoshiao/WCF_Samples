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
            CallASMXService();
        }

        private static void CallASMXService()
        {
            ASMXProxy.TestWebServiceSoapClient client = new ASMXProxy.TestWebServiceSoapClient();

            Console.WriteLine(client.GetData());
        }
    }
}
