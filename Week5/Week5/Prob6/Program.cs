using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob6
{
    class Program
    {
        #region Fields
        private static string[] strings = new string[] { "blueberry", "chimpanzee", "abacus", "banana", "apple", "cheese" }; 
        #endregion

        static void Main(string[] args)
        {
            Display(GroupByFirstLetter(strings));
        }

        #region Methods
        private static IEnumerable<IGrouping<char, string>> GroupByFirstLetter(string[] strings)
        {
            IEnumerable<IGrouping<char, string>> result = strings
                 .GroupBy(word => word[0])
                 .OrderBy(wordGroup => wordGroup.Key);

            return result;
        }

        private static void Display(IEnumerable<IGrouping<char, string>> result)
        {
            foreach (var wordGroup in result)
            {
                Console.WriteLine($"Starts with {wordGroup.Key}");
                foreach (var word in wordGroup)
                {
                    Console.Write($"{word} ");
                }

                Console.WriteLine();
            }
        } 
        #endregion
    }
}
