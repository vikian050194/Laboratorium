using System;
using System.IO;
using System.Reflection;

namespace Laboratorium.Core.Managers
{
    internal interface IAssemblyManager
    {
        Assembly GetAssembly(string path);
        Assembly GetMainAssembly();
    }

    internal class AssemblyManager : IAssemblyManager
    {
        private readonly IPathManager _pathManager;

        public AssemblyManager()
        {
            _pathManager = new PathManager();
        }

        public Assembly GetAssembly(string path)
        {
            var appDomain = AppDomain.CreateDomain("domain");
            var assembly = appDomain.Load(File.ReadAllBytes(path));
            AppDomain.Unload(appDomain);

            return assembly;
        }

        public Assembly GetMainAssembly()
        {
            return GetAssembly(_pathManager.PathToLib);
        }
    }
}