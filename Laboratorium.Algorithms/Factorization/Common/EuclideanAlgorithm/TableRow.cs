﻿using System.Numerics;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Factorization.Common.EuclideanAlgorithm
{
    [Ignore]
    public class TableRow
    {
        public BigInteger U { get; set; }
        public BigInteger V { get; set; }
        public BigInteger R { get; set; }
        public BigInteger Q { get; set; }
    }
}