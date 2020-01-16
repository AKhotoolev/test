using System;
using Xunit;

namespace MathLib.tests
{
    public class TestThatTests
    {
        [Theory]
        [InlineData(-double.Epsilon, 4, 5)]
        [InlineData(4, -double.Epsilon, 5)]
        [InlineData(5, 4, -double.Epsilon)]
        public void TriangleIsRight_NonPositiveArgumentsTest(double a, double b, double c)
        {
            var exception = Assert.Throws<ArgumentException>(() => TestThat.TriangleIsRight(a, b, c));
            Assert.StartsWith("Side length should not be negative.", exception.Message);
        }

        [Theory]
        [InlineData(3, 4, 5, true)]
        [InlineData(4, 3, 5, true)]
        [InlineData(5, 4, 3, true)]
        [InlineData(1, 1, 1, false)]
        public void TriangleIsRight_BasicTest(double a, double b, double c, bool expected)
        {
            var actual = TestThat.TriangleIsRight(a, b, c);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TriangleIsRight_FuzzyTest()
        {
            var rnd = new Random();

            var a = rnd.NextDouble();
            var b = rnd.NextDouble();
            var c = Math.Sqrt(a * a + b * b);

            if (a > b)
                (a, b) = (b, a);
            if (b > c)
                (b, c) = (c, b);

            var expected = Math.Abs(a * a + b * b - c * c) < Constants.FloatingPointPrecision;

            var actual = TestThat.TriangleIsRight(a, b, c);

            Assert.Equal(expected, actual);
        }
    }
}