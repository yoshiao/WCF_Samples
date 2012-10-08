using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;

namespace CustomLib
{
    public class CustomEncoderFactory : MessageEncoderFactory
    {
      CustomEncoder encoder;
      MessageEncoderFactory innerFactory;

      public CustomEncoderFactory(BindingElement bindingElement, MessageEncoderFactory innerFactory)
      {
         this.innerFactory = innerFactory;
         this.encoder = new CustomEncoder(bindingElement, innerFactory.Encoder);
      }

      public override MessageEncoder Encoder
      {
          get { return this.encoder; }
      }

      public override MessageVersion MessageVersion
      {
         get { return this.innerFactory.MessageVersion; }
      }

    }
}
