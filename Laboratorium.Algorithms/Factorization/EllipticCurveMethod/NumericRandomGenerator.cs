using System;
using System.Numerics;

namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    internal class NumericRandomGenerator
    {
        private readonly Random _random;
        private readonly BigInteger _n;

        public NumericRandomGenerator(BigInteger n)
        {
            _random = new Random();
            _n = n;
        }

        public BigInteger Next()
        {
            var nextValue = _random.Next(1, int.MaxValue);

            var result = new BigInteger(nextValue) % _n;

            return result;
        }
    }
}