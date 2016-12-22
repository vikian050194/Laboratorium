using System;
using System.Collections.Generic;
using System.Numerics;

namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    public class RandomSequenceGenarator
    {
        public List<BigInteger> GetList(BigInteger n, BigInteger attempts)
        {
            if (n < attempts)
            {
                attempts = n - 1;
            }

            var result = new List<BigInteger>();

            var random = new Random();

            while (result.Count < attempts)
            {
                var a = random.Next(1, (int)n);
                if (!result.Contains(a))
                {
                    result.Add(a);
                }
            }

            return result;
        }
    }
}