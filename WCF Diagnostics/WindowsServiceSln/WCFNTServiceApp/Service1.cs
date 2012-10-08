using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;

namespace WCFNTServiceApp
{
    public partial class Service1 : ServiceBase
    {
        ServiceHost _host = null;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _host = new ServiceHost(typeof(TestService));
            _host.Open();
        }

        protected override void OnStop()
        {
            if (_host != null && _host.State == CommunicationState.Opened)
                _host.Close();
        }
    }
}
