using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Homework
{
    public class Store : INotifyPropertyChanged
    {
        #region Fields
        public static int cnt = 0;
        private string storeName;
        private List<Product> listOfProducts;
        private Employee worker;
        private Manager manager;
        #endregion

        #region Constructor
        /// <summary>
        /// General purpouse
        /// </summary>
        /// <param name="storeName"></param>
        /// <param name="listOfProducts"></param>
        public Store(List<Product> listOfProducts)
        {
            cnt++;
            StoreName = $"Store {cnt}";
            ListOfProducts = listOfProducts;
        }
        #endregion

        #region Events
        public event EventHandler Appoint;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
        public string StoreName
        {
            get { return storeName; }
            set { storeName = value; }
        }
        public List<Product> ListOfProducts
        {
            get
            {
                return listOfProducts;
            }
            set
            {
                if (value != null && value != listOfProducts)
                {
                    Console.WriteLine($"{StoreName}: New list of products assigned to store");
                    listOfProducts = new List<Product>(value);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListOfProducts"));
                }
;
            }
        }
        public Employee Worker
        {
            get { return worker; }
            set { worker = value; }
        }
        public Manager Manager
        {
            get { return manager; }
            set { manager = value; }
        }
        #endregion

        #region Methods
        public void OnUpdateQuantity(int index, int newQty)
        {
            if (index < listOfProducts.Count)
            {
                Console.WriteLine($"PROD: { ListOfProducts[index].Description} OLD: { ListOfProducts[index].Quantity} NEW: {newQty}");
                ListOfProducts[index].Quantity = newQty;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ProductQuantity"));
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void OnAppointment(Employee employee)
        {
            if (employee != null)
            {
                switch (employee)
                {
                    case Employee empl when empl is Employee:
                        worker = new Employee(employee);
                        break;
                    case Employee empl when empl is Manager:
                        manager = new Manager((Manager)employee);
                        break;
                    default:
                        break;
                }

                Appoint.Invoke(this, employee);
            }
        }

        public override string ToString()
        {
            return $"{StoreName}";
        }
        #endregion
    }
}