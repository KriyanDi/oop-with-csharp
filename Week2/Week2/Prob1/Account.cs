using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob1
{
    public class Account
    {
        #region Fields
        #region public

        #endregion

        #region private
        private int anualInterestRate;
        private decimal balance;
        private Date dateCreated;
        private int id;

        #endregion
        #endregion

        #region Constructors
        public Account()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Properties
        public int AnualInterestRate
        {
            get { return anualInterestRate; }
            set { anualInterestRate = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public Date DateCreated
        {
            get { return dateCreated; }
            set { dateCreated = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        #endregion

        #region Methods
        #region public
        public void Deposit()
        {
            throw new System.NotImplementedException();
        }

        public void Withdraw()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region private

        #endregion
        #endregion
    }
}