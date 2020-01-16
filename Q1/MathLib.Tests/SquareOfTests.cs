using System;
using Xunit;

namespace MathLib.tests
{
    public class SquareOfTests
    {
        [Fact]
        public void CircleTest()
        {
            var rnd = new Random();
            var r = rnd.NextDouble();
            var expected = Math.PI * r * r;

            var actual = MathLib.SquareOf.Circle(r);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Circle_NegativeArgumentTest()
        {
            var rnd = new Random();
            var r = 0.0 - double.Epsilon;

            var exception = Assert.Throws<ArgumentException>(() => MathLib.SquareOf.Circle(r));

            Assert.StartsWith("Radius should not be negative.", exception.Message);
        }

        [Fact]
        public void TriangleBySidesTest()
        {
            var rnd = new Random();

            var a = rnd.NextDouble();
            var b = rnd.NextDouble();
            var minC = Math.Abs(a - b) + double.Epsilon;
            var maxC = a + b;
            var c = Math.Abs(a - b) + rnd.NextDouble() * (maxC - minC);

            var p = (a + b + c) / 2.0;
            var expected = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            var actual = MathLib.SquareOf.TriangleBySides(a, b, c);

            Assert.True(Math.Abs(actual - expected) < Constants.FloatingPointPrecision);
        }

        [Theory]
        [InlineData(-double.Epsilon, 1, 1)]
        [InlineData(1, -double.Epsilon, 1)]
        [InlineData(1, 1, -double.Epsilon)]
        public void TriangleBySides_NegativeTest(double a, double b, double c)
        {
            var exception = Assert.Throws<ArgumentException>(() => MathLib.SquareOf.TriangleBySides(a, b, c));

            Assert.StartsWith("Side length should not be negative.", exception.Message);
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(1, 1, 2 + double.Epsilon)]
        public void TriangleBySides_NotATriangleTest(double a, double b, double c)
        {
            var exception = Assert.Throws<ArgumentException>(() => MathLib.SquareOf.TriangleBySides(a, b, c));

            Assert.StartsWith("Not a triangle.", exception.Message);
        }
    }
}