using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFServiceApp
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class TimeService : ITimeService
    {
        public TimeService()
        {
            Console.WriteLine("A new instance of TimeService is constructed at {0}", DateTime.Now);
        }

        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}
