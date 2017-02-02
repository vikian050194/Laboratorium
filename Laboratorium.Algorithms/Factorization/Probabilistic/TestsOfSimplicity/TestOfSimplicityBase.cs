using System.Numerics;

namespace Laboratorium.Algorithms.Factorization.Probabilistic.TestsOfSimplicity
{
    public abstract class TestOfSimplicityBase
    {
        protected BigInteger GetIterations(BigInteger n, BigInteger rounds)
        {
            BigInteger iterations;
            var iterationsMaxValue = n - 3;

            if (rounds == 0)
            {
                iterations = iterationsMaxValue;
            }
            else
            {
                var iterationsValue = rounds;
                iterations = iterationsValue < iterationsMaxValue
                    ? iterationsValue
                    : iterationsMaxValue;
            }

            return iterations;
        }
    }
}