using System.Numerics;

namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    internal class Point
    {
        public bool IsZero { get; set; }

        public Point()
        {
            X = BigInteger.Zero;
            Y = BigInteger.Zero;

            IsZero = true;
        }

        public Point(BigInteger x, BigInteger y)
        {
            X = x;
            Y = y;
        }

        public BigInteger X { get; private set; }
        public BigInteger Y { get; private set; }

        public bool Equals(Point other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public Point Clone()
        {
            var result = new Point(X, Y);

            return result;
        }
    }
}