using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex2
{
    public class CommissionEmployee : Employee
    {
        #region Fields
        private decimal wage;
        private decimal hours; 
        #endregion

        #region Constructors
        public CommissionEmployee(string firstName, string lastName, string socialSecurityNumber, decimal wage, decimal hours) : base(firstName, lastName, socialSecurityNumber)
        {
            Wage = wage;
            Hours = hours;
        }
        #endregion

        #region Properties
        public decimal Wage
        {
            get { return wage; }
            set { wage = value; }
        }

        public decimal Hours
        {
            get { return hours; }
            set { hours = value; }
        }
        #endregion

        #region Methods
        public override decimal Earnings()
        {
            if (Hours <= 40)
            {
                return Wage * Hours;
            }
            else
            {
                return (40 * Wage) + ((Hours - 40) * Wage * 1.5M);
            }
        }

        public override string ToString()
        {
            return string.Format("hourly employee: {0}\n{1}: {2:C}; {3}: {4:F2}",
                base.ToString(), "hourly wage", Wage, "hours worked", Hours);
        } 
        #endregion
    }
}