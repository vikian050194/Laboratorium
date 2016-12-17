using System;

namespace Laboratorium.Algorithms.Factorization.GreatestCommonDivisor
{
    public interface IGreaterCommonDivisorAlgorithm<T> where T : IComparable<T>, IEquatable<T>
    {
        T Execute(T a, T b);
    }
}