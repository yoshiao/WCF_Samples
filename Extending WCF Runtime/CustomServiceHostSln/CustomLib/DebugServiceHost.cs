using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Activation;

namespace CustomLib
{
    public class DebugServiceHost : ServiceHost
    {
        public DebugServiceHost(Type serviceType, Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        { }

        protected override void ApplyConfiguration()
        {
            base.ApplyConfiguration();

            // Our custom configuration code

            ServiceDebugBehavior sdb = this.Description.Behaviors.Find<ServiceDebugBehavior>();
            if (sdb == null)
            {
                sdb = new ServiceDebugBehavior();
                this.Description.Behaviors.Add(sdb);
            }

            // Ensure exception detail is included in response
            sdb.IncludeExceptionDetailInFaults = true; 
        }

         
    }

    // Custom ServiceHostFactory used for IIS/WAS hosting scenario
    public class DebugServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            return new DebugServiceHost(serviceType, baseAddresses);
        }

    }
}
