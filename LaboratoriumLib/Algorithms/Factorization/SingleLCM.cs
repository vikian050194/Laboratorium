using LaboratoriumLib.Attributes;

namespace LaboratoriumLib.Algorithms.Factorization
{
    [Function("lcm")]
    public class SingleLCM : IAlgorithm<int>
    {
        public int Execute(int a, int b)
        {
            var d = new SingleGCD().Execute(a, b);
            var result = a * b / d;
            return result;
        }
    }
}