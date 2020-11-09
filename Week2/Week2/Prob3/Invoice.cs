using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob3
{
    public class Invoice
    {
        #region Fields
        #region public

        #endregion

        #region private
        private string partNumber;
        private string partDescription;
        private int quantity;
        private decimal pricePerItem;

        #endregion

        #endregion

        #region Constructors
        public Invoice(string partNumber, string partDescription, decimal pricePerItem, int quantity)
        {
            PartNumber = partNumber;
            PartDescription = partDescription;
            PricePerItem = pricePerItem;
            Quantity = quantity;
        }

        #endregion

        #region Properties
        public string PartNumber
        {
            get { return partNumber; }
            set { partNumber = value; }
        }

        public string PartDescription
        {
            get { return partDescription; }
            set { partDescription = value; }
        }

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public decimal PricePerItem
        {
            get { return pricePerItem; }
            set { pricePerItem = value; }
        }

        #endregion

        #region Methods
        #region public

        #endregion

        #region private

        #endregion

        #endregion

        public decimal GetInvoiceAmount()
        {
            decimal result = quantity * pricePerItem;

            return result;
        }
    }
}