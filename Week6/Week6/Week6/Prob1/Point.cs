using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob1
{
    public class Point
    {
        #region Fields
        private int[] coordinates;
        private string[] coordinatesName = new string[] { "x", "y" };
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse
        /// </summary>
        /// <param name="coordinates"></param>
        public Point(int[] coordinates)
        {
            Coordinates = coordinates;
        }

        /// <summary>
        /// Default 
        /// </summary>
        public Point() : this(new int[2])
        {

        }

        /// <summary>
        /// Copy 
        /// </summary>
        /// <param name="point"></param>
        public Point(Point point) : this(point.coordinates)
        {

        }
        #endregion

        #region Properties
        public int[] Coordinates
        {
            get
            {
                return new int[] { coordinates[0], coordinates[1] };
            }

            set
            {
                coordinates = (value != null && value.Length == 2) ?
                    new int[] { value[0], value[1] } :
                    new int[2];
            }
        }

        public int this[string index]
        {
            get
            {
                switch (index.ToLower())
                {
                    case "x":
                        return Coordinates[0];
                    case "y":
                        return Coordinates[1];
                    default:
                        return -1;
                }
            }

            set
            {
                switch (index.ToLower())
                {
                    case "x":
                        Coordinates[0] = (int)value;
                        break;
                    case "y":
                        coordinates[1] = (int)value;
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Coordinates: [{coordinates[0]} , {coordinates[1]}]";
        }
        #endregion
    }
}
