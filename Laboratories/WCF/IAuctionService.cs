using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAuctionService
    {
        [OperationContract]
        void Register(int id, string name, string surname);

        [OperationContract]
        Exponat GetCurrentExponat();

        [OperationContract]
        void GiveUpOnCurrentExponat(int clientId);

        [OperationContract]
        void BidOnCurrentExponat(int clientId, double amount);
    }

    [DataContract]
    public class Exponat
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public int HighestBidderId { get; set; }
    }
}
