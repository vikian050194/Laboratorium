using System;

namespace Laboratorium.Types.Common
{
    public class FooInt<T>
    {
        private readonly T _value;
        private readonly Func<T, T, T> _toAdd;
        private readonly Func<T, T, T> _toMultiply;
        private readonly Func<T, T, bool> _toCompare;

        private FooInt(T value, T zero, T one,
            Func<T, T, T> toAdd,
            Func<T, T, T> toMultiply,
            Func<T, T, bool> toCompare)
        {
            _value = value;

            Zero = CreateFoo(zero);
            One = CreateFoo(one);

            _toAdd = toAdd;
            _toMultiply = toMultiply;
            _toCompare = toCompare;
        }

        public static FooInt<T> Zero { get; private set; }
        public static FooInt<T> One { get; private set; } 

        public static FooInt<int> FromInt(int value)
        {
            var result = new FooInt<int>(value, 0, 1,
                (a, b) => a + b,
                (a, b) => a * b,
                (a, b) => a==b);

            return result;
        }

        public static FooInt<double> FromDouble(double value)
        {
            var result = new FooInt<double>(value, 0, 1,
                (a, b) => a + b,
                (a, b) => a * b,
                (a, b) => Math.Abs(a - b) < 0.000001);

            return result;
        }

        public FooInt<T> Add(FooInt<T> a)
        {
            T result = _toAdd(_value, a._value);
            return CreateFoo(result);
        }

        public FooInt<T> Multiply(FooInt<T> a)
        {
            T result = _toMultiply(_value, a._value);
            return CreateFoo(result);
        }

        public bool Equals(FooInt<T> a)
        {
            var result = _toCompare(_value, a._value);
            return result;
        }

        private FooInt<T> CreateFoo(T value)
        {
            var result = new FooInt<T>(value, Zero._value, One._value, _toAdd, _toMultiply, _toCompare);

            return result;
        }
    }
}