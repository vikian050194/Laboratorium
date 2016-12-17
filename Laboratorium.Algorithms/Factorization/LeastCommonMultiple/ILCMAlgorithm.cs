using Laboratorium.Algorithms.Factorization.GreatestCommonDivisor;

namespace Laboratorium.Algorithms.Factorization.LeastCommonMultiple
{
    public interface ILCMAlgorithm<T>
    {
        T Execute(T a, T b, IGreaterCommonDivisorAlgorithm<T> subAlgorithm);
    }
}