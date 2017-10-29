using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Laboratorium.Core.Containers;
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

        public Packet GetNewEmptyPacket()
        {
            var result = new Packet
            {
                Title = @"Пакет-" + DateTime.Now
            };
            var algorithmFamilies = _codeManager.GetAlgorithmFamilies();

            foreach (var algorithmFamily in algorithmFamilies)
            {
                var info = Resources.Properties.Resources.ResourceManager.GetString(algorithmFamily) ?? string.Empty;
                result.Modules.Add(new ModuleItem(algorithmFamily, info, _codeManager.GetFunctions(algorithmFamily)));
            }

            return result;
        }

        public Packet Execute(Packet packet)
        {
            var modules = packet.Modules;

            var fileManager = new FileManager();
            var script = new StringBuilder();

            if (modules.Any(m => m.IsEnadled))
            {
                AddReference(script);
                var enabledModules = packet.Modules.Where(m => m.IsEnadled).Select(m => m.Name).ToList();
                AddOpen(script, enabledModules);
                AddFunctions(script, enabledModules);
            }

            script.Append(packet.Script);
            var file = fileManager.SaveScript(script.ToString());
            var processInfo = GetProcessInfo(file);
            var process = Process.Start(processInfo);

            var writer = process.StandardInput;
            var reader = process.StandardOutput;
            var error = process.StandardError;

            var output = reader.ReadToEnd();
            var errors = error.ReadToEnd();

            writer.Close();
            reader.Close();
            process.WaitForExit();
            process.Close();

            var outputManager = new OutputManager();
            packet = outputManager.Process(script.ToString(), output, errors);
            packet.Modules = modules;
            return packet;
        }

        private List<string> GetArguments(string file)
        {
            return new List<string>
            {
                "--nologo",
                "--exec",
                $@"--use:""{file}"""
            };
        }

        private void AddFunctions(StringBuilder script, List<string> modules)
        {
            var functions = _codeManager.GetFunctions(modules);
            functions.Add("let bi (n:int) = (new BigInteger(n));;");
            foreach (var function in functions)
            {
                script.AppendLine(function + ";;");
            }
        }

        private void AddOpen(StringBuilder script, List<string> modules)
        {
            var opens = _codeManager.GetOpens(modules);
            opens.Add("open System.Numerics;;");
            foreach (var line in opens)
            {
                script.AppendLine(line + ";;");
            }
        }

        private void AddReference(StringBuilder script)
        {
            var line = $"#r @\"{_pathManager.PathToAssembly}\";;";
            script.AppendLine(line);
        }

        private ProcessStartInfo GetProcessInfo(string file)
        {
            var argumentsList = GetArguments(file);
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