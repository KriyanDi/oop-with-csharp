using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Program
    {
        private static void Display(IEnumerable<int> result, string text)
        {
            Console.WriteLine(text);
            foreach (var item in result)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        private static double Compute(int n)
        {
            for (int i = 0; i < 1000; i++)
            {

            }

            return 1;
        }
        static void Main(string[] args)
        {
            //LINQ - Basics
            int[] values1 = { 2, 9, 5, 0, 3, 7, 1, 4, 8, 5 };

            Display(values1, "Original values:");

            //filter greater than 4
            var filtered =
                from value in values1
                where value > 4
                select value;

            Display(filtered, "Greater than 4:");

            //sorted 
            var sorted =
                from value in values1
                orderby value
                select value;

            Display(sorted, "Sorted:");

            //filtered sorted
            var filteredSorted =
                from x in filtered
                orderby x
                select x;

            Display(filteredSorted, "Filtered Sorted");

            //sort and filter
            var sortAndFilter =
                from value in values1
                where value > 4
                orderby value descending
                select value;

            Display(sortAndFilter, "Sorted and filtered");

            //More LINQ example
            Console.WriteLine("More LINQ:");
            List<int> values2 = new List<int> { 2, 9, 5, 0, 3, 7, 1, 4, 8, 5 };

            var odds = values2.Select(n => { if (n % 2 != 0) { return n; } else { return 0; } });
            foreach (var item in odds)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine();

            //TPL example
            double result = 0.0;
            object lockObject1 = new object();

            Parallel.For<double>(0, 1000000, new ParallelOptions { MaxDegreeOfParallelism = 2 },
                () => 0.0,
                (i, loop, localState) =>
                {
                    return localState + Compute(i);
                },
                (localPartialSum) =>
                {
                    lock (lockObject1)
                    {
                        result += localPartialSum;
                    }
                }
                );
            Console.WriteLine($"Actual: {result}, Expected 1000000");

            Console.WriteLine();
            Console.WriteLine();

            double[] sequence = Enumerable.Range(0, 1000000).Select<int, double>(x => (double)x / 2.0).ToArray<double>();
            Console.WriteLine($"Number of elements: {sequence.Length}");

            object lockObject2 = new object();
            double sum = 0.0d;

            Parallel.ForEach(
                sequence,
                () => 0.0,
                (range, loopState, localPartialSum) =>
                 {
                     return localPartialSum + range * 2.0;
                 },
                (localPartialSum) =>
                {
                    lock (lockObject2)
                    {
                        sum += localPartialSum;
                    }
                });

            Console.WriteLine($"Actual {sum}, Expexted {((1000000/2.0)*999999)}");

            //PLINQ
        }
    }
}
