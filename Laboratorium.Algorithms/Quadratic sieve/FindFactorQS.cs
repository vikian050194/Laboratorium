using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Laboratorium.Algorithms.Elliptic_curve_method;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Quadratic_sieve
{
    interface IQs
    {
        BigInteger Execute(BigInteger number,int sieveSize,long smoothBound);
    }
    [FunctionAlias("FindFactorQs"), DefaultImplementation]
    public class FindFactorQs : IQs
    {
        public BigInteger Execute(BigInteger number, int sieveSize, long smoothBound)
        {
            var qs=new Siqs(sieveSize,smoothBound,10);
            return qs.FindFactor(number);
        }
    }
}
