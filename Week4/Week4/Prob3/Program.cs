using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Write ZIPcode: ");
            string ZIPcode = Console.ReadLine();

            BarcodeMaker barcodeMaker = new BarcodeMaker();
            Console.WriteLine(barcodeMaker.BarcodeFromZipCode(ZIPcode));
        }
    }
}
