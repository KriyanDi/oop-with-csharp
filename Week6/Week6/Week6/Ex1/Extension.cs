using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExampleNamespace2;

namespace Ex1
{
    public static class Extension
    {
        public static void ExtensionClass2Dummy<T>(this T class1) where T: Class2
        {
            Console.WriteLine("Extension function");
        }
    }
}
