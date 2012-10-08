using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WCFServiceApp
{
    
    public class DataService : IDataService
    {
        public string GetData()
        {
            Thread.Sleep(1000 * 3);

            return "Some data...";
        }
    }
}
