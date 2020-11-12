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
            int countSuccesses = 0;
            int randomNumber = 0;

            for (int i = 0; i < experiments; i++)
            {
                randomNumber = randomFiveDigitNumber();

                if (randomNumber % 4 == 0)
                {
                    Console.WriteLine($"Number: {randomNumber}");
                    countSuccesses++;
                }
            }

            double probability = countSuccesses/experiments ;

            return probability;
        }
        
        static private int randomFiveDigitNumber()
        {
            Random randomNumber = new Random();

            int firstDigit = randomNumber.Next(1, 6);
            int secondDigit = randomNumber.Next(4, 10);
            int thirdDigit = randomNumber.Next(3, 9);
            int fourthDigit = randomNumber.Next(6, 10);
            int fifthDigit = randomNumber.Next(2, 9);

            int randomFiveDigitNumber = 10000 * firstDigit + 1000 * secondDigit + 100 * thirdDigit + 10 * fourthDigit + fifthDigit;

            return randomFiveDigitNumber;
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Probability is: {ProbabilityFiveDigitNumber()}");
            }
            
        }
    }
}
