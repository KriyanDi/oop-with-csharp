using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob3
{
    class Program
    {
        static private double ProbabilityFiveDigitNumber(int experiments = 1000)
        {
            int firstDigit = 0;
            int secondDigit = 0;
            int thirdDigit = 0;
            int fourthDigit = 0;
            int fifthDigit = 0;

            Random randomNumber = new Random();
            int randomFiveDigitNumber = 0;

            int countSuccesses = 0;

            for (int i = 0; i < experiments; i++)
            {
                firstDigit = randomNumber.Next(1, 6);
                secondDigit = randomNumber.Next(4, 10);
                thirdDigit = randomNumber.Next(3, 9);
                fourthDigit = randomNumber.Next(6, 10);
                fifthDigit = randomNumber.Next(2, 9);

                randomFiveDigitNumber = 10000 * firstDigit + 1000 * secondDigit + 100 * thirdDigit + 10 * fourthDigit + fifthDigit;

                if (randomFiveDigitNumber % 4 == 0)
                {
                    countSuccesses++;
                }
            }

            double probability = (double)countSuccesses / experiments;
            return probability;
        }

        // This function not always returns different number
        //static private int randomFiveDigitNumber()
        //{
        //    Random randomNumber = new Random();

        //    int firstDigit = randomNumber.Next(1, 6);
        //    int secondDigit = randomNumber.Next(4, 10);
        //    int thirdDigit = randomNumber.Next(3, 9);
        //    int fourthDigit = randomNumber.Next(6, 10);
        //    int fifthDigit = randomNumber.Next(2, 9);

        //    int randomFiveDigitNumber = 10000 * firstDigit + 1000 * secondDigit + 100 * thirdDigit + 10 * fourthDigit + fifthDigit;

        //    return randomFiveDigitNumber;
        //}

        static void Main(string[] args)
        {
            Console.WriteLine($"Probability is: {ProbabilityFiveDigitNumber()}");
        }
    }
}
