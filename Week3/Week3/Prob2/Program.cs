using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob2
{
    class Program
    {
        static private bool HasCommonDevisor((int number1, int number2) numbers, out (int leastDevisor, int greatestDevisor) devisors)
        {
            if (numbers.number1 == 0 ||
                numbers.number2 == 0)
            {
                devisors.leastDevisor = -1;
                devisors.greatestDevisor = -1;
                return false;
            }

            if (numbers.number1 > numbers.number2)
            {
                int temp = numbers.number1;
                numbers.number1 = numbers.number2;
                numbers.number2 = temp;
            }

            int[] allDevisors = new int[numbers.number1];
            //Array.Fill(allDevisors, -1);

            for (int i = 0; i < allDevisors.Length; i++)
            {
                allDevisors[i] = 1;
            }

            for (int i = 1; i <= Math.Abs(numbers.number1); i++)
            {
                if (numbers.number1 % i == 0 &&
                    numbers.number2 % i == 0)
                {
                    allDevisors[i-1] = i;
                }
            }

            devisors.leastDevisor = allDevisors.Min();
            devisors.greatestDevisor = allDevisors.Max();

            if (devisors.leastDevisor == devisors.greatestDevisor)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number1: ");
            int number1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter number2: ");
            int number2 = Convert.ToInt32(Console.ReadLine());

            (int frst, int scnd) numbers = (number1, number2);

            if (HasCommonDevisor(numbers, out (int leastDevisor, int greatestDevisor) devisors))
            {
                Console.WriteLine($"Numbers: {numbers.frst} {numbers.scnd}");
                Console.WriteLine($"Least devisor: {devisors.leastDevisor}");
                Console.WriteLine($"Greatest devisor: {devisors.greatestDevisor}");
            }
            else
            {
                Console.WriteLine("No common devisors...");
            }
        }
    }
}
