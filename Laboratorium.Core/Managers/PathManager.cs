using System;
using System.IO;
using System.Reflection;
using Laboratorium.Resources.Properties;

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
            PathToAssembly = Path.Combine(AssembliesDirectory, Settings.Default.MainAssemblyName);
        }

        private string GetAssembliesDirectory()
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
            PathToFsi = AssembliesDirectory + @"\..\..\FSharp\Fsi.exe";
        }
    }

    public class TestPathManager : PathManager
    {
        public TestPathManager()
        {
            PathToFsi = AssembliesDirectory + @"\..\..\..\FSharp\Fsi.exe";
        }
    }
}