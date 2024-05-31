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
    public class AuctionService : IAuctionService
    {
        List<Client> clients = new List<Client>();
        Dictionary<int, Client> biddersForCurrentExponat = new Dictionary<int, Client>();
        Exponat currentExponat;

        public void BidOnCurrentExponat(int clientId, double amount)
        {
            if (currentExponat == null)
            {
                Console.WriteLine("No exponat available");
                return;
            }
            if (amount <= currentExponat.Price)
            {
                Console.WriteLine("Bid amount must be higher than current price");
                return;
            }
            currentExponat.Price = amount;
            currentExponat.HighestBidderId = clientId;

            if (!biddersForCurrentExponat.ContainsKey(clientId))
            {
                biddersForCurrentExponat.Add(clientId, clients.First(c => c.Id == clientId));
            }
        }

        public Exponat GetCurrentExponat()
        {
            if (currentExponat == null)
            {
                currentExponat = new Exponat()
                {
                    Id = 1,
                    Name = "Mona Lisa replica",
                    Price = 100,
                    HighestBidderId = -1
                };
            }
            return currentExponat;
        }

        public void GiveUpOnCurrentExponat(int clientId)
        {
            if (currentExponat == null)
            {
                Console.WriteLine("No exponat available");
                return;
            }
            if (currentExponat.HighestBidderId == clientId)
            {
                currentExponat.HighestBidderId = -1;
                currentExponat.Price = 100;
            }
            biddersForCurrentExponat.Remove(clientId);
        }

        public void Register(int id, string name, string surname)
        {
            var test = clients.FirstOrDefault(c => c.Id == id);
            if (test != null)
            {
                Console.WriteLine("Client with that id already exists");
                return;
            }

            clients.Add(new Client()
            {
                Id = id,
                Name = name,
                Surname = surname
            });
        }
    }
}
