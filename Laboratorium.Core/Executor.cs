using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Laboratorium.Core
{
    public class Executor
    {
        private readonly IExecutorHelper _executorHelper;

        public Executor(IExecutorHelper executorHelper)
        {
            _executorHelper = executorHelper; ;
        }

        public Packet Execute(Packet packet)
        {
            var fileManager = new FileManager();

            var script = new StringBuilder();

            var line = $"#r @\"{_executorHelper.PathToLib}\"";
            script.AppendLine(line);

            var algorithmFamilies = _executorHelper.GetAlgorithmTypes();
            var foo = _executorHelper.GetNamespaces();
            foreach (var algorithmFamily in foo.Values)
            {
                line = $"open {algorithmFamily}";
                script.AppendLine(line);
            }

            var functions = _executorHelper.GetFunctions(algorithmFamilies);

            foreach (var function in functions)
            {
                script.AppendLine(function);
            }

            script.Append(packet.Script);

            var path = fileManager.SaveScript(script.ToString(), packet.User, _executorHelper.GetAssemblyDirectory());

            var processInfo = GetProcessInfo();
            var arguments = new List<string>
            {
                "--nologo",
                "--exec",
                $"--use:\"{path}\"",
                //"--debug+",
                //"--debug:full"
            };

            foreach (var argument in arguments)
            {
                processInfo.Arguments += (argument + " ");
            }

            var process = Process.Start(processInfo);

            var writer = process.StandardInput;
            var reader = process.StandardOutput;
            var error = process.StandardError;

            packet.Result = reader
                    .ReadToEnd()
                    .Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

            packet.Errors = error
                .ReadToEnd()
                .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            if (packet.Errors.Count == 0)
            {
                packet.Result = packet.Result.GetRange(2, packet.Result.Count - 3);
            }

            writer.Close();
            reader.Close();
            process.WaitForExit();
            process.Close();

            packet.Input = script.ToString().Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

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