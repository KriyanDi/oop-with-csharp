using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob1
{
    public class CaesarCipher
    {
        #region Constant Fields
        const int SHIFT_LENGTH = 3;
        const int LETTER_IN_ENGLISH_ALPHABET = 26;
        const int ASCII_CODE_OF_UPPER_CASE_LETTER_A = 65;
        #endregion

        #region Fields
        private SortedList letters;
        #endregion

        #region Constructors
        public CaesarCipher()
        {
            InitLetters(ref letters);
        }
        #endregion

        #region Methods
        #region public
        public string CodeCaesarCipher(string plainText)
        {
            char[] plainTextArray = plainText.ToCharArray();

            //code plainText -> cipherText
            int newLetterId;
            for (int i = 0; i < plainTextArray.Length; i++)
            {
                newLetterId = (((int)plainTextArray[i] - ASCII_CODE_OF_UPPER_CASE_LETTER_A) + SHIFT_LENGTH) % 26;
                plainTextArray[i] = (char)letters[newLetterId];
            }

            string cipherText = new string(plainTextArray);
            return cipherText;
        }

        public string DecodeCaesarCipher(string cipherText)
        {
            char[] cipherTextArray = cipherText.ToCharArray();

            //decode cipherText -> plainText
            int newLetterId;
            for (int i = 0; i < cipherTextArray.Length; i++)
            {
                newLetterId = (((int)cipherTextArray[i] - ASCII_CODE_OF_UPPER_CASE_LETTER_A) - SHIFT_LENGTH);

                newLetterId = (newLetterId < 0) ? newLetterId = newLetterId + 26 : newLetterId;

                cipherTextArray[i] = (char)letters[newLetterId];
            }

            string plainText = new string(cipherTextArray);
            return plainText;
        }
        #endregion

        #region private
        private void InitLetters(ref SortedList letters)
        {
            letters = new SortedList();
            for (int i = 0; i < LETTER_IN_ENGLISH_ALPHABET; i++)
            {
                letters[i] = (char)(ASCII_CODE_OF_UPPER_CASE_LETTER_A + i);
            }
        }
        #endregion
        #endregion
    }
}
