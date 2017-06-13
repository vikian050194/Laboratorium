using System.Collections.Generic;
using System.Numerics;
using Laboratorium.Algorithms.Factorization.Common.EuclideanAlgorithm;

namespace Laboratorium.Algorithms.Factorization.Common.AdvancedEuclideanAlgorithm
{
    public interface IAdvancedEuclideanAlgorithm
    {
        List<TableRow> Execute(BigInteger a, BigInteger b);
    }
}