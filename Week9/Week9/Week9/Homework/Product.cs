using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework
{
    public class Product
    {
        #region Fields
        private string description;
        private int quantity;
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse
        /// </summary>
        public Product(string descritpion, int quantity)
        {
            Description = description;
            Quantity = quantity;
        }

        /// <summary>
        /// Default
        /// </summary>
        public Product() : this("", 0)
        {

        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="product"></param>
        public Product(Product product) : this(product.Description, product.Quantity)
        {

        }
        #endregion

        #region Properties
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"{description} {quantity}";
        }
        #endregion
    }
}