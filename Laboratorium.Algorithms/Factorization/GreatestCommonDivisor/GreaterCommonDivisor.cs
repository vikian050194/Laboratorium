using System.Numerics;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Factorization.GreatestCommonDivisor
{
    [FunctionAlias("gcd")]
    [DefaultImplementation]
    public class GreaterCommonDivisor
    {
        public BigInteger Execute(BigInteger a, BigInteger b)
        {
            while (a != 0 && b != 0)
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