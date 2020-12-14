using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob1
{
    public class Rectangle
    {
        #region Fields
        private Point[] points;
        #endregion

        #region Constructors
        /// <summary>
        /// General purpouse
        /// </summary>
        /// <param name="points"></param>
        public Rectangle(Point[] points)
        {
            Points = points;
        }

        /// <summary>
        /// Default
        /// </summary>
        public Rectangle() : this(new Point[] { new Point(), new Point() })
        {

        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="rectangle"></param>
        public Rectangle(Rectangle rectangle) : this(rectangle.points)
        {

        } 
        #endregion

        #region Properties
        public Point[] Points
        {
            get
            {
                return new Point[] { points[0], points[1] };
            }

            set
            {
                points = (value != null && value.Length == 2) ?
                    new Point[] { value[0], value[1] } :
                    new Point[] { new Point(), new Point() };
            }

        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return $"Coordinates: {points[0].ToString()} , {points[1].ToString()}";
        }

        public double Perimeter()
        {
            double horizontalSide = Math.Abs(points[0]["y"] - points[1]["y"]); 
            double verticalSide = Math.Abs(points[0]["x"] - points[1]["x"]);

            Console.WriteLine($"Sides: {horizontalSide} {verticalSide}");

            double perimeter = 2 * (horizontalSide + verticalSide);
            return perimeter;
        }
        #endregion
    }
}
