using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel.MsmqIntegration;
using System.ServiceModel;

using ClassLib;
using System.Transactions;

namespace WCFClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void Run()
        {
            MsmqIntegrationBinding binding = new MsmqIntegrationBinding();
            binding.Security.Mode = MsmqIntegrationSecurityMode.None;
            EndpointAddress address = new EndpointAddress("msmq.formatname:DIRECT=OS:" + Constants.QUEUE_PATH);

            ChannelFactory<ClassLib.IOrderProcessor> channelFactory = new ChannelFactory<ClassLib.IOrderProcessor>(binding, address);

            try
            {
                ClassLib.IOrderProcessor channel = channelFactory.CreateChannel();

                MyOrder order = new MyOrder();
                order.ID = DateTime.Now.Ticks.ToString();
                order.Name = "Order_" + order.ID;

                MsmqMessage<MyOrder> ordermsg = new MsmqMessage<MyOrder>(order);
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    channel.SubmitPurchaseOrderInMessage(ordermsg);
                    scope.Complete();
                }

                Console.WriteLine("Order has been submitted:{0}", ordermsg);
            }
            finally
            {
                channelFactory.Close();
            }

        }
    }
}
