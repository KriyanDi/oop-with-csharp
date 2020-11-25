using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Prob7
{
    class Program
    {
        #region Fields
        private static Customer[] customers = new Customer[] {
            new Customer{ ID = 1, FirstName = "Sandeep" , LastName = "Ramani" },
            new Customer{ ID = 2, FirstName = "Dharmik" , LastName = "Chotaliya" },
            new Customer{ ID = 3, FirstName = "Nisar", LastName = "Kalia" },
            new Customer{ ID = 4, FirstName = "Ravi", LastName = "Mapara" },
            new Customer{ ID = 5, FirstName = "Hardik", LastName = "Mistry" },
            new Customer{ ID = 6, FirstName = "Sandy", LastName = "Ramani" },
            new Customer{ ID = 7, FirstName = "Jigar", LastName = "Shah" },
            new Customer{ ID = 8, FirstName = "Kaushal", LastName = "Parik" },
            new Customer{ ID = 9, FirstName = "Abhishek", LastName = "Swarnker" },
            new Customer{ ID = 10, FirstName = "Sanket", LastName = "Patel" },
            new Customer{ ID = 11, FirstName = "Dinesh", LastName = "Prajapati" },
            new Customer{ ID = 12, FirstName = "Jayesh", LastName = "Patel" },
            new Customer{ ID = 13, FirstName = "Nimesh", LastName = "Mishra" },
            new Customer{ ID = 14, FirstName = "Shiva", LastName = "Reddy" },
            new Customer{ ID = 15, FirstName = "Jasmin", LastName = "Malviya" },
            new Customer{ ID = 16, FirstName = "Haresh", LastName = "Bhanderi" },
            new Customer{ ID = 17, FirstName = "Ankit", LastName = "Ramani" },
            new Customer{ ID = 18, FirstName = "Sanket", LastName = "Shah" },
            new Customer{ ID = 19, FirstName = "Amit", LastName = "Shah" },
            new Customer{ ID = 19, FirstName = "Amit", LastName = "Shah" },
            new Customer{ ID = 19, FirstName = "Amit", LastName = "Shah" },
            new Customer{ ID = 20, FirstName = "Nilesh", LastName = "Soni" }}; 
        #endregion

        static void Main(string[] args)
        {
            //Display(SelectCustomersBetween5and15(customers), "Customers with ID between 5 and 15:");
            Display(SelectCustomersWithDistinctLastName(customers), "Customers with distinct last name:");
            //Display(SeparateCustomerDataWithCommas(customers), "Separate customer's data with commas:");
        }

        #region Methods
        //a)
        private static ParallelQuery<Customer> SelectCustomersBetween5and15(Customer[] customers)
        {
            ParallelQuery<Customer> result = customers
                .AsParallel()
                .AsOrdered()
                .Where(customer => (5 <= customer.ID && customer.ID <= 15))
                .Select(customer => customer);

            return result;
        }

        //b)
        private static ParallelQuery<Customer> SelectCustomersWithDistinctLastName(Customer[] customers)
        {
            ParallelQuery<Customer> result = customers
                .AsParallel()
                .AsOrdered()
                .Where(customer => !customers.Any(otherCustomer => (customer != otherCustomer && customer.LastName == otherCustomer.LastName)));

            return result;
        }

        //c)
        private static ParallelQuery<string> SeparateCustomerDataWithCommas(Customer[] customers)
        {
            ParallelQuery<string> result = customers
                .AsParallel()
                .AsOrdered()
                .Select(customer => $"{customer.ID}, {customer.FirstName}, {customer.LastName}");

            return result;
        }

        private static void Display(ParallelQuery<Customer> result, string title)
        {
            Console.WriteLine(title);

            Console.WriteLine("Sequential:");
            foreach (var customer in result)
            {
                Console.WriteLine($"{customer.ID} {customer.FirstName} {customer.LastName}");
            }

            Console.WriteLine();

            Console.WriteLine("Parallel:");
            Parallel.ForEach(result, customer =>
            {
                Console.WriteLine($"{customer.ID} {customer.FirstName} {customer.LastName}");
            });
            Console.WriteLine();
        }

        private static void Display(ParallelQuery<string> result, string title)
        {
            Console.WriteLine(title);

            Console.WriteLine("Sequential:");
            foreach (var customer in result)
            {
                Console.WriteLine(customer);
            }

            Console.WriteLine();

            Console.WriteLine("Parallel:");
            Parallel.ForEach(result, customer =>
            {
                Console.WriteLine(customer);
            });
            Console.WriteLine();
        } 
        #endregion
    }
}
