using System.Collections.Generic;
using System.Linq;

namespace Laboratorium.Core.AlgorithmsLibrary
{
    internal class Librarian
    {
        private readonly List<AlgorithmFamily> _algorithmFamilies;

        public Librarian()
        {
            var codeGenerator = new CodeGenerator();
            _algorithmFamilies = codeGenerator.GetAlgorithmFamilies();
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
            var result = _algorithmFamilies.Find(af => af.Name == algorithmFamily).Open;

            return result;
        }
    }
}