using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextChangeLib
{
    public class TextChangeEventArgs : EventArgs
    {
        #region Fields
        private List<string> code;
        #endregion

        #region Constructors
        public TextChangeEventArgs(List<string> code)
        {
            Code = code;
        }
        #endregion

        #region Properties
        public List<string> Code
        {
            get
            {
                List<string> temp = new List<string>();
                foreach (var item in code)
                {
                    temp.Add(item);
                }

                return temp;
            }

            set 
            { 
                if(value != null)
                {
                    List<string> temp = new List<string>();
                    foreach (var item in value)
                    {
                        temp.Add(item);
                    }

                    code = temp; 
                }
                else
                {
                    throw new ArgumentNullException("Value is Null!");
                }
            }
        } 
        #endregion
    }

    public delegate void TextChangeEventHandler(object o, TextChangeEventArgs e);
}
