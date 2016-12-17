using System;
using Laboratorium.Attributes;
using Laboratorium.Types.Common;

namespace Laboratorium.Algorithms.Factorization.GreatestCommonDivisor
{
    [FunctionAlias("gcd")]
    [DefaultImplementation]
    public class GreaterCommonDivisor<T> : IGreaterCommonDivisorAlgorithm<T> where T : IComparable<T>, IEquatable<T>
    {
        public T Execute(T a, T b)
        {
            var wrapperA = new NumericWrapper<T>(a);
            var wrapperB = new NumericWrapper<T>(b);

            var zero = new NumericWrapper<T>(0);

            while (wrapperA != zero && wrapperB != zero)
            {
                if (wrapperA > wrapperB)
                {
                    wrapperA %= wrapperB;
                }
                else
                {
                    wrapperB %= wrapperA;
                }
            }

            var result = wrapperA + wrapperB;

            return result.Value;
        }
    }
}