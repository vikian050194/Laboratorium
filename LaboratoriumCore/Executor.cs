using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace LaboratoriumCore
{
    public class Executor
    {
        private string GetAssemblyDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        public List<string> Execute(string query)
        {
            var path = GetAssemblyDirectory();
            var pathToFsi = path+ @"\..\..\packages\FSharp.Compiler.Tools.4.0.1.10\tools\fsi.exe";
            //var pathToFsi = path+ @"\v4.0\Fsi.exe";
            //var pathToFsi = @"C:\Program Files (x86)\Microsoft SDKs\F#\4.0\Framework\v4.0\Fsi.exe";
            var pathToLib = path+ @"\LaboratoriumLib.dll";

            var processInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                Arguments = $"/c \"{pathToFsi}\""
            };

            

            var process = Process.Start(processInfo);

            var writer = process.StandardInput;
            var reader = process.StandardOutput;

            writer.WriteLine($"#r \"{pathToLib}\";;");
            writer.WriteLine(@"open LaboratoriumLib;;");
            writer.WriteLine(@"{0};;", query);
            writer.WriteLine("#quit;;");

            var resultLog = new List<string>();

            try
            {
                var line = reader.ReadToEnd();
                resultLog = line.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception e)
            {
                resultLog.Add(e.Message);
            }
            finally
            {
                writer.Close();
                reader.Close();
                //process.WaitForExit();
                process.Close();
            }

            return resultLog;
        }
    }
}
