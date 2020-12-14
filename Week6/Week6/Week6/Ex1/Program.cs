using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleNamespace1;
using ExampleNamespace2;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Class1 indexers
            Class1 indexTest = new Class1();
            Console.WriteLine(indexTest[1]);

            //here we use library from Ex2
            ExampleNamespace1.Class1.Hello();
            ExampleNamespace2.Class2.Hello();

            Class2 class2 = new Class2();
            class2.ExtensionClass2Dummy();
        }
    }
}
