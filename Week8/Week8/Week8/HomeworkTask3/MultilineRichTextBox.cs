using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTask3
{
    public class MultilineRichTextBox : RichTextBox
    {
        private static void Main(string[] args)
        {
            PolyTest();

        }

        protected override void Undo()
        {
            Console.WriteLine($"{(GetType())}.Undo");
        }

        private static void PolyTest()
        {
            RichTextBox richTextBox = new RichTextBox();
            MultilineRichTextBox multilineRichTextBox = new MultilineRichTextBox();

            ((IUndoable)richTextBox).Undo();
            ((IUndoable)multilineRichTextBox).Undo();
            multilineRichTextBox.Undo();

            //ъпкаствайки до типа на интерфейса, само тогава имаме достъп до функцията Undo, която се вика от интерфейса, а резултатът е такъв защото в геттайп се връща типа на това към което сочи референтната променлива
        }
    }
}