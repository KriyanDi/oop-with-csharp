using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex2
{
    public class BasePlusCommissionEmployee : HourlyEmployee
    {
        #region Fields
        private decimal baseSalary;
        #endregion

        #region Constructors
        public BasePlusCommissionEmployee(string firstName, string lastName, string socialSecurityNumber, decimal sales, decimal rate, decimal salary) : base(firstName, lastName, socialSecurityNumber, sales, rate)
        {
            BaseSalary = salary;
        }
        #endregion

        #region Properties
        public decimal BaseSalary
        {
            get { return baseSalary; }
            set { baseSalary = value; }
        }
        #endregion

        #region Methods
        public override decimal Earnings()
        {
            return BaseSalary + base.Earnings();
        }

        public override string ToString()
        {
            return string.Format("base-salaried {0}; base salary: {1:C}",
            base.ToString(), BaseSalary);
        }
        #endregion
    }
}