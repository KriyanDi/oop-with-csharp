using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prob3
{
    class Rational
    {
        #region Fields
        private int numerator;
        private int denominator;
        private string reducedForm;
        #endregion

        #region Constructor
        /// <summary>
        /// General purpouse
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        public Rational(int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
            ReducedForm = $"{(Reduce(numerator, denominator)).Numerator} / {(Reduce(numerator, denominator)).Denominator}";
        }

        /// <summary>
        /// Default
        /// </summary>
        public Rational() : this(0, 1)
        {

        } 
        #endregion

        #region Properties
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get { return denominator; }
            set { denominator = (value != 0) ? value : 1; }
        }

        public string ReducedForm
        {
            get { return reducedForm; }
            set { reducedForm = value; }
        }
        #endregion

        #region Methods
        public static Rational AddTwoRational(Rational num1, Rational num2)
        {
            int numerator = num1.numerator * num2.denominator + num2.numerator * num1.denominator;
            int denominator = num1.denominator * num2.denominator;
            (int Numerator, int Denominator) result = Reduce(numerator, denominator);

            return new Rational(result.Numerator, result.Denominator);
        }

        public static Rational SubtractTwoRational(Rational num1, Rational num2)
        {
            int numerator = num1.numerator * num2.denominator - num2.numerator * num1.denominator;
            int denominator = num1.denominator * num2.denominator;
            (int Numerator, int Denominator) result = Reduce(numerator, denominator);

            return new Rational(result.Numerator, result.Denominator);
        }

        public static Rational MultiplyTwoRational(Rational num1, Rational num2)
        {
            int numerator = num1.numerator * num2.numerator;
            int denominator = num1.denominator * num2.denominator;
            (int Numerator, int Denominator) result = Reduce(numerator, denominator);

            return new Rational(result.Numerator, result.Denominator);
        }

        public static Rational DevideTwoRational(Rational num1, Rational num2)
        {
            int numerator = num1.numerator * num2.denominator;
            int denominator = num1.denominator * num2.numerator;
            (int Numerator, int Denominator) result = Reduce(numerator, denominator);

            return new Rational(result.Numerator, result.Denominator);
        }

        public void DisplayNormal()
        {
            Console.WriteLine($"{numerator} / {denominator}");
        }

        public void DisplayFloatingPoint()
        {
            float result = (float)numerator / (float)denominator;
            Console.WriteLine($"Floating point: {result}");
        }

        private static (int Numerator, int Denominator) Reduce(int numerator, int denominator)
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            (int Numerator, int Denominator) result = (numerator / gcd, denominator / gcd);
            return result;
        }

        private static int GCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }

        public override string ToString()
        {
            return $"{reducedForm}";
        }
        #endregion
    }
}
