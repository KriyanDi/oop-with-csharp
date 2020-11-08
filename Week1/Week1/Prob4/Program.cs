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
            Console.Write("Enter your number:");
            int number = Convert.ToInt32(Console.ReadLine());

            string numberString = number.ToString();

            for (int i = 0; i < numberString.Length; i++)
            {
                Console.Write($"{numberString[i]}   ");
            }
        }
    }
}
