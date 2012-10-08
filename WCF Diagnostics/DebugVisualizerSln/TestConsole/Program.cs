﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            using(ServiceHost host = new ServiceHost(typeof(Service1)))
            {
                host.Open();


                Console.WriteLine("service started ....");
                Console.ReadLine();


            }
        }
    }
}
