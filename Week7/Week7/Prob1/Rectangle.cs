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
        private Point<double> topLeft;
        private double length;
        private double width;
        private string[] attributesNames = new string[] { "x", "y", "w", "h" };
        #endregion

        #region Constructors
        /// <summary>
        /// Genreal purpouse
        /// </summary>
        /// <param name="corners"></param>
        public Rectangle(Point<double> topLeft, double length, double width)
        {
            TopLeft = topLeft;
            Length = length;
            Width = width;
        }

        /// <summary>
        /// Default
        /// </summary>
        public Rectangle() : this(new Point<double>(), 0 ,0)
        {

        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="rectangle"></param>
        public Rectangle(Rectangle rectangle) : this(new Point<double>(rectangle.topLeft), rectangle.length, rectangle.width )
        {

        }
        #endregion

        #region Properties
        public Point<double> TopLeft
        {
            get { return new Point<double>(topLeft); }
            set { topLeft = (value != null) ? new Point<double>(value) : new Point<double>(); }
        }

        public double Length
        {
            get { return length; }
            set { length = (0 <= value) ? value : 0; }
        }

        public double Width
        {
            get { return width; }
            set { width = (0 <= value) ? value : 0; }
        }

        public double this[string index]
        {
            get
            {
                switch (index)
                {
                    case "x":
                        return topLeft["x"];
                    case "y":
                        return topLeft["y"];
                    case "w":
                        return width;
                    case "l":
                        return length;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case "x":
                        topLeft["x"] = value;
                        break;
                    case "y":
                        topLeft["y"] = value;
                        break;
                    case "w":
                        width = (0 <= value) ? value : throw new ArgumentException();
                        break;
                    case "l":
                        length = (0 <= value) ? value : throw new ArgumentException();
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
        #endregion

        #region Methods
        public double Perimeter()
        {
            double result = 2 * (length + width);
            return result;
        }

        public double Area()
        {
            double result = length * width;
            return result;
        }

        public override string ToString()
        {
            return $"{topLeft} , w: {width} , l: {length}";
        }
        #endregion
    }
}
