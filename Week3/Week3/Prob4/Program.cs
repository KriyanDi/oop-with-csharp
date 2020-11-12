using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob4
{
    class Program
    {
        private const int TRIANGLE_SIDE_LIMIT = 30;

        static private bool IsTriangleValid((int side1, int side2, int hypotenuse) triangle)
        {
            if (triangle.side1 + triangle.side2 > triangle.hypotenuse)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static private void AllPythagoreanTriples()
        {
            Console.WriteLine($"Side1: Side2: Hypotenuse:");

            for (int i = 0; i < TRIANGLE_SIDE_LIMIT; i++)
            {
                for (int j = 0; j < TRIANGLE_SIDE_LIMIT; j++)
                {
                    for (int k = 0; k < TRIANGLE_SIDE_LIMIT; k++)
                    {
                        if (IsTriangleValid((i, j, k)) &&
                            Math.Pow(i, 2) + Math.Pow(j, 2) == Math.Pow(k, 2))
                        {
                            Console.WriteLine($"{i, 6}{j, 7}{k, 12}");
                        }
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            AllPythagoreanTriples();
        }
    }
}
