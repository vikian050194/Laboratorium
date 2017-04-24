using System.Collections.Generic;
using System.Linq;

namespace Laboratorium.Core.Managers
{
    public class CodeManager : ICodeManager
    {
        private readonly CodeGenerator _codeGenerator;

        public CodeManager()
        {
            _codeGenerator = new CodeGenerator();
        }

        public List<string> GetFunctions(string algorithmFamily)
        {
            var family = _codeGenerator.GetAlgorithmFamilies().Find(af => af.Name == algorithmFamily);

            var result = family.Functions.Select(f => f.DefaultFunction).ToList();

            return result;
        }

        public List<string> GetAlgorithmFamilies()
        {
            return _codeGenerator.GetAlgorithmFamilies().Select(f => f.Name).ToList();
        }

        public List<string> GetFunctions(List<string> algorithmFamilies)
        {
            var result = new List<string>();

            foreach (var algorithmFamily in algorithmFamilies)
            {
                var functions = GetFunctions(algorithmFamily);
                result.AddRange(functions);
            }

            return result;
        }

        public List<string> GetAdapters(List<string> algorithmFamilies)
        {
            var result = new List<string>();
            return result;
        }

        private string GetOpen(string algorithmFamily)
        {
            return _codeGenerator.GetAlgorithmFamilies().Find(af => af.Name == algorithmFamily).Open;
        }

        public List<string> GetOpens(List<string> algorithmFamilies)
        {
            var result = new List<string>();

            foreach (var algorithmFamily in algorithmFamilies)
            {
                var open = GetOpen(algorithmFamily);
                result.Add(open);
            }

            return result;
        }
    }
}