using System;
using System.Collections.Generic;

namespace Laboratorium.Types.Common
{
    public class NumericWrapper<T> : IComparable<NumericWrapper<T>>, IEquatable<NumericWrapper<T>> where T : IComparable<T>, IEquatable<T>
    {
        public T Value { get; private set; }
        public T Module { get; private set; }
        public bool IsModule { get; private set; }

        public NumericWrapper()
        {
            Value = default(T);
        }

        public NumericWrapper(int value)
        {
            Value = (T)Convert.ChangeType(value, typeof(T));
            //Value = (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString(value);
            Module = default(T);
            IsModule = false;
        }

        public NumericWrapper(string value, string module)
        {
            Value = (T)Convert.ChangeType(value, typeof(T));
            Module = (T)Convert.ChangeType(module, typeof(T));

            Value = (dynamic)Value % (dynamic)Module;

            IsModule = true;
        }

        public NumericWrapper(T value)
        {
            Value = value;
            Module = default(T);
            IsModule = false;
        }

        public NumericWrapper(T value, T module)
        {
            Value = value;
            Module = module;

            Value = (dynamic)Value % (dynamic)Module;

            IsModule = true;
        }

        //public static NumericWrapper<int> From(int value)
        //{
        //    return new NumericWrapper<int>(value);
        //}

        //public static NumericWrapper<int> From(int value, int module)
        //{
        //    return new NumericWrapper<int>(value, module);
        //}

        //public static NumericWrapper<int> From(string value)
        //{
        //    return new NumericWrapper<int>(value);
        //}

        //public static NumericWrapper<int> From(string value, string module)
        //{
        //    return new NumericWrapper<int>(value, module);
        //}

        private static bool CheckCompatibility(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            var check1 = a.IsModule == b.IsModule;
            var check2 = a.Module.Equals(b.Module);

            var result = check1 && check2;

            return result;
        }

        public static NumericWrapper<T> operator +(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            if (CheckCompatibility(a, b))
            {
                dynamic result = (dynamic)a.Value + (dynamic)b.Value;

                if (a.IsModule)
                {
                    result = result % a.Module;
                    return new NumericWrapper<T>(result, a.Module);
                }

                return new NumericWrapper<T>(result);
            }

            throw new ArithmeticException();
        }

        public static NumericWrapper<T> operator -(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            if (CheckCompatibility(a, b))
            {
                dynamic result = (dynamic)a.Value - (dynamic)b.Value;

                if (a.IsModule)
                {
                    if (result < default(T))
                    {
                        result += a.Module;
                    }

                    return new NumericWrapper<T>(result, a.Module);
                }

                return new NumericWrapper<T>(result);
            }

            throw new ArithmeticException();
        }

        public static NumericWrapper<T> operator *(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            if (CheckCompatibility(a, b))
            {
                dynamic result = (dynamic)a.Value * (dynamic)b.Value;

                if (a.IsModule)
                {
                    result = result % a.Module;
                    return new NumericWrapper<T>(result, a.Module);
                }

                return new NumericWrapper<T>(result);
            }

            throw new ArithmeticException();
        }

        public static NumericWrapper<T> operator /(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            if (CheckCompatibility(a, b))
            {
                dynamic result = (dynamic)a.Value / (dynamic)b.Value;

                if (a.IsModule)
                {
                    return new NumericWrapper<T>(result, a.Module);
                }

                return new NumericWrapper<T>(result);
            }

            throw new ArithmeticException();
        }

        public static NumericWrapper<T> operator %(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            if (CheckCompatibility(a, b))
            {
                dynamic result = (dynamic)a.Value % (dynamic)b.Value;

                if (a.IsModule)
                {
                    return new NumericWrapper<T>(result, a.Module);
                }

                return new NumericWrapper<T>(result);
            }

            throw new ArithmeticException();
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
