using System;
using System.IO;
using System.Reflection;

namespace Laboratorium.Core.Managers
{
    public abstract class PathManager
    {
        public string PathToFsi { get; protected set; }
        public string PathToAssembly { get; private set; }
        public string AssembliesDirectory { get; private set; }

        protected PathManager()
        {
            AssembliesDirectory = GetAssembliesDirectory();
            PathToAssembly = Path.Combine(AssembliesDirectory, "Laboratorium.Algorithms.dll");
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