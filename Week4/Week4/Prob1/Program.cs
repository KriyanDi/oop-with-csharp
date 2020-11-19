using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob1
{
    class Program
    {
        static void Main(string[] args)
        {
            //possible commands are: code, decode
            Console.Write("What do you want to do: ");
            string command = Console.ReadLine();

            Console.Write("Type the word: ");
            string word = Console.ReadLine();

            CaesarCipher caesarCipher = new CaesarCipher();

            switch (command)
            {
                case "code":
                    Console.WriteLine(caesarCipher.CodeCaesarCipher(word));
                    break;
                case "decode":
                    Console.WriteLine(caesarCipher.DecodeCaesarCipher(word));
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    break;
            }
        }
    }
}
