using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
namespace Laboratorium.Core
{
    public class Executor
    {
        private readonly IExecutorHelper _executorHelper;

        public Executor(IExecutorHelper executorHelper)
        {
            _executorHelper = executorHelper;
        }

        public Packet Execute(Packet packet)
        {
            var inputLines = new List<string>();

            var processInfo = GetProcessInfo();

            var process = Process.Start(processInfo);

            var writer = process.StandardInput;
            var reader = process.StandardOutput;
            var error = process.StandardError;

            var line = $"#r @\"{_executorHelper.PathToLib}\";;";
            writer.WriteLine(line);
            inputLines.Add(line);

            var algorithmFamilies = _executorHelper.GetAlgorithmTypes();
            var foo = _executorHelper.GetNamespaces();
            foreach (var algorithmFamily in foo.Values)
            {
                line = $"open {algorithmFamily};;";

                writer.WriteLine(line);
                inputLines.Add(line);
            }

            var functions = _executorHelper.GetFunctions(algorithmFamilies);

            foreach (var function in functions)
            {
                writer.WriteLine(function);
                inputLines.Add(function);
            }

            line = packet.Query;
            writer.WriteLine(line);
            inputLines.Add(line);
            line = "#quit;;";
            writer.WriteLine(line);
            inputLines.Add(line);

            packet.Results =
                reader
                .ReadToEnd()
                .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            packet.Errors =
                error
                .ReadToEnd()
                .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            writer.Close();
            reader.Close();
            process.WaitForExit();
            process.Close();

            //TODO: Add filter for result  

            packet.Errors = inputLines;

            return packet;
        }

        private ProcessStartInfo GetProcessInfo()
        {
            return new ProcessStartInfo
            {
                FileName = _executorHelper.PathToFsi,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
        }
    }
}