using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class Service1 : IDataService
    {
        public List<ProductItem> GetProductList()
        {
            List<ProductItem> items = new List<ProductItem>();
            items.Add(new ProductItem() { Name = "Product1", Amount = 11 });
            items.Add(new ProductItem() { Name = "Product2", Amount = 22 });
            items.Add(new ProductItem() { Name = "Product3", Amount = 33 });

            return items;
        }
    }
}
