using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public static class InvoiceExtension
    {
        public static void AddAllInvoice(this Invoice invoice, InvoiceDetail[] invoiceDetails)
        {
            InvoiceDetail[] result = new InvoiceDetail[invoice.InvoiceItems.Length + invoiceDetails.Length];

            int i = 0;
            foreach (var item in invoice.InvoiceItems)
            {
                result[i] = item;
                i++;
            }

            foreach (var item in invoiceDetails)
            {
                result[i] = item;
                i++;
            }

            invoice.InvoiceItems = result;
        }
    }
}