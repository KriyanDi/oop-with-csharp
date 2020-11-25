using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = GetArrayWithRandomElements(100);

            Display(GroupByRemainderWhenDividedBy8(array));
        }

        #region Methods
        private static int[] GetArrayWithRandomElements(int number)
        {
            Random randomNumber = new Random();

            int[] array = new int[number];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomNumber.Next(20, 51);
            }

            return array;
        }

        private static IEnumerable<IGrouping<int, int>> GroupByRemainderWhenDividedBy8(int[] array)
        {
            IEnumerable<IGrouping<int, int>> result = array
                .GroupBy(number => number % 8)
                .OrderBy(numberGroup => numberGroup.Key);

            return result;
        }

        private static void Display(IEnumerable<IGrouping<int, int>> result)
        {
            foreach (var numberGroup in result)
            {
                Console.WriteLine($"Remainder {numberGroup.Key}: ");
                foreach (var number in numberGroup)
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine();
            }
        } 
        #endregion
    }
}
