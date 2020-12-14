using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using System;

namespace Prob1
{
    class Program
    {
        //Invoice data
        #region Fields
        private static Invoice[] invoices = new Invoice[]
                 {
                new Invoice(83,"Electric sander", 7, 57.98m ),
                new Invoice(24,"Power saw", 18, 99.99m ),
                new Invoice(7, "Sledge hamme", 11, 21.50m ),
                new Invoice(77,"Hammer", 76, 11.99m ),
                new Invoice(77,"Hammer", 11, 11.99m ),
                new Invoice(77,"Hammer", 32, 11.99m ),
                new Invoice(77,"Hammer", 55, 11.99m ),
                new Invoice(39,"Lawn mower", 3 ,79.50m ),
                new Invoice(68,"Screwdriver", 11, 6.99m ),
                new Invoice(68,"Screwdriver", 122, 6.99m ),
                new Invoice(68,"Screwdriver", 150, 6.99m ),
                new Invoice(56,"Jig saw", 21, 11.00m ),
                new Invoice(3,"Wrench", 34, 7.50m)
                };

        private static List<Invoice> listOfInvoices = new List<Invoice>
        {
                new Invoice(83,"Electric sander", 7, 57.98m ),
                new Invoice(24,"Power saw", 18, 99.99m ),
                new Invoice(7, "Sledge hamme", 11, 21.50m ),
                new Invoice(77,"Hammer", 76, 11.99m ),
                new Invoice(77,"Hammer", 11, 11.99m ),
                new Invoice(77,"Hammer", 32, 11.99m ),
                new Invoice(77,"Hammer", 55, 11.99m ),
                new Invoice(39,"Lawn mower", 3 ,79.50m ),
                new Invoice(68,"Screwdriver", 11, 6.99m ),
                new Invoice(68,"Screwdriver", 122, 6.99m ),
                new Invoice(68,"Screwdriver", 150, 6.99m ),
                new Invoice(56,"Jig saw", 21, 11.00m ),
                new Invoice(3,"Wrench", 34, 7.50m)
            };
        #endregion

        static void Main(string[] args)
        {
            DisplayInvoiceResult(SortByPartDescription(listOfInvoices), "Sort by PartDescription:"); //a)
            DisplayInvoiceResult(SortByPrice(listOfInvoices), "Sort by Price:"); //b)
            DisplayInvoiceResult(SortByQuantityPartDescriptionAndQuantity(listOfInvoices), "Sort by Quantity:"); //c)
            DisplayInvoiceResult(SortByTotalPrice(listOfInvoices), "Sort by Total price:"); //d)
            DisplayInvoiceResult(TotalPriceRange200To500(listOfInvoices), "Show 200$ to 500$:"); //e)
            DisplayInvoiceResult(GroupByPriceBelowAbove(listOfInvoices, 12), "Show items above and below 12$:"); //f)

            Console.WriteLine("Group and subgroups by letter:"); //g)
            
            for (int i = 0; i < 26; i++)
            {
                char letter = (char)(65 + i);
                DisplayInvoiceResult(GroupByFirstLetter(listOfInvoices, letter.ToString()), $"Starts with letter {letter}");
            }

            DisplayInvoiceResult(GroupByPriceRangeBelow10Between10And20Above20(listOfInvoices), "Group below 10$, between 10$ -20$, above 20$"); //i)
        }

        #region Methods
        //a)
        private static IEnumerable<Invoice> SortByPartDescription(List<Invoice> listOfInvoices)
        {
            IEnumerable<Invoice> result = listOfInvoices
                            .OrderBy(invoice => invoice.PartDescription)
                            .Select(invoice => invoice);

            //IEnumerable<Invoice> result =
            //    from invoice in listOfInvoices
            //    orderby invoice.PartDescription
            //    select invoice;


            return result;
        }

