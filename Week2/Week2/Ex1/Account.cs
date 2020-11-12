using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Account
    {
        #region Fields
        #region public

        #endregion

        #region private
        private decimal balance;

        #endregion
        #endregion

        #region Constructors
        public Account(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        #endregion

        #region Properties
        public decimal Balance
        {
            get { return balance; }
            set { balance = (0 <= value ? value : 0); }
        }

        #endregion

        #region Methods
        #region public
        public void Credit(decimal amount)
        {
            Balance = Balance + amount;
        }

        #endregion

        #region private

        #endregion
        #endregion
    }
}
