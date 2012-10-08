using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;

namespace WCFNTServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService" in both code and config file together.
    public class TestService : ITestService
    {
        public void DoWork()
        {
            // Do some work here

            Debug.WriteLine("DoWork is called...");
        }
    }
}
