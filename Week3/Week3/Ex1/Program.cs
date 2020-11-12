using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Random
            Random myRandom = new Random();
            int randomValue;

            randomValue = myRandom.Next(1, 11);
            Console.WriteLine($"Random value is: {randomValue}");

            randomValue = 1 + 5 * myRandom.Next(11);
            Console.WriteLine($"Random value is: {randomValue}");

            randomValue = myRandom.Next(11);
            Console.WriteLine($"Random value is: {randomValue}");

            //Array
            int[] myArray = new int[123];
            int[] myArrayInit = { 1, 2, 3, 4 };
            int[] myArrayBarChart = { 0, 0, 0, 0, 0, 0, 1, 2, 4, 2, 1 };

            //Bar chart
            for (int i = 0; i < myArrayBarChart.Length; i++)
            {
                if(i == 10)
                {
                    Console.Write("100:");
                }
                else
                {
                    Console.Write($"{i * 10:D2}-{((i + 1) * 10 - 1):D2}:");
                }

                for (int y = 0; y < myArrayBarChart[i]; y++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}
