using System;
using System.Diagnostics;
using System.Linq;

namespace LaboratoriumCore
{
    public class Executor
    {
        private readonly ExecutorHelper _executorHelper;

        public Executor()
        {
            _executorHelper = new ExecutorHelper();
        }

        public Packet Execute(Packet packet)
        {
            var processInfo = GetProcessInfo();

            var process = Process.Start(processInfo);

            var writer = process.StandardInput;
            var reader = process.StandardOutput;
            var error = process.StandardError;

            writer.WriteLine("#r @\"{0}\";;", _executorHelper.PathToLib);

            var algorithmFamilies = _executorHelper.GetAlgorithmTypes();
            var foo = _executorHelper.GetNamespaces();
            foreach (var algorithmFamily in foo.Values)
            {
                writer.WriteLine("open {0};;", algorithmFamily);
            }
            var functions = _executorHelper.GetFunctions(algorithmFamilies);

            foreach (var function in functions)
            {
                writer.WriteLine(function);
            }

            writer.WriteLine("{0}", packet.Query);
            writer.WriteLine("#quit;;");

            try
            {
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
            }
            catch (Exception e)
            {
                packet.Errors.Add(e.Message);
            }
            finally
            {
                writer.Close();
                reader.Close();
                process.WaitForExit();
                process.Close();
            }

            //TODO: Add filter for result  

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