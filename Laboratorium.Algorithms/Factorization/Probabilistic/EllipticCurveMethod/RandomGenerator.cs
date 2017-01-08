﻿using System;
using Laboratorium.Types.Common;

namespace Laboratorium.Algorithms.Factorization.Probabilistic.EllipticCurveMethod
{
    internal class RandomGenerator<T> : IRandomGenerator<T> where T : IEquatable<T>, IComparable<T>
    {
        private readonly INumericRandomGenerator<T> _numericRandomGenerator;

        public RandomGenerator(INumericRandomGenerator<T> numericRandomGenerator)
        {
            _numericRandomGenerator = numericRandomGenerator;
        }

        private NumericWrapper<T> Next()
        {
            var result = _numericRandomGenerator.Next();

            return result;
        }

        public Point<T> GetNextPoint()
        {
            var x = Next();
            var y = Next();

            var point = new Point<T>(x, y);

            return point;
        }

        public EllipticCurve<T> GetNextEllipticCurve(Point<T> point)
        {
            var a = Next();
            var b = point.Y * point.Y - point.X * point.X * point.X - a * point.X;

            var ellipticCurve = new EllipticCurve<T>(a, b);

            return ellipticCurve;
        }
    }
}