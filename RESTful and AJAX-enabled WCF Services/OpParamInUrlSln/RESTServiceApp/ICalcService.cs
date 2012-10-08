using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;

namespace RESTServiceApp
{
    
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract]
        [WebGet(UriTemplate="Add?lv={lv}&rv={rv}")]
        int Add_ParamsInQueryString(string lv, string rv);

        [OperationContract]
        [WebGet(UriTemplate = "Add({lv},{rv})")]
        int Add_ParamsInUrlSuffix(string lv, string rv);
    }
}
