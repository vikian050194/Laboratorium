using System;
using Laboratorium.Types.Common;

namespace Laboratorium.Algorithms.Factorization.Probabilistic.EllipticCurveMethod
{
    internal class Point<T> : IEquatable<Point<T>> where T: IEquatable<T>, IComparable<T>
    {
        public Point(NumericWrapper<T> x, NumericWrapper<T> y)
        {
            X = x;
            Y = y;
        }

        public NumericWrapper<T> X { get; private set; }
        public NumericWrapper<T> Y { get; private set; }

        public bool Equals(Point<T> other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public Point<T> Clone()
        {
            var result = new Point<T>(X, Y);

            return result;
        }
    }
}