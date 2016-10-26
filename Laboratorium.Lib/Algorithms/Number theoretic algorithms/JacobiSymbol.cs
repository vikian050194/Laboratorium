using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Laboratorium.Lib.Attributes;

namespace Laboratorium.Lib.Algorithms.Number_theoretic_algorithms
{
    [Function("jacobi")]
    public class JacobiSymbol : IAlgorithm<int>
    {
        BigInteger _number;
        BigInteger _mod;


        public JacobiSymbol(BigInteger number, BigInteger mod)
        {
            _number = number;
            _mod = mod;
        }
        public int Execute()
        {
            _number = (_mod + (_number + _mod) % _mod) % _mod;
            int t = 1;
            while (_number != 0)
            {
                while (_number % 2 == 0)
                {
                    _number = _number / 2;
                    var r = _mod % 8;
                    if (r == 3 || r == 5)
                    {
                        t = -t;
                    }
                }
                var tmp = _number;
                _number = _mod;
                _mod = tmp;
                var resA = _number % 4;
                var resMod = _mod % 4;
                if (resA == 3 && resMod == 3)
                {
                    t = -t;
                }
                _number = _number % _mod;
            }
            if (_mod == 1)
                return t;
            return 0;
        }


    }
}
