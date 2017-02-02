using System.Numerics;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Factorization.Probabilistic.TestsOfSimplicity
{
    [FunctionAlias("fermatTest")]
    public class FermatTest : TestOfSimplicityBase, ITestOfSimplicity
    {
        public BigInteger Execute(BigInteger n, BigInteger rounds)
        {
            var a = BigInteger.Parse("2");
            var iterations = GetIterations(n, rounds);

            for (var i = BigInteger.One; i <= iterations; i++)
            {
                var r = BigInteger.ModPow(a, n, n);

                if (r != a)
                {
                    return (int)Status.Composite;
                }

                a++;
            }

            return (int)Status.Unknown;
        }
    }
}