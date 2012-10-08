using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;

namespace RESTServiceApp
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CalcService : ICalcService
    {
        public int Add_ParamsInQueryString(string lv, string rv)
        {
            int ilv = int.Parse(lv);
            int irv = int.Parse(rv);
            return ilv + irv;
        }


        public int Add_ParamsInUrlSuffix(string lv, string rv)
        {
            int ilv = int.Parse(lv);
            int irv = int.Parse(rv);
            return ilv + irv;
        }
    }
}
