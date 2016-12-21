using System.Numerics;

namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    public class EllipticCurve
    {
        public EllipticCurve(BigInteger a, BigInteger b)
        {
            A = a;
            B = b;
        }

        public BigInteger A { get; private set; }
        public BigInteger B { get; private set; }


        public bool Contains(Point point, BigInteger n)
        {
            var left = point.Y * point.Y;
            left = new ZnCutter().Cut(left, n);
            var right = point.X * point.X * point.X + point.X * A + B;
            right = new ZnCutter().Cut(right, n);
            var result = left.Equals(right);

            return result;
        }
    }
}
