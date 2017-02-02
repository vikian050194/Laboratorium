using System.Numerics;
using Laboratorium.Algorithms.Factorization.Common.EuclideanAlgorithm;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Factorization.Common.LeastCommonMultiple
{
    [FunctionAlias("lcm"), DefaultImplementation]
    public class LeastCommonMultipleAlgorithm : ILeastCommonMultipleAlgorithm
    {
        public BigInteger Execute(IEuclideanAlgorithm euclideanAlgorithm, BigInteger a, BigInteger b)
        {
            var d = euclideanAlgorithm.Execute(a, b);
            var result = a*b/d;

            return result;
        }
    }
}