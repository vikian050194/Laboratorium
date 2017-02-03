using System.IO;

namespace Laboratorium.Core.Managers
{
    public class FileManager
    {
        private string _lastFile;

        public void SaveScript(string script, string path)
        {
            var file = Path.GetTempFileName();
            file = Path.ChangeExtension(file, "fsx");
            _lastFile = file;
            //var file = path;
            File.WriteAllText(file, script);
        }

        public string GetLastFile()
        {
            return _lastFile;
        }
    }
}