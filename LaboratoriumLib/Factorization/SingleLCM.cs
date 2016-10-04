namespace LaboratoriumLib.Factorization
{
    public class SingleLCM : IAlgorithm
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