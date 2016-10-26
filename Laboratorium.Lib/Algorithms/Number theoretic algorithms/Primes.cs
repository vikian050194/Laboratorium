using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laboratorium.Lib.Attributes;

namespace Laboratorium.Lib.Algorithms.Number_theoretic_algorithms
{
    [Function("primes")]
    public class Primes : IAlgorithm<ulong[]>
    {
        ulong _lowerBound;
        ulong _upperBound;


        public Primes(ulong lowerBound, ulong upperBound)
        {
            _lowerBound = lowerBound;
            _upperBound = upperBound;
        }
        public ulong[] Execute()
        {
            if (_lowerBound % 2 == 0)
                _lowerBound++;
            if (_upperBound % 2 == 0)
                _upperBound--;
            var primesCount = (_upperBound - _lowerBound) / 2 + 1;
            bool[] isNotPrime = new bool[primesCount];
            for (ulong d = 3; d * d <= _upperBound; d = d + 2)
            {
                ulong j;
                ulong r = _lowerBound % d;
                if (r != 0)
                {
                    if (r % 2 == 1)
                    {
                        j = (d - r) / 2;
                    }
                    else
                    {
                        j = d - r / 2;
                    }
                }
                else
                {
                    j = 0;
                }
                if (d >= _lowerBound)
                {
                    j = j + d;
                }
                for (ulong i = j; i < (ulong)isNotPrime.Length; i += d)
                {
                    if (!isNotPrime[i])
                    {
                        primesCount--;
                    }
                    isNotPrime[i] = true;
                }
                if (d % 6 == 1)
                    d += 2;
            }
            ulong[] result = new ulong[primesCount];
            var nextIndex = 0;
            for (ulong i = 0; i < (ulong)isNotPrime.Length; i++)
            {
                if (!isNotPrime[i])
                {
                    ulong p = _lowerBound + 2 * i;
                    result[nextIndex++] = p;
                }
            }
            return result;
        }
    }
}
