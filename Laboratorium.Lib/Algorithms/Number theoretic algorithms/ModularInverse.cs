using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Laboratorium.Lib.Attributes;

namespace Laboratorium.Lib.Algorithms.Number_theoretic_algorithms
{
    [Function("inverse")]
    public class ModularInverse : IAlgorithm<BigInteger>
    {
        BigInteger _number, _mod;

        public ModularInverse(BigInteger number, BigInteger mod)
        {
            _number = number;
            _mod = mod;
        }
        public BigInteger Execute()
        {
            BigInteger gcd = 1;
            var result = GfMath.Inverse(_number, _mod, out gcd);
            if (gcd != 1)
                throw new ArgumentException("Inverse doesnt exist");
            return result;
        }
    }
}
