using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob5
{
    class Program
    {
        static private void CalculateACGT(int number, ref int a, ref int c, ref int g, ref int t)
        {
            //TODO:  
        }

        static void Main(string[] args)
        {
            int a = 0;
            int c = 0;
            int g = 0;
            int t = 0;

            Console.Write("Enter ACGT number:");
            int number = Convert.ToInt32(Console.ReadLine());

            if (1000 <= number && number <= 9999)
            {
                CalculateACGT(number, ref a, ref c, ref g, ref t);

                Console.WriteLine($"A:{a} C:{c} G:{g} T:{t}\n");
            }
            else
            {
                Console.WriteLine("Incorrect number!\n");
            }
        }
    }
}
