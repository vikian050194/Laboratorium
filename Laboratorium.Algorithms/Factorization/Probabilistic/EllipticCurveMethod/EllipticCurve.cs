using System;
using Laboratorium.Types.Common;

namespace Laboratorium.Algorithms.Factorization.Probabilistic.EllipticCurveMethod
{
    class EllipticCurve<T>  where T: IEquatable<T>, IComparable<T>
    {
        public EllipticCurve(NumericWrapper<T> a, NumericWrapper<T> b)
        {
            A = a;
            B = b;
        }

        public NumericWrapper<T> A { get; private set; }
        public NumericWrapper<T> B { get; private set; }


        public bool Contains(Point<T> point)
        {
            var left = point.Y * point.Y;
            var right = point.X * point.X * point.X + point.X * A + B;

            var result = left.Equals(right);

            return result;
        }
    }
}
