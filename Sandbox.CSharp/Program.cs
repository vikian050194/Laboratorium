using System;
using Laboratorium.Core;

namespace Sandbox.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var executor = new Executor(new ExecutorHelper());

            var script = "let x = 5";

            var packet = new Packet
            {
                Script = script
            };

            packet = executor.Execute(packet);

            Console.ReadLine();
        }
    }
}
