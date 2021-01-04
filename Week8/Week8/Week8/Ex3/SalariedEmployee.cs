using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex3
{
    public class SalariedEmployee : Employee
    {
        private decimal weeklySalary;

        public SalariedEmployee(string first, string last, string ssn,
        decimal salary) : base(first, last, ssn)
        {
            WeeklySalary = salary;
        }

        public decimal WeeklySalary
        {
            get
            {
                return weeklySalary;
            }
            set
            {
                weeklySalary = value < 0 ? 0 : value;
            }
        }

        public override decimal GetPaymentAmount()
        {
            return WeeklySalary;
        }

        public override string ToString()
        {
            return string.Format("salaried employee: {0}\n{1}: {2:C}",
            base.ToString(), "weekly salary", WeeklySalary);
        }
    }
}