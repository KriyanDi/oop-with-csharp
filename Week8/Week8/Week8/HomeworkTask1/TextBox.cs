using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeworkTask1
{
    public abstract class TextBox
    {
        protected string baseText;
        protected string text;

        public TextBox()
        {
            baseText = $"{(GetType())}:Type baseText";
            text = $"{(GetType())}:Type text";
        }

        public abstract void EditTextAllowed();

        public abstract void EditTextDisAllowed();

        protected virtual void TypeText()
        {
            Console.WriteLine(text); 
        }
    }
}