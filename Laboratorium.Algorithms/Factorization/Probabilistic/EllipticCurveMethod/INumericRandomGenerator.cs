﻿using System;
using Laboratorium.Types.Common;

namespace Laboratorium.Algorithms.Factorization.Probabilistic.EllipticCurveMethod
{
    internal interface INumericRandomGenerator<T> where T : IEquatable<T>, IComparable<T>
    {
        NumericWrapper<T> Next();
    }
}