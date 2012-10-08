using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;


[assembly: System.Diagnostics.DebuggerVisualizer(
typeof(DebugLib.ServiceHostVisualizer),
typeof(DebugLib.ServiceHostVisualizerObjectSource),
Target = typeof(System.ServiceModel.ServiceHostBase),
Description = "My WCF ServiceHost Visualizer")]



namespace DebugLib
{

    // Visualizer for ServiceHost type
    public class ServiceHostVisualizer : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            string svcHostData = objectProvider.GetObject() as string;

            if (svcHostData != null) MessageBox.Show(svcHostData);
           
        }        
    }

    // ObjectSource class for serializing the target object into custom data
    public class ServiceHostVisualizerObjectSource : VisualizerObjectSource
    {
      
        public override void GetData(object inObject, Stream outStream)
        {
            if (inObject != null && inObject is ServiceHostBase)
            {
                var svcHost = inObject as ServiceHostBase;

                StringBuilder sb = new StringBuilder("Endpoints in ServiceHost:\n");
                foreach (var ep in svcHost.Description.Endpoints)
                {
                    sb.AppendFormat("Address:{0}, Binding:{1}, Contract:{2}\n",
                        ep.Address, ep.Binding, ep.Contract
                        );
                }

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(outStream, sb.ToString());
            }
        }
    }

}
