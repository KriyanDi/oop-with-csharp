using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob1
{
    public class TableTest
    {
        #region Constructors
        public TableTest()
        {
            double startInterval = 0, endInterval = 0, step = 0;

            Console.Write("Enter interval start: ");
            startInterval = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter interval end: ");
            endInterval = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter step: ");
            step = Convert.ToDouble(Console.ReadLine());

            if(startInterval > endInterval)
            {
                double temp = startInterval;
                startInterval = endInterval;
                endInterval = startInterval;
            }

            Table myTable = new Table(startInterval, endInterval, step);

            myTable.MakeTable();
        }
        #endregion
    }
}