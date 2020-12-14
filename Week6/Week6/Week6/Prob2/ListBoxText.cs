using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob2
{
    public class ListBoxText
    {
        #region Fields
        private List<string> myStrings;
        #endregion

        public ListBoxText()
        {
            myStrings = new List<string>();
        }

        #region Properties
        public int Count 
        { get
            { return myStrings.Count(); }
        }

        public string this[int index]
        {
            get
            {
                if (0 <= index && index <= myStrings.Count)
                {
                    return myStrings[index];
                }
                else
                {
                    return "Invalid index";
                }
            }

            set
            {
                if (0 <= index && index <= myStrings.Count)
                {
                    myStrings[index] = value;
                }
            }
        }
        #endregion

        #region Methods
        public void AddList(string str)
        {
            myStrings.Add(str);
        } 
        #endregion
    }
}
