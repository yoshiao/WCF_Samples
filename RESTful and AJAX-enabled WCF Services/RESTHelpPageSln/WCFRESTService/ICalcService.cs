using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace WCFRESTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IICalcService" in both code and config file together.
    [ServiceContract]
    public interface ICalcService
    {
        [OperationContract]
        [WebGet(BodyStyle=WebMessageBodyStyle.Wrapped)]
        int Add(int lv, int rv);

        [OperationContract]
        [WebInvoke(BodyStyle=WebMessageBodyStyle.Wrapped)]
        int Subtract(int lv, int rv);
    }
}
