namespace Laboratorium.Core.Managers
{
    public class TestPathManager : PathManager
    {
        public TestPathManager()
        {
            PathToFsi = AssembliesDirectory + @"\..\..\..\FSharp\Fsi.exe";
        }
    }
}