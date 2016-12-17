using System;
using Laboratorium.Types.Common;

namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    internal class NumericRandomGenerator<T> : INumericRandomGenerator<T> where T : IEquatable<T>, IComparable<T>
    {
        private readonly Random _random;
        private readonly NumericWrapper<T> _module;

        public NumericRandomGenerator(T n)
        {
            _random = new Random();
            _module = new NumericWrapper<T>(n);
        }

        public NumericWrapper<T> Next()
        {
            var nextValue = _random.Next(int.MaxValue).ToString();
            var result = new NumericWrapper<T>(nextValue) % _module;

            return result;
        }
    }
}