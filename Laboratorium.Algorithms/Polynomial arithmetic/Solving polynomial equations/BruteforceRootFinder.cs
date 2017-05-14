using System.Collections.Generic;
using Laboratorium.Types.Algebra;

namespace Laboratorium.Algorithms.Polynomial_arithmetic.Solving_polynomial_equations
{
    public class BruteforceRootFinder
    {
        public List<long> FindRoots(Polynomial polynomial, long mod)
        {
            polynomial = polynomial.Reduce(mod);

            var roots=new List<long>();
            for (long i = 0; i < mod; i++)
            {
                if (polynomial.Value(i)%mod == 0)
                {
                    roots.Add(i);
                }
            }
            return roots;
        } 
    }
}
