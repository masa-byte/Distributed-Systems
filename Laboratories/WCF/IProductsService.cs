using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IProductCallback), SessionMode = SessionMode.Required)]
    public interface IProductsService
    {
        [OperationContract]
        void Register();

        [OperationContract]
        void AddNewProduct(Product p);

        [OperationContract]
        Dictionary<int, Product> GetAllProducts();

        [OperationContract]
        void ProduceProduct(int productId, double quantity);
    }

    public interface IProductCallback
    {
        [OperationContract]
        void Notify(Product product);
    }

    public class Product
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Quantity { get; set; }
    }
}
