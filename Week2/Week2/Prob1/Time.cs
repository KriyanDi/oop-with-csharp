using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prob1
{
    public class Time
    {
        #region Fields
        #region public

        #endregion

        #region private
        private int seconds;
        private int minutes;
        private int hours;

        #endregion
        #endregion

        #region Constructors
        public Time(int seconds, int minutes, int hours)
        {
            Seconds = seconds;
            Minutes = minutes;
            Hours = hours;
        }

        public Time(Time time)
        {
            seconds = time.seconds;
            minutes = time.minutes;
            hours = time.hours;
        }

        public Time()
        {
            seconds = 0;
            minutes = 0;
            hours = 0;
        }

        #endregion

        #region Properties
        public int Seconds
        {
            get { return seconds; }
            set { seconds = (0 <= value && value <= 59 ? value : 0); }
        }

        public int Minutes
        {
            get { return minutes; }
            set { minutes = (0 <= value && value <= 59 ? value : 0); }
        }

        public int Hours
        {
            get { return hours; }
            set { hours = (0 <= value && value <= 23 ? value : 0); }
        }

        #endregion

        #region Methods
        #region public
        public override string ToString()
          => $"{hours:d2}:{minutes:d2}:{seconds:d2}";

        public void AddSecond()
        {
            seconds++;
            if (seconds > 59)
            {
                seconds = 0;

                minutes++;
                if (minutes > 59)
                {
                    minutes = 0;

                    hours++;
                    hours = hours % 24;
                }
            }
        }

        #endregion

        #region private

        #endregion
        #endregion
    }
}