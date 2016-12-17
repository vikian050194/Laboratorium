using Laboratorium.Algorithms.Factorization.GreatestCommonDivisor;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Factorization.LeastCommonMultiple
{
    [FunctionAlias("lcm")]
    [DefaultImplementation]
    public class SingleLCM : ILCMAlgorithm<int>
    {
        public int Execute(int a, int b, IGreaterCommonDivisorAlgorithm<int> subAlgorithm)
        {
            var d = subAlgorithm.Execute(a, b);
            var result = a*b/d;
            return result;
        }
    }
}