using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter phrase: ");
            string text = Console.ReadLine();

            int key = 1;
            string cipherText;
            string planeText;

            //top left counter clockwise spiraling inwards
            RouteCipher routeCipher1 = new RouteCipher(key);
            cipherText = routeCipher1.Encrypt(text);
            Console.WriteLine($"Cipher text: {cipherText}");

            planeText = routeCipher1.Decrypt(cipherText);
            Console.WriteLine($"Plane text: {planeText}");

            //bottom right counter clockwise spiraling inwards
            RouteCipher routeCipher2 = new RouteCipher(-key);
            cipherText = routeCipher2.Encrypt(text);
            Console.WriteLine($"Cipher text: {cipherText}");

            planeText = routeCipher2.Decrypt(cipherText);
            Console.WriteLine($"Plane text: {planeText}");
        }
    }
}
