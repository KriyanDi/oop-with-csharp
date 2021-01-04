using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeworkTask2
{
    public interface IEnumerator
    {
        bool MoveNext();

        object Current { get; }

        void Reset();

        class CountDown : IEnumerator
        {
            int[] numbers;
            int currentPossition;

            public CountDown()
            {
                numbers = new int[] { 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
                currentPossition = 0;
            }

            public int CurrentPossition
            {
                get { return currentPossition; }
                set { currentPossition = value; }
            }

            public object Current => (currentPossition == -1) ? "CurrentPossition invalid!" : numbers[currentPossition];

            public virtual bool MoveNext()
            {
                if (currentPossition + 1 <= 17)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public virtual void Reset()
            {
                currentPossition = 0;
            }
        }
    }
}