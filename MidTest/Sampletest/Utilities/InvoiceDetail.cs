using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class InvoiceDetail
    {
        #region Fields
        private decimal dblLineTotal;
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse
        /// </summary>
        /// <param name="dblLineTotal"></param>
        public InvoiceDetail(decimal dblLineTotal)
        {
            DblLineTotal = dblLineTotal;
        }
        #endregion

        #region Properties
        /// <summary>
        /// dblLineTotal property
        /// </summary>
        public decimal DblLineTotal
        {
            get { return dblLineTotal; }
            set { dblLineTotal = value >= 0 ? value : throw new ArgumentException("Invalid value for dblLineTotal"); }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{DblLineTotal:F2}";
        }
        #endregion
    }
}