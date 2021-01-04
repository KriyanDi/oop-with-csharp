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
            Console.WriteLine("Creating a new product:");
            Product p1 = new Product("Christmas tree", 20);
            Console.WriteLine(p1);
            Console.WriteLine();

            Console.WriteLine("Creating a new product:");
            Product p2 = new Product("Christmas lights", 100);
            Console.WriteLine(p2);
            Console.WriteLine();

            Console.WriteLine("Creating an new employee:");
            Employee e1 = new Employee("employee1");
            Console.WriteLine(e1);
            Console.WriteLine();

            Console.WriteLine("Creating a new manager:");
            Manager m1 = new Manager("manager1");
            Console.WriteLine(m1);
            Console.WriteLine();

            Store s1 = new Store(new List<Product> { p1, p2 });

            m1.WorksAt = s1;
            e1.WorksAt = s1;

            s1.OnAppointment(e1);
            s1.OnAppointment(m1);

            Console.WriteLine("Testing store:");
            Console.WriteLine(s1);
            Console.WriteLine();

            Console.WriteLine("Testing updating quantity:");
            e1.WorksAt.OnUpdateQuantity(1, 2);
            Console.WriteLine();

            Console.WriteLine("Changed store:");
            Console.WriteLine(s1);
            Console.WriteLine();
        }
    }
}
