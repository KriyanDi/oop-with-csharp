using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex3
{
    public class Invoice : IPayable
    {
        private int quantity;
        private decimal pricePerItem;

        public string PartNumber { get; set; }

        public string PartDescription { get; set; }

        public Invoice(string part, string description, int count, decimal price)
        {
            PartNumber = part;
            PartDescription = description;
            Quantity = count;
            PricePerItem = price;
        }

        public int Quantity
        {
            get
            {
                return quantity;
            } 
            set
            {
                quantity = (value < 0) ? 0 : value;
            } 
        } 
        public decimal PricePerItem
        {
            get
            {
                return pricePerItem;
            } // end get
            set
            {
                pricePerItem = (value < 0) ? 0 : value; 
            }
        } 
        public override string ToString()
        {
            return string.Format(
            "{0}: \n{1}: {2} ({3}) \n{4}: {5} \n{6}: {7:C}",
            "invoice", "part number", PartNumber, PartDescription,
            "quantity", Quantity, "price per item", PricePerItem);
        }

        public decimal GetPaymentAmount()
        {
            return Quantity * PricePerItem;
        }
    }


}