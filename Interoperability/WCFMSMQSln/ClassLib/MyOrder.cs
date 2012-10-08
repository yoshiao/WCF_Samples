using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace ClassLib
{
    [DataContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public class MyOrder
    {
        [DataMember]
        public string ID;

        [DataMember]
        public string Name;
    }
}
