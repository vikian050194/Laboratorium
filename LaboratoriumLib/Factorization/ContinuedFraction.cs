using System;
using System.Collections.Generic;

namespace LaboratoriumLib.Factorization
{
    public class ContinuedFraction : IAlgorithm<int[]>
    {
        private int _a;
        private int _b;
        public ContinuedFraction(int a, int b)
        {
            _a = a;
            _b = b;
        }
        public int[] Execute()
        {
            var result = new List<int>();

            int r = -1;
            int q = -1;

            while (r != 0)
            {
                q = _a / _b;
                r = _a - q * _b;

                result.Add(q);

                _a = _b;
                _b = r;
            }

            return result.ToArray();
        }
    }
}