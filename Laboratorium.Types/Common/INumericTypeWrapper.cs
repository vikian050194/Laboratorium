using System;
using System.Security.Cryptography.X509Certificates;

namespace Laboratorium.Types.Common
{
    public interface INumericTypeWrapper<T> : IComparable<INumericTypeWrapper<T>>, IEquatable<INumericTypeWrapper<T>>
        where T : IEquatable<T>, IComparable<T>
    {
       T Value { get; }
    }
}