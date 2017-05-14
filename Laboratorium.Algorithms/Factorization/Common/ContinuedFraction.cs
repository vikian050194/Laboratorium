using System.Collections.Generic;

namespace Laboratorium.Algorithms.Factorization
{
    [Function("continuedfraction")]
    public class ContinuedFraction : IAlgorithm<int[]>
    {
        private readonly int _a;
        private readonly int _b;

        public ContinuedFraction(int a, int b)
        {
            _a = a;
            _b = b;
        }

        public int[] Execute()
        {
            var result = new List<int>();

            var a = _a;
            var b = _b;

            int r = -1;
            int q = -1;

            while (r != 0)
            {
                q = a / b;
                r = a - q * b;

                result.Add(q);

                a = b;
                b = r;
            }

            return result.ToArray();
        }
    }
}