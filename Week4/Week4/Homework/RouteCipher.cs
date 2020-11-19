using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class RouteCipher
    {
        #region Fields
        private int key;
        #endregion

        #region Constructors
        public RouteCipher(int key)
        {
            Key = key;
        }
        #endregion

        #region Properties
        public int Key
        {
            get { return key; }
            set { key = ((value < 0 || 0 < value) ? value : 1 /*default value*/); }
        }
        #endregion

        #region Methods
        #region public
        public string Encrypt(string plainText)
        {
            if (key == 1)
            {
                return plainText;
            }
            else if (key == -1)
            {
                char[] temp = plainText.ToCharArray();
                Array.Reverse(temp);
                string cipherText = new string(temp);
                return cipherText;
            }
            else
            {
                string cipherText = EncryptPlainText(plainText);

                return cipherText;
            }

        }

        public string Decrypt(string cipherText)
        {
            if (key == 1)
            {
                return cipherText;
            }
            else if (key == -1)
            {
                char[] temp = cipherText.ToCharArray();
                Array.Reverse(temp);
                string plainText = new string(temp);
                return plainText;
            }
            else
            {
                string plainText = DecryptCipherText(cipherText);

                return plainText;
            }

        }

        public override string ToString()
        => $"Key: {key}";
        #endregion

        #region private
        #region Encryption
        private string EncryptPlainText(string plainText)
        {
            string cipherText = "";

            char[,] cipherMatrix = CipherMatrix(plainText);

            if (key > 0)
            {
                cipherText = EncryptTopLeftCounterClockwiseSpiralingInwardsCipherMatrix(cipherMatrix);
            }
            else
            {
                cipherText = EncryptBottomRightCounterClockwiseSpiralingInwardsCipherMatrix(cipherMatrix);
            }

            return cipherText;
        }

        private char[,] CipherMatrix(string plainText)
        {
            RemoveSpacesAndCommasFromString(ref plainText);

            AddNeededXsToTheEndOfTheStringToFormNiceRectangleFromIt(ref plainText);

            char[,] cipherMatrix = GetCipherMatrix(plainText);

            return cipherMatrix;
        }

        private void RemoveSpacesAndCommasFromString(ref string planeText)
        {
            string newString = "";

            for (int i = 0; i < planeText.Length; i++)
            {
                if (planeText[i] != ' ' && planeText[i] != ',' && planeText[i] != '.')
                {
                    newString = newString + planeText[i];
                }
            }

            planeText = newString;
        }

        private void AddNeededXsToTheEndOfTheStringToFormNiceRectangleFromIt(ref string plainText)
        {
            char[] plainTextCharArray = plainText.ToCharArray();

            int tempCalc = plainTextCharArray.Length % Math.Abs(key);
            int numberOfXs = (tempCalc > 0 ? Math.Abs(key) - tempCalc : 0);
            for (int i = 0; i < numberOfXs; i++)
            {
                plainText = plainText + "X";
            }
        }

        private char[,] GetCipherMatrix(string plainText)
        {
            char[] plainTextCharArray = plainText.ToCharArray();

            int rowsCipherMatrix = plainTextCharArray.Length / Math.Abs(key);
            int colsCipherMatrix = Math.Abs(key);

            char[,] cipherMatrix = new char[rowsCipherMatrix, colsCipherMatrix];

            int index = 0;
            for (int i = 0; i < rowsCipherMatrix; i++)
            {
                for (int j = 0; j < colsCipherMatrix; j++)
                {
                    cipherMatrix[i, j] = plainTextCharArray[index];
                    index++;
                }
            }

            return cipherMatrix;
        }

        private string EncryptTopLeftCounterClockwiseSpiralingInwardsCipherMatrix(char[,] cipherMatrix)
        {
            string cipherText = "";

            int rowStart = 0;
            int rowEnd = cipherMatrix.GetLength(0) - 1;
            int colStart = 0;
            int colEnd = cipherMatrix.GetLength(1) - 1;

            while (colStart <= colEnd && rowStart <= rowEnd)
            {
                //top left -> bottom left
                for (int i = rowStart; i < rowEnd; i++)
                {
                    cipherText = cipherText + cipherMatrix[i, colStart];
                }

                //bottom left -> bottom right
                for (int i = colStart; i < colEnd; i++)
                {
                    cipherText = cipherText + cipherMatrix[rowEnd, i];
                }

                //bottom right ->  top right
                for (int i = rowEnd; i > rowStart; i--)
                {
                    cipherText = cipherText + cipherMatrix[i, colEnd];
                }

                //top right -> top left
                for (int i = colEnd; i > colStart; i--)
                {
                    cipherText = cipherText + cipherMatrix[rowStart, i];
                }

                rowStart++;
                rowEnd--;
                colStart++;
                colEnd--;
            }

            return cipherText;
        }

        private string EncryptBottomRightCounterClockwiseSpiralingInwardsCipherMatrix(char[,] cipherMatrix)
        {
            string cipherText = "";

            int rowStart = 0;
            int rowEnd = cipherMatrix.GetLength(0) - 1;
            int colStart = 0;
            int colEnd = cipherMatrix.GetLength(1) - 1;

            while (colStart <= colEnd && rowStart <= rowEnd)
            {
                //bottom right ->  top right
                for (int i = rowEnd; i > rowStart; i--)
                {
                    cipherText = cipherText + cipherMatrix[i, colEnd];
                }

                //top right -> top left
                for (int i = colEnd; i > colStart; i--)
                {
                    cipherText = cipherText + cipherMatrix[rowStart, i];
                }

                //top left -> bottom left
                for (int i = rowStart; i < rowEnd; i++)
                {
                    cipherText = cipherText + cipherMatrix[i, colStart];
                }

                //bottom left -> bottom right
                for (int i = colStart; i < colEnd; i++)
                {
                    cipherText = cipherText + cipherMatrix[rowEnd, i];
                }

                rowStart++;
                rowEnd--;
                colStart++;
                colEnd--;
            }

            return cipherText;
        }
        #endregion

        #region Decryption
        private string DecryptCipherText(string cipherText)
        {
            string planeText = "";

            if (key > 0)
            {
                planeText = DecryptTopLeftCounterClockwiseSpiralingInwardsEncryptedString(cipherText);
            }
            else
            {
                planeText = DecryptBottomRightCounterClockwiseSpiralingInwardsEncryptedString(cipherText);
            }

            return planeText;
        }

        private string DecryptTopLeftCounterClockwiseSpiralingInwardsEncryptedString(string cipherText)
        {
            char[,] decryptedCipherMatrix = GetDecryptedCipherMatrixForTopLeftCounterClockwiseSpiralingInwardsEncryptedString(cipherText);

            string planeText = CombineAllDecryptedCipherMatrixRowsIntoString(decryptedCipherMatrix);
            return planeText;
        }

        private char[,] GetDecryptedCipherMatrixForTopLeftCounterClockwiseSpiralingInwardsEncryptedString(string cipherText)
        {
            int rowCipherMatrix = cipherText.Length / Math.Abs(key);
            int colCipherMatrix = Math.Abs(key);
            char[,] cipherMatrix = new char[rowCipherMatrix, colCipherMatrix];

            int cipherTextIndex = 0;

            int rowStart = 0;
            int rowEnd = cipherMatrix.GetLength(0) - 1;
            int colStart = 0;
            int colEnd = cipherMatrix.GetLength(1) - 1;

            while (colStart <= colEnd && rowStart <= rowEnd)
            {
                //top left -> bottom left
                for (int i = rowStart; i < rowEnd; i++)
                {
                    cipherMatrix[i, colStart] = cipherText[cipherTextIndex];
                    cipherTextIndex++;
                }

                //bottom left -> bottom right
                for (int i = colStart; i < colEnd; i++)
                {
                    cipherMatrix[rowEnd, i] = cipherText[cipherTextIndex];
                    cipherTextIndex++;
                }

                //bottom right ->  top right
                for (int i = rowEnd; i > rowStart; i--)
                {
                    cipherMatrix[i, colEnd] = cipherText[cipherTextIndex];
                    cipherTextIndex++;
                }

                //top right -> top left
                for (int i = colEnd; i > colStart; i--)
                {
                    cipherMatrix[rowStart, i] = cipherText[cipherTextIndex];
                    cipherTextIndex++;
                }

                rowStart++;
                rowEnd--;
                colStart++;
                colEnd--;
            }

            return cipherMatrix;
        }

        private string DecryptBottomRightCounterClockwiseSpiralingInwardsEncryptedString(string cipherText)
        {
            char[,] decryptedCipherMatrix = GetDecryptedCipherMatrixForBottomRightCounterClockwiseSpiralingInwardsEncryptedString(cipherText);

            string planeText = CombineAllDecryptedCipherMatrixRowsIntoString(decryptedCipherMatrix);
            return planeText;
        }

        private char[,] GetDecryptedCipherMatrixForBottomRightCounterClockwiseSpiralingInwardsEncryptedString(string cipherText)
        {
            int rowCipherMatrix = cipherText.Length / Math.Abs(key);
            int colCipherMatrix = Math.Abs(key);
            char[,] cipherMatrix = new char[rowCipherMatrix, colCipherMatrix];

            int cipherTextIndex = 0;

            int rowStart = 0;
            int rowEnd = cipherMatrix.GetLength(0) - 1;
            int colStart = 0;
            int colEnd = cipherMatrix.GetLength(1) - 1;

            while (colStart <= colEnd && rowStart <= rowEnd)
            {
                //bottom right ->  top right
                for (int i = rowEnd; i > rowStart; i--)
                {
                    cipherMatrix[i, colEnd] = cipherText[cipherTextIndex];
                    cipherTextIndex++;
                }

                //top right -> top left
                for (int i = colEnd; i > colStart; i--)
                {
                    cipherMatrix[rowStart, i] = cipherText[cipherTextIndex];
                    cipherTextIndex++;
                }

                //top left -> bottom left
                for (int i = rowStart; i < rowEnd; i++)
                {
                    cipherMatrix[i, colStart] = cipherText[cipherTextIndex];
                    cipherTextIndex++;
                }

                //bottom left -> bottom right
                for (int i = colStart; i < colEnd; i++)
                {
                    cipherMatrix[rowEnd, i] = cipherText[cipherTextIndex];
                    cipherTextIndex++;
                }

                rowStart++;
                rowEnd--;
                colStart++;
                colEnd--;
            }

            return cipherMatrix;
        }

        private string CombineAllDecryptedCipherMatrixRowsIntoString(char[,] cipherMatrix)
        {
            string planeText = "";

            for (int i = 0; i < cipherMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < cipherMatrix.GetLength(1); j++)
                {
                    planeText = planeText + cipherMatrix[i, j];
                }
            }

            return planeText;
        }
        #endregion
        #endregion
        #endregion
    }
}
