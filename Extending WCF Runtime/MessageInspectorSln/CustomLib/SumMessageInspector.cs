using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.Xml.Linq;
using System.Xml;
using System.IO;

namespace CustomLib
{
    public class SumMessageInspector : IClientMessageInspector
    {
        #region IClientMessageInspector Members

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        { 
            reply = GetTransformedMessage(reply);
        }

        Message GetTransformedMessage(Message oldMsg)
        {
            MessageBuffer mb = oldMsg.CreateBufferedCopy(int.MaxValue);
            Message newMsg = mb.CreateMessage();

            var reader = newMsg.GetReaderAtBodyContents().ReadSubtree();
            XElement bodyElm = XElement.Load(reader);

            var items = bodyElm.Descendants("ProductItem");
            int totalAmount = 0;
            foreach (var item in items)
            {
                totalAmount += int.Parse(item.Element("Amount").Value);
               
            }

            var products = items.First().Parent;
            products.Add(
                new XElement("ProductItem",
                    new XElement("Amount", totalAmount),
                    new XElement("Name", "TotalItems")
                    )
                    );
            reader.Close();
            newMsg.Close();

            MemoryStream ms = new MemoryStream();
            bodyElm.Save(ms);
            ms.Position = 0;

            var xmlreader = XmlDictionaryReader.CreateTextReader(
                ms,
                new XmlDictionaryReaderQuotas()
                );

            newMsg = Message.CreateMessage(oldMsg.Version, oldMsg.Headers.Action, xmlreader);
            newMsg.Headers.CopyHeadersFrom(oldMsg.Headers);
            newMsg.Properties.CopyProperties(oldMsg.Properties);

            return newMsg;
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            // Do nothing here
            return null;
        }

        #endregion
    }

    public class SumInspectorBehavior : IEndpointBehavior
    {
        #region IEndpointBehavior Members

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(
                new SumMessageInspector()
                );
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {}

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {}

        public void Validate(ServiceEndpoint endpoint)
        {}

        #endregion
    }

}
