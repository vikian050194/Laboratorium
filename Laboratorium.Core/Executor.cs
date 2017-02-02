using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Laboratorium.Core.AlgorithmsLibrary;
using Laboratorium.Core.Managers;

namespace Laboratorium.Core
{
    public class Executor
    {
        private readonly ICodeManager _codeManager;
        private readonly PathManager _pathManager;

        public Executor(PathManager pathManager)
        {
            _codeManager = new CodeManager();
            _pathManager = pathManager;
        }

        public Packet Execute(Packet packet)
        {
            var fileManager = new FileManager();
            var script = new StringBuilder();

            AddReference(script);

            AddOpen(script);

            AddFunctions(script);

            script.Append(packet.Script);

            fileManager.SaveScript(script.ToString(), "C:\\test.fsx");//, "foobar", _pathManager.AssembliesDirectory);
            var path = fileManager.GetLastFile();

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
            var algorithmFamilies = _codeManager.GetAlgorithmFamilies();
            var functions = _codeManager.GetFunctions(algorithmFamilies);

            foreach (var function in functions)
            {
                script.AppendLine(function);
            }
        }

        private void AddOpen(StringBuilder script)
        {
            var algorithmFamilies = _codeManager.GetAlgorithmFamilies();
            var opens = _codeManager.GetOpens(algorithmFamilies);

            foreach (var line in opens)
            {
                script.AppendLine(line);
            }
        }

        private void AddReference(StringBuilder script)
        {
            var line = $"#r @\"{_pathManager.PathToAssembly}\"";
            script.AppendLine(line);
        }

        private ProcessStartInfo GetProcessInfo(string path)
        {
            var argumentsList = GetArguments(path);
            var arguments = new StringBuilder();

            for (var i = 0; i < argumentsList.Count; i++)
            {
                arguments.Append(argumentsList[i]);
                if (i != argumentsList.Count)
                {
                    arguments.Append(" ");
                }
            }

            var result = new ProcessStartInfo
            {
                FileName = _pathManager.PathToFsi,
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