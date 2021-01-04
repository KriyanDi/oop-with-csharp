using System;
using System.Collections.Generic;

namespace HomeworkTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            ////a
            //CountDown countDown = new CountDown();
            //while(countDown.MoveNext())
            //{
            //    countDown.CurrentPossition++;
            //    Console.Write(countDown.Current);
            //}
            //countDown.Reset();

            //b
            CountDownWithDefaults.Test();

            Console.WriteLine();

            //c
            CountDownWithOverride.Test();
        }
    }
}
