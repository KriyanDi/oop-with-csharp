using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Homework
{
    public class Employee : EventArgs
    {
        #region Fields
        private string name;
        private Store worksAt;
        #endregion

        #region Constructors
        /// <summary>
        /// General purposue
        /// </summary>
        public Employee(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Default
        /// </summary>
        public Employee() : this("")
        {

        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="employee"></param>
        public Employee(Employee employee) : this(employee.Name)
        {

        }
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Store WorksAt
        {
            get { return worksAt; }
            set 
            { 
                if(value != null)
                {
                    worksAt = value;
                    worksAt.Appoint += GetAppointed;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }
        #endregion

        #region Methods
        public virtual void GetAppointed(object s, EventArgs e)
        {
            worksAt = (Store)s;
            worksAt.PropertyChanged += ManageListOfProducts;
            Console.WriteLine($"POS: {GetType()} STORE_NAME: {worksAt.StoreName}");
        }

        protected void ManageListOfProducts(object s, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ListOfProducts")
            {
                Console.WriteLine($"{GetType()} {e.PropertyName}");
            }
        }

        public void ManageQty(Product p, int qty)
        {
            int index = 0;
            foreach (var product in WorksAt.ListOfProducts)
            {
                if (product.Description == p.Description)
                {
                    WorksAt.OnUpdateQuantity(index, qty);
                    return;
                }

                index++;
            }

            throw new ArgumentException("Argument not found");
        }

        public override string ToString()
        {
            return $"{name} {worksAt}";
        } 
        #endregion
    }
}