using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prob1;

namespace Prob1_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Point - Test

            //General purpouse constructor
            Point point = new Point(new int[] { 10, 2 });
            Point point1 = new Point(new int[] { 1, 20 });
            Console.WriteLine(point1.ToString());
            Console.WriteLine($"X: {point1["x"].ToString()}");
            Console.WriteLine($"Y: {point1["y"].ToString()}");

            Console.WriteLine();

            //Default constructor
            Point point2 = new Point();
            Console.WriteLine(point2.ToString());
            Console.WriteLine($"X: {point2["x"].ToString()}");
            Console.WriteLine($"Y: {point2["y"].ToString()}");

            Console.WriteLine();

            //Copy constructor
            Point point3 = new Point(point1);
            Console.WriteLine(point3.ToString());
            Console.WriteLine($"X: {point3["x"].ToString()}");
            Console.WriteLine($"Y: {point3["y"].ToString()}");

            //Rectangle - Test

            //General purpouse constructor
            Rectangle rectangle1 = new Rectangle(new Point[] { new Point(point), new Point(point1) });
            Console.WriteLine(rectangle1.ToString());
            Console.WriteLine($"Perimeter: {rectangle1.Perimeter()}");

            Console.WriteLine();

            //Defaul constructor
            Rectangle rectangle2 = new Rectangle();
            Console.WriteLine(rectangle2.ToString());
            Console.WriteLine($"Perimeter: {rectangle2.Perimeter()}");

            Console.WriteLine();

            //Copy constructor
            Rectangle rectangle3 = new Rectangle(rectangle1);
            Console.WriteLine(rectangle3.ToString());
            Console.WriteLine($"Perimeter: {rectangle3.Perimeter()}");
            Console.WriteLine($"Circle Area: {rectangle3.CircleArea()}");
        }
    }
}
