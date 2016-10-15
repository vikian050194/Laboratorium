namespace LaboratoriumLib
{
    public interface IAlgorithm<T>
    {
        T Execute(T a, T b);
    }
}