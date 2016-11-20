using System;
using Laboratorium.Core;
using Laboratorium.Core.Managers;

namespace Sandbox.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var executor = new Executor(new TestPathManager());

            var script = "let x = 5";

            var packet = new Packet
            {
                Script = script,
                User = "foobar"

            };

            packet = executor.Execute(packet);

            Console.ReadLine();
        }
    }
}
