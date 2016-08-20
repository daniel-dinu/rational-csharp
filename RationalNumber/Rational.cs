using System;

namespace RationalNumber
{
    public class Rational
    {
        private const string DenominatorZeroDivisionErrorMessage = "The denominator of a rational number can not be zero!";

        private const string DividerZeroDivisionErrorMessage = "The divider cannot be 0!";

        private const string ZeroToNegativePowerZeroDivisionErrorMessage = "0 cannot be raised to a negative power!";

        private const string NegativeIntegerToFractionalPowerErrorMessage = "Negative number cannot be raised to a fractional power!";


        private readonly long numerator;

        private readonly long denominator;


        private static long Modulo(long a, long b)
        {
            long result = a % b;

            if ((a < 0 && b > 0) || (a > 0 && b < 0))
            {
                result += b;
            }

            return result;
        }

        private static long Gcd(long a, long b)
        {
            while (0 != b)
            {
                long r = Modulo(a, b);
                a = b;
                b = r;
            }

            return a;
        }

        private static long Power(long x, long power)
        {
            long ret = 1;

            while (0 < power)
            {
                if (1 == (power & 1))
                {
                    ret *= x;
                }
                x *= x;
                power >>= 1;
            }

            return ret;
        }

        public Rational(long numerator = 0, long denominator = 1)
        {
            if (0 == denominator)
            {
                throw new DivideByZeroException(DenominatorZeroDivisionErrorMessage);
            }

            long divisor = Gcd(numerator, denominator);

            this.numerator = numerator / divisor;
            this.denominator = denominator / divisor;
        }

        public Rational(long a, Rational b) : this(a * b.denominator, b.numerator)
        {

        }

        public Rational(Rational a, long b = 1) : this(a.numerator, a.denominator * b)
        {

        }

        public Rational(Rational a, Rational b) : this(a.numerator * b.denominator, a.denominator * b.numerator)
        {

        }


        public long Numerator => numerator;

        public long Denominator => denominator;

        public double Value => numerator / (denominator * 1.0);

        public long Quotient => numerator / denominator;

        public long Remainder => Modulo(numerator, denominator);

        public string Representation => this.GetType().Name + "(" + numerator + ", " + denominator + ")";

        public override string ToString()
        {
            if (1 == denominator)
            {
                return numerator.ToString();
            }
            return numerator + "/" + denominator;
        }

        public Rational Abs => new Rational(Math.Abs(numerator), Math.Abs(denominator));


        public static Rational operator -(Rational r)
        {
            return new Rational(-r.numerator, r.denominator);
        }

        public static Rational operator +(Rational r)
        {
            return new Rational(r.numerator, r.denominator);
        }

        public static Rational operator ~(Rational r)
        {
            return new Rational(r.denominator, r.numerator);
        }


        public static bool operator ==(Rational r1, Rational r2)
        {
            if (ReferenceEquals(r1, r2))
            {
                return true;
            }

            if ((null == (object)r1) || (null == (object)r2))
            {
                return false;
            }

            return r1.numerator * r2.denominator == r1.denominator * r2.numerator;
        }

        public static bool operator !=(Rational r1, Rational r2)
        {
            if (ReferenceEquals(r1, r2))
            {
                return false;
            }

            if ((null == (object)r1) || (null == (object)r2))
            {
                return true;
            }

            return r1.numerator * r2.denominator != r1.denominator * r2.numerator;
        }

        public override bool Equals(object o)
        {
            Rational r = o as Rational;
            if (null == (object)r)
            {
                return false;
            }

            return numerator == r.Numerator && denominator == r.Denominator;
        }

        public override int GetHashCode()
        {
            return (int)((numerator ^ denominator) % int.MaxValue);
        }

        public static bool operator <(Rational r1, Rational r2)
        {
            return r1.numerator * r2.denominator < r1.denominator * r2.numerator;
        }

        public static bool operator >(Rational r1, Rational r2)
        {
            return r1.numerator * r2.denominator > r1.denominator * r2.numerator;
        }

        public static bool operator <=(Rational r1, Rational r2)
        {
            return r1.numerator * r2.denominator <= r1.denominator * r2.numerator;
        }

        public static bool operator >=(Rational r1, Rational r2)
        {
            return r1.numerator * r2.denominator >= r1.denominator * r2.numerator;
        }


        public static Rational operator +(Rational r1, Rational r2)
        {
            long numerator = r1.numerator * r2.denominator + r1.denominator * r2.numerator;
            long denominator = r1.denominator * r2.denominator;

            return new Rational(numerator, denominator);
        }

        public static Rational operator +(Rational r1, long r2)
        {
            Rational r = new Rational(r2);

            return r1 + r;
        }

        public static Rational operator +(long r1, Rational r2)
        {
            Rational r = new Rational(r1);

            return r + r2;
        }

        public static Rational operator -(Rational r1, Rational r2)
        {
            long numerator = r1.numerator * r2.denominator - r1.denominator * r2.numerator;
            long denominator = r1.denominator * r2.denominator;

            return new Rational(numerator, denominator);
        }

        public static Rational operator -(Rational r1, long r2)
        {
            Rational r = new Rational(r2);

            return r1 - r;
        }

        public static Rational operator -(long r1, Rational r2)
        {
            Rational r = new Rational(r1);

            return r - r2;
        }

        public static Rational operator *(Rational r1, Rational r2)
        {
            long numerator = r1.numerator * r2.numerator;
            long denominator = r1.denominator * r2.denominator;

            return new Rational(numerator, denominator);
        }

        public static Rational operator *(Rational r1, long r2)
        {
            long numerator = r1.numerator * r2;
            long denominator = r1.denominator;

            return new Rational(numerator, denominator);
        }

        public static Rational operator *(long r1, Rational r2)
        {
            long numerator = r1 * r2.numerator;
            long denominator = r2.denominator;

            return new Rational(numerator, denominator);
        }

        public static Rational operator /(Rational r1, Rational r2)
        {
            if (0 == r2.numerator)
            {
                throw new DivideByZeroException(DividerZeroDivisionErrorMessage);
            }

            long numerator = r1.numerator * r2.denominator;
            long denominator = r1.denominator * r2.numerator;

            return new Rational(numerator, denominator);
        }

        public static Rational operator /(Rational r1, long r2)
        {
            if (0 == r2)
            {
                throw new DivideByZeroException(DividerZeroDivisionErrorMessage);
            }

            long numerator = r1.numerator;
            long denominator = r1.denominator * r2;

            return new Rational(numerator, denominator);
        }

        public static Rational operator /(long r1, Rational r2)
        {
            if (0 == r2.numerator)
            {
                throw new DivideByZeroException(DividerZeroDivisionErrorMessage);
            }

            long numerator = r1 * r2.denominator;
            long denominator = r2.numerator;

            return new Rational(numerator, denominator);
        }

        public static Rational operator ^(Rational r, long power)
        {
            if (0 > power && 0 == r.numerator)
            {
                throw new DivideByZeroException(ZeroToNegativePowerZeroDivisionErrorMessage);
            }

            if (0 == power && 0 == r.numerator)
            {
                return new Rational(r.numerator, r.denominator);
            }

            long numerator;
            long denominator;

            if (0 > power)
            {
                numerator = Power(r.denominator, -power);
                denominator = Power(r.numerator, -power);
            }
            else
            {
                numerator = Power(r.numerator, power);
                denominator = Power(r.denominator, power);
            }

            return new Rational(numerator, denominator);
        }

        public static double operator ^(long x, Rational r)
        {
            if (0 > x && 1 != r.denominator)
            {
                throw new ArgumentException(NegativeIntegerToFractionalPowerErrorMessage);
            }

            return Math.Pow(x, r.Value);
        }
    }
}
