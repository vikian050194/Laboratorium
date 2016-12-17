using System;
using System.Collections.Generic;

namespace Laboratorium.Types.Common
{
    public class NumericWrapper<T> : IComparable<NumericWrapper<T>>, IEquatable<NumericWrapper<T>> where T: IComparable<T>, IEquatable<T>
    {
        public T Value { get; private set; }

        public NumericWrapper(T value)
        {
            Value = value;
        }

        public static NumericWrapper<int> From(int value)
        {
            return new NumericWrapper<int>(value);
        }

        public NumericWrapper(string value)
        {
            Value = (T)Convert.ChangeType(value, typeof(T));
        }

        public NumericWrapper()
        {
            Value = default(T);
        }

        public static NumericWrapper<T> operator +(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            dynamic result = (dynamic)a.Value + (dynamic)b.Value;
            return new NumericWrapper<T>(result);
        }

        public static NumericWrapper<T> operator -(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            dynamic result = (dynamic)a.Value - (dynamic)b.Value;
            return new NumericWrapper<T>(result);
        }

        public static NumericWrapper<T> operator *(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            dynamic result = (dynamic)a.Value * (dynamic)b.Value;
            return new NumericWrapper<T>(result);
        }

        public static NumericWrapper<T> operator /(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            dynamic result = (dynamic)a.Value / (dynamic)b.Value;
            return new NumericWrapper<T>(result);
        }

        public static NumericWrapper<T> operator %(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            dynamic result = (dynamic)a.Value % (dynamic)b.Value;
            return new NumericWrapper<T>(result);
        }

        public static bool operator >(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            var result = (dynamic)a.Value > (dynamic)b.Value;
            return result;
        }

        public static bool operator <(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            var result = (dynamic)a.Value < (dynamic)b.Value;
            return result;
        }

        public static bool operator >=(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            var result = (dynamic)a.Value >= (dynamic)b.Value;
            return result;
        }

        public static bool operator <=(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            var result = (dynamic)a.Value <= (dynamic)b.Value;
            return result;
        }

        public static bool operator ==(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            var result = (dynamic)a.Value == (dynamic)b.Value;
            return result;
        }

        public static bool operator !=(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            var result = (dynamic)a.Value != (dynamic)b.Value;
            return result;
        }

        public override int GetHashCode()
        {
            return EqualityComparer<T>.Default.GetHashCode(Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NumericWrapper<T>)obj);
        }

        public bool Equals(NumericWrapper<T> other)
        {
            var result = Value.Equals(other.Value);

            return result;
        }

        public int CompareTo(NumericWrapper<T> other)
        {
            var result = Value.CompareTo(other.Value);

            return result;
        }
    }
}
