﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Laboratorium.Models.ViewModels;

namespace Laboratorium
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

        public PacketViewModel Execute(PacketViewModel packet)
        {
            var path = GetAssemblyDirectory();
            var pathToFsi = path+ @"\..\..\packages\FSharp.Compiler.Tools.4.0.1.10\tools\fsi.exe";
            //var pathToFsi = path+ @"\v4.0\Fsi.exe";
            //var pathToFsi = @"C:\Program Files (x86)\Microsoft SDKs\F#\4.0\Framework\v4.0\Fsi.exe";
            var pathToLib = path+ @"\LaboratoriumLib.dll";
            //var pathToLib = @"D:\Code\MVC\Laboratorium\LaboratoriumLib\bin\Debug\LaboratoriumLib.dll";

            var processInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                Arguments = $"/c \"{pathToFsi}\""
            };

            var process = Process.Start(processInfo);

            var writer = process.StandardInput;
            var reader = process.StandardOutput;
            var error = process.StandardError;

            writer.WriteLine("#r @\"{0}\";;", pathToLib);
            writer.WriteLine("open LaboratoriumLib;;");
            writer.WriteLine("open LaboratoriumLib.Factorization;;");
            writer.WriteLine("{0}", packet.Query);
            writer.WriteLine("#quit;;");

            try
            {
                packet.Results = reader.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
                packet.Errors = error.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
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

            return packet;
        }
    }
}