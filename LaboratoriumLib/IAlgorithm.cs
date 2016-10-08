using System.Collections.Generic;

namespace LaboratoriumLib
{
    public interface IAlgorithm<out T>
    {
        T Execute();
    }
}