using System;
using Laboratorium.Core;
using Laboratorium.Core.Compiler;
using Laboratorium.Core.Managers;

namespace Sandbox.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Compiler();
            t.Compile("  ");
            var executor = new Executor(new TestPathManager());

            Console.ReadLine();
        }
    }
}
