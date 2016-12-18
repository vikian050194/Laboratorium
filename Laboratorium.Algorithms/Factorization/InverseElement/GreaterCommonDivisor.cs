using System.Numerics;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Factorization.InverseElement
{
    [FunctionAlias("inverseelement")]
    [DefaultImplementation]
    public class InverseElement
    {
        public BigInteger Execute(BigInteger a, BigInteger n)
        {
            var euclid = new AdvancedEuclid.AdvancedEuclid();

            a %= n;

            var table = euclid.Execute(n, a);

            return BigInteger.MinusOne;
        }
    }
}