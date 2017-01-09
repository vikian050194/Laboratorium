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

            Console.ReadLine();
        }
    }
}
