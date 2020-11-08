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
            //Formatting Text Console.Write and Console.WriteLine
            Console.Write("Welcome to ");
            Console.WriteLine("C# Programming!");
            Console.WriteLine("Welcome\nto\nC\nProgramming!");
            Console.WriteLine("{0}\n{1}", "Welcome to", "C# Programming!");

            string a = "Hello", b = ", my name is Chris!\n";
            Console.WriteLine($"{a}{b}");

            //Reading from the console
            int number1;
            int number2;
            int sum;

            Console.Write("N1: ");
            number1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("N2: ");
            number2 = Convert.ToInt32(Console.ReadLine());

            sum = number1 + number2;
            Console.WriteLine($"Result: {sum}");

            //if statement
            Console.Write("Enter first integer: ");
            number1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second integer: ");
            number2 = Convert.ToInt32(Console.ReadLine());

            if (number1 == number2)
                Console.WriteLine("{0} == {1}", number1, number2);

            if (number1 != number2)
                Console.WriteLine("{0} != {1}", number1, number2);

            if (number1 < number2)
                Console.WriteLine("{0} < {1}", number1, number2);

            if (number1 > number2)
                Console.WriteLine("{0} > {1}", number1, number2);

            if (number1 <= number2)
                Console.WriteLine("{0} <= {1}", number1, number2);
        }
    }
}
