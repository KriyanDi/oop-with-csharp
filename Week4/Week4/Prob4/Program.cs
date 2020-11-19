using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob4
{
    class Program
    {
        static private void PrintTable(int[,] table)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    Console.Write($"{table[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        static private void PrintList(int[] lst)
        {
            for (int i = 0; i < lst.Length; i++)
            {
                Console.Write($"{lst[i]} ");
            }
        }

        static private int[,] Substract(int[,] table, int[] lst)
        {
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    table[i, j] = table[i, j] - lst[j];
                }
            }

            return table;
        }

        static private ref int[] Multiply(int[,] table, ref int[] lst)
        {
            int tempSum = 0;
            for (int i = 0; i < table.GetLength(1); i++)
            {
                for (int j = 0; j < table.GetLength(0); j++)
                {
                    tempSum = table[j, i] * lst[j];
                }

                lst[i] = tempSum;
                tempSum = 0;
            }

            return ref lst;
        }

        static void Main(string[] args)
        {
            var table = new[,]{
                { 3, 4, 5, 6, 3 },
                { 2, 1, 2, 1, 1 },
                { 3, 2, 1, 4, 9 },
                { 1, 0, 0, 1, 1 },
                { 9, 2, 6, 4, 9 }};

            var lst = new int[] { 2, 1, 2, 3, 4 };

            Console.WriteLine("Before:");
            Console.WriteLine();
            PrintTable(table);
            
            Console.WriteLine();
            PrintList(lst);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("After:");
            Console.WriteLine();
            PrintTable(Substract(table,lst));

            Console.WriteLine();
            PrintList(Multiply(table,ref lst));

        }
    }
}
