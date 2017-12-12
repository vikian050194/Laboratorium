using System;
using System.IO;

namespace Laboratorium.Core.Managers
{
    public class FileManager
    {
        public string SaveScript(string script)
        {
            var file = string.Empty;
            file = Path.GetTempFileName();
            file = Path.ChangeExtension(file, "fsx");
            var indexOfDot = file.IndexOf(".");
            file = file.Insert(indexOfDot, DateTime.Now.Ticks.ToString());

            File.WriteAllText(file, script);

            return file;
        }
    }
}