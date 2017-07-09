using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Laboratorium.Attributes;
using Laboratorium.Core.Containers;
using Laboratorium.Core.Managers;

namespace Laboratorium.Core
{
    internal class CodeGenerator
    {
        private readonly IAssemblyManager _assemblyManager;

        public CodeGenerator()
        {
            _assemblyManager = new AssemblyManager(new RealPathManager());
        }

        public List<AlgorithmFamily> GetAlgorithmFamilies()
        {
            var algorithmFamilies = new List<AlgorithmFamily>();
            var assembly = _assemblyManager.GetMainAssembly();
            var includedFamilies = new List<Type>();
            var necessaryFamilies = new List<Type>();
            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                if (type.IsInterface)
                {
                    includedFamilies.Add(type);
                    AddNewFamily(type, algorithmFamilies);
                    var argumentsTypes = GetArgumentsTypes(type);

                    foreach (var argumentsType in argumentsTypes)
                    {
                        if (argumentsType.IsInterface &&
                            necessaryFamilies.All(f => f.Namespace != argumentsType.Namespace))
                        {
                            necessaryFamilies.Add(argumentsType);
                        }
                    }
                }
            }

            foreach (var type in types)
            {
                if (!type.IsInterface && !type.IsAbstract)
                {
                    AddAlgorithmInFamily(type, algorithmFamilies);
                }
            }

            algorithmFamilies.RemoveAll(f => !f.Functions.Any());

            return algorithmFamilies;
        }

        private MethodInfo GetMainMethod(Type type)
        {
            var result = type.GetMethods().First();
            return result;
        }

        private List<ParameterInfo> GetArguments(Type type)
        {
            var method = GetMainMethod(type);
            var result = method.GetParameters().ToList();
            return result;
        }

        private List<string> GetArgumentsNames(Type type)
        {
            return GetArguments(type).Select(parameterInfo => parameterInfo.Name).ToList();
        }

        private List<Type> GetArgumentsTypes(Type type)
        {
            return GetArguments(type).Select(parameterInfo => parameterInfo.ParameterType).ToList();
        }

        private AlgorithmFamily AddNewFamily(Type type, List<AlgorithmFamily> algorithmFamilies)
        {
            var familyNamespace = type.Namespace;
            AlgorithmFamily family;

            if (!algorithmFamilies.Exists(f => f.Namespace == familyNamespace))
            {
                family = new AlgorithmFamily(type.Name, familyNamespace);
                algorithmFamilies.Add(family);
            }
            else
            {
                family = algorithmFamilies.Find(f => f.Namespace == familyNamespace);
            }

            return family;
        }

        private void AddAdapterInFamily(Type type, AlgorithmFamily family)
        {
            //TODO
        }

        private void AddAlgorithmInFamily(Type type, List<AlgorithmFamily> algorithmFamilies)
        {
            var function = new StringBuilder();
            var aliasAttribute = type.GetCustomAttributes<FunctionAliasAttribute>().FirstOrDefault();

            if (aliasAttribute == null)
            {
                return;
            }

            var implementationOf = type.GetInterfaces().FirstOrDefault();
            if (implementationOf == null)
            {
                return;
            }

            var family = algorithmFamilies.FirstOrDefault(f => f.Name == implementationOf.Name);
            if (family == null)
            {
                return;
            }
            
            var alias = aliasAttribute.Alias;
            function.AppendFormat("let {0} ", alias);
            var method = GetMainMethod(type);
            var arguments = GetArgumentsNames(type);

            foreach (var argument in arguments)
            {
                function.AppendFormat("{0} ", argument);
            }

            function.AppendFormat("= {0}().{1}(", type.Name, method.Name);

            for (var i = 0; i < arguments.Count; i++)
            {
                function.Append(arguments[i]);

                if (i != arguments.Count - 1)
                {
                    function.Append(",");
                }
            }

            function.Append(")");
            var newFunction = new AlgorithmFamilyFunction(function.ToString(), "little bit later");
            family.Functions.Add(newFunction);
        }

        private bool IsNewAlgorithmFamily(Type type, List<AlgorithmFamily> algorithmFamilies)
        {
            var result = algorithmFamilies.All(af => af.Namespace != type.Namespace);
            return result;
        }

        private bool IsAlgorithmImplementation(Type type)
        {
            var result = type.IsClass;
            return result;
        }
    }
}