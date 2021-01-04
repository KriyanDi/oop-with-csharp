using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask2
{
    class CountDownWithDefaults
    {
        public static void Test()
        {
            IEnumerator.CountDown countDown = new IEnumerator.CountDown();
            while (countDown.MoveNext())
            {
                Console.Write(countDown.Current);
                countDown.CurrentPossition++;
            }
            countDown.Reset();
        }
    }

    class CountDownWithOverride
    {
        public static void Test()
        {
            //c
            CountDownOverride countDownOverride = new CountDownOverride();
            while (countDownOverride.MoveNext())
            {
                Console.Write(countDownOverride.Current);
                countDownOverride.CurrentPossition--;
            }
            countDownOverride.Reset();
        }
    }
}
