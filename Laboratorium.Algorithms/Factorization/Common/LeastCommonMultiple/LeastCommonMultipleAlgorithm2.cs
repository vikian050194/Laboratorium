using System.Linq;
using System.Numerics;
using Laboratorium.Algorithms.Factorization.Common.EuclideanAlgorithm;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Factorization.Common.LeastCommonMultiple
{
    [FunctionAlias("lcmN")]
    [DefaultImplementation]
    public class LeastCommonMultipleAlgorithm2 : ILeastCommonMultipleAlgorithm2
    {
        public BigInteger Execute(IEuclideanAlgorithm euclideanAlgorithm, params BigInteger[] numbers)
        {
            var result = numbers.First();

            for (var i = 1; i < numbers.Length && result != 1; i++)
            {
                result = euclideanAlgorithm.Execute(result, numbers[i]);
            }

            return result;
        }
    }
}
