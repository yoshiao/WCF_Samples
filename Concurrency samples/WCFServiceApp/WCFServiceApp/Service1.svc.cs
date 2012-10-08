using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace WCFServiceApp
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall,
                     ConcurrencyMode= ConcurrencyMode.Multiple)]
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            Thread.Sleep(1000 * 3);

            return string.Format("You entered: {0}", value);
        }

        
    }
}
