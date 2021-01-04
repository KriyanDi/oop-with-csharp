using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTask2
{
    public interface IEnumeratorExplicit
    {
        bool MoveNext();

        object Current { get; }

        void Reset();

        class CountDownExplict : IEnumeratorExplicit
        {
            int[] numbers;
            int currentPossition;

            public CountDownExplict()
            {
                numbers = new int[] { 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
                currentPossition = 0;
            }

            public int CurrentPossition
            {
                get { return currentPossition; }
                set { currentPossition = value; }
            }


            object IEnumeratorExplicit.Current => (currentPossition == -1) ? "CurrentPossition invalid!" : numbers[currentPossition];

            bool IEnumeratorExplicit.MoveNext()
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
            
            void IEnumeratorExplicit.Reset()
            {
                currentPossition = 0;
            }
        }
    }
}
