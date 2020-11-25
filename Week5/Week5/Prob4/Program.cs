using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob4
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxNumber = 0;

            for (int i = 0; i < 100000; i++)
            {
                if (i == NumberOfOnesRequiredWhenWritingOutAllNumbersBetweenZeroAndGivenNumber(i))
                {
                    maxNumber = i;
                }
            }

            Console.WriteLine($"Biggest number is: {maxNumber}");
        }

        #region Methods
        private static int CountOnes(int number)
        {
            int counter = 0;
            char[] digits = number.ToString().ToCharArray();

            foreach (var digit in digits)
            {
                if (digit == '1')
                {
                    counter++;
                }
            }

            return counter;
        }

        private static int NumberOfOnesRequiredWhenWritingOutAllNumbersBetweenZeroAndGivenNumber(int givenNumber)
        {
            IEnumerable<int> numbers = Enumerable.Range(0, givenNumber + 1);

            IEnumerable<int> onesOfNumber = numbers
                .Select(number => CountOnes(number));

            int sum = 0;
            foreach (var item in onesOfNumber)
            {
                sum = sum + item;
            }

            return sum;
        }           
        #endregion
    }
}
