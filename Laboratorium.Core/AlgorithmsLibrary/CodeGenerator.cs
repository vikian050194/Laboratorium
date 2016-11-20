using System.Collections.Generic;

namespace Laboratorium.Core.AlgorithmsLibrary
{
    public interface ICodeGenerator
    {
        List<string> GetAlgorithmFamilies();
        List<string> GetFunctions(List<string> algorithmFamilies);
        List<string> GetAdapters(List<string> algorithmFamilies);
        List<string> GetOpens(List<string> algorithmFamilies);
    }

    public class CodeGenerator : ICodeGenerator
    {
        private readonly Librarian _librarian;

        public CodeGenerator()
        {
            _librarian = new Librarian();
        }

        public List<string> GetAlgorithmFamilies()
        {
            return _librarian.GetAlgorithmFamiliesNames();
        }

        public List<string> GetFunctions(List<string> algorithmFamilies)
        {
            var result = new List<string>();

            foreach (var algorithmFamily in algorithmFamilies)
            {
                var functions = _librarian.GetFunctions(algorithmFamily);

                result.AddRange(functions);
            }

            return result;
        }

        public List<string> GetAdapters(List<string> algorithmFamilies)
        {
            var result = new List<string>();

            return result;
        }

        public List<string> GetOpens(List<string> algorithmFamilies)
        {
            var result = new List<string>();

            foreach (var algorithmFamily in algorithmFamilies)
            {
                var open = _librarian.GetOpen(algorithmFamily);

                result.Add(open);
            }

            return result;
        }
    }
}