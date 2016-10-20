using LaboratoriumLib.Attributes;

namespace LaboratoriumLib.Algorithms.Factorization
{
    [Function("lcm")]
    public class SingleLCM : IAlgorithm<int>
    {
        private int _a;
        private int _b;

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