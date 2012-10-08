using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;

namespace CustomLib
{
    public class CustomAuthManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
          
            HttpRequestMessageProperty httpProps =
                OperationContext.Current.IncomingMessageProperties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            string userAgent = httpProps.Headers["User-Agent"];

            if (string.IsNullOrEmpty(userAgent)) return false;

            return true;
        }
    }
}
