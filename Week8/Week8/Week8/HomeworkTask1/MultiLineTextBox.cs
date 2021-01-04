using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeworkTask1
{
    public class MultiLineTextBox : TextBox
    {
        new protected string text;

        public override void EditTextAllowed()
        {
            base.TypeText();
            Console.WriteLine(base.text);
            Console.WriteLine(base.baseText);
        }

        public override void EditTextDisAllowed()
        {
            EditTextBox editTextBox = new EditTextBox();
            //((TextBox)editTextBox).TypeText(); 
            //((TextBox)editTextBox).text = "test"; 
            //((TextBox)editTextBox).baseText = "test"; 
        }

        protected override void TypeText()
        {
            Console.WriteLine(text);
        }
    }
}