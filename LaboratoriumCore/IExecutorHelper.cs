using System.Collections.Generic;

namespace LaboratoriumCore
{
    public interface IExecutorHelper
    {
        string PathToFsi { get; }
        string PathToLib { get; }

        Dictionary<string, string> GetNamespaces();
        List<string> GetAlgorithmTypes();
        List<string> GetFunctions(List<string> algorithmFamilies);
    }
}