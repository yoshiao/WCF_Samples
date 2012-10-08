using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.ServiceModel.Activation;
using System.Web;
using System.ServiceModel.Web;

namespace WCFRESTService
{
    [AspNetCompatibilityRequirements(RequirementsMode=AspNetCompatibilityRequirementsMode.Allowed)]
    public class FileService : IFileService
    {
        public Stream GetFile(string filename, string ext)
        {
            string filepath = Path.Combine(HttpContext.Current.Server.MapPath("~/Files/") ,filename+"."+ext);

            if (!File.Exists(filepath)) throw new ArgumentException("Invalid filename---\"" + filepath + "\"");

            WebOperationContext.Current.OutgoingResponse.ContentType = "application/octet-stream";

            return File.OpenRead(filepath);
        }
    }
}
