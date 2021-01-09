using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class Invoice : IReceivable, IOutgoing
    {
        #region Fields
        private static long counter = 0;
        private readonly long INVOICE_NUMBER;
        private InvoiceDetail[] invoiceItems;
        #endregion

        #region Constructor
        /// <summary>
        /// General purpouse
        /// </summary>
        /// <param name="invoiceItems"></param>
        public Invoice(InvoiceDetail[] invoiceItems)
        {
            counter++;
            INVOICE_NUMBER = counter;
            InvoiceItems = invoiceItems;
        }
        #endregion

        #region Properties
        public long InvoiceNumber { get { return INVOICE_NUMBER; } }
        
        public InvoiceDetail[] InvoiceItems
        {
            get
            {
                InvoiceDetail[] result = new InvoiceDetail[invoiceItems.Length];
                for (int i = 0; i < invoiceItems.Length; i++)
                {
                    result[i] = invoiceItems[i];
                }
                return result;
            }
            set
            {
                if (value != null)
                {
                    InvoiceDetail[] deepCopy = new InvoiceDetail[value.Length];
                    for (int i = 0; i < invoiceItems.Length; i++)
                    {
                        deepCopy[i] = value[i];
                    }

                    invoiceItems = deepCopy;
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
        }

        decimal IReceivable.InvoiceTotal 
        { 
            get => this.InvoiceTotal();
            
        }

        decimal IOutgoing.InvoiceTotal 
        { 
            get => -(this.InvoiceTotal()); 
        }

        public override bool Equals(object obj)
        { 
            return obj is Invoice invoice &&
                   this.InvoiceTotal() == invoice.InvoiceTotal();
        }
        #endregion

        #region Methods
        public static void PrintInvoices(List<Invoice> listOfInvoice)
        {
            foreach (var invoice in listOfInvoice)
            {
                Console.WriteLine($"ID: {invoice.InvoiceNumber}");
                var descendingInvoiceItems = invoice.InvoiceItems
                    .ToList()
                    .OrderByDescending(item => item.DblLineTotal);
               
                foreach(var invoiceItem in descendingInvoiceItems)
                {
                    Console.WriteLine( $"{invoiceItem:C}" );
                }

                if(invoice is IReceivable receivable)
                {
                    Console.WriteLine(receivable.InvoiceTotal);
                }
                else if (invoice is IOutgoing outgoing)
                {
                    Console.WriteLine(outgoing.InvoiceTotal);
                }
            }
        }

        public decimal InvoiceTotal()
        {
            decimal result = invoiceItems.Sum(invoice => invoice.DblLineTotal);

            return result;
        }

        public override string ToString()
        {
            string result;
            result = $"ID: {INVOICE_NUMBER}\nItem:\n";
            foreach (var ivnoice in invoiceItems)
            {
                result = result + $"{ivnoice.ToString()}\n";
            }

            return result;
        }
        #endregion
    }
}