using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob2
{
    class Program
    {
        static void Main(string[] args)
        {
            //List Box Test

            ListBoxText myListBox = new ListBoxText();

            Console.WriteLine($"Currently stored lists: {myListBox.Count}");

            Console.WriteLine();

            Console.WriteLine("Adding 5 lists");
            myListBox.AddList("Clean my room");
            myListBox.AddList("Debug my code");
            myListBox.AddList("Walk outside");
            myListBox.AddList("Drive my car");
            myListBox.AddList("Make a dinner");

            Console.WriteLine($"Currently stored lists: {myListBox.Count}");

            Console.WriteLine();

            Console.WriteLine("Showing list by index");
            Console.WriteLine( $"index 0: {myListBox[0]}" );
            Console.WriteLine( $"index 2: {myListBox[2]}" );
            Console.WriteLine( $"index 4: {myListBox[4]}" );
            Console.WriteLine( $"index 1: {myListBox[1]}" );
            Console.WriteLine( $"index 3: {myListBox[3]}" );
            
        }
    }
}
