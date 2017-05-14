using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Laboratorium.Attributes;
using Laboratorium.Core.Managers;

namespace Laboratorium.Tests.General
{
    internal class AssemblyExplorer
    {
        private IAssemblyManager _assemblyManager;
        public AssemblyExplorer(IAssemblyManager assemblyManager)
        {
            _assemblyManager = assemblyManager;
        }

        public List<string> GetIterfaces()
        {
            var result = new List<string>();
            var assembly = _assemblyManager.GetMainAssembly();
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.IsInterface)
                {
                    result.Add(type.Name);
                }
            }

            return result;
        }

        public List<string> GetAliases()
        {
            var result = new List<string>();
            var assembly = _assemblyManager.GetMainAssembly();
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                var aliasAttribute = type.GetCustomAttributes<FunctionAliasAttribute>().FirstOrDefault();
                if (aliasAttribute != null)
                {
                    result.Add(aliasAttribute.Alias);
                }
            }

            return result;
        }
    }
}