using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob6
{
    public class SortUtilsTest
    {
        public SortUtilsTest()
        {
            Console.Write("Enter size of the array: ");
            int sizeOfArray = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            int[] myArray = new int[sizeOfArray];

            //init array
            Console.WriteLine("Initilise array:");
            SortUtils.InitArray(myArray);
            Console.WriteLine();

            //print array
            Console.WriteLine("Print array:");
            SortUtils.PrintArray(myArray);
            Console.WriteLine();

            //sort array
            Console.WriteLine("Sort array:");
            SortUtils.SortArray(myArray);
            SortUtils.PrintArray(myArray);
            Console.WriteLine();

            //merge two arrays
            int[] frst = { 1, 2, 3, 4, 5, 6, 6 };
            int[] scnd = { 2, 4, 8, 9, 10, };
            int[] mergedArray;

            Console.WriteLine("Merge two arrays:");
            SortUtils.PrintArray(frst);
            SortUtils.PrintArray(scnd);
            mergedArray = SortUtils.MergeSort(frst, scnd);
            SortUtils.PrintArray(mergedArray);
        }
    }
}