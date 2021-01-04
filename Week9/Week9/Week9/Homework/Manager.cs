using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Homework
{
    public class Manager : Employee
    {
        #region Constructors
        /// <summary>
        /// General purpouse
        /// </summary>
        /// <param name="name"></param>
        /// <param name="worksAt"></param>
        public Manager(string name)
            : base(name)
        {

        }

        /// <summary>
        /// Default
        /// </summary>
        public Manager()
            : base("")
        {

        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="manager"></param>
        public Manager(Manager manager)
            : base(manager.Name)
        {

        }

        #endregion

        #region Methods
        public override void GetAppointed(object s, EventArgs e)
        {
            WorksAt = (Store)s;
            WorksAt.PropertyChanged += ManageListOfProducts;
            WorksAt.PropertyChanged += ManageProductQuantity;
            Console.WriteLine($"POS: {GetType()} STORE_NAME: {WorksAt.StoreName}");
        }

        public void ManageProductQuantity(object s, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ProductQuantity")
            {
                Console.WriteLine($"{GetType()} {e.PropertyName}");
            }
        }

        public override string ToString()
        {
            return $"MANAGER: {Name} STORE: {WorksAt}";
        }
        #endregion
    }
}