using System;
using System.IO;
using System.Reflection;

namespace Laboratorium.Core.Managers
{
    public abstract class PathManager
    {
        public string PathToFsi { get; protected set; }
        public string PathToLib { get; protected set; }
        public string AssembliesDirectory { get; protected set; }
        protected string GetAssembliesDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }

    public class RealPathManager : PathManager
    {
        public RealPathManager()
        {
            AssembliesDirectory = GetAssembliesDirectory();
            PathToFsi = AssembliesDirectory + @"\..\..\FSharp\Fsi.exe";
            PathToLib = AssembliesDirectory + @"\Laboratorium.Algorithms.dll";
        }
    }

    public class TestPathManager : PathManager
    {
        public TestPathManager()
        {
            AssembliesDirectory = GetAssembliesDirectory();
            PathToFsi = AssembliesDirectory + @"\..\..\..\FSharp\Fsi.exe";
            PathToLib = AssembliesDirectory + @"\Laboratorium.Algorithms.dll";
        }
    }
}