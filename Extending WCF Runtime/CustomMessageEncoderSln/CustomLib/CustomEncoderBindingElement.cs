using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;

namespace CustomLib
{
    public class CustomEncoderBindingElement : MessageEncodingBindingElement
    {
        MessageEncodingBindingElement innerBindingElement;

        public CustomEncoderBindingElement(MessageEncodingBindingElement innerBE)
            : base()
        {
            this.innerBindingElement = innerBE;
        }

        public override MessageEncoderFactory CreateMessageEncoderFactory()
        {
            return new CustomEncoderFactory(this, innerBindingElement.CreateMessageEncoderFactory());
        }

        public override MessageVersion MessageVersion
        {
            get
            {
                return innerBindingElement.MessageVersion;
            }
            set
            {
                innerBindingElement.MessageVersion = value;
            }
        }

        public override BindingElement Clone()
        {
            return new CustomEncoderBindingElement(this.innerBindingElement);
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            context.BindingParameters.Add(this);
            return base.BuildChannelFactory<TChannel>(context);
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            context.BindingParameters.Add(this);
            return base.BuildChannelListener<TChannel>(context);
        }

    }
}
