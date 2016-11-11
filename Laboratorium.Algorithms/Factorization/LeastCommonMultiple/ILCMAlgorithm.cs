using Laboratorium.Algorithms.Factorization.GreatestCommonDivisor;

namespace Laboratorium.Algorithms
{
    public interface ILCMAlgorithm<T>
    {
        T Execute(T a, T b, IGCDAlgorithm<T> subAlgorithm);
    }
}