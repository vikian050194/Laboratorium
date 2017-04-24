using System.Reflection;

namespace Laboratorium.Core.Managers
{
    public interface IAssemblyManager
    {
        Assembly GetAssembly(string path);
        Assembly GetMainAssembly();
    }
}