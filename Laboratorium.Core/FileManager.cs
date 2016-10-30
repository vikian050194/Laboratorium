using System.IO;

namespace Laboratorium.Core
{
    public class FileManager
    {
        public string SaveScript(string script, string user, string path)
        {
            var result = Path.Combine(path, user + ".fsx");

            File.WriteAllText(result, script);

            return result;
        }
    }
}
