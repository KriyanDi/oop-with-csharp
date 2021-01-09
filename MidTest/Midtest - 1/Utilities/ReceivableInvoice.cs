using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Utilities
{
    public class ReceivableInvoice : Invoice, INotifyPropertyChanged
    {
        #region Fields
        public string R_ID;
        public double discount;
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse
        /// </summary>
        /// <param name="discount"></param>
        public ReceivableInvoice((string description, decimal cost)[] invoiceItems, double discount)
            :base(invoiceItems)
        {
            R_ID = $"R{INVOICE_ID}";
            Discount = discount;
        }

        /// <summary>
        /// Default
        /// </summary>
        public ReceivableInvoice() : this(new (string description, decimal cost)[0], 0.0)
        {
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged; 
        #endregion

        #region Properties
        /// <summary>
        /// discount property
        /// </summary>
        public double Discount
        {
            get 
            { 
                return discount; 
            }
            set 
            { 
                discount = (0.0 <= value && value < 1.0) ? value : throw new ArgumentOutOfRangeException("Should be number between [0.0, 1.0)");

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Discount"));
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{R_ID} {discount}";
        }
        #endregion
    }
}