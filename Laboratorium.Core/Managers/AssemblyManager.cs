using System;
using System.IO;
using System.Reflection;

namespace Laboratorium.Core.Managers
{
    public class AssemblyManager : IAssemblyManager
    {
        private readonly PathManager _pathManager;

        public AssemblyManager(PathManager pathManager)
        {
            _pathManager = pathManager;
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
            return GetAssembly(_pathManager.PathToAssembly);
        }
    }
}