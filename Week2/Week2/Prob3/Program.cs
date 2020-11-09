using System;
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
            Invoice myInvoice = new Invoice("12344322", "Laptop", 2000, 13);
            Console.WriteLine($"Amount: {myInvoice.GetInvoiceAmount()}");
        }
    }
}
