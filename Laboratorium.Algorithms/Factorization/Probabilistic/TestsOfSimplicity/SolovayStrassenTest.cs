using System.Numerics;
using Laboratorium.Algorithms.Factorization.Common.GaussCriterion;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Factorization.Probabilistic.TestsOfSimplicity
{
    public interface ISolovayStrassenTest
    {
        BigInteger Execute(BigInteger n, BigInteger rounds);
    }

    [FunctionAlias("solovayStrassenTest")]
    [DefaultImplementation]
    public class SolovayStrassenTest : TestOfSimplicityBase, ISolovayStrassenTest
    {
        public BigInteger Execute(BigInteger n, BigInteger rounds)
        {
            var n1 = n - 1;
            var a = BigInteger.Parse("2");
            var iterations = GetIterations(n, rounds);

            for (var i = BigInteger.One; i <= iterations; i++)
            {
                var d = BigInteger.GreatestCommonDivisor(a, n);

                if (d == 1)
                {
                    var r = BigInteger.ModPow(a, n1 / 2, n);

                    if (r != 1 && r != n - 1)
                    {
                        return (int)Status.Composite;
                    }

                    var s = new GaussCriterion().Execute(a, n) == -1 ? n1 : 1;

                    if (s != r)
                    {
                        return (int)Status.Composite;
                    }
                }

                a++;
            }

            return (int)Status.Unknown;
        }
    }
}