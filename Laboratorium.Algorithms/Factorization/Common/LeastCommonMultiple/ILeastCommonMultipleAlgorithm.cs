using System.Numerics;
using Laboratorium.Algorithms.Factorization.Common.EuclideanAlgorithm;

namespace Laboratorium.Algorithms.Factorization.Common.LeastCommonMultiple
{
    public interface ILeastCommonMultipleAlgorithm
    {
        BigInteger Execute(IEuclideanAlgorithm euclideanAlgorithm, BigInteger a, BigInteger b);
    }

    public interface ILeastCommonMultipleAlgorithm2
    {
        BigInteger Execute(IEuclideanAlgorithm euclideanAlgorithm, params BigInteger[] numbers);
    }
}