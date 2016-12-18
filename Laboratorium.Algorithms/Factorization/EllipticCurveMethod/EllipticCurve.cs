using System.Numerics;

namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    class EllipticCurve
    {
        public EllipticCurve(BigInteger a, BigInteger b)
        {
            A = a;
            B = b;
        }

        public BigInteger A { get; private set; }
        public BigInteger B { get; private set; }


        public bool Contains(Point point)
        {
            var left = point.Y * point.Y;
            var right = point.X * point.X * point.X + point.X * A + B;

            var result = left.Equals(right);

            return result;
        }
    }
}
