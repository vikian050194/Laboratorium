using System.IO;

namespace Laboratorium.Core.Managers
{
    public class FileManager
    {
        private string _path;

        public void SaveScript(string script, string user, string path)
        {
            _path = Path.Combine(path, user + ".fsx");

            File.WriteAllText(_path, script);
        }

        public string GetPath()
        {
            return _path;
        }
    }
}