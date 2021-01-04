using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex4
{
    public class Fahrenheit : Temperature
    {
        public Fahrenheit(float temp) : base(temp) { }

        public static implicit operator Fahrenheit(float Temp)
        {
            return new Fahrenheit(Temp);
        }

        public static explicit operator Fahrenheit(Celsius C)
        {
            return new Fahrenheit(((C.Temp * 9) / 5) + 32);
        }

        public static implicit operator float(Fahrenheit F)
        {
            return F.Temp;
        }
    }
}