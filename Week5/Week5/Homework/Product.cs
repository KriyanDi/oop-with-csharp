using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework
{
    public class Product
    {
        #region Fields
        private static long cnt;
        public string ID;
        private static Random rnd = new Random();
        public List<int> WeeklyPurchases;
        private static List<Product> products = new List<Product>
        {
            new Product("Electric sander", Type.M, new List<int>{99, 82, 81, 79}, 157.98M),
            new Product("Power saw", Type.M, new List<int>{99, 86, 90, 94}, 99.99M),
            new Product("Sledge hammer", Type.F, new List<int>{93, 92, 80, 87}, 21.50M),
            new Product("Hammer", Type.M, new List<int>{97, 89, 85, 82}, 11.99M),
            new Product("Lawn mower", Type.F, new List<int>{35, 72, 91, 70}, 139.50M),
            new Product("Screwdriver", Type.F, new List<int>{88, 94, 65, 91}, 56.99M),
            new Product("Jig saw", Type.M, new List<int>{75, 84, 91, 39}, 11.00M),
            new Product("Wrench", Type.F, new List<int>{97, 92, 81, 60}, 17.50M),
            new Product("Sledge hammer", Type.M, new List<int>{75, 84, 91, 39}, 21.50M),
            new Product("Hammer", Type.F, new List<int>{94, 92, 91, 91}, 11.99M),
            new Product("Lawn mower", Type.M, new List<int>{96, 85, 91, 60}, 179.50M),
            new Product("Screwdriver", Type.M, new List<int>{96, 85, 51, 30}, 66.99M)
        };
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse constructor
        /// </summary>
        /// <param name="description"></param>
        /// <param name="category"></param>
        /// <param name="weeklyPurchases"></param>
        /// <param name="price"></param>
        public Product(string description, Type category, List<int> weeklyPurchases, decimal price)
        {
            cnt++;



            Description = description;
            Category = category;
            WeeklyPurchases = new List<int>(weeklyPurchases);
            Price = price;

            Quarter = (YearlyQuarter)rnd.Next(1, 5);
            ID = $"{category}{cnt:D6}";

        }
        #endregion

        #region Properties
        public Type Category { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public YearlyQuarter Quarter { get; set; }
        #endregion

        #region Methods
        //a)
        public static void GroupByCategoryCountDescending()
        {
            var result = products
                .GroupBy(product => product.Category)
                .Select(group => new { Key = group.Key, Products = group.OrderByDescending(product => product.Price) });


            foreach (var group in result)
            {
                Console.WriteLine($"Category group: {group.Key}");
                Console.WriteLine($"Number of products of Type {group.Key} in this group: {group.Products.Count()}");
                Console.WriteLine("Products:");
                foreach (var product in group.Products)
                {
                    Console.WriteLine("{0,-15}{1, 30:C}", product.Description, product.Price);
                }
                Console.WriteLine();
            }
        }

        //b)
        public static decimal AverageProductGroupPrice(IGrouping<YearlyQuarter, Product> productGroup)
        {
            decimal sum = 0;
            foreach (var product in productGroup)
            {
                sum += product.Price;
            }

            decimal result = sum / productGroup.Count();

            return result;
        }

        public static void GroupByQtrAndProductPriceAvg()
        {
            var result = products
                 .GroupBy(product => product.Quarter)
                 .Select(group => new
                 {
                     Key = group.Key,
                     AveragePrice = AverageProductGroupPrice(group),
                     Products = group.OrderBy(product => product.Price),
                 })
                 .OrderBy(group => group.Key);

            foreach (var group in result)
            {
                Console.WriteLine($"Quarter group: {group.Key}");
                Console.WriteLine($"Average price: {group.AveragePrice:C}");
                Console.WriteLine($"Products:");
                foreach (var product in group.Products)
                {
                    Console.WriteLine("{0,-15}{1, 30:C}", product.Description, product.Price);
                }
                Console.WriteLine();
            }
        }

        //c)
        public static void GroupByQtrCategoryWeeklySum()
        {
            var result = products
                 .GroupBy(product => product.Quarter)
                 .Select(group => new
                 {
                     Key = group.Key,
                     CategoryGroup = group
                        .GroupBy(product => product.Category)
                        .Select(categroyGroup => new
                        {
                            Key = categroyGroup.Key,
                            Products = categroyGroup.OrderBy(product => product.Price)
                        })
                        .OrderBy(categoryGroup => categoryGroup.Key)
                 })
                 .OrderBy(group => group.Key);

            foreach (var group in result)
            {
                Console.WriteLine($"Quarter group: {group.Key}");
                foreach (var categoryGroup in group.CategoryGroup)
                {
                    Console.WriteLine($"\t\tCategory group: {categoryGroup.Key}");
                    foreach (var product in categoryGroup.Products)
                    {
                        Console.WriteLine("\t\t\t\t({0,-20}{1,5})", product.Description, Enumerable.Sum(product.WeeklyPurchases));
                    }
                }
            }
        }

        //d)
        public static void GroupByQtrCategoryAndProducts()
        {
            var result = products
                .GroupBy(product => product.Quarter)
                .Select(group => new
                {
                    Key = group.Key,
                    CategoryGroup = group
                       .GroupBy(product => product.Category)
                       .Select(categroyGroup => new
                       {
                           Key = categroyGroup.Key,
                           Products = categroyGroup.OrderBy(product => product.Price)
                       })
                       .OrderBy(categoryGroup => categoryGroup.Key)
                })
                .OrderBy(group => group.Key);

            foreach (var group in result)
            {
                Console.WriteLine($"Quarter group: {group.Key}");
                foreach (var categoryGroup in group.CategoryGroup)
                {
                    Console.WriteLine($"\t\tCategory group: {categoryGroup.Key}");
                    foreach (var product in categoryGroup.Products)
                    {
                        Console.WriteLine($"\t\t\t\t{product}");
                    }
                }
            }
        }

        //e)
        public static void GroupByQtrMinMaxPrice()
        {
            var result = products
                 .GroupBy(product => product.Quarter)
                 .Select(group => new
                 {
                     Key = group.Key,
                     Min = group.Min(product => product.Price),
                     Max = group.Max(product => product.Price)
                 })
                 .OrderBy(group => group.Key);

            foreach (var group in result)
            {
                Console.WriteLine($"Quarter group: {group.Key}");
                Console.WriteLine($"\t\tMin price per Quarter: {group.Min}");
                Console.WriteLine($"\t\tMax price per Quarter: {group.Max}");
                Console.WriteLine();
            }
        }

        public override string ToString() => $"{ID}: {(string.Join(" , ", WeeklyPurchases.Select(number => number.ToString()).ToArray()))}";
        #endregion
    }
}