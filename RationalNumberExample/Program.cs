using RationalNumber;
using System;

namespace RationalNumberExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational r = new Rational(1, 2);
            Console.WriteLine("Object:      {0}", r.Representation);
            Console.WriteLine("Numerator:   {0}", r.Numerator);
            Console.WriteLine("Denominator: {0}", r.Denominator);
            Console.WriteLine("Value:       {0}", r.Value);
            Console.WriteLine("Quotient:    {0}", r.Quotient);
            Console.WriteLine("Remainder:   {0}", r.Remainder);

            Console.WriteLine();


            Rational a = new Rational(1, 2);
            Rational b = new Rational(a);
            double c = 0;

            Console.WriteLine("Initial: a = {0}; b = {1}", a, b);
            a += 1;
            b = 2 - b;
            Console.WriteLine("Final:   a = {0}; b = {1}", a, b);

            Console.WriteLine();

            Console.WriteLine("Initial: a = {0}; b = {1}", a, b);
            a = r / b;
            b = a * r;
            Console.WriteLine("Final:   a = {0}; b = {1}", a, b);

            Console.WriteLine();

            Console.WriteLine("Initial: a = {0}; c = {1}", a, c);
            a ^= 2;
            c = 2 ^ b;
            Console.WriteLine("Final:   a = {0}; c = {1}", a, c);

            Console.WriteLine();

            Rational d = new Rational(a - b);
            Console.WriteLine("Initial:                {0}", d);
            Console.WriteLine("Absolute value:         {0}", d.Abs);
            Console.WriteLine("Additive inverse:       {0}", -d);
            Console.WriteLine("Multiplicative inverse: {0}", ~d);

            Console.WriteLine();

            Rational s = new Rational(0);
            for (int i = 1; i < 10; i++)
            {
                s += new Rational(1, i);
            }
            Console.WriteLine("s = {0} = {1}", s, s.Value);

            Rational p = new Rational(1);
            for (int i = 1; i < 10; i++)
            {
                p *= new Rational(1, i);
            }
            Console.WriteLine("p = {0} = {1}", p, p.Value);

            Console.WriteLine();

            Console.WriteLine("{0} <  {1} : {2}", s, p, s < p);
            Console.WriteLine("{0} <= {1} : {2}", s, p, s <= p);
            Console.WriteLine("{0} == {1} : {2}", s, p, s == p);
            Console.WriteLine("{0} != {1} : {2}", s, p, s != p);
            Console.WriteLine("{0} >= {1} : {2}", s, p, s >= p);
            Console.WriteLine("{0} >  {1} : {2}", s, p, s > p);

            //Console.ReadLine();
        }
    }
}
