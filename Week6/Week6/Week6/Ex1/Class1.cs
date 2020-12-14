using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class Class1
    {
        //indexers

        int[] values = new int[] { 1, 2, 3 };

        public int this[int index]
        {
            get 
            {
                //check if index is valid
                if (0<=index && index <= values.Length)
                {
                    return values[index];
                }
                else
                {
                    //error
                    return -1;
                }
            }
            set 
            {
                //check if index is valid
                if (0 <= index && index <= values.Length)
                {
                    values[index] = value;
                }
                //error?
            }
        }
    }
}
