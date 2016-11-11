using Laboratorium.Algorithms.Factorization.GreatestCommonDivisor;

namespace Laboratorium.Algorithms.Factorization.LeastCommonMultiple
{
    [Function("lcm")]
    public class SingleLCM : ILCMAlgorithm<int>
    {
        public int Execute(int a, int b, IGCDAlgorithm<int> subAlgorithm)
        {
            var d = subAlgorithm.Execute(a, b);
            var result = a*b/d;
            return result;
        }
    }
}