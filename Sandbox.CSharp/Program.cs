using System;
using System.Collections.Generic;
using System.Numerics;
using Laboratorium.Algorithms.Factorization.EllipticCurveMethod;

namespace Sandbox.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ecm1 = new EllipticCurveMethod1();
            var ecm2 = new EllipticCurveMethod2();
            var ecm3 = new EllipticCurveMethod3();

            var list = new List<BigInteger>
            {
                128,
                36,
                300,
                455838,
                455839,
                661643,
                5429,
                23
            };

            foreach (var bigInteger in list)
            {
                var d = ecm1.Execute(bigInteger, 10, 100);
                Print(bigInteger, d, "Without random");
                d = ecm2.Execute(bigInteger, 10, 100);
                Print(bigInteger, d, "Random A");
                d = ecm3.Execute(bigInteger, 10, 100);
                Print(bigInteger, d, "Full random");
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void Print(BigInteger n, Tuple<BigInteger, BigInteger> d, string name)
        {
            Console.WriteLine("n: {0} name: {1} d: {2} count: {3}",n, name, d.Item1, d.Item2);
        }
    }
}
