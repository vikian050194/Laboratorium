namespace Laboratorium.Algorithms.Test
{
    [Function("bar")]
    public class Bar : IAlgorithm<int>
    {
        private readonly int _a;
        public Bar(int a)
        {
            _a = a;
        }

        public int Execute()
        {
            return _a;
        }
    }
}