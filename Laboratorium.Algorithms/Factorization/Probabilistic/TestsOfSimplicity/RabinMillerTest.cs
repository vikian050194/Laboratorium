using System.Numerics;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Factorization.Probabilistic.TestsOfSimplicity
{
    public interface IRabinMillerTest
    {
        BigInteger Execute(BigInteger n, BigInteger rounds);
    }

    [FunctionAlias("rabinMillerTest")]
    [DefaultImplementation]
    public class RabinMillerTest : TestOfSimplicityBase, IRabinMillerTest
    {
        public BigInteger Execute(BigInteger n, BigInteger rounds)
        {
            var n1 = n - 1;
            var a = BigInteger.Parse("2");
            var iterations = GetIterations(n, rounds);
            var s = BigInteger.Zero;
            var t = n1;

            while (t % 2 == 0)
            {
                s++;
                t /= 2;
            }

            for (var i = BigInteger.One; i <= iterations; i++)
            {
                var x = BigInteger.ModPow(a, t, n);

                if (x == 1 || x == n1)
                {
                    a++;
                    continue;
                }

                for (var j = BigInteger.One; j < s && x != n1; j++)
                {
                    x = BigInteger.ModPow(x, 2, n);

                    if (x == 1)
                    {
                        return (int)Status.Composite;
                    }
                    if (x == n1)
                    {
                        break;
                    }
                }

                if (x != n1)
                {
                    return (int)Status.Composite;
                }

                a++;
            }

            return (int)Status.Unknown;
        }
    }
}