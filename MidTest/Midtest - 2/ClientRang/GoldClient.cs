using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientRang
{
    public class GoldClient : Client
    {
        #region Fields
        private decimal credit;
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse constructor
        /// </summary>
        /// <param name="purchases"></param>
        /// <param name="credit"></param>
        public GoldClient(List<decimal> purchases, decimal credit)
            : base(purchases)
        {
            Credit = credit;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public GoldClient() : this(new List<decimal>(), 0.0M)
        {
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="goldClient"></param>
        public GoldClient(GoldClient goldClient) : this(goldClient.Purchases, goldClient.Credit)
        {
        } 
        #endregion

        #region Properties
        /// <summary>
        /// Credit property
        /// </summary>
        public decimal Credit
        {
            get { return credit; }
            set { credit = (0 <= value) ? value : throw new ArgumentException("Credit should be above 0.00"); }
        }
        #endregion

        #region Methods
        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"VIP Enterprise: {ID} AvergePurchases: {AvergePurchases():C2} Credit: {credit:C2}";
        } 
        #endregion
    }
}