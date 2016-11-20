using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Laboratorium.Attributes;
using Laboratorium.Core.Managers;

namespace Laboratorium.Core.AlgorithmsLibrary
{
    internal class Librarian
    {
        private readonly List<AlgorithmFamily> _algorithmFamilies;

        public Librarian()
        {
            _algorithmFamilies = GetAlgorithmFamilies();
        }

        private List<AlgorithmFamily> GetAlgorithmFamilies()
        {
            var algorithmFamilies = new List<AlgorithmFamily>();

            IAssemblyManager assemblyManager = new AssemblyManager();

            var assembly = assemblyManager.GetMainAssembly();

            foreach (var type in assembly.GetTypes())
            {
                if (!IsAlgorithmInterface(type))
                {
                    if (IsNewAlgorithmFamily(type, algorithmFamilies))
                    {
                        AddNewFamily(type, algorithmFamilies);
                    }

                    var family = algorithmFamilies.Find(f => f.Namespace == type.Namespace);

                    if (IsAlgorithmImplementation(type))
                    {
                        AddAlgorithmInFamily(type, family);
                    }
                }

                //if (IsAlgorithmInterface(type))
                //{
                //    AddAdapterInFamily(type, family);
                //}
            }

            return algorithmFamilies;
        }

        private void AddNewFamily(Type type, List<AlgorithmFamily> algorithmFamilies)
        {
            var familyNamespace = type.Namespace;

            var levels = type.Namespace.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var familyName = levels.Last();

            algorithmFamilies.Add(new AlgorithmFamily(familyName, familyNamespace));
        }

        private bool IsAlgorithmInterface(Type type)
        {
            var result = type.IsInterface;

            return result;
        }

        private void AddAdapterInFamily(Type type, AlgorithmFamily family)
        {
            //TODO
        }

        private void AddAlgorithmInFamily(Type type, AlgorithmFamily family)
        {
            var function = new StringBuilder();

            var alias = type.GetCustomAttributes<FunctionAliasAttribute>().First().Alias;
            function.AppendFormat("let {0} ", alias);
            var ial = type.GetInterfaces().First();
            var method = ial.GetMethods().First();
            var args = method.GetParameters();
            var arguments = args.Select(parameterInfo => parameterInfo.Name).ToList();

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

        public List<string> GetAlgorithmFamiliesNames()
        {
            var result = _algorithmFamilies.Select(f => f.Name).ToList();

            return result;
        }

        public List<string> GetFunctions(string algorithmFamily)
        {
            var family = _algorithmFamilies.Find(af => af.Name == algorithmFamily);

            var result = family.Functions.Select(f => f.DefaultFunction).ToList();

            return result;
        }

        public string GetOpen(string algorithmFamily)
        {
            var result = "open " + _algorithmFamilies.Find(af => af.Name == algorithmFamily).Namespace;

            return result;
        }
    }
}