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
            Console.Write("Enter your text:");
            string sentence = Console.ReadLine();

            Console.WriteLine();
            Display(SortWordsWithoudDublication(sentence), "Nonduplicate words in alphabetical order:");
        }

        #region Methods
        static private IEnumerable<string> SortWordsWithoudDublication(string sentence)
        {
            string[] words = sentence.Split();

            IEnumerable<string> result = words
                .Select(word => word.ToLower())
                .Distinct()
                .OrderBy(word => word);

            return result;
        }

        static private void Display(IEnumerable<string> result, string title)
        {
            Console.WriteLine(title);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        } 
        #endregion
    }
}
