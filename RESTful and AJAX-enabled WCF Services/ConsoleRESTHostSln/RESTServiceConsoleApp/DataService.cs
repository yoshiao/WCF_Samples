using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RESTServiceConsoleApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CalcService" in both code and config file together.
    public class DataService : IDataService
    {
        public SimpleData GetData()
        {
            var sd = new SimpleData()
            {
                StringValue = "test string",
                IntValue = 11,
                BoolValue = true
            };

            return sd;
        }
    }
}
