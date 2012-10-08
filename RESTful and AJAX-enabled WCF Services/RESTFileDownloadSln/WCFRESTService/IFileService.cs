using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.ServiceModel.Web;

namespace WCFRESTService
{
    
    [ServiceContract]
    public interface IFileService
    {
        [OperationContract]
        [WebGet(UriTemplate="GetFile/{filename}/{ext}")]
        Stream GetFile(string filename, string ext);
    }
}
