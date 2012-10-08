using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.ServiceModel.Configuration;

namespace CustomLib
{
    public class CultureHeaderFilter : MessageFilter
    {
        public CultureHeaderFilter()
        {}

        public override bool Match(System.ServiceModel.Channels.Message message)
        {
            // Look for the culture header
            int i = message.Headers.FindHeader("culture", "urn:wcf:extension");

            return (i >= 0);
        }

        public override bool Match(System.ServiceModel.Channels.MessageBuffer buffer)
        {
            return Match(buffer.CreateMessage());
        }
    }

    public class CultureHeaderFilterEndpointBehavior : IEndpointBehavior
    {

        #region IEndpointBehavior Members
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            // Set AddressFilter to CultureHeaderFilter
            endpointDispatcher.AddressFilter =
                new CultureHeaderFilter(); 
        }


        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {}

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {}
 
        public void Validate(ServiceEndpoint endpoint)
        {}

        #endregion
    }

    public class CultureHeaderFilterEndpointBehaviorExtension : BehaviorExtensionElement
    {

        public override Type BehaviorType
        {
            get { return typeof(CultureHeaderFilterEndpointBehavior); }
        }

        protected override object CreateBehavior()
        {
            return new CultureHeaderFilterEndpointBehavior();
        }
    }
}

