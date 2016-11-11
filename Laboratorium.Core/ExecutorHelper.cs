﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Laboratorium.Core
{
    public class ExecutorHelper : IExecutorHelper
    {
        public ExecutorHelper()
        {
            var path = GetAssemblyDirectory();
            PathToFsi = path + @"\..\..\FSharp\Fsi.exe";
            PathToLib = path + @"\Laboratorium.Algorithms.dll";
        }

        public string GetAssemblyDirectory()
        {
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        public string PathToFsi { get; }
        public string PathToLib { get; }

        public Dictionary<string, string> GetNamespaces()
        {
            var assembly = Assembly.ReflectionOnlyLoadFrom(PathToLib);
            var result = new Dictionary<string, string>();

            var types = new Type[0];

            types = assembly.GetExportedTypes();

            foreach (var type in types)
            {
                var levels = type.Namespace.Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries);

                if (levels.Count() == 3)
                {
                    result[levels[2]] = type.Namespace;
                }
            }

            return result;
        }

        public List<string> GetAlgorithmTypes()
        {
            return GetNamespaces().Keys.ToList();
        }

        public List<string> GetFunctions(List<string> algorithmFamilies)
        {
            var assembly = Assembly.ReflectionOnlyLoadFrom(PathToLib);
            var result = new List<string>();
            var function = new StringBuilder();

            foreach (var algorithmFamily in algorithmFamilies)
            {
                foreach (var type in assembly.GetTypes())
                {
                    if (type.Namespace.Contains(algorithmFamily) && CheckType(type))
                    {
                        function.Clear();
                        var alias = type.GetCustomAttributesData().First().ConstructorArguments.First().Value.ToString();
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

                        result.Add(function.ToString());
                    }
                }
            }

            return result;
        }

        private bool CheckType(Type type)
        {
            var result = !type.IsAbstract;

            result = result && type.IsClass;

            return result;
        }
    }
}