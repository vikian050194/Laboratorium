using System;
using Laboratorium.Algorithms.Factorization.EllipticCurveMethod;

namespace Sandbox.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ecm = new EllipticCurveMethod();
            var d = ecm.Execute(5429, 100, 100);
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
