using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob3
{
    class BarcodeMaker
    {
        #region Fields
        private SortedList digitsRepresentation;
        #endregion

        #region Constructors
        public BarcodeMaker()
        {
            InitDigits(ref digitsRepresentation);
        }
        #endregion

        #region Methods
        #region public
        public string BarcodeFromZipCode(string ZipCode)
        {
            if (ZipCode.Length == 3)
            {
                string Barcode = "";

                foreach (var item in ZipCode)
                {
                    Barcode = Barcode + DecodeDigitForBarcode(item);
                }

                return Barcode;
            }
            else
            {
                Console.WriteLine("Error! ZIPcodes has 3 digits!");
                return null;
            }
        }
        #endregion

        #region private
        private string DecodeDigitForBarcode(char digit)
        {
            string decode = DigitBarcodeRepresentation((int)digitsRepresentation[digit]);

            return decode;
        }

        private string DigitBarcodeRepresentation(int digit)
        {
            string represenation = "";
            int bitMask = 1;
            for (int i = 0; i < 5; i++)
            {
                represenation = ((digit & bitMask) == 0 ? ":" : "|") + represenation;
                bitMask = bitMask << 1;
            }

            return represenation;
        }

        private void InitDigits(ref SortedList digitsRepresentation)
        {
            digitsRepresentation = new SortedList();
            digitsRepresentation.Add('1', 3);
            digitsRepresentation.Add('2', 5);
            digitsRepresentation.Add('3', 6);
            digitsRepresentation.Add('4', 9);
            digitsRepresentation.Add('5', 10);
            digitsRepresentation.Add('6', 12);
            digitsRepresentation.Add('7', 17);
            digitsRepresentation.Add('8', 18);
            digitsRepresentation.Add('9', 20);
            digitsRepresentation.Add('0', 24);
        }
        #endregion 
        #endregion
    }
}
