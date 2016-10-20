using LaboratoriumLib.Attributes;

namespace LaboratoriumLib.Algorithms.Factorization
{
    [Function("gcd")]
    public class SingleGCD : IAlgorithm<int>
    {
        private int _a;
        private int _b;

        public SingleGCD(int a, int b)
        {
            _a = a;
            _b = b;
        }

        public int Execute()
        {
            while (_a != _b)
            {
                if (_a > _b)
                {
                    _a -= _b;
                }
                else
                {
                    _b -= _a;
                }
            }

            return _a;
        }
    }
}