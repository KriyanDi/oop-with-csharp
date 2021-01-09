using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientRang
{
    public class Client : IUpgradable
    {
        #region Fields
        private static int count;
        public readonly string ID;
        private List<decimal> purchases;
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse constructor
        /// </summary>
        /// <param name="purchases"></param>
        public Client(List<decimal> purchases)
        {
            count++;
            ID = $"U{count:D6}";
            Purchases = purchases;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Client() : this(new List<decimal>())
        {
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="client"></param>
        public Client(Client client) : this(client.purchases)
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Purchases property
        /// </summary>
        public List<decimal> Purchases
        {
            get
            {
                List<decimal> copy = new List<decimal>();
                for (int i = 0; i < purchases.Count; i++)
                {
                    copy.Add(purchases[i]);
                }

                return copy;
            }
            set
            {
                if (value != null)
                {
                    List<decimal> copy = new List<decimal>();
                    for (int i = 0; i < value.Count; i++)
                    {
                        copy.Add(value[i]);
                    }

                    purchases = copy;
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
        /// Calculate the average of purchases
        /// </summary>
        /// <returns></returns>
        public decimal AvergePurchases()
        {
            if (purchases.Count != 0)
            {
                decimal result = (purchases.Sum(purchase => purchase)) / purchases.Count;

                return result;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   ID == client.ID;
        }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Enterprise: {ID} AvergePurchases: {AvergePurchases():C2}";
        }

        /// <summary>
        /// IUpgradable Method Upgrade
        /// </summary>
        /// <param name="action"></param>
        void IUpgradable.Upgrade(Action<IUpgradable> action)
        {
            action?.Invoke(this);
        }
        #endregion
    }
}