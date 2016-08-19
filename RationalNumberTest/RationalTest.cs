using NUnit.Framework;
using RationalNumber;
using System;

namespace RationalNumberTest
{
    [TestFixture]
    public class RationalTest
    {
        private static readonly TestDelegate[] ConstructorZeroDivisionErrorTestCases = {
            () => new Rational(1, 0),
            () => new Rational(new Rational(), 0),
            () => new Rational(new Rational(), new Rational())
        };

        [Test, TestCaseSource(nameof(ConstructorZeroDivisionErrorTestCases))]
        public void TestConstructorZeroDivisonError(TestDelegate action)
        {
            Assert.Throws<DivideByZeroException>(action);
        }


        private static readonly object[] ConstructorIntegerIntegerTestCases = {
            new object[] { 1, 2, 1, 2 },
            new object[] { 2, 4, 1, 2 },
            new object[] { -1, 2, -1, 2 },
            new object[] { -2, 4, -1, 2 },
            new object[] { 1, -2, -1, 2 },
            new object[] { 2, -4, -1, 2 },
            new object[] { -1, -2, 1, 2 },
            new object[] { -2, -4, 1, 2 }
        };

        [Test, TestCaseSource(nameof(ConstructorIntegerIntegerTestCases))]
        public void TestConstructorIntegerInteger(long numerator, long denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = new Rational(numerator, denominator);
            Assert.AreEqual(expectedNumerator, r.Numerator);
            Assert.AreEqual(expectedDenominator, r.Denominator);
        }


        private static readonly object[] ConstructorIntegerRationalTestCases = {
            new object[] { 1, new Rational(1, 2), 2, 1 },
            new object[] { 2, new Rational(1, 2), 4, 1 },
            new object[] { -1, new Rational(1, 2), -2, 1 },
            new object[] { -2, new Rational(1, 2), -4, 1 },
            new object[] { 1, new Rational(-1, 2), -2, 1 },
            new object[] { 2, new Rational(-1, 2), -4, 1 },
            new object[] { 1, new Rational(1, -2), -2, 1 },
            new object[] { 2, new Rational(1, -2), -4, 1 },
            new object[] { -1, new Rational(1, 2), -2, 1 },
            new object[] { -2, new Rational(1, 2), -4, 1 }
        };

        [Test, TestCaseSource(nameof(ConstructorIntegerRationalTestCases))]
        public void TestConstructorIntegerRational(long numerator, Rational denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = new Rational(numerator, denominator);
            Assert.AreEqual(expectedNumerator, r.Numerator);
            Assert.AreEqual(expectedDenominator, r.Denominator);
        }


        private static readonly object[] ConstructorRationalIntegerTestCases = {
            new object[] { new Rational(1, 2), 1, 1, 2 },
            new object[] { new Rational(1, 2), 2, 1, 4 },
            new object[] { new Rational(-1, 2), 1, -1, 2 },
            new object[] { new Rational(-1, 2), 2, -1, 4 },
            new object[] { new Rational(1, -2), 1, -1, 2 },
            new object[] { new Rational(1, -2), 2, -1, 4 },
            new object[] { new Rational(1, 2), -1, -1, 2 },
            new object[] { new Rational(1, 2), -2, -1, 4 },
            new object[] { new Rational(-1, 2), -1, 1, 2 },
            new object[] { new Rational(-1, 2), -2, 1, 4 }
        };

        [Test, TestCaseSource(nameof(ConstructorRationalIntegerTestCases))]
        public void TestConstructorRationalInteger(Rational numerator, long denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = new Rational(numerator, denominator);
            Assert.AreEqual(expectedNumerator, r.Numerator);
            Assert.AreEqual(expectedDenominator, r.Denominator);
        }


        private static readonly object[] ConstructorRationalRationalTestCases = {
            new object[] { new Rational(1, 2), new Rational(1, 2), 1, 1 },
            new object[] { new Rational(1, 2), new Rational(1, 4), 2, 1 },
            new object[] { new Rational(1, 4), new Rational(1, 2), 1, 2 },
            new object[] { new Rational(-1, 2), new Rational(1, 2), -1, 1 },
            new object[] { new Rational(-1, 2), new Rational(1, 4), -2, 1 },
            new object[] { new Rational(-1, 4), new Rational(1, 2), -1, 2 },
            new object[] { new Rational(1, 2), new Rational(-1, 2), -1, 1 },
            new object[] { new Rational(1, 2), new Rational(-1, 4), -2, 1 },
            new object[] { new Rational(1, 4), new Rational(-1, 2), -1, 2 },
            new object[] { new Rational(-1, 2), new Rational(-1, 2), 1, 1 },
            new object[] { new Rational(-1, 2), new Rational(-1, 4), 2, 1 },
            new object[] { new Rational(-1, 4), new Rational(-1, 2), 1, 2 }
        }; 

        [Test, TestCaseSource(nameof(ConstructorRationalRationalTestCases))]
        public void TestConstructorRationalRational(Rational numerator, Rational denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = new Rational(numerator, denominator);
            Assert.AreEqual(expectedNumerator, r.Numerator);
            Assert.AreEqual(expectedDenominator, r.Denominator);
        }


        private static readonly object[] KnownTestCases = {
            new object[] { 1, 2, 1, 2 },
            new object[] { -1, 2, -1, 2 },
            new object[] { 1, -2, -1, 2 },
            new object[] { -1, -2, 1, 2 },

            new object[] { 2, 4, 1, 2 },
            new object[] { -2, 4, -1, 2 },
            new object[] { 2, -4, -1, 2 },
            new object[] { -2, -4, 1, 2 },

            new object[] { 2, 1, 2, 1 },
            new object[] { -2, 1, -2, 1 },
            new object[] { 2, -1, -2, 1 },
            new object[] { -2, -1, 2, 1 },

            new object[] { 4, 2, 2, 1 },
            new object[] { -4, 2, -2, 1 },
            new object[] { 4, -2, -2, 1 },
            new object[] { -4, -2, 2, 1 }
        };

        [Test, TestCaseSource(nameof(KnownTestCases))]
        public void TestConstructorNumerator(long numerator, long denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = new Rational(numerator, denominator);
            Assert.AreEqual(expectedNumerator, r.Numerator);
        }


        [Test, TestCaseSource(nameof(KnownTestCases))]
        public void TestConstructorDenominator(long numerator, long denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = new Rational(numerator, denominator);
            Assert.AreEqual(expectedDenominator, r.Denominator);
        }


        [Test, TestCaseSource(nameof(KnownTestCases))]
        public void TestValue(long numerator, long denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = new Rational(numerator, denominator);
            double expectedValue = expectedNumerator / (expectedDenominator * 1.0);
            Assert.AreEqual(expectedValue, r.Value);
        }


        [Test, TestCaseSource(nameof(KnownTestCases))]
        public void TestQuotient(long numerator, long denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = new Rational(numerator, denominator);
            long expectedValue = expectedNumerator / expectedDenominator;
            Assert.AreEqual(expectedValue, r.Quotient);
        }


        private static long Modulo(long a, long b)
        {
            long result = a % b;

            if ((a < 0 && b > 0) || (a > 0 && b < 0))
            {
                result += b;
            }

            return result;
        }

        private static readonly object[] ModuloTestCases = {
            new object[] { 1, 2, 1 },
            new object[] { 4, 3, 1 },

            new object[] { 1, -2, -1 },
            new object[] { 4, -3, -2 },

            new object[] { -1, 2, 1 },
            new object[] { -4, 3, 2 },

            new object[] { -1, -2, -1 },
            new object[] { -4, -3, -1 },
        };

        [TestCaseSource(nameof(ModuloTestCases))]
        public void TestModulo(long a, long b, long expectedValue)
        {
            Assert.AreEqual(expectedValue, Modulo(a, b));
        }


        [TestCaseSource(nameof(KnownTestCases))]
        public void TestRemainder(long numerator, long denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = new Rational(numerator, denominator);
            long expectedValue = Modulo(expectedNumerator, expectedDenominator);
            Assert.AreEqual(expectedValue, r.Remainder);
        }


        [Test, TestCaseSource(nameof(KnownTestCases))]
        public void TestRepresentation(long numerator, long denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = new Rational(numerator, denominator);
            string expectedValue = "Rational(" + expectedNumerator + ", " + expectedDenominator + ")";
            Assert.AreEqual(expectedValue, r.Representation);
        }


        [Test, TestCaseSource(nameof(KnownTestCases))]
        public void TestToString(long numerator, long denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = new Rational(numerator, denominator);

            string expectedValue;
            if (1 == expectedDenominator)
            {
                expectedValue = expectedNumerator.ToString();
            }
            else
            {
                expectedValue = expectedNumerator + "/" + expectedDenominator;
            }

            Assert.AreEqual(expectedValue, r.ToString());
        }


        [Test, TestCaseSource(nameof(KnownTestCases))]
        public void TestMinus(long numerator, long denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = -new Rational(numerator, denominator);
            Assert.AreEqual(-expectedNumerator, r.Numerator);
            Assert.AreEqual(expectedDenominator, r.Denominator);
        }


        [Test, TestCaseSource(nameof(KnownTestCases))]
        public void TestPlus(long numerator, long denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = +new Rational(numerator, denominator);
            Assert.AreEqual(expectedNumerator, r.Numerator);
            Assert.AreEqual(expectedDenominator, r.Denominator);
        }


        [Test, TestCaseSource(nameof(KnownTestCases))]
        public void TestAbs(long numerator, long denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = new Rational(numerator, denominator).Abs;
            Assert.AreEqual(Math.Abs(expectedNumerator), r.Numerator);
            Assert.AreEqual(expectedDenominator, r.Denominator);
        }


        private static readonly TestDelegate[] InvertZeroDivisionErrorTestCases = {
            () => { Rational r = ~new Rational(); }
        };

        [Test, TestCaseSource(nameof(InvertZeroDivisionErrorTestCases))]
        public void TestInvertZeroDivisionError(TestDelegate action)
        {
            Assert.Throws<DivideByZeroException>(action);
        }


        [Test, TestCaseSource(nameof(KnownTestCases))]
        public void TestInvert(long numerator, long denominator, long expectedNumerator, long expectedDenominator)
        {
            Rational r = ~new Rational(numerator, denominator);

            long expectedInvertedNumerator;
            long expectedInvertedDenominator;
            if (0 > expectedNumerator)
            {
                expectedInvertedNumerator = -expectedDenominator;
                expectedInvertedDenominator = -expectedNumerator;
            }
            else
            {
                expectedInvertedNumerator = expectedDenominator;
                expectedInvertedDenominator = expectedNumerator;
            }

            Assert.AreEqual(expectedInvertedNumerator, r.Numerator);
            Assert.AreEqual(expectedInvertedDenominator, r.Denominator);
        }


        private static readonly object[] EqualToTestCases = {
            new object[] { new Rational(), new Rational(), true },
            new object[] { new Rational(-1, 2), new Rational(1, -2), true },
            new object[] { new Rational(1, 2), new Rational(2, 4), true },

            new object[] { new Rational(-1, 2), new Rational(), false },
            new object[] { new Rational(), new Rational(1, 2), false },
            new object[] { new Rational(1, 2), new Rational(), false },
            new object[] { new Rational(), new Rational(-1, 2), false },
            new object[] { new Rational(-1, 2), new Rational(1, 2), false },
            new object[] { new Rational(1, 4), new Rational(1, 2), false },
            new object[] { new Rational(-1, 2), new Rational(-1, 4), false },
            new object[] { new Rational(1, 2), new Rational(-1, 2), false },
            new object[] { new Rational(1, 2), new Rational(1, 4), false },
            new object[] { new Rational(-1, 4), new Rational(-1, 2), false },

            new object[] {null, null, true},
            new object[] {new Rational(), null, false},
            new object[] {null, new Rational(), false}
        };

        [Test, TestCaseSource(nameof(EqualToTestCases))]
        public void TestEqualTo(Rational r1, Rational r2, bool expectedValue)
        {
            Assert.AreEqual(expectedValue, r1 == r2);
        }


        private static readonly object[] NotEqualToTestCases = {
            new object[] { new Rational(-1, 2), new Rational(), true },
            new object[] { new Rational(), new Rational(1, 2), true },
            new object[] { new Rational(1, 2), new Rational(), true },
            new object[] { new Rational(), new Rational(-1, 2), true },
            new object[] { new Rational(-1, 2), new Rational(1, 2), true },
            new object[] { new Rational(1, 4), new Rational(1, 2), true },
            new object[] { new Rational(-1, 2), new Rational(-1, 4), true },
            new object[] { new Rational(1, 2), new Rational(-1, 2), true },
            new object[] { new Rational(1, 2), new Rational(1, 4), true },
            new object[] { new Rational(-1, 4), new Rational(-1, 2), true },

            new object[] { new Rational(), new Rational(), false },
            new object[] { new Rational(-1, 2), new Rational(1, -2), false },
            new object[] { new Rational(1, 2), new Rational(2, 4), false },

            new object[] {new Rational(), null, true},
            new object[] {null, new Rational(), true},
            new object[] {null, null, false}
        };

        [Test, TestCaseSource(nameof(NotEqualToTestCases))]
        public void TestNotEqualTo(Rational r1, Rational r2, bool expectedValue)
        {
            Assert.AreEqual(expectedValue, r1 != r2);
        }


        private static readonly Rational RationalObject = new Rational();

        private static readonly object[] EqualsTestCases = {
            new object[] { new Rational(), new Rational(), true },
            new object[] { RationalObject, - -RationalObject, true },

            new object[] { new Rational(), new object(), false },
            new object[] { new Rational(), null, false }
        };

        [Test, TestCaseSource(nameof(EqualsTestCases))]
        public void TestEquals(Rational r, object o, bool expectedValue)
        {
            Assert.AreEqual(expectedValue, r.Equals(o));
        }


        private static readonly object[] GetHashCodeTestCases = {
            new object[] { new Rational(), new Rational(), true },
            new object[] { RationalObject, - -RationalObject, true },
            new object[] { RationalObject, RationalObject, true },

            new object[] { new Rational(1, 3), new Rational(), false },
            new object[] { new Rational(1, 3), RationalObject, false }
        };

        [Test, TestCaseSource(nameof(GetHashCodeTestCases))]
        public void TestGetHashCode(Rational r1, Rational r2, bool expectedValue)
        {
            Assert.AreEqual(expectedValue, r1.GetHashCode() == r2.GetHashCode());
        }


        private static readonly object[] LessThanTestCases = {
            new object[] { new Rational(-1, 2), new Rational(), true },
            new object[] { new Rational(), new Rational(1, 2), true },
            new object[] { new Rational(-1, 2), new Rational(1, 2), true },
            new object[] { new Rational(1, 4), new Rational(1, 2), true },
            new object[] { new Rational(-1, 2), new Rational(-1, 4), true },

            new object[] { new Rational(), new Rational(), false },
            new object[] { new Rational(1, 2), new Rational(), false },
            new object[] { new Rational(), new Rational(-1, 2), false },
            new object[] { new Rational(-1, 2), new Rational(1, -2), false },
            new object[] { new Rational(1, 2), new Rational(2, 4), false },
            new object[] { new Rational(1, 2), new Rational(-1, 2), false },
            new object[] { new Rational(1, 2), new Rational(1, 4), false },
            new object[] { new Rational(-1, 4), new Rational(-1, 2), false }
        };

        [Test, TestCaseSource(nameof(LessThanTestCases))]
        public void TestLessThan(Rational r1, Rational r2, bool expectedValue)
        {
            Assert.AreEqual(expectedValue, r1 < r2);
        }


        private static readonly object[] GreaterThanTestCases = {
            new object[] { new Rational(1, 2), new Rational(), true },
            new object[] { new Rational(), new Rational(-1, 2), true },
            new object[] { new Rational(1, 2), new Rational(-1, 2), true },
            new object[] { new Rational(1, 2), new Rational(1, 4), true },
            new object[] { new Rational(-1, 4), new Rational(-1, 2), true },

            new object[] { new Rational(), new Rational(), false },
            new object[] { new Rational(-1, 2), new Rational(), false },
            new object[] { new Rational(), new Rational(1, 2), false },
            new object[] { new Rational(-1, 2), new Rational(1, -2), false },
            new object[] { new Rational(1, 2), new Rational(2, 4), false },
            new object[] { new Rational(-1, 2), new Rational(1, 2), false },
            new object[] { new Rational(1, 4), new Rational(1, 2), false },
            new object[] { new Rational(-1, 2), new Rational(-1, 4), false }
        };

        [Test, TestCaseSource(nameof(GreaterThanTestCases))]
        public void TestGreaterThan(Rational r1, Rational r2, bool expectedValue)
        {
            Assert.AreEqual(expectedValue, r1 > r2);
        }


        private static readonly object[] LessThanOrEqualToTestCases = {
            new object[] { new Rational(), new Rational(), true },
            new object[] { new Rational(-1, 2), new Rational(), true },
            new object[] { new Rational(), new Rational(1, 2), true },
            new object[] { new Rational(-1, 2), new Rational(1, -2), true },
            new object[] { new Rational(1, 2), new Rational(2, 4), true },
            new object[] { new Rational(-1, 2), new Rational(1, 2), true },
            new object[] { new Rational(1, 4), new Rational(1, 2), true },
            new object[] { new Rational(-1, 2), new Rational(-1, 4), true },

            new object[] { new Rational(1, 2), new Rational(), false },
            new object[] { new Rational(), new Rational(-1, 2), false },
            new object[] { new Rational(1, 2), new Rational(-1, 2), false },
            new object[] { new Rational(1, 2), new Rational(1, 4), false },
            new object[] { new Rational(-1, 4), new Rational(-1, 2), false }
        };

        [Test, TestCaseSource(nameof(LessThanOrEqualToTestCases))]
        public void TestLessThanOrEqualTo(Rational r1, Rational r2, bool expectedValue)
        {
            Assert.AreEqual(expectedValue, r1 <= r2);
        }


        private static readonly object[] GreaterThanOrEqualToTestCases = {
            new object[] { new Rational(), new Rational(), true },
            new object[] { new Rational(1, 2), new Rational(), true },
            new object[] { new Rational(), new Rational(-1, 2), true },
            new object[] { new Rational(-1, 2), new Rational(1, -2), true },
            new object[] { new Rational(1, 2), new Rational(2, 4), true },
            new object[] { new Rational(1, 2), new Rational(-1, 2), true },
            new object[] { new Rational(1, 2), new Rational(1, 4), true },
            new object[] { new Rational(-1, 4), new Rational(-1, 2), true },

            new object[] { new Rational(-1, 2), new Rational(), false },
            new object[] { new Rational(), new Rational(1, 2), false },
            new object[] { new Rational(-1, 2), new Rational(1, 2), false },
            new object[] { new Rational(1, 4), new Rational(1, 2), false },
            new object[] { new Rational(-1, 2), new Rational(-1, 4), false }
        };

        [Test, TestCaseSource(nameof(GreaterThanOrEqualToTestCases))]
        public void TestGreaterThanOrEqualTo(Rational r1, Rational r2, bool expectedValue)
        {
            Assert.AreEqual(expectedValue, r1 >= r2);
        }


        private static readonly object[] AdditionOfRationalAndRationalTestCases = {
            new object[] { new Rational(), new Rational(1, 2), new Rational(1, 2) },
            new object[] { new Rational(1, 2), new Rational(), new Rational(1, 2) },
            new object[] { new Rational(1, 2), new Rational(1, 2), new Rational(1) },
            new object[] { new Rational(1, 2), new Rational(-1, 2), new Rational() },
            new object[] { new Rational(1, 4), new Rational(2, 4), new Rational(3, 4) },
            new object[] { new Rational(1, 4), new Rational(3, 4), new Rational(1) },
            new object[] { new Rational(1, 4), new Rational(-3, 4), new Rational(-1, 2) },
            new object[] { new Rational(1, 2), new Rational(1, 3), new Rational(5, 6) }
        };

        [Test, TestCaseSource(nameof(AdditionOfRationalAndRationalTestCases))]
        public void TestAdditionOfRationalAndRational(Rational r1, Rational r2, Rational expectedResult)
        {
            Rational r = r1 + r2;
            Assert.AreEqual(expectedResult.Numerator, r.Numerator);
            Assert.AreEqual(expectedResult.Denominator, r.Denominator);
        }

        private static readonly object[] AdditionOfRationalAndIntegerTestCases = {
            new object[] { new Rational(2), -1, new Rational(1) },
            new object[] { new Rational(2), 1, new Rational(3) }
        };

        [Test, TestCaseSource(nameof(AdditionOfRationalAndIntegerTestCases))]
        public void TestAdditionOfRationalAndInteger(Rational r1, long r2, Rational expectedResult)
        {
            Rational r = r1 + r2;
            Assert.AreEqual(expectedResult.Numerator, r.Numerator);
            Assert.AreEqual(expectedResult.Denominator, r.Denominator);
        }

        private static readonly object[] AdditionOfIntegerAndRationalTestCases = {
            new object[] { 1, new Rational(1, 2), new Rational(3, 2) },
            new object[] { 1, new Rational(), new Rational(1) },
            new object[] { -1, new Rational(1, 2), new Rational(-1, 2) },
            new object[] { 1, new Rational(-1, 2), new Rational(1, 2) },
            new object[] { 1, new Rational(2, 4), new Rational(3, 2) },
            new object[] { 1, new Rational(3, 4), new Rational(7, 4) },
            new object[] { 1, new Rational(-3, 4), new Rational(1, 4) },
            new object[] { 1, new Rational(1, 3), new Rational(4, 3) }
        };

        [Test, TestCaseSource(nameof(AdditionOfIntegerAndRationalTestCases))]
        public void TestAdditionOfIntegerAndRational(long r1, Rational r2, Rational expectedResult)
        {
            Rational r = r1 + r2;
            Assert.AreEqual(expectedResult.Numerator, r.Numerator);
            Assert.AreEqual(expectedResult.Denominator, r.Denominator);
        }


        private static readonly object[] SubtractionOfRationalAndRationalTestCases = {
            new object[] { new Rational(), new Rational(1, 2), new Rational(-1, 2) },
            new object[] { new Rational(1, 2), new Rational(), new Rational(1, 2) },
            new object[] { new Rational(1, 2), new Rational(1, 2), new Rational() },
            new object[] { new Rational(1, 2), new Rational(-1, 2), new Rational(1) },
            new object[] { new Rational(1, 4), new Rational(2, 4), new Rational(-1, 4) },
            new object[] { new Rational(1, 4), new Rational(3, 4), new Rational(-1, 2) },
            new object[] { new Rational(1, 4), new Rational(-3, 4), new Rational(1) },
            new object[] { new Rational(1, 2), new Rational(1, 3), new Rational(1, 6) }
        };

        [Test, TestCaseSource(nameof(SubtractionOfRationalAndRationalTestCases))]
        public void TestSubstractionOfRationalAndRational(Rational r1, Rational r2, Rational expectedResult)
        {
            Rational r = r1 - r2;
            Assert.AreEqual(expectedResult.Numerator, r.Numerator);
            Assert.AreEqual(expectedResult.Denominator, r.Denominator);
        }


        private static readonly object[] SubtractionOfRationalAndIntegerTestCases = {
            new object[] { new Rational(2), -1, new Rational(3) },
            new object[] { new Rational(2), 1, new Rational(1) }
        };

        [Test, TestCaseSource(nameof(SubtractionOfRationalAndIntegerTestCases))]
        public void TestSubtractionOfRationalAndInteger(Rational r1, long r2, Rational expectedResult)
        {
            Rational r = r1 - r2;
            Assert.AreEqual(expectedResult.Numerator, r.Numerator);
            Assert.AreEqual(expectedResult.Denominator, r.Denominator);
        }


        private static readonly object[] SubtractionOfIntegerAndRationalTestCases = {
            new object[] { 1, new Rational(1, 2), new Rational(1, 2) },
            new object[] { 1, new Rational(), new Rational(1) },
            new object[] { -1, new Rational(1, 2), new Rational(-3, 2) },
            new object[] { 1, new Rational(-1, 2), new Rational(3, 2) },
            new object[] { 1, new Rational(2, 4), new Rational(1, 2) },
            new object[] { 1, new Rational(3, 4), new Rational(1, 4) },
            new object[] { 1, new Rational(-3, 4), new Rational(7, 4) },
            new object[] { 1, new Rational(1, 3), new Rational(2, 3) }
        };
        [Test, TestCaseSource(nameof(SubtractionOfIntegerAndRationalTestCases))]
        public void TestSubtractionOfIntegerAndRational(long r1, Rational r2, Rational expectedResult)
        {
            Rational r = r1 - r2;
            Assert.AreEqual(expectedResult.Numerator, r.Numerator);
            Assert.AreEqual(expectedResult.Denominator, r.Denominator);
        }


        private static readonly object[] MultiplicationOfRationalAndRationalTestCases = {
            new object[] { new Rational(), new Rational(1, 2), new Rational() },
            new object[] { new Rational(1, 2), new Rational(), new Rational() },
            new object[] { new Rational(1, 2), new Rational(1, 2), new Rational(1, 4) },
            new object[] { new Rational(1, 2), new Rational(-1, 2), new Rational(-1, 4) },
            new object[] { new Rational(1, 4), new Rational(2, 4), new Rational(1, 8) },
            new object[] { new Rational(1, 4), new Rational(3, 4), new Rational(3, 16) },
            new object[] { new Rational(1, 4), new Rational(-3, 4), new Rational(-3, 16) },
            new object[] { new Rational(1, 2), new Rational(1, 3), new Rational(1, 6) }
        };

        [Test, TestCaseSource(nameof(MultiplicationOfRationalAndRationalTestCases))]
        public void TestMultiplicationOfRationalAndRational(Rational r1, Rational r2, Rational expectedResult)
        {
            Rational r = r1 * r2;
            Assert.AreEqual(expectedResult.Numerator, r.Numerator);
            Assert.AreEqual(expectedResult.Denominator, r.Denominator);
        }


        private static readonly object[] MultiplicationOfRationalAndIntegerTestCases = {
            new object[] { new Rational(2), 1, new Rational(2) },
            new object[] { new Rational(2), -1, new Rational(-2) }
        };

        [Test, TestCaseSource(nameof(MultiplicationOfRationalAndIntegerTestCases))]
        public void TestMultiplicationOfRationalAndInteger(Rational r1, long r2, Rational expectedResult)
        {
            Rational r = r1 * r2;
            Assert.AreEqual(expectedResult.Numerator, r.Numerator);
            Assert.AreEqual(expectedResult.Denominator, r.Denominator);
        }


        private static readonly object[] MultiplicationOfIntegerAndRationalTestCases = {
            new object[] { 1, new Rational(1, 2), new Rational(1, 2) },
            new object[] { 1, new Rational(), new Rational() },
            new object[] { -1, new Rational(1, 2), new Rational(-1, 2) },
            new object[] { 1, new Rational(-1, 2), new Rational(-1, 2) },
            new object[] { 1, new Rational(2, 4), new Rational(1, 2) },
            new object[] { 1, new Rational(3, 4), new Rational(3, 4) },
            new object[] { 1, new Rational(-3, 4), new Rational(-3, 4) },
            new object[] { 1, new Rational(1, 3), new Rational(1, 3) }
        };

        [Test, TestCaseSource(nameof(MultiplicationOfIntegerAndRationalTestCases))]
        public void TestMultiplicationOfIntegerAndRational(long r1, Rational r2, Rational expectedResult)
        {
            Rational r = r1 * r2;
            Assert.AreEqual(expectedResult.Numerator, r.Numerator);
            Assert.AreEqual(expectedResult.Denominator, r.Denominator);
        }


        private static readonly TestDelegate[] DivisionZeroDivisionErrorTestCases = {
            () => { Rational r = new Rational(1, 2) / new Rational(); },
            () => { Rational r = new Rational() / 0; },
            () => { Rational r = 1 / new Rational(); }
        };

        [Test, TestCaseSource(nameof(DivisionZeroDivisionErrorTestCases))]
        public void TestDivisionZeroDivisonError(TestDelegate action)
        {
            Assert.Throws<DivideByZeroException>(action);
        }


        private static readonly object[] DivisionRationalAndRationalTestCases = {
            new object[] { new Rational(), new Rational(1, 2), new Rational() },
            new object[] { new Rational(1, 2), new Rational(1, 2), new Rational(1) },
            new object[] { new Rational(1, 2), new Rational(-1, 2), new Rational(-1) },
            new object[] { new Rational(1, 4), new Rational(2, 4), new Rational(1, 2) },
            new object[] { new Rational(1, 4), new Rational(3, 4), new Rational(1, 3) },
            new object[] { new Rational(1, 4), new Rational(-3, 4), new Rational(-1, 3) },
            new object[] { new Rational(1, 2), new Rational(1, 3), new Rational(3, 2) }
        };

        [Test, TestCaseSource(nameof(DivisionRationalAndRationalTestCases))]
        public void TestDivisionRationalAndRational(Rational r1, Rational r2, Rational expectedResult)
        {
            Rational r = r1 / r2;
            Assert.AreEqual(expectedResult.Numerator, r.Numerator);
            Assert.AreEqual(expectedResult.Denominator, r.Denominator);
        }


        private static readonly object[] DivisionRationalAndIntegerTestCases = {
            new object[] { new Rational(2), 1, new Rational(2) },
            new object[] { new Rational(2), -1, new Rational(-2) }
        };

        [Test, TestCaseSource(nameof(DivisionRationalAndIntegerTestCases))]
        public void TestDivisionRationalAndInteger(Rational r1, long r2, Rational expectedResult)
        {
            Rational r = r1 / r2;
            Assert.AreEqual(expectedResult.Numerator, r.Numerator);
            Assert.AreEqual(expectedResult.Denominator, r.Denominator);
        }


        private static readonly object[] DivisionIntegerAndRationalTestCases = {
            new object[] { 1, new Rational(1, 2), new Rational(2) },
            new object[] { -1, new Rational(1, 2), new Rational(-2) },
            new object[] { 1, new Rational(-1, 2), new Rational(-2) },
            new object[] { 1, new Rational(2, 4), new Rational(2) },
            new object[] { 1, new Rational(3, 4), new Rational(4, 3) },
            new object[] { 1, new Rational(-3, 4), new Rational(-4, 3) },
            new object[] { 1, new Rational(1, 3), new Rational(3) }
        };

        [Test, TestCaseSource(nameof(DivisionIntegerAndRationalTestCases))]
        public void TestDivisionIntegerAndRational(long r1, Rational r2, Rational expectedResult)
        {
            Rational r = r1 / r2;
            Assert.AreEqual(expectedResult.Numerator, r.Numerator);
            Assert.AreEqual(expectedResult.Denominator, r.Denominator);
        }


        private static readonly TestDelegate[] PowerDivideByZeroErrorTestCases = {
            () => { Rational r = new Rational() ^ -3; },
            () => { Rational r = new Rational() ^ -2; },
            () => { Rational r = new Rational() ^ -1; }
        };

        [Test, TestCaseSource(nameof(PowerDivideByZeroErrorTestCases))]
        public void TestDivideByZeroError(TestDelegate action)
        {
            Assert.Throws<DivideByZeroException>(action);
        }


        private static readonly TestDelegate[] PowerArgumentErrorTestCases = {
            () => { double r = -2 ^ new Rational(1, 2); },
            () => { double r = -1 ^ new Rational(1, 2); },
            () => { double r = -3 ^ new Rational(-1, 2); },
            () => { double r = -2 ^ new Rational(-1, 2); },
            () => { double r = -1 ^ new Rational(-1, 2); },
            () => { double r = -3 ^ new Rational(1, 3); },
            () => { double r = -2 ^ new Rational(1, 3); },
            () => { double r = -1 ^ new Rational(1, 3); },
            () => { double r = -3 ^ new Rational(-1, 3); },
            () => { double r = -2 ^ new Rational(-1, 3); },
            () => { double r = -1 ^ new Rational(-1, 3); }
        };

