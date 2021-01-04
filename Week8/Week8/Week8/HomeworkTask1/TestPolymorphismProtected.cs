using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeworkTask1
{
    public class TestPolymorphismProtected
    {
        static void Main(string[] args)
        {
            TextBox[] textBoxes = new TextBox[]
            {
                new EditTextBox(),
                new RichTextBox(),
                new MultiLineTextBox()
            };

            foreach (var item in textBoxes)
            {
                //item.TypeText(); //заради нивото на протекция не можем да го достъпим
                item.EditTextAllowed();
                Console.WriteLine();
            }
        }
    }
}