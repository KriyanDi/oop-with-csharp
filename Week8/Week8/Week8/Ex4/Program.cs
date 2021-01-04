using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex4
{
    class Program
    {
        public static void DisplayTemp(Celsius Temp)
        {
            Console.WriteLine($"C -> F: {Temp.Temp} -> {(((Fahrenheit)Temp).Temp)}");
        }

        public static void DisplayTemp(Fahrenheit Temp)
        {
            Console.WriteLine($"F -> C: {Temp.Temp} -> {(((Celsius)Temp).Temp)}");
        }


        static void Main(string[] args)
        {
            Fahrenheit f = new Fahrenheit(98.6F);
            DisplayTemp(f);
            Celsius c = new Celsius(0F);
            DisplayTemp(c);
            Console.ReadLine();
        }
    }
}