        //b)
        private static IEnumerable<Invoice> SortByPrice(List<Invoice> listOfInvoices)
        {
            IEnumerable<Invoice> result = listOfInvoices
                            .OrderBy(invoice => invoice.Price)
                            .Select(invoice => invoice);

            //IEnumerable<Invoice> result =
            //    from invoice in listOfInvoices
            //    orderby invoice.Price
            //    select invoice;

            return result;
        }

        //c)
        private static IEnumerable<(string PartDescription, int Quantity)> SortByQuantityPartDescriptionAndQuantity(List<Invoice> listOfInvoices)
        {
            IEnumerable<(string PartDescription, int Quantity)> result = listOfInvoices
                            .OrderBy(invoice => invoice.Quantity)
                            .Select(invoice => (invoice.PartDescription, invoice.Quantity));

            //IEnumerable<(string PartDescription, int Quantity)> result =
            //    from invoice in listOfInvoices
            //    orderby invoice.Quantity
            //    select new (invoice.PartDescription, invoice.Quantity);

            return result;
        }

        //d)
        private static IEnumerable<(string PartDescription, decimal InvoiceTotal)> SortByTotalPrice(List<Invoice> listOfInvoices)
        {
            IEnumerable<(string PartDescription, decimal InvoiceTotal)> result = listOfInvoices
                .OrderBy(invoice => invoice.Quantity * invoice.Price)
                .Select(invoice => (invoice.PartDescription, invoice.Quantity * invoice.Price));

            //IEnumerable<(string PartDescription, decimal InvoiceTotal)> result =
            //    from invoice in listOfInvoices
            //    let total = (invoice.Quantity * invoice.Price)
            //    orderby total
            //    select (invoice.PartDescription, total);

            return result;
        }

        //e)
        private static IEnumerable<decimal> TotalPriceRange200To500(List<Invoice> listOfInvoices)
        {
            IEnumerable<decimal> result = SortByTotalPrice(listOfInvoices)
               .Where(invoice => (200 <= invoice.InvoiceTotal && invoice.InvoiceTotal <= 500))
               .Select(invoice => invoice.InvoiceTotal);

            //IEnumerable<decimal> result =
            //    from invoice in sortByTotalPrice(listOfInvoices)
            //    where (200 <= invoice.InvoiceTotal && invoice.InvoiceTotal <= 500)
            //    select invoice.InvoiceTotal;

            return result;
        }

        //f)

        private static IEnumerable<IGrouping<string, Invoice>> GroupByPriceBelowAbove(List<Invoice> listOfInvoices, decimal price)
        {
            IEnumerable<IGrouping<string, Invoice>> result = listOfInvoices
                .GroupBy(invoice => GroupByPriceBelowAbove(invoice, price));

            //IEnumerable<IGrouping<string, Invoice>> result =
            //    from invoice in listOfInvoices
            //    group invoice by GroupByPriceBelowAbove(invoice, price) into priceGroup
            //    select priceGroup;

            return result;
        }

        //g)
        private static IEnumerable<IGrouping<string, Invoice>> GroupByFirstLetter(List<Invoice> listOfInvoices, string letter)
        {
            IEnumerable<IGrouping<string, Invoice>> result = listOfInvoices
                .Where(invoice => invoice.PartDescription.StartsWith(letter))
                .Select(invoice => invoice)
                .GroupBy(invoice => invoice.PartDescription);

            //IEnumerable<Invoice> partNamesThatStartWithTheLetter =
            //    from invoice in listOfInvoices
            //    where invoice.PartDescription.StartsWith(letter)
            //    select invoice;

            //IEnumerable<IGrouping<string, Invoice>> result =
            //    from invoice in partNamesThatStartWithTheLetter
            //    group invoice by invoice.PartDescription into partDescriptionGroup
            //    select partDescriptionGroup;

            return result;
        }

        //i)
        private static string GroupByPriceBelowBetweenAbove(Invoice invoice, decimal firstPrice, decimal secondPrice)
        {
            if (invoice.Price < firstPrice)
            {
                return $"Below {firstPrice}$";
            }
            else if (10 <= invoice.Price && invoice.Price <= 20)
            {
                return $"Between {firstPrice}$ - {secondPrice}$";
            }
            else
            {
                return $"Above {secondPrice}$";
            }
        }

        private static string GroupByPriceBelowAbove(Invoice invoice, decimal price)
        {
            string result = ((invoice.Price <= price) ? $"Below {price}$" : $"Above {price}$");

            return result;
        }

        private static IEnumerable<IGrouping<string, Invoice>> GroupByPriceRangeBelow10Between10And20Above20(List<Invoice> listOfInvoices)
        {
            IEnumerable<IGrouping<string, Invoice>> result = listOfInvoices
                .GroupBy(invoice => GroupByPriceBelowBetweenAbove(invoice, 10, 20));

            //IEnumerable<IGrouping<string, Invoice>> result =
            //    from invoice in listOfInvoices
            //    group invoice by GroupByPriceBelowBetweenAbove(invoice, 10, 20) into priceGroup
            //    select priceGroup;

            return result;
        }

        private static void DisplayInvoiceResult(IEnumerable<Invoice> result, string title)
        {
            Console.WriteLine(title);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Parallel.ForEach(result, item =>
            {
                Console.WriteLine(item);
            });
            stopwatch.Stop();

            Console.WriteLine($"Parallel: {stopwatch.ElapsedMilliseconds}");

            stopwatch.Start();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            stopwatch.Stop();

            Console.WriteLine($"Normal: {stopwatch.ElapsedMilliseconds}");
        }

        private static void DisplayInvoiceResult(IEnumerable<(string PartDescription, int Quantity)> result, string title)
        {
            Console.WriteLine(title);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Parallel.ForEach(result, item =>
            {
                Console.WriteLine($"PartDescription: {item.PartDescription}, Quantity: {item.Quantity}");
            });
            stopwatch.Stop();

            Console.WriteLine($"Parallel: {stopwatch.ElapsedMilliseconds}");

            stopwatch.Start();
            foreach (var item in result)
            {
                Console.WriteLine($"PartDescription: {item.PartDescription}, Quantity: {item.Quantity}");
            }
            stopwatch.Stop();

            Console.WriteLine($"Normal: {stopwatch.ElapsedMilliseconds}");
        }

        private static void DisplayInvoiceResult(IEnumerable<(string PartDescription, decimal InvoiceTotal)> result, string title)
        {
            Console.WriteLine(title);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Parallel.ForEach(result, item =>
            {
                Console.WriteLine($"PartDescription: {item.PartDescription}, Quantity: {item.InvoiceTotal}");
            });
            stopwatch.Stop();

            Console.WriteLine($"Parallel: {stopwatch.ElapsedMilliseconds}");

            stopwatch.Start();
            foreach (var item in result)
            {
                Console.WriteLine($"PartDescription: {item.PartDescription}, InvoiceTotal: {item.InvoiceTotal}");
            }
            stopwatch.Stop();

            Console.WriteLine($"Normal: {stopwatch.ElapsedMilliseconds}");
        }

        private static void DisplayInvoiceResult(IEnumerable<decimal> result, string title)
        {
            Console.WriteLine(title);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Parallel.ForEach(result, item =>
            {
                Console.WriteLine(item);
            });
            stopwatch.Stop();

            Console.WriteLine($"Parallel: {stopwatch.ElapsedMilliseconds}");

            stopwatch.Start();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            stopwatch.Stop();

            Console.WriteLine($"Normal: {stopwatch.ElapsedMilliseconds}");
        }

        private static void DisplayInvoiceResult(IEnumerable<IGrouping<string, Invoice>> result, string title)
        {
            Console.WriteLine(title);
            foreach (var group in result)
            {
                Console.WriteLine(group.Key);

                foreach (var item in group)
                {
                    Console.WriteLine(item);
                }
            }
        }
        #endregion
    }
}
