using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Laboratorium.Algorithms.Integer_arithmetic.Mod_inverse;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Integer_arithmetic.Crt
{
    interface ICrtSolver
    {
        BigInteger Execute(IEnumerable<BigInteger> coefficients, IEnumerable<BigInteger> primes);
    }
    [FunctionAlias("Crt"), DefaultImplementation]
    public class GarnerCrt:ICrtSolver
    {
        public BigInteger Execute(IEnumerable<BigInteger> coefficients, IEnumerable<BigInteger> primes)
        {
            return Calculate(coefficients.ToList(), primes.ToList());
        }
        public BigInteger Calculate(List<BigInteger> coefficients,List<BigInteger> primes)
        {
            var m = new BigInteger[primes.Count];
            var c = new BigInteger[primes.Count];
            var inverse = new ModularInverse();
            m[0] = 1;
            for (int i = 1; i < primes.Count; i++)
            {
                m[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    m[i] *= primes[j];

                }
                c[i] = inverse.Inverse(m[i], primes[i]);
            }
            var M = m[primes.Count - 1] * primes[primes.Count - 1];
            var n = coefficients[0];
            for (int i = 1; i < primes.Count; i++)
            {
                var u = (c[i] * (coefficients[i] - n)) % primes[i];
                n += u * m[i];
            }
            n = n % M;
            return n;
        }

     
    }
}
