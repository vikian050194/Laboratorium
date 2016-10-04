using System.Collections.Generic;

namespace LaboratoriumLib
{
    public interface IAlgorithm
    {
        int Execute();
    }

    public interface IListAlgorithm
    {
        int[] Execute();
    }
}