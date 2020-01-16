using System;

namespace MathLib
{
    public static class TestThat
    {
        public static bool TriangleIsRight(double a, double b, double c, double epsilon = 1e-10)
        {
            Asserts.SidesFormsTriangle(a,b,c);

            if (a > b)
                (a, b) = (b, a);
            if (b > c)
                (b, c) = (c, b);

            return (Math.Abs(a * a + b * b - c * c) < Constants.FloatingPointPrecision);
        }
    }
}
