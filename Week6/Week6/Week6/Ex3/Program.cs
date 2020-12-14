using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    class Program
    {
        //delegate
        public delegate bool NumberPred(int number);

        static void Main(string[] args)
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            NumberPred evenPred = IsEven;
            NumberPred evenPredLambda = number => (number % 2 == 0);

            Console.WriteLine("Is 4 even?: {0}", evenPred(4));
            Console.WriteLine("Is 4 even?: {0}", evenPredLambda(4));

            var person = new { Name = "a", Age = "1" };                                            
        }

        private static bool IsEven(int number)
        {
            return (number % 2 == 0);
        }
    }
}
