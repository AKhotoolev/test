using System;

namespace MathLib
{
    static class Asserts
    {
        public static void SidesFormsTriangle(double a, double b, double c)
        {
            if (a < 0) throw new ArgumentException("Side length should not be negative.", nameof(a));
            if (b < 0) throw new ArgumentException("Side length should not be negative.", nameof(b));
            if (c < 0) throw new ArgumentException("Side length should not be negative.", nameof(c));

            if (!(c > Math.Abs(a - b) && c < a + b))
                throw new ArgumentException("Not a triangle.");
        }
    }
}
