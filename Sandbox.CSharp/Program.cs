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
            var result = executor.Execute(new Packet() {Script = "let x = 2 * 16;;"});
            Console.ReadLine();
        }
    }
}