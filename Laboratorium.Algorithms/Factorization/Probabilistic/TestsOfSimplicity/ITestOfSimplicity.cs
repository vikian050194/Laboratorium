using System.Numerics;

namespace Laboratorium.Algorithms.Factorization.Probabilistic.TestsOfSimplicity
{
    public interface ITestOfSimplicity
    {
        BigInteger Execute(BigInteger n, BigInteger rounds);
    }
}