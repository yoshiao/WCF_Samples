using System;
using System.Collections.Generic;
using System.Text;
using System.Messaging;
using ClassLib;
using System.Threading;

namespace MSMQClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        static void Run()
        {
    
            MessageQueue queue = null;
            MessageQueueTransaction trans = null;
            try
            {
                queue = new MessageQueue();
                queue.Path = Constants.QUEUE_PATH;
                queue.DefaultPropertiesToSend.Recoverable = true;


                trans = new MessageQueueTransaction();
                trans.Begin();

                MyOrder order = new MyOrder();
                order.ID = DateTime.Now.Ticks.ToString();
                order.Name = "Order_" + order.ID;

                Message msg = new Message(order);

            
                queue.Send(msg, trans);
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Abort();
            }
            finally
            {
                queue.Close();
            }

            Console.WriteLine("message sent..");
        }
    }
}
