using System.Numerics;

namespace Laboratorium.Algorithms.Factorization.Common.EuclideanAlgorithm
{
    public interface IEuclideanAlgorithm
    {
        BigInteger Execute(BigInteger a, BigInteger b);
    }

    public interface IEuclideanAlgorithm2
    {
        BigInteger Execute(params BigInteger[] numbers);
    }
}