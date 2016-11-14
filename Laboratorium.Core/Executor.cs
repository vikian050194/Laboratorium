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
            _executorHelper = executorHelper;
        }

        public Packet Execute(Packet packet)
        {
            var fileManager = new FileManager();
            var script = new StringBuilder();

            AddReference(script);

            AddOpen(script);

            AddFunctions(script);

            script.Append(packet.Script);

            fileManager.SaveScript(script.ToString(), packet.User, _executorHelper.GetAssemblyDirectory());
            var path = fileManager.GetPath();

            var processInfo = GetProcessInfo(path);

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
                .Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            if (packet.Errors.Count == 0)
            {
                packet.Result = packet.Result.GetRange(2, packet.Result.Count - 3);
            }

            writer.Close();
            reader.Close();
            process.WaitForExit();
            process.Close();

            packet.Input = script.ToString().Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries).ToList();

            return packet;
        }

        private List<string> GetArguments(string path)
        {
            return new List<string>
            {
                "--nologo",
                "--exec",
                $"--use:\"{path}\""
            };
        }

        private void AddFunctions(StringBuilder script)
        {
            var algorithmFamilies = _executorHelper.GetAlgorithmTypes();
            var functions = _executorHelper.GetFunctions(algorithmFamilies);
            foreach (var function in functions)
            {
                script.AppendLine(function);
            }
        }

        private void AddOpen(StringBuilder script)
        {
            var algorithmFamilies = _executorHelper.GetNamespaces();

            foreach (var algorithmFamily in algorithmFamilies.Values)
            {
                var line = $"open {algorithmFamily}";
                script.AppendLine(line);
            }
        }

        private void AddReference(StringBuilder script)
        {
            var line = $"#r @\"{_executorHelper.PathToLib}\"";
            script.AppendLine(line);
        }

        private ProcessStartInfo GetProcessInfo(string path)
        {
            var argumentsList = GetArguments(path);
            var arguments = new StringBuilder();

            for (int i = 0; i < argumentsList.Count; i++)
            {
                arguments.Append(argumentsList[i]);
                if (i != argumentsList.Count)
                {
                    arguments.Append(" ");
                }
            }

            var result = new ProcessStartInfo
            {
                FileName = _executorHelper.PathToFsi,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Arguments = arguments.ToString()
            };

            return result;
        }
    }
}