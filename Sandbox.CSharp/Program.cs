using System;
using System.Numerics;
using Laboratorium.Algorithms.Factorization.Probabilistic.TestsOfSimplicity;
using Laboratorium.Core;
using Laboratorium.Core.Containers;
using Laboratorium.Core.Managers;

namespace Sandbox.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var executor = new Executor(new TestPathManager());
            executor.GetNewEmptyPacket();
            var result = executor.Execute(new Packet() {Script = "let x = 2 * 16;;"});
            //var alg = new SolovayStrassenTest();
            //var result = alg.Execute(new BigInteger(31), new BigInteger(3));
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}