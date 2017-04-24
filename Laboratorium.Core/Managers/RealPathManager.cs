namespace Laboratorium.Core.Managers
{
    public class RealPathManager : PathManager
    {
        public RealPathManager()
        {
            PathToFsi = AssembliesDirectory + @"\..\..\FSharp\Fsi.exe";
        }
    }
}