using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ProductsService : IProductsService
    {
        Dictionary<int, IProductCallback> users = new Dictionary<int, IProductCallback>();
        Dictionary<int, Product> products = new Dictionary<int, Product>();

        int productId = 0;
        int userId = 0;

        public void AddNewProduct(Product p)
        {
            p.Id = productId;
            p.Quantity = 0;
            products.Add(productId, p);
            productId++;

            foreach (var user in users)
            {
                user.Value.Notify(p);
            }
        }

        public Dictionary<int, Product> GetAllProducts()
        {
            return products;
        }

        public void ProduceProduct(int productId, double quantity)
        {
            products[productId].Quantity += quantity;
        }

        public void Register()
        {
            users.Add(userId, OperationContext.Current.GetCallbackChannel<IProductCallback>());
            userId++;
        }
    }
}
