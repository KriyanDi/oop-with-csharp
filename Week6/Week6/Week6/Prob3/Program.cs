using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob3
{
    class Program
    {
        private static void Menu(Rational rational1, Rational rational2)
        {
            Console.WriteLine(rational1.ToString());
            rational1.DisplayNormal();
            rational1.DisplayFloatingPoint();

            Console.WriteLine();

            Console.WriteLine(rational2.ToString());
            rational2.DisplayNormal();
            rational2.DisplayFloatingPoint();

            string command;

            //a) Add two Rational numbers.
            //b) Subtract two Rational numbers.
            //c) Multiply two Rational numbers.
            //d) Divide two Rational numbers.
            //e) Display Rational numbers in the form a / b, where a is the numerator and b is the denominator.
            //f) Display Rational numbers in floating - point format. (Consider providing formatting capabilities that

            while (true)
            {
                Console.WriteLine("Enter command: ");
                command = Console.ReadLine();

                switch (command)
                {
                    case "a":
                        Console.WriteLine($"Add: {(Rational.AddTwoRational(rational1, rational2)).ToString()}");
                        break;
                    case "b":
                        Console.WriteLine($"Substract: {(Rational.SubtractTwoRational(rational1, rational2)).ToString()}");
                        break;
                    case "c":
                        Console.WriteLine($"Multiply: {(Rational.MultiplyTwoRational(rational1, rational2)).ToString()}");
                        break;
                    case "d":
                        Console.WriteLine($"Devide: {(Rational.DevideTwoRational(rational1, rational2)).ToString()}");
                        break;
                    default:
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            Rational rational1 = new Rational(4, 12); // 1 / 3
            Rational rational2 = new Rational(25, 105); // 5 / 21
            Menu(rational1, rational2);
        }
    }
}
