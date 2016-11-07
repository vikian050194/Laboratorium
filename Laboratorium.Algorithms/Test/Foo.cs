namespace Laboratorium.Algorithms.Test
{
    [Function("foo")]
    public class Foo : IAlgorithm<int>
    {
        private readonly IAlgorithm<int> _bar; 
        public Foo(IAlgorithm<int> bar)
        {
            _bar = bar;
        }

        public int Execute()
        {
            return _bar.Execute();
        }
    }
}