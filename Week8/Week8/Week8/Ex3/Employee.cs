using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex3
{
    public abstract class Employee : IPayable
    {
        public string FirstName { get; private set; }
  
        public string LastName { get; private set; }
 
        public string SocialSecurityNumber { get; private set; }
    
        public Employee(string first, string last, string ssn)
        {
            FirstName = first;
            LastName = last;
            SocialSecurityNumber = ssn;
        }

        // return string representation of Employee object
        public override string ToString()
        {
            return string.Format("{0} {1}\nsocial security number: {2}",
            FirstName, LastName, SocialSecurityNumber);
        } 

        public abstract decimal GetPaymentAmount();
    }
}