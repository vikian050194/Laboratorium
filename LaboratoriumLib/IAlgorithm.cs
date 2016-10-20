namespace LaboratoriumLib
{
    public interface IAlgorithm<out T>
    {
        T Execute();
    }
}