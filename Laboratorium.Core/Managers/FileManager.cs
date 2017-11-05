using System;
using System.IO;

namespace Laboratorium.Core.Managers
{
    public class FileManager
    {
        public string SaveScript(string script)
        {
            var file = Path.GetRandomFileName();
            file = Path.ChangeExtension(file, "fsx");
            var indexOfDot = file.IndexOf(".");
            file = file.Insert(indexOfDot, DateTime.Now.Ticks.ToString());
            file = Path.Combine(Properties.Resources.Dustbin, file);
            File.WriteAllText(file, script);

            return file;
        }
    }
}