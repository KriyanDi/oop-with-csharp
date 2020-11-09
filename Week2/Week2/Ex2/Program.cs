using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class Program
    {
        static private void SwitchPatternMatching(int horsePower)
        {
            Car myCar = new Car(horsePower);

            switch (myCar)
            {
                case Car car when (0 <= car.HorsePower && car.HorsePower <= 100):
                    Console.WriteLine("Its a good car!");
                    break;
                case Car car when (110 <= car.HorsePower && car.HorsePower <= 1000):
                    Console.WriteLine("Wow, you got an airplane!?");
                    break;
                default:
                    break;
            }
        }
            
        static void Main(string[] args)
        {
            //Pattern matching
            SwitchPatternMatching(1000);

            //if..if else
            Console.WriteLine(10 >= 60 ? "Good" : "Bad");

            if (4 <= 60)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");

            }

            //while
            int i = 3;
            while (i < 10)
            {
                Console.WriteLine("{0}", i);
                i++;
            }
        }
    }
}
