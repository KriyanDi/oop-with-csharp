using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob2
{
    public class TransCipher
    {
        #region Methods
        #region public
        static public string Code(string planeText, int cipherKey)
        {
            AddNeededSpacesToTheEndOfTheStringAccordingToCipherKey(ref planeText, cipherKey);

            char[,] matrix = SpreadStringIntoMatrixAccordingToCipherKey(planeText, cipherKey);

            string cipherText = (CombineMatrixColumnsIntoAString(matrix));

            return cipherText;
        }

        static public string Decode(string cipherText, int cipherKey)
        {
            char[,] matrix = ReverseSpreadStringIntoMatriceAccordingToCipherKey(cipherText, cipherKey);

            string planeText = CombineAllMatrixRowsIntoAString(matrix);

            return planeText;
        }
        #endregion

        #region private
        static private void AddNeededSpacesToTheEndOfTheStringAccordingToCipherKey(ref string planeText, int cipherKey)
        {
            int calculate = planeText.Length % cipherKey;
            int numberOfSpaces = calculate > 0 ? cipherKey - calculate : 0;
            for (int i = 0; i < numberOfSpaces; i++)
            {
                planeText += " ";
            }
        }

        static private char[,] SpreadStringIntoMatrixAccordingToCipherKey(string planeText, int cipherKey)
        {
            char[] planeTextArray = planeText.ToCharArray();

            int rowMatrix = planeTextArray.Length / cipherKey;
            int colMatrix = cipherKey;

            char[,] matrix = new char[rowMatrix, colMatrix];

            int planeTextArrayIndex = 0;
            for (int i = 0; i < rowMatrix; i++)
            {
                for (int j = 0; j < colMatrix; j++)
                {
                    matrix[i, j] = planeTextArray[planeTextArrayIndex];
                    planeTextArrayIndex++;
                }
            }

            return matrix;
        }

        static private string CombineMatrixColumnsIntoAString(char[,] matrix)
        {
            string cipherText = "";
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    cipherText = cipherText + $"{matrix[j, i]}";
                }
            }

            return cipherText;
        }

        static private char[,] ReverseSpreadStringIntoMatriceAccordingToCipherKey(string cipherText, int cipherKey)
        {
            char[] cipherTextArray = cipherText.ToCharArray();

            int rowMatrix = cipherTextArray.Length / cipherKey;
            int colMatrix = cipherKey;

            char[,] matrix = new char[rowMatrix, colMatrix];

            int cipherTextArrayIndex = 0;
            for (int i = 0; i < colMatrix; i++)
            {
                for (int j = 0; j < rowMatrix; j++)
                {
                    matrix[j, i] = cipherTextArray[cipherTextArrayIndex];
                    cipherTextArrayIndex++;
                }
            }

            return matrix;
        }

        static private string CombineAllMatrixRowsIntoAString(char[,] matrix)
        {
            string planeText = "";
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    planeText = planeText + matrix[i, j];
                }
            }

            return planeText;
        }
        #endregion 
        #endregion
    }
}
