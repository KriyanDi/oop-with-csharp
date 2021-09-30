using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CardCipherTesting
{
    class CreditCard
    {
        #region Fields
        private string cardNumber;
        private (string first, string last) cardHolderName;
        private string expirationDate;
        private string cvcCode;

        private int cipheringTheCardCounter;
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse constructor
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="cardHolderName"></param>
        /// <param name="expirationDate"></param>
        /// <param name="cvcCode"></param>
        public CreditCard(string cardNumber, (string, string) cardHolderName, string expirationDate, string cvcCode)
        {
            CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            ExpirationDate = expirationDate;
            CvcCode = cvcCode;
            CipheringTheCardCounter = 0;
        }

        /// <summary>
        /// Card Number Only Constructor
        /// </summary>
        /// <param name="cardNumber"></param>
        public CreditCard(string cardNumber) : this(cardNumber, ("#NAME", "#NAME"), "00/00", "000")
        {

        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreditCard() : this("0000000000000000", ("#NAME", "#NAME"), "00/00", "000")
        {

        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="creditCard"></param>
        public CreditCard(CreditCard creditCard) : this(creditCard.CardNumber, creditCard.CardHolderName, creditCard.ExpirationDate, creditCard.CvcCode)
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Card Number Property
        /// </summary>
        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = (IsCardNumberValid(value)) ? value : throw new InvalidDataException("Invalid Card Number!"); }
        }

        /// <summary>
        /// Card Holder Property
        /// </summary>
        public (string first, string last) CardHolderName
        {
            get { return cardHolderName; }
            set { cardHolderName = value; }
        }

        /// <summary>
        /// Expiration Date Property
        /// </summary>
        public string ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }

        /// <summary>
        /// Cvc Code Property
        /// </summary>
        public string CvcCode
        {
            get { return cvcCode; }
            set { cvcCode = value; }
        }

        /// <summary>
        /// Ciphering The Card Counter
        /// </summary>
        public int CipheringTheCardCounter
        {
            get { return cipheringTheCardCounter; }
            set { cipheringTheCardCounter = value; }
        }
        #endregion

        #region Methods
        public static bool IsCardNumberValid(string cardNumber)
        {
            if (cardNumber.Length == 16 &&
                LuhnCheck(cardNumber) &&
                (cardNumber[0] == '3' ||
                cardNumber[0] == '4' ||
                cardNumber[0] == '5' ||
                cardNumber[0] == '6'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string EncryptCardNumber(string cardNumber, int shift)
        {
            char[] encrypted = new char[cardNumber.Length];

            for (int i = 0; i < cardNumber.Length; i++)
            {
                int number = ((cardNumber[i] - '0') + shift);
                number = (number >= 10) ? number / 10 : number;
                encrypted[i] = Convert.ToChar(number + 48);
            }

            string result = new string(encrypted);

            return result;
        }

        public static string DecryptCardNumber(string cardNumber, int shift)
        {
            char[] derypted = new char[cardNumber.Length];

            for (int i = 0; i < cardNumber.Length; i++)
            {
                int number = cardNumber[i] - '0';
                number = (number < shift) ? number + 10 - shift : number - shift;
                derypted[i] = Convert.ToChar(number + 48);
            }

            string result = new string(derypted);

            return result;
        }

        #region Utility Methods
        private static bool LuhnCheck(string cardNumber)
        {
            if (cardNumberLuhnSum(cardNumber) % 10 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static int cardNumberLuhnSum(string cardNumber)
        {
            int sum = 0;
            for (int i = 0; i < cardNumber.Length; i++)
            {
                sum += (i % 2 == 0) ?
                    (((cardNumber[i] - '0') * 2 >= 10) ?
                        ((cardNumber[i] - '0') * 2 / 10 + (cardNumber[i] - '0') * 2 % 10)
                        : (cardNumber[i] - '0') * 2)
                    : cardNumber[i] - '0';
            }

            return sum;
        }  
        #endregion
        #endregion
    }
}
