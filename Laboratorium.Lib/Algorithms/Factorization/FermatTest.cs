using System.Numerics;
using Laboratorium.Lib.Attributes;

namespace Laboratorium.Lib.Algorithms.Factorization
{
    [Function("fermattest")]
    public class FermatTest : ProbabilisticTestOfSimplicity, IAlgorithm<int>
    {
        private readonly BigInteger _n;
        private readonly BigInteger _r;

        public FermatTest(string n, string r)
        {
            _n = BigInteger.Parse(n);
            _r = BigInteger.Parse(r);
        }

        public int Execute()
        {
            var n = _n;
            var a = BigInteger.Parse("2");
            var iterations = GetIterations(_n, _r);

            for (var i = BigInteger.One; i <= iterations; i++)
            {
                var r = BigInteger.ModPow(a, n, n);

                if (r != a)
                {
                    return (int)Status.Composite;
                }

                a++;
            }

            return (int)Status.Unknown;
        }
    }
}