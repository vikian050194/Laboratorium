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
            var packet = executor.GetNewEmptyPacket();
            packet.Script = "let x = [1..10]";
            packet = executor.Execute(packet);
            Console.ReadLine();
        }
    }
}