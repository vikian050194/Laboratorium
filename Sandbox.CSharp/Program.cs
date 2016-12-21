using System;
using System.Collections.Generic;
using System.Numerics;
using Laboratorium.Algorithms.Factorization.AdvancedEuclid;
using Laboratorium.Algorithms.Factorization.EllipticCurveMethod;

namespace Sandbox.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ecm = new EllipticCurveMethod1();

            var list = new List<BigInteger>
            {
                455839,
                661643,
                5429,
                23
            };

            foreach (var bigInteger in list)
            {
                var d = ecm.Execute(bigInteger, 10, 100);
                Console.WriteLine(d);
            }

            Console.ReadLine();
        }
    }
}
