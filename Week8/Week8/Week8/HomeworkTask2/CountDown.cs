using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeworkTask2
{
    public class CountDownOverride : IEnumerator.CountDown
    { 
        public CountDownOverride()
        {
            CurrentPossition = 16;
        }

        public override bool MoveNext()
        {
            if(CurrentPossition - 1 >= -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            CurrentPossition = 16;
        }
    }
}