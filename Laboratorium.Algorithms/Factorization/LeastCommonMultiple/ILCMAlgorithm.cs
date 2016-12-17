using System;
using Laboratorium.Algorithms.Factorization.GreatestCommonDivisor;

namespace Laboratorium.Algorithms.Factorization.LeastCommonMultiple
{
    public interface ILCMAlgorithm<T> where T : IComparable<T>, IEquatable<T>
    {
        T Execute(T a, T b, IGreaterCommonDivisorAlgorithm<T> subAlgorithm);
    }
}