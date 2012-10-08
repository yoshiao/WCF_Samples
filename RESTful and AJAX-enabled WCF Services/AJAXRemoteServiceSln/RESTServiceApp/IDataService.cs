using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RESTServiceApp
{
    
    [ServiceContract]
    public interface IDataService
    {
        [OperationContract]
        [WebGet(UriTemplate="GetData?val={value}", ResponseFormat=WebMessageFormat.Json)]
        string GetData(int value);

        
    }


}
