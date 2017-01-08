using System;
using System.Numerics;

namespace Laboratorium.Types.Common
{
    public interface INumericType<T> : IComparable<INumericType<T>>, IEquatable<INumericType<T>>
        where T : IEquatable<T>, IComparable<T>
    {
        T Value { get; }

        INumericType<T> Add(INumericType<T> a);
        INumericType<T> Mul(INumericType<T> a);
        INumericType<T> Sub(INumericType<T> a);
        INumericType<T> Div(INumericType<T> a);
        INumericType<T> Mod(INumericType<T> a);
    }

    public class NumericType<T> where T : IEquatable<T>, IComparable<T>
    {
        public NumericType(INumericType<T> value)
        {
            Value = value;
        }

        public INumericType<T> Value;

        public static NumericType<T> operator +(NumericType<T> a, NumericType<T> b)
        {
            var result = a.Value.Add(b.Value);

            return new NumericType<T>(result);
        }

        public static NumericType<T> operator -(NumericType<T> a, NumericType<T> b)
        {
            var result = a.Value.Sub(b.Value);

            return new NumericType<T>(result);
        }

        public static NumericType<T> operator *(NumericType<T> a, NumericType<T> b)
        {
            var result = a.Value.Mul(b.Value);

            return new NumericType<T>(result);
        }

        public static NumericType<T> operator /(NumericType<T> a, NumericType<T> b)
        {
            var result = a.Value.Div(b.Value);

            return new NumericType<T>(result);
        }

        public static NumericType<T> operator %(NumericType<T> a, NumericType<T> b)
        {
            var result = a.Value.Mod(b.Value);

            return new NumericType<T>(result);
        }

        public static bool operator >(NumericType<T> a, NumericType<T> b)
        {
            var result = a.Value.CompareTo(b.Value) == 1;

            return result;
        }

        public static bool operator <(NumericType<T> a, NumericType<T> b)
        {
            var result = a.Value.CompareTo(b.Value) == -1;

            return result;
        }

        public static bool operator >=(NumericType<T> a, NumericType<T> b)
        {
            var result = a.Value.CompareTo(b.Value) != -1;

            return result;
        }

        public static bool operator <=(NumericType<T> a, NumericType<T> b)
        {
            var result = a.Value.CompareTo(b.Value) != 1;

            return result;
        }

        public static bool operator ==(NumericType<T> a, NumericType<T> b)
        {
            var result = a.Value.CompareTo(b.Value) == 0;

            return result;
        }

        public static bool operator !=(NumericType<T> a, NumericType<T> b)
        {
            var result = a.Value.CompareTo(b.Value) != 0;

            return result;
        }
    }

    public class NumericTypeFactory
    {
        public static NumericType<T> GetNumericType<T>(string value) where T : IEquatable<T>, IComparable<T>
        {
            if (typeof(T) == typeof(int))
            {
                var foo = new NumericTypeInt((int)Convert.ChangeType(value, typeof(int)));
                return new NumericType<T>(foo);
            }

            throw new Exception();
        }
    }

    public class NumericTypeInt<T> : INumericType<T> where T: Int32
    {
        public NumericTypeInt(string value)
        {
            Value = int.Parse(value);
        }
        public NumericTypeInt(int value)
        {
            Value = value;
        }
        public int CompareTo(INumericType<int> other)
        {
            return Value.CompareTo(other.Value);
        }

        public bool Equals(INumericType<int> other)
        {
            return Value.Equals(other.Value);
        }

        public int Value { get; }

        T INumericType<T>.Value
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public INumericType<int> Add(INumericType<int> a)
        {
            var result = Value + a.Value;

            return new NumericTypeInt(result);
        }

        public INumericType<int> Mul(INumericType<int> a)
        {
            var result = Value + a.Value;

            return new NumericTypeInt(result);
        }

        public INumericType<T> Add(INumericType<T> a)
        {
            throw new NotImplementedException();
        }

        public INumericType<T> Mul(INumericType<T> a)
        {
            throw new NotImplementedException();
        }

        public INumericType<T> Sub(INumericType<T> a)
        {
            throw new NotImplementedException();
        }

        public INumericType<T> Div(INumericType<T> a)
        {
            throw new NotImplementedException();
        }

        public INumericType<T> Mod(INumericType<T> a)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(INumericType<T> other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(INumericType<T> other)
        {
            throw new NotImplementedException();
        }
    }

    public class NumericTypeBigInt : INumericType<BigInteger>
    {
        public NumericTypeBigInt(string value)
        {
            Value = BigInteger.Parse(value);
        }
        public NumericTypeBigInt(BigInteger value)
        {
            Value = value;
        }
        public int CompareTo(INumericType<BigInteger> other)
        {
            return Value.CompareTo(other.Value);
        }

        public bool Equals(INumericType<BigInteger> other)
        {
            return Value.Equals(other.Value);
        }

        public BigInteger Value { get; }
        public INumericType<BigInteger> Add(INumericType<BigInteger> a)
        {
            var result = Value + a.Value;

            return new NumericTypeBigInt(result);
        }

        public INumericType<BigInteger> Mul(INumericType<BigInteger> a)
        {
            var result = Value + a.Value;

            return new NumericTypeBigInt(result);
        }
    }
}