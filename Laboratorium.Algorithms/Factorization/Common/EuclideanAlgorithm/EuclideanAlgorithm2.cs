using System.Linq;
using System.Numerics;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Factorization.Common.EuclideanAlgorithm
{
    public interface IEuclideanAlgorithm2
    {
        BigInteger Execute(params BigInteger[] numbers);
    }

    [FunctionAlias("gcd2"), DefaultImplementation]
    public class EuclideanAlgorithm2 : IEuclideanAlgorithm2
    {
        public BigInteger Execute(params BigInteger[] numbers)
        {
            var euclideanAlgorithm = new EuclideanAlgorithm();
            var result = numbers.First();

            for (var i = 1; i < numbers.Length && result != 1; i++)
            {
                result = euclideanAlgorithm.Execute(result, numbers[i]);
            }

            return result;
        }
    }
}
