using System;
using System.Collections.Generic;
using FluentAssertions;
using Laboratorium.Core.Managers;
using Laboratorium.Tests.AlgorithmsLibraryState;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Laboratorium.Tests.General
{
    [TestClass]
    public class BasicRequirementsTest: BaseTest
    {
        private readonly AssemblyExplorer _assemblyExplorer;
        public BasicRequirementsTest()
        {
            _assemblyExplorer = new AssemblyExplorer(new AssemblyManager(new TestPathManager()));
            
        }
         
        [TestMethod]
        public void ResourcesContainsInformationAboutAllFamilies()
        {
            var interfaces = _assemblyExplorer.GetIterfaces();

            foreach (var name in interfaces)
            {
                Trace(name);
                Resources.Properties.Resources.ResourceManager.GetString(name)
                    .Should()
                    .NotBeNullOrWhiteSpace();
            }
        }

        [TestMethod]
        public void FunctionsAliasesAreUnique()
        {
            var aliases = _assemblyExplorer.GetAliases();
            var uniqueAliases = new HashSet<string>();

            foreach (var name in aliases)
            {
                Trace(name);
                if (uniqueAliases.Contains(name))
                {
                    throw new ArgumentException("Не уникальное значение псевдонима: " + name);
                }
                uniqueAliases.Add(name);
            }
        }

        [TestMethod]
        public void Attribut()
        {

        }
    }
}
