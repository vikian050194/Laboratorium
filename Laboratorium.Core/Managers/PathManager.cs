using System;
using System.IO;
using System.Reflection;

namespace Laboratorium.Core.Managers
{
    interface IPathManager
    {
        string PathToFsi { get; }
        string PathToLib { get; }
        string AssembliesDirectory { get; }
    }
    class PathManager: IPathManager
    {
        public string PathToFsi { get; private set; }
        public string PathToLib { get; private set; }
        public string AssembliesDirectory { get; private set; }

        public PathManager()
        {
            AssembliesDirectory = GetAssembliesDirectory();
            PathToLib = AssembliesDirectory + @"\..\..\FSharp\Fsi.exe";
            PathToLib = AssembliesDirectory + @"\Laboratorium.Algorithms.dll";
        }

        private string GetAssembliesDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}
