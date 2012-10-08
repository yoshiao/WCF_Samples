using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace RESTServiceConsoleApp
{
    [ServiceContract(Namespace="WCF.REST")]
    public interface IDataService
    {
        [OperationContract]
        [WebGet(/*ResponseFormat= WebMessageFormat.Json*/)]
        SimpleData GetData();
    }

    [DataContract]
    public class SimpleData
    {
        [DataMember]
        public string StringValue { get; set; }
        [DataMember]
        public bool BoolValue { get; set; }
        [DataMember]
        public int IntValue { get; set; }
    }
}
