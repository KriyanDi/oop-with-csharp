using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob5
{
    class Program
    {
        static private string EncodeDigit(int digit)
        {
            switch (digit)
            {
                case 0: return "A";
                case 1: return "C";
                case 2: return "G";
                case 3: return "T";
            }

            return "Undefined digit";
        }

        static private string CalculateACGT(int number, int digit1, int digit2, int digit3, int digit4)
        {
            digit1 = number % 4;
            number = number / 4;

            digit2 = number % 4;
            number = number / 4;

            digit3 = number % 4;
            number = number / 4;

            digit4 = number % 4;

            string representation = EncodeDigit(digit1) + EncodeDigit(digit2) + EncodeDigit(digit3) + EncodeDigit(digit4);

            return representation;
        }

        static void Main(string[] args)
        {
            int digit1 = 0;
            int digit2 = 0;
            int digit3 = 0;
            int digit4 = 0;

            Console.Write("Enter ACGT number: ");
            int number = Convert.ToInt32(Console.ReadLine());

            if (1000 <= number && number <= 9999)
            {
                string numberRepresentation = CalculateACGT(number, digit1, digit2, digit3, digit4);

                Console.WriteLine($"The representation of {number} is {numberRepresentation}");
            }
            else
            {
                Console.WriteLine("Incorrect number!\n");
            }
        }
    }
}
