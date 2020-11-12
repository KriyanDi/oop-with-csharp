using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Prob6
{
    public class SortUtils
    {
        static public void InitArray(int[] arr)
        {
            int val = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{i} element: ");
                val = Convert.ToInt32(Console.ReadLine());
                arr[i] = val;
            }
        }

        static public void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine();
        }

        static public void SortArray(int[] arr)
        {
            //Bubble sort
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        static public int[] MergeSort(int[] frst, int[] scnd)
        {
            int[] mergedArray = new int[frst.Length + scnd.Length];

            int frstId = 0, scndId = 0;

            int i = 0;
            while (frstId + scndId != mergedArray.Length)
            {
                if (frst[frstId] < scnd[scndId])
                {
                    mergedArray[i] = frst[frstId];
                    frstId++;
                }
                else
                {
                    mergedArray[i] = scnd[scndId];
                    scndId++;
                }

                if(frstId == frst.Length)
                {
                    i++;

                    while(scndId < scnd.Length)
                    {
                        mergedArray[i] = scnd[scndId];
                        scndId++;
                        i++;
                    }
                }
                
                if(scndId == scnd.Length)
                {
                    i++; 

                    while (frstId < frst.Length)
                    {
                        mergedArray[i] = frst[frstId];
                        frstId++;
                        i++;
                    }
                }

                i++;
            }

            return mergedArray;
        }
    }
}