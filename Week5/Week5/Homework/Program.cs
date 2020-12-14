using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Product.GroupByCategoryCountDescending();
            Product.GroupByQtrAndProductPriceAvg();
            Product.GroupByQtrCategoryWeeklySum();
            Product.GroupByQtrCategoryAndProducts();
            Product.GroupByQtrMinMaxPrice();
        }
    }
}
