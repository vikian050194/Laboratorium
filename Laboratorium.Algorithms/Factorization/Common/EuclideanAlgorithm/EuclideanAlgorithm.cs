using System.Numerics;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Factorization.Common.EuclideanAlgorithm
{
    public interface IEuclideanAlgorithm
    {
        BigInteger Execute(BigInteger a, BigInteger b);
    }

    [FunctionAlias("gcd"), DefaultImplementation]
    public class EuclideanAlgorithm : IEuclideanAlgorithm
    {
        public BigInteger Execute(BigInteger a, BigInteger b)
        {
            while (a != BigInteger.Zero && b != BigInteger.Zero)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            var result = a + b;

            return result;
        }
    }
}