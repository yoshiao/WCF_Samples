using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFRESTService
{
    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        [WebGet]
        [AspNetCacheProfile("CacheFor30Seconds")]
        string GetData();

    }


}
