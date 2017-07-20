using System;
using NUnit;
using NUnit.Framework;

namespace TestPtojectForHH
{
    class AreaOfTriangle
    {
        public double Square(double a, double b, double c)
        {
            
            if (a + b < c || a + c < b || c + b < a)
            {
                throw new ArgumentException("It is not a triangle");
            }
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }

    [TestFixture]
    class AreaOfTriangleTest
    {
        [TestCase(-1,4,5) ]
        [TestCase(0,4.9,6)]
        [TestCase(100.1,1.5,90.7)]
        public void Square_NotTriangleArgument_Throws(double a, double b, double c)
        {
            var triag = Creator();
            
            var ex = Assert.Catch<Exception>(() => triag.Square(a, b, c));
            StringAssert.Contains(ex.Message, "It is not a triangle");

        }
        [TestCase(3,4,5,6)]
        [TestCase(555.33, 645.11, 727, 172290.03648437656)]
        public void Square_CorrectCalculations_AlwaysTrue(double a, double b, double c, double result)
        {
            var triag = Creator();
            Assert.AreEqual(triag.Square(a, b, c), result);
        }
        private AreaOfTriangle Creator()
        {
            return new AreaOfTriangle();
        }
    }



}

