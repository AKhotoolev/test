using System;

namespace MathLib
{
    public static class SquareOf
    {
        /// <summary>
        /// Calculates square of circle represented by it's radius
        /// </summary>
        /// <param name="r">Radius</param>
        public static double Circle(double r)
        {
            if (r < 0)
                throw new ArgumentException("Radius should not be negative.", nameof(r));

            return Math.PI * r * r;
        }

        /// <summary>
        /// Calculates square of triangle represented by it's sides
        /// </summary>
        /// <remarks>
        /// Cause of finite precision of type 'double' not all results will be precise
        /// </remarks>
        public static double TriangleBySides(double a, double b, double c)
        {
            Asserts.SidesFormsTriangle(a,b,c);

            if (a > b)
                (a, b) = (b, a);
            if (b > c)
                (b, c) = (c, b);

            var p = (a + b + c) / 2.0;

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public static double CustomShape(double[] x, double[] y)
        {
            // here Gauss's area formula can be used to calculate square of custom polygonal shape
            // note: self overlapping are not permitted and should be verified
            throw new NotImplementedException();
        }
    }
}
