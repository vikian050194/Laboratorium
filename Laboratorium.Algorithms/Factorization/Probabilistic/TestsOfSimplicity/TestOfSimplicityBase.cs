using System.Numerics;

namespace Laboratorium.Algorithms.Factorization.Probabilistic.TestsOfSimplicity
{
    public abstract class TestOfSimplicityBase
    {
        protected BigInteger GetIterations(BigInteger n, BigInteger r)
        {
            BigInteger iterations;
            var iterationsMaxValue = n - 3;

            if (r == 0)
            {
                iterations = iterationsMaxValue;
            }
            else
            {
                var iterationsValue = r;
                iterations = iterationsValue < iterationsMaxValue
                    ? iterationsValue
                    : iterationsMaxValue;
            }

            return iterations;
        }
    }
}
