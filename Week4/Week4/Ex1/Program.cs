using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            //collections
            
            //ArrayList
            ArrayList array1 = new ArrayList(10);

            foreach (var item in new int[] { 1,2,3,4,5,6,7,8,9,19})
            {
                array1.Add(item);
            }

            array1.Insert(array1.Count - 1, 1222); //inserts 1222 on position last - 1
            array1.Remove(3); // removes first element whose value is 3
            array1.RemoveAt(6); //removes at INDEX 6

            foreach (var item in array1)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();

            //List
            List<int> array2 = new List<int>();

            //Queue
            Queue queue1 = new Queue();

            foreach (var item in new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 19 })
            {
                queue1.Enqueue(item);
            }

            foreach (var item in queue1)
            {
                Console.Write($"{item} ");
            }

            int dequeuedValue = (int)queue1.Dequeue();

            Queue<int> queue2 = new Queue<int>();

            //Stack
            Stack stack1 = new Stack();

            Stack<int> stack2 = new Stack<int>();

            foreach (var item in new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 19 })
            {
                stack2.Push(item);
            }

            var stackPopped = stack2.Pop();

            //Hashtable
            Hashtable ages = new Hashtable();
            
            ages["name1"] = 41;
            ages["name2"] = 12;
            ages["name3"] = 42;
            ages["name4"] = 12;
            ages["name5"] = 4;

            foreach (DictionaryEntry item in ages)
            {
                string name = (string)item.Key;
                int age = (int)item.Value;
            }

            //SortedList
            SortedList ages1 = new SortedList();
            ages1["name1"] = 41;
            ages1["name2"] = 12;
            ages1["name3"] = 42;
            ages1["name4"] = 12;
            ages1["name5"] = 4;

            foreach (DictionaryEntry item in ages1)
            {
                string name = (string)item.Key;
                int age = (int)item.Value;
            }

        }
    }
}
