using System.IO;
using System.Net;

namespace Laboratorium.Core.Managers
{
    public class FileManager
    {
        public string SaveScript(string script)
        {
            var file = Path.GetTempFileName();
            file = Path.ChangeExtension(file, "fsx");
            File.WriteAllText(file, script);

            return file;
        }
    }
}