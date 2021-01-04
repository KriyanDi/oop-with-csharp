using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex2
{
    public class SalariedEmployee : Employee
    {
        #region Fields
        private decimal weeklySalary;
        #endregion

        #region Constructors
        public SalariedEmployee(string firstName, string lastName, string socialSecurityNumber, decimal weeklySalary) : base(firstName, lastName, socialSecurityNumber)
        {
            this.weeklySalary = weeklySalary;
        }
        #endregion

        #region Properties
        public decimal WeeklySalary
        {
            get { return weeklySalary; }
            set { weeklySalary = (0 <= value) ? value : 0; }
        }
        #endregion

        #region Methods
        public override decimal Earnings()
        {
            return WeeklySalary;
        }

        public override string ToString()
        {
            return string.Format("salaried employee: {0}\n{1}: {2:C}", base.ToString(), "weekly salary", WeeklySalary);
        } 
        #endregion
    }
}