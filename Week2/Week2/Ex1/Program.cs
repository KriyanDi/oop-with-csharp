using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Program
    {
        static private (int, int) TupleTest()
            => (2, 4);

        static void Main(string[] args)
        {
            //class Gradebook example
            Gradebook myGradebook = new Gradebook("C# .NET");

            Console.WriteLine($"Course name: {myGradebook.CourseName}");

            //myGradebook.CourseName = Console.ReadLine();
            //Console.WriteLine($"Course name: {myGradebook.CourseName}");

            //tuples
            (int number1, int number2) numbers = TupleTest();
            //Console.WriteLine($"number1: {numbers.number1}\nnumber2: {numbers.number2}");

            //class Account example
            Account myAccount = new Account(-400M);

            Console.WriteLine($"Balance: {myAccount.Balance:C}");

            myAccount.Credit(1300);
            Console.WriteLine($"Balance: {myAccount.Balance:C}");
        }
    }
}
