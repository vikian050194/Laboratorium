using System.Collections.Generic;

namespace Laboratorium.Core.Managers
{
    public interface ICodeManager
    {
        List<string> GetAlgorithmFamilies();
        List<string> GetFunctions(string algorithmFamily);
        List<string> GetFunctions(List<string> algorithmFamilies);
        List<string> GetAdapters(List<string> algorithmFamilies);
        List<string> GetOpens(List<string> algorithmFamilies);
    }
}