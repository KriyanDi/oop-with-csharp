using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex2
{
    public abstract class Employee
    {
        #region Constructors
        protected Employee(string firstName, string lastName, string socialSecurityNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
        }
        #endregion

        #region Properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return string.Format("{0} {1}\nsocial security number: {2}", FirstName, LastName, SocialSecurityNumber);
        }

        public abstract decimal Earnings();
        #endregion
    }
}