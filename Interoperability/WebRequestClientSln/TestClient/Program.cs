using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //CallServiceWithWCFChannelFactory();

                CallServiceWithWebRequest();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static void CallServiceWithWebRequest()
        {
            var soapRequest =
                   @"<s:Envelope xmlns:s='http://schemas.xmlsoap.org/soap/envelope/'>
                      <s:Body>
                        <GetData xmlns='http://wcf.test.org/'>
                          <value>11</value>
                        </GetData>
                      </s:Body>
                    </s:Envelope>";

            var bytes = Encoding.UTF8.GetBytes(soapRequest);

            WebRequest request = WebRequest.Create("http://localhost:6950/Service1.svc");
            request.Method = "POST";
            request.ContentType = "text/xml; charset=utf-8";
            request.Headers.Add("SOAPAction", "GetData");
          

            var requestStream = request.GetRequestStream();
            requestStream.Write(bytes, 0, bytes.Length);
            requestStream.Close();

            // Get the response. 
            WebResponse response = request.GetResponse();

            var responseStream = response.GetResponseStream();
            var reader = new StreamReader(responseStream);
            Console.WriteLine(reader.ReadToEnd());

            reader.Close();
            responseStream.Close();
            response.Close();
        }

        private static void CallServiceWithWCFChannelFactory()
        {
            string url = "http://ipv4.fiddler:6950/Service1.svc";

            var binding = new BasicHttpBinding();

            ChannelFactory<WCFHttpService.IService1> cf = 
                new ChannelFactory<WCFHttpService.IService1>(binding, url);

            var proxy = cf.CreateChannel();

            string data = proxy.GetData(11);

            Console.WriteLine(data);
        }
    }
}
