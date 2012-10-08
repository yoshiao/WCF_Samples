using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SimpleWCFService
{

    [ServiceContract(Namespace="http://wcf.test.org")]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);
    }
}
