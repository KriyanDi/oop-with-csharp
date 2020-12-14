using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prob1;

namespace Prob1_Test
{
    public static class RectangleExtension
    {
        public static double CircleArea<T>(this T rectangle) where T : Rectangle
        {
            double horizontalSide = Math.Abs(rectangle.Points[0]["y"] - rectangle.Points[1]["y"]);
            double verticalSide = Math.Abs(rectangle.Points[0]["x"] - rectangle.Points[1]["x"]);

            double radius = Math.Sqrt(horizontalSide * horizontalSide + verticalSide * verticalSide);

            double circleArea = (Math.PI * radius * radius);
            return circleArea;            
        }
    }
}
