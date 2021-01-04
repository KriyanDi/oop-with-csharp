using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {    
            IPayable[] payableObjects = new IPayable[4];
            
            payableObjects[0] = new Invoice("01234", "seat", 2, 375.00M);
            payableObjects[1] = new Invoice("56789", "tire", 4, 79.95M);
            payableObjects[2] = new SalariedEmployee("John", "Smith",
            "111-11-1111", 800.00M);
            payableObjects[3] = new SalariedEmployee("Lisa", "Barnes",
            "888-88-8888", 1200.00M);

            Console.WriteLine("Invoices and Employees processed polymorphically:\n");
           
            foreach (var currentPayable in payableObjects)
            {
                Console.WriteLine("payment due \n{0}: {1:C}\n",
                currentPayable, currentPayable.GetPaymentAmount());
            } 
        } 
    }
}

