using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkTask3
{
    public class TextBox : IUndoable
    {
        protected virtual void Undo()
        {
            Console.WriteLine($"{(GetType())}.Undo");
        }

        void IUndoable.Undo()
        {
            Console.WriteLine("IUndoable");
            Undo();
        }
    }
}