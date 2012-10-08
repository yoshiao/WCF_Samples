using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;

namespace WebApplication
{
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
    public class AccountService : IAccountService
    {
        public bool ValidateUser(string username, string password)
        {
            if (username != password) return false;

            return true;
        }
    }
}
