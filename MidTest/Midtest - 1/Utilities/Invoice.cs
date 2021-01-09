using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class Invoice
    {
        #region Fields
        public static long invNbr;
        protected readonly string INVOICE_ID;
        private (string description, decimal cost)[] invoiceItems;
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse
        /// </summary>
        /// <param name="invoiceItems"></param>
        public Invoice((string description, decimal cost)[] invoiceItems)
        {
            invNbr++;
            INVOICE_ID = $"T{invNbr:D6}";
            InvoiceItems = invoiceItems;
        }

        /// <summary>
        /// Default
        /// </summary>
        public Invoice() : this(new (string description, decimal cost)[0])
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// invoiceItems property
        /// </summary>
        public (string description, decimal cost)[] InvoiceItems
        {
            get
            {
                (string description, decimal cost)[] deepCopy = new (string description, decimal cost)[invoiceItems.Length];
                for (int i = 0; i < invoiceItems.Length; i++)
                {
                    deepCopy[i] = invoiceItems[i];
                }
                return deepCopy;
            }
            set
            {
                if (value != null)
                {
                    (string description, decimal cost)[] deepCopy = new (string description, decimal cost)[value.Length];
                    for (int i = 0; i < value.Length; i++)
                    {
                        deepCopy[i] = value[i];
                    }

                    invoiceItems = value;
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
        /// Returns sum of cost of invoiceItems
        /// </summary>
        /// <returns></returns>
        public decimal InvoiceTotal()
        {
            decimal costSum = InvoiceItems.Sum(item => item.cost);

            return costSum;
        }

        public override string ToString()
        {
            return $"Invoice total : {InvoiceTotal():C2}";
        } 
        #endregion
    }
}