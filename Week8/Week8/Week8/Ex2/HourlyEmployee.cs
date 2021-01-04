using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex2
{
    public class HourlyEmployee : Employee
    {
        #region Fields
        private decimal grossSales;
        private decimal commissionRate;
        #endregion

        #region Constructors
        public HourlyEmployee(string firstName, string lastName, string socialSecurityNumber, decimal grossSales, decimal commisssionRate) : base(firstName, lastName, socialSecurityNumber)
        {
            GrossSales = grossSales;
            CommissionRate = commissionRate;
        } 
        #endregion

        #region Properties
        public decimal GrossSales
        {
            get { return grossSales; }
            set { grossSales = value; }
        }

        public decimal CommissionRate
        {
            get { return commissionRate; }
            set { commissionRate = value; }
        }
        #endregion

        #region Methods
        public override decimal Earnings()
        {
            return CommissionRate * GrossSales;
        }
        public override string ToString()
        {
            return string.Format("{0}: {1}\n{2}: {3:C}\n{4}: {5:F2}",
            "commission employee", base.ToString(),
            "gross sales", GrossSales, "commission rate", CommissionRate);
        }  
        #endregion
    }
}