using System.Numerics;

namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    class ZnCutter
    {
        public BigInteger Cut(BigInteger value, BigInteger n)
        {
            value %= n;

            if (value < BigInteger.Zero)
            {
                value += n;
            }

            return value;
        }
    }
}
