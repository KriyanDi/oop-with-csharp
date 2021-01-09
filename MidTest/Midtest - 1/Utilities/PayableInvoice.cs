using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class PayableInvoice : Invoice
    {
        #region Fiedls
        private string P_ID;
        #endregion

        #region Constructors
        /// <summary>
        /// General purspouse
        /// </summary>
        public PayableInvoice((string description, decimal cost)[] invoiceItems, PaymentType paymentType)
            :base(invoiceItems)
        {
            P_ID = $"P{INVOICE_ID}";
            Payment = paymentType;
        }

        /// <summary>
        /// Default
        /// </summary>
        public PayableInvoice() : this(new (string description, decimal cost)[0], PaymentType.CASH)
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Payment property
        /// </summary>
        public PaymentType Payment { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{P_ID} {Payment}";
        } 
        #endregion
    }
}