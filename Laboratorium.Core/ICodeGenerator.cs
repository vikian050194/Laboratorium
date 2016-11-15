using System.Collections.Generic;

namespace Laboratorium.Core
{
    public interface ICodeGenerator
    {
        Dictionary<string, string> GetNamespaces();
        List<string> GetAlgorithmTypes();
        List<string> GetFunctions(List<string> algorithmFamilies);
    }
}