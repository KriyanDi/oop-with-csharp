using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex4
{
    public class Celsius : Temperature
    {
        public Celsius(float temp) : base(temp) { }

        public static implicit operator Celsius(float Temp)
        {
            return new Celsius(Temp);
        }

        public static explicit operator Celsius(Fahrenheit F)
        {
            return new Celsius(((F.Temp - 32) / 9) * 5);
        }

        public static implicit operator float(Celsius C)
        {
            return C.Temp;
        }
    }
}