using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeworkTask1
{
    public class EditTextBox : TextBox
    {
        new protected string text;

        public override void EditTextAllowed()
        {
            base.TypeText();
            Console.WriteLine(base.text);
            Console.WriteLine(baseText);
        }

        public override void EditTextDisAllowed()
        {
            EditTextBox editTextBox = new EditTextBox();
            //((TextBox)editTextBox).TypeText(); // заради нивото на протекция не можем да достъпим този елемент 
            //((TextBox)editTextBox).text = "test"; // заради нивото на протекция не можем да достъпим този елемент 
            //((TextBox)editTextBox).baseText = "test"; // заради нивото на протекция не можем да достъпим този елемент 
        }

        protected override void TypeText()
        {
            Console.WriteLine(text);
        }
    }
}