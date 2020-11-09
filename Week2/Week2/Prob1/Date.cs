using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob1
{
    public class Date
    {
        #region Fields
        #region public

        #endregion

        #region private
        private int day;
        private int month;
        private int year;

        #endregion
        #endregion

        #region Constructors
        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        #endregion

        #region Properties
        public int Day
        {
            get { return day; }
            set { day = (0 < value && value <= 31 ? value : 1); }
        }

        public int Month
        {
            get { return month; }
            set { month = (0 < value && value <= 12 ? value : 1); }
        }

        public int Year
        {
            get { return year; }
            set { year = (0 <= value ? value : 0); }
        }

        #endregion
    }
}