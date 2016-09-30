using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace LaboratoriumCore
{
    public class Executor
    {
        public List<string> Execute(string query)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = @"cmd.exe",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                Arguments = @"/c ""C:\Program Files (x86)\Microsoft SDKs\F#\4.0\Framework\v4.0\Fsi.exe"""
            };

            var process = Process.Start(processInfo);

            var writer = process.StandardInput;
            var reader = process.StandardOutput;
            //var currentDirectory = Environment.CurrentDirectory;
            //writer.WriteLine(@"#I ""C:\Users\KirillV\Documents\Git\Laboratorium\LaboratoriumLib\bin\Debug"";;");
            //writer.WriteLine(@"#r "".\LaboratoriumLib.dll"";;");
            //writer.WriteLine(@"open LaboratoriumLib;;");
            writer.WriteLine(@"{0}", query);

            var resultLog = new List<string>();

            try
            {
                var line = "";
                for (int i = 0; i < 7; i++)
                {
                    line = reader.ReadLine();
                    resultLog.Add(line);
                }
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

        public List<string> Foo()
        {
            var files = Directory.GetFiles(Environment.CurrentDirectory).ToList();
            return files;
        }
    }
}
