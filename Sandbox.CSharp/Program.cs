using System;
using Laboratorium.Algorithms.Factorization.EllipticCurveMethod;
using Laboratorium.Algorithms.Factorization.GreatestCommonDivisor;
using Laboratorium.Types.Common;

namespace Sandbox.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ecm = new EllipticCurveMethod();
            //ecm.Execute(new SingleGCD(), 5429, 3, 100);
            var a = new NumericWrapper<int>(5);
            var b = new NumericWrapper<int>(3);
            var c = a * b;
            var v = c.Value;
            //var executor = new Executor(new TestPathManager());

            //var script = "let x = 5";

            //var packet = new Packet
            //{
            //    Script = script,
            //    User = "foobar"

            //};

            //packet = executor.Execute(packet);

            Console.ReadLine();
        }
    }
}
