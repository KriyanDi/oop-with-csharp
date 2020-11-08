using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob3
{
    class Program
    {
        static private int EncryptNumber(int number)
        {
            string numberForEncryption = number.ToString();

            int result = 0;
            int number1;
            int number2;
            int number3;
            int number4;

            if (Int32.TryParse(numberForEncryption[0].ToString(), out number1) &&
                Int32.TryParse(numberForEncryption[1].ToString(), out number2) &&
                Int32.TryParse(numberForEncryption[2].ToString(), out number3) &&
                Int32.TryParse(numberForEncryption[3].ToString(), out number4))
            {
                number1 = (number1 + 7) % 10;
                number2 = (number2 + 7) % 10;
                number3 = (number3 + 7) % 10;
                number4 = (number4 + 7) % 10;

                result = 1000 * number3 + 100 * number4 + 10 * number1 + number2;

                return result;
            }
            else
            {
                return -1;
            }
        }
        static private int DecryptSingleNumber(int number)
        {
            switch (number)
            {
                case 7:
                    return 0;
                case 8:
                    return 1;
                case 9:
                    return 2;
                case 0:
                    return 3;
                case 1:
                    return 4;
                case 2:
                    return 5;
                case 3:
                    return 6;
                case 4:
                    return 7;
                case 5:
                    return 8;
                case 6:
                    return 9;
                default:
                    return -1;
                    break;
            }
        }

        static private int DecryptNumber(int number)
        {
            int result = 0;
            int number1;
            int number2;
            int number3;
            int number4;

            if (0 <= number && number <= 9) // before encryption: 3_33 -> after encryption 000_
            {
                number4 = DecryptSingleNumber(number);

                result = 1000 * 3 + 100 * number4 + 10 * 3 + 3;

                return result;
            }

            string numberForDecryption = number.ToString();

            if (10 <= number && number <= 99) // before encryption: __33 -> after encryption 00__
            {
                if (Int32.TryParse(numberForDecryption[0].ToString(), out number3) &&
                     Int32.TryParse(numberForDecryption[1].ToString(), out number4))
                {
                    number3 = DecryptSingleNumber(number3);
                    number4 = DecryptSingleNumber(number4);

                    result = 1000 * number3 + 100 * number4 + 10 * 3 + 3;

                    return result;
                }
                else
                {
                    return -1;
                }
            }

            if (100 <= number && number <= 999) // before encryption: __3_ -> after encryption 0___
            {
                if (Int32.TryParse(numberForDecryption[0].ToString(), out number2) &&
                     Int32.TryParse(numberForDecryption[1].ToString(), out number3) &&
                     Int32.TryParse(numberForDecryption[2].ToString(), out number4))
                {
                    number2 = DecryptSingleNumber(number2);
                    number3 = DecryptSingleNumber(number3);
                    number4 = DecryptSingleNumber(number4);

                    result = 1000 * number3 + 100 * number4 + 10 * 3 + number2;

                    return result;
                }
                else
                {
                    return -1;
                }
            }

            if (1000 <= number && number <= 9999) // before encryption: ____ -> after encryption ____
            {
                if (Int32.TryParse(numberForDecryption[0].ToString(), out number1) &&
                     Int32.TryParse(numberForDecryption[1].ToString(), out number2) &&
                     Int32.TryParse(numberForDecryption[2].ToString(), out number3) &&
                     Int32.TryParse(numberForDecryption[3].ToString(), out number4))
                {
                    number1 = DecryptSingleNumber(number1);
                    number2 = DecryptSingleNumber(number2);
                    number3 = DecryptSingleNumber(number3);
                    number4 = DecryptSingleNumber(number4);

                    result = 1000 * number3 + 100 * number4 + 10 * number1 + number2;

                    return result;
                }
                else
                {
                    return -1;
                }
            }

            return -1;
        }


        static void Main(string[] args)
        {
            Console.Write("Enter your number:");
            int number = Convert.ToInt32(Console.ReadLine());

            if (1000 <= number && number <= 9999)
            {
                Console.Write("Encrypted:");
                Console.WriteLine(EncryptNumber(number).ToString());

                Console.Write("Decrypted:");
                Console.WriteLine(DecryptNumber(EncryptNumber(number)).ToString());
            }
            else
            {
                Console.WriteLine("Your number has more than 4 digits!");
            }

        }
    }
}
