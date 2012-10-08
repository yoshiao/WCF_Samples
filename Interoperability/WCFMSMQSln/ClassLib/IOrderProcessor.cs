using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using ClassLib;

namespace ClassLib
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    [ServiceKnownType(typeof(MyOrder))]
    public interface IOrderProcessor
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void SubmitPurchaseOrderInMessage(MsmqMessage<MyOrder> msg);
    }

}