        [Test, TestCaseSource(nameof(PowerArgumentErrorTestCases))]
        public void TestArgumentZeroError(TestDelegate action)
        {
            Assert.Throws<ArgumentException>(action);
        }


        private static readonly object[] RationalRaisedToIntegerTestCases = {
            new object[] { new Rational(), 0, new Rational() },
            new object[] { new Rational(), 1, new Rational() },
            new object[] { new Rational(), 2, new Rational() },
            new object[] { new Rational(), 3, new Rational() },

            new object[] { new Rational(1, 2), -3, new Rational(8) },
            new object[] { new Rational(1, 2), -2, new Rational(4) },
            new object[] { new Rational(1, 2), -1, new Rational(2) },
            new object[] { new Rational(1, 2), 0, new Rational(1) },
            new object[] { new Rational(1, 2), 1, new Rational(1, 2) },
            new object[] { new Rational(1, 2), 2, new Rational(1, 4) },
            new object[] { new Rational(1, 2), 3, new Rational(1, 8) },

            new object[] { new Rational(-1, 2), -3, new Rational(-8) },
            new object[] { new Rational(-1, 2), -2, new Rational(4) },
            new object[] { new Rational(-1, 2), -1, new Rational(-2) },
            new object[] { new Rational(-1, 2), 0, new Rational(1) },
            new object[] { new Rational(-1, 2), 1, new Rational(-1, 2) },
            new object[] { new Rational(-1, 2), 2, new Rational(1, 4) },
            new object[] { new Rational(-1, 2), 3, new Rational(-1, 8) },

            new object[] { new Rational(1, 3), -3, new Rational(27) },
            new object[] { new Rational(1, 3), -2, new Rational(9) },
            new object[] { new Rational(1, 3), -1, new Rational(3) },
            new object[] { new Rational(1, 3), 0, new Rational(1) },
            new object[] { new Rational(1, 3), 1, new Rational(1, 3) },
            new object[] { new Rational(1, 3), 2, new Rational(1, 9) },
            new object[] { new Rational(1, 3), 3, new Rational(1, 27) },

            new object[] { new Rational(-1, 3), -3, new Rational(-27) },
            new object[] { new Rational(-1, 3), -2, new Rational(9) },
            new object[] { new Rational(-1, 3), -1, new Rational(-3) },
            new object[] { new Rational(-1, 3), 0, new Rational(1) },
            new object[] { new Rational(-1, 3), 1, new Rational(-1, 3) },
            new object[] { new Rational(-1, 3), 2, new Rational(1, 9) },
            new object[] { new Rational(-1, 3), 3, new Rational(-1, 27) }
        };

        [Test, TestCaseSource(nameof(RationalRaisedToIntegerTestCases))]
        public void TestRationalRaisedToInteger(Rational r1, long r2, Rational expectedResult)
        {
            Rational r = r1 ^ r2;
            Assert.AreEqual(expectedResult.Numerator, r.Numerator);
            Assert.AreEqual(expectedResult.Denominator, r.Denominator);
        }


        private static readonly object[] IntegerRaisedToRationalTestCases = {
            new object[] { 0, new Rational(), 1 },
            new object[] { 1, new Rational(), 1 },
            new object[] { 2, new Rational(), 1 },
            new object[] { 3, new Rational(), 1 },

            new object[] { 0, new Rational(1, 2), 0 },
            new object[] { 1, new Rational(1, 2), 1 },
            new object[] { 2, new Rational(1, 2), 1.4142135623730951 },
            new object[] { 3, new Rational(1, 2), 1.7320508075688772 },

            new object[] { 1, new Rational(-1, 2), 1 },
            new object[] { 2, new Rational(-1, 2), 0.7071067811865476 },
            new object[] { 3, new Rational(-1, 2), 0.5773502691896257 },

            new object[] { 0, new Rational(1, 3), 0 },
            new object[] { 1, new Rational(1, 3), 1 },
            new object[] { 2, new Rational(1, 3), 1.2599210498948732 },
            new object[] { 3, new Rational(1, 3), 1.4422495703074083 },

            new object[] { 1, new Rational(-1, 3), 1 },
            new object[] { 2, new Rational(-1, 3), 0.7937005259840998 },
            new object[] { 3, new Rational(-1, 3), 0.6933612743506348 },

            new object[] { -1, new Rational(1), -1 },
            new object[] { -2, new Rational(1), -2 },
            new object[] { -1, new Rational(-1), -1 },
            new object[] { -2, new Rational(-2), 0.25 }
        };

        [Test, TestCaseSource(nameof(IntegerRaisedToRationalTestCases))]
        public void TestIntegerRaisedToRational(long r1, Rational r2, double expectedResult)
        {
            double result = r1 ^ r2;
            Assert.AreEqual(expectedResult, result);
        }
    }
}