using System.Numerics;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Factorization.Common.GaussCriterion
{
    internal interface IGaussCriterion
    {
        BigInteger Execute(BigInteger a, BigInteger n);
    }

    [FunctionAlias("gauss"), DefaultImplementation]
    class GaussCriterion : IGaussCriterion
    {
        public BigInteger Execute(BigInteger a, BigInteger n)
        {
            var max = (n - 1) / 2;
            var count = BigInteger.Zero;

            for (var i = BigInteger.One; i <= max; i++)
            {
                var positiveValue = a * i % n;
                var negativeValue = positiveValue - n;
                if (-1 * negativeValue < positiveValue)
                {
                    count++;
                }
            }

            return count % 2 == 0 ? 1 : -1;
        }
    }
}
