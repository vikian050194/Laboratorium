﻿using System.Numerics;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Integer_arithmetic.Jacobi_Symbol
{
    interface IJacobiSymbol
    {
        int Execute(BigInteger n, BigInteger m);
    }
    [FunctionAlias("JacobiSymbol"), DefaultImplementation]
    public class JacobiSymbol:IJacobiSymbol
    {
        public int Execute(BigInteger n, BigInteger m)
        {
            return Calculate(n, m);
        }
        public int Calculate(BigInteger number, BigInteger mod)
        {
            number = (mod + (number + mod) % mod) % mod;
            int t = 1;
            while (number != 0)
            {
                while (number % 2 == 0)
                {
                    number = number / 2;
                    var r = mod % 8;
                    if (r == 3 || r == 5)
                    {
                        t = -t;
                    }
                }
                var tmp = number;
                number = mod;
                mod = tmp;
                var resA = number % 4;
                var resMod = mod % 4;
                if (resA == 3 && resMod == 3)
                {
                    t = -t;
                }
                number = number % mod;
            }
            if (mod == 1)
                return t;
            return 0;
        }

      
    }
}
