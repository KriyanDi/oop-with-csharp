using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Prob1
{
    public class Table
    {
        #region Constant Fields
        #region public

        #endregion

        #region private
        const int SERIES = 20;

        #endregion
        #endregion

        #region Fields
        #region public

        #endregion

        #region private
        private double startInterval;
        private double endInterval;
        private double step;

        #endregion

        #endregion

        #region Constructors
        public Table(double startInterval, double endInterval, double step)
        {
            StartInterval = startInterval;
            EndInterval = endInterval;
            Step = step;
        }

        #endregion

        #region Properties
        public double StartInterval
        {
            get { return startInterval; }
            set { startInterval = value; }
        }



        public double EndInterval
        {
            get { return endInterval; }
            set { endInterval = value; }
        }



        public double Step
        {
            get { return step; }
            set { step = value; }
        }

        #endregion

        #region Methods
        #region public
        public void MakeTable()
        {
            Console.WriteLine("X:\tF(x):");

            int seriesCounter = 0;
            for (double i = startInterval; i <= endInterval; i = i + step)
            {
                if(seriesCounter % SERIES == 0 && seriesCounter != 0)
                {
                    Console.WriteLine("Press return to continue ...");

                    string command = Console.ReadLine();
                    if(command != "Return")
                    {
                        break;
                    }
                }
                else
                {
                    double result = CalculateFunction(i);

                    Console.WriteLine($"{i}\t{result:0.0000}");
                }

                seriesCounter++;
            }
        }
        #endregion

        #region private
        private double CalculateFunction(double x)
        {
            double result = (Math.Pow(Math.Abs(x - 2), 2)) / (Math.Pow(x, 2) + 1);

            return result;
        }

        #endregion
        #endregion
    }
}