using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Laboratorium.Lib.Attributes;

namespace Laboratorium.Lib.Algorithms.Number_theoretic_algorithms
{
    [Function("sqrtgf")]
    public class SqrtGf : IAlgorithm<BigInteger>
    {
        BigInteger _number, _mod;
        public SqrtGf(BigInteger number, BigInteger mod)
        {
            _number = number;
            _mod = mod;
        }
        public BigInteger Execute()
        {
            return GfMath.Sqrt(_number, _mod);
        }
    }
}
