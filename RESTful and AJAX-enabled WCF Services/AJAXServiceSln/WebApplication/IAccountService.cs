using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;

namespace WebApplication
{
    
    [ServiceContract(Namespace="AccountService", Name="AccountSVC")]
    public interface IAccountService
    {
        [OperationContract]
        [WebGet]
        bool ValidateUser(string username, string password);
    }
}
