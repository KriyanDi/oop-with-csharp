using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob1
{
    public class Point<T>
    {
        #region Fields
        private T[] coordinates;
        private string[] coordinatesNames = new string[] { "x", "y" };
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse
        /// </summary>
        /// <param name="coordinates"></param>
        public Point(T[] coordinates)
        {
            Coordinates = coordinates;
        }

        /// <summary>
        /// Default
        /// </summary>
        public Point() : this(new T[2])
        {

        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="point"></param>
        public Point(Point<T> point) : this(new T[] { point["x"], point["y"] })
        {

        } 
        #endregion

        #region Properties
        public T[] Coordinates
        {
            get { return new T[] { coordinates[0], coordinates[1] }; }
            set { coordinates = (value != null && value.Length == 2) ? new T[] { value[0], value[1] } : new T[2]; }
        }

        public T this[string index]
        {
            get
            {
                switch (index)
                {
                    case "x":
                        return coordinates[0];
                    case "y":
                        return coordinates[1];
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case "x":
                        coordinates[0] = value;
                        break;
                    case "y":
                        coordinates[1] = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"[{this["x"]} , {this["y"]}]";
        } 
        #endregion
    }
}
