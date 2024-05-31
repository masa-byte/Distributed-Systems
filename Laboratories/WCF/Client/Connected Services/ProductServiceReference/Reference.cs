﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductServiceReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Product", Namespace="http://schemas.datacontract.org/2004/07/WCF")]
    public partial class Product : object
    {
        
        private int IdField;
        
        private string NameField;
        
        private double QuantityField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Quantity
        {
            get
            {
                return this.QuantityField;
            }
            set
            {
                this.QuantityField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ProductServiceReference.IProductsService", CallbackContract=typeof(ProductServiceReference.IProductsServiceCallback))]
    public interface IProductsService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductsService/Register", ReplyAction="http://tempuri.org/IProductsService/RegisterResponse")]
        void Register();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductsService/Register", ReplyAction="http://tempuri.org/IProductsService/RegisterResponse")]
        System.Threading.Tasks.Task RegisterAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductsService/AddNewProduct", ReplyAction="http://tempuri.org/IProductsService/AddNewProductResponse")]
        void AddNewProduct(ProductServiceReference.Product p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductsService/AddNewProduct", ReplyAction="http://tempuri.org/IProductsService/AddNewProductResponse")]
        System.Threading.Tasks.Task AddNewProductAsync(ProductServiceReference.Product p);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductsService/GetAllProducts", ReplyAction="http://tempuri.org/IProductsService/GetAllProductsResponse")]
        System.Collections.Generic.Dictionary<int, ProductServiceReference.Product> GetAllProducts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductsService/GetAllProducts", ReplyAction="http://tempuri.org/IProductsService/GetAllProductsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, ProductServiceReference.Product>> GetAllProductsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductsService/ProduceProduct", ReplyAction="http://tempuri.org/IProductsService/ProduceProductResponse")]
        void ProduceProduct(int productId, double quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductsService/ProduceProduct", ReplyAction="http://tempuri.org/IProductsService/ProduceProductResponse")]
        System.Threading.Tasks.Task ProduceProductAsync(int productId, double quantity);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IProductsServiceCallback
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProductsService/Notify", ReplyAction="http://tempuri.org/IProductsService/NotifyResponse")]
        void Notify(ProductServiceReference.Product product);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public interface IProductsServiceChannel : ProductServiceReference.IProductsService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.2.0-preview1.23462.5")]
    public partial class ProductsServiceClientBase : System.ServiceModel.DuplexClientBase<ProductServiceReference.IProductsService>, ProductServiceReference.IProductsService
    {
        
        public ProductsServiceClientBase(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress)
        {
        }
        
        public void Register()
        {
            base.Channel.Register();
        }
        
        public System.Threading.Tasks.Task RegisterAsync()
        {
            return base.Channel.RegisterAsync();
        }
        
        public void AddNewProduct(ProductServiceReference.Product p)
        {
            base.Channel.AddNewProduct(p);
        }
        
        public System.Threading.Tasks.Task AddNewProductAsync(ProductServiceReference.Product p)
        {
            return base.Channel.AddNewProductAsync(p);
        }
        
        public System.Collections.Generic.Dictionary<int, ProductServiceReference.Product> GetAllProducts()
        {
            return base.Channel.GetAllProducts();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.Dictionary<int, ProductServiceReference.Product>> GetAllProductsAsync()
        {
            return base.Channel.GetAllProductsAsync();
        }
        
        public void ProduceProduct(int productId, double quantity)
        {
            base.Channel.ProduceProduct(productId, quantity);
        }
        
        public System.Threading.Tasks.Task ProduceProductAsync(int productId, double quantity)
        {
            return base.Channel.ProduceProductAsync(productId, quantity);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
    }
    
    public class NotifyReceivedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {
        
        private object[] results;
        
        public NotifyReceivedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState)
        {
            this.results = results;
        }
        
        public ProductServiceReference.Product product
        {
            get
            {
                base.RaiseExceptionIfNecessary();
                return ((ProductServiceReference.Product)(this.results[0]));
            }
        }
    }
    
    public partial class ProductsServiceClient : ProductsServiceClientBase
    {
        
        public ProductsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                this(new ProductsServiceClientCallback(), binding, remoteAddress)
        {
        }
        
        private ProductsServiceClient(ProductsServiceClientCallback callbackImpl, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(new System.ServiceModel.InstanceContext(callbackImpl), binding, remoteAddress)
        {
            callbackImpl.Initialize(this);
        }
        
        public event System.EventHandler<NotifyReceivedEventArgs> NotifyReceived;
        
        private void OnNotifyReceived(object state)
        {
            if ((this.NotifyReceived != null))
            {
                object[] results = ((object[])(state));
                this.NotifyReceived(this, new NotifyReceivedEventArgs(results, null, false, null));
            }
        }
        
        private class ProductsServiceClientCallback : object, IProductsServiceCallback
        {
            
            private ProductsServiceClient proxy;
            
            public void Initialize(ProductsServiceClient proxy)
            {
                this.proxy = proxy;
            }
            
            public void Notify(ProductServiceReference.Product product)
            {
                this.proxy.OnNotifyReceived(new object[] {
                            product});
            }
        }
    }
}
