using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utilities;

namespace InvoiceProcesing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Invoice> invoices;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Buttons Events
        private void BtnCrtInvc_Click(object sender, RoutedEventArgs e)
        {
            invoices = new List<Invoice>();

            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                //make random invoiceItems data
                (string description, decimal cost)[] invoiceItems = new (string description, decimal cost)[random.Next(1, 11)];
                for (int j = 0; j < invoiceItems.Length; j++)
                {
                    invoiceItems[j].description = $"Item{j}";
                    invoiceItems[j].cost = (decimal)random.NextDouble() * (200 - 100) + 100; // random() * (maximum - minimum) + minimum
                }

                //make random invoice
                switch (random.Next(0, 2))
                {
                    case 0:
                        if (Double.TryParse(TxtDisc.Text, out double discount))
                        {
                            ReceivableInvoice receivableInvoice = new ReceivableInvoice(invoiceItems, discount);
                            receivableInvoice.PropertyChanged += ManageDiscounts;
                            invoices.Add(receivableInvoice);

                        }
                        else
                        {
                            throw new Exception("Failed TxtDisc.Text parse to Double");
                        }
                        break;
                    case 1:
                        PayableInvoice payableInvoice = new PayableInvoice(invoiceItems, (PaymentType)random.Next(0, 3));
                        invoices.Add(payableInvoice);
                        break;
                }
            }
        }

        private void BtnQuit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void BtnShwSrt_Click(object sender, RoutedEventArgs e)
        {
            var ordered = invoices.
                OrderByDescending(invoice => invoice.InvoiceTotal());

            string result = "";
            foreach (var invoice in ordered)
            {
                result = result + $"{invoice.ToString()} InvoiceTotal: {invoice.InvoiceTotal():C2}\n";
            }

            TxtRslt.Text = result;
        }

        private void BtnGrpByPaymnt_Click(object sender, RoutedEventArgs e)
        {
            var grouped = invoices
                .Where(invoice => invoice is PayableInvoice)
                .GroupBy(invoice => ((PayableInvoice)invoice).Payment);

            string result = "";
            foreach(var invoice in grouped)
            {
                var sum = invoice.Sum(item => item.InvoiceTotal());
                result = result + $"{invoice.Key} Total cost : {sum:C2}\n";
            }

            TxtRslt.Text = result;
        }

        private void BtnUpdDisc_Click(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(TxtDisc.Text, out double discount))
            {
                for (int i = 0; i < invoices.Count; i++)
                {
                    if (invoices[i] is ReceivableInvoice)
                    {
                        for (int j = 0; j < ((ReceivableInvoice)invoices[i]).InvoiceItems.Length; j++)
                        {
                            ((ReceivableInvoice)invoices[i]).Discount = discount;
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Failed TxtDisc.Text parse to Double");
            }
        }
        #endregion

        private void ManageDiscounts(object sender, PropertyChangedEventArgs e)
        {
            for (int i = 0; i < invoices.Count; i++)
            {
                if (invoices[i] is ReceivableInvoice)
                {
                    for (int j = 0; j < ((ReceivableInvoice)invoices[i]).InvoiceItems.Length; j++)
                    {
                        decimal discount = (decimal)((ReceivableInvoice)invoices[i]).Discount;
                        decimal cost = ((ReceivableInvoice)invoices[i]).InvoiceItems[j].cost;
                        ((ReceivableInvoice)invoices[i]).InvoiceItems[j].cost = cost - discount;
                    }
                }
            }
        }
    }
}
