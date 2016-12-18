using System;
using Laboratorium.Algorithms.Factorization.AdvancedEuclid;
using Laboratorium.Algorithms.Factorization.EllipticCurveMethod;

namespace Sandbox.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var e = new AdvancedEuclid();
            //e.Execute(128, 112);

            var ecm = new EllipticCurveMethod(23, 10, 100);
            //var ecm = new EllipticCurveMethod(5429, 100, 100);
            //var ecm = new EllipticCurveMethod(661643, 100, 100);
            var d = ecm.Execute();
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
