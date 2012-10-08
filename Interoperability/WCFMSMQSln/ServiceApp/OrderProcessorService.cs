using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using ClassLib;
using System.ServiceModel.MsmqIntegration;
using System.Security.Principal;
using System.Messaging;
using System.ServiceModel.Description;

namespace ServiceApp
{
    public class OrderProcessorService : IOrderProcessor
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        [ServiceKnownType(typeof(MyOrder))]
        public void SubmitPurchaseOrderInMessage(MsmqMessage<MyOrder> ordermsg)
        {
            MyOrder po = (MyOrder)ordermsg.Body;
            Console.WriteLine("Processing id:{0}, name:{1} ", po.ID, po.Name);
        }

      


     
        public static void Main()
        {
            //init queue
            if (!MessageQueue.Exists(Constants.QUEUE_PATH)) MessageQueue.Create(Constants.QUEUE_PATH, true);


            //init wcf host via code
            Uri baseUri = new Uri("http://localhost:7878/msmqsvc");
            using (ServiceHost host = new ServiceHost(typeof(OrderProcessorService),baseUri))
            {
                //add metadata behavior
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior(){ HttpGetEnabled=true};
                host.Description.Behaviors.Add(smb);

                //add service endpoint
                MsmqIntegrationBinding binding = new MsmqIntegrationBinding(MsmqIntegrationSecurityMode.None);
                host.AddServiceEndpoint(typeof(ClassLib.IOrderProcessor), binding, "msmq.formatname:DIRECT=OS:" + Constants.QUEUE_PATH);

                host.Open();


                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press any key to terminate service.");
                Console.ReadLine();
                host.Close();
            }
        }

    }

}
