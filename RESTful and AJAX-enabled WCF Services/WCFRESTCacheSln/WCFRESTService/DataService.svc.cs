using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;

namespace WCFRESTService
{
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
    public class DataService : IDataService
    {
        public string GetData()
        {
            return string.Format("Current Time: {0}", DateTime.Now.ToLongTimeString());
        }

       
    }
}
