using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientRang
{
    public class Trader
    {
        #region Fields
        private List<Client> clients;
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse constructor
        /// </summary>
        /// <param name="clients"></param>
        public Trader(List<Client> clients)
        {
            Clients = clients;
        } 
        #endregion

        #region Properties
        /// <summary>
        /// Clients property
        /// </summary>
        public List<Client> Clients
        {
            get
            {
                return new List<Client>(clients);
            }
            set
            {
                if (value != null)
                {
                    clients = new List<Client>(value);
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        /// <summary>
        /// Indexer by client ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Client this[string ID]
        {
            get 
            {
                var wantedClient = clients.Where(client => client.ID == ID);

                if(wantedClient.Any())
                {
                     return wantedClient.First();
                }
                else
                {
                    return null;
                }
            }
            set 
            {
                // check if the value is not null
                if(value != null)
                {
                    //find if there is such client
                    var wantedClient = clients.Where(client => client.ID == ID);

                    //check if we found such client
                    if(wantedClient.Any())
                    {
                        //search for that client id in "clients"
                        int i = 0;
                        while(i < clients.Count)
                        {
                            if(clients[i].ID == ID)
                            {
                                //we change the client data
                                clients[i] = value;
                                break;
                            }
                            i++;
                        }
                    }
                    else
                    {
                        //we add that client if he does not exist
                        clients.Add(value);
                    }
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Generates random purchases for every client
        /// </summary>
        public void SellProducts()
        {
            Random random = new Random();

            for (int i = 0; i < clients.Count; i++)
            {
                //number of sells
                int sells = random.Next(10, 31);

                //generating list with purchases for the given number of sells
                List<decimal> purchases = new List<decimal>();
                for (int j = 0; j < sells; j++)
                {
                    purchases.Add((decimal)random.Next(100, 10001) / 100);
                }

                //update the client purchases list
                clients[i].Purchases = purchases;
            }
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "Trader [\n";

            foreach (var client in clients)
            {
                result = result + client.ToString() + "\n";
            }

            result = result + "]";

            return result;
        } 
        #endregion
    }
}