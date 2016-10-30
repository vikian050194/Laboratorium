using Laboratorium.Lib.Attributes;

namespace Laboratorium.Lib.Algorithms.Factorization
{
    [Function("lcm")]
    public class SingleLCM : IAlgorithm<int>
    {
        private readonly int _a;
        private readonly int _b;

        public SingleLCM(int a, int b)
        {
            _a = a;
            _b = b;
        }

        public int Execute()
        {
            var d = new SingleGCD(_a, _b).Execute();
            var result = _a * _b / d;
            return result;
        }
    }
}