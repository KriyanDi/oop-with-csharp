using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTask3
{
    public class RichTextBox : TextBox
    {
        protected override void Undo()
        {
            Console.WriteLine($"{(GetType())}.Undo");
        }
    }
}