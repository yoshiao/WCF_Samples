using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ServiceWebApp
{
    /// <summary>
    /// Summary description for TestWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class TestWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetData()
        {
            return "Hello World";
        }
    }
}
