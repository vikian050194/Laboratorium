using Laboratorium.Lib.Attributes;

namespace Laboratorium.Lib.Algorithms.Factorization
{
    [Function("gausscriterion")]
    public class GaussCriterion : IAlgorithm<int>
    {
        private readonly int _a;
        private readonly int _b;

        public GaussCriterion(int a, int b)
        {
            _a = a;
            _b = b;
        }

        public int Execute()
        {
            var gcd = new SingleGCD(_a,_b);

            if (gcd.Execute() != 1)
            {
                return 0;
            }

            var max = (_b - 1) / 2;
            var count = 0;

            for (var i = 1; i <= max; i++)
            {
                var positiveValue = _a * i % _b;
                var negativeValue = positiveValue - _b;
                if (-1 * negativeValue < positiveValue)
                {
                    count++;
                }
            }

            return count % 2 == 0 ? 1 : -1;
        }
    }
}