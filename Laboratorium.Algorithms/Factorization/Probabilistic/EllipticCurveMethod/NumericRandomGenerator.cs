using System;
using Laboratorium.Types.Common;

namespace Laboratorium.Algorithms.Factorization.Probabilistic.EllipticCurveMethod
{
    internal class NumericRandomGenerator<T> : INumericRandomGenerator<T> where T : IEquatable<T>, IComparable<T>
    {
        private readonly Random _random;
        private readonly string _module;

        public NumericRandomGenerator(T module)
        {
            _random = new Random();
            _module = module.ToString();
        }

        public NumericWrapper<T> Next()
        {
            var value = _random.Next(1, int.MaxValue).ToString();
            var result = new NumericWrapper<T>(value, _module);

            return result;
        }
    }
}