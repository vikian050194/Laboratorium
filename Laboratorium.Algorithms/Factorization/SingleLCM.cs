namespace Laboratorium.Algorithms.Factorization
{
    [Function("lcm")]
    public class SingleLCM : IAlgorithm2<int>
    {
        public int Execute(int a, int b, IAlgorithmS<int> subAlgorithm)
        {
            var d = subAlgorithm.Execute(a, b);
            var result = a * b / d;
            return result;
        }
    }
}