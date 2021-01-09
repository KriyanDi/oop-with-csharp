using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ReceivableInvoice invoice = new ReceivableInvoice();
            Console.WriteLine(invoice.R_ID);

            if (invoice is ReceivableInvoice receivable)
            {
                receivable.R_ID = "CHUGUN";
            }

            Console.WriteLine(invoice.R_ID);
        }
    }
}
