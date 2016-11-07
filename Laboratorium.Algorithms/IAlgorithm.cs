namespace Laboratorium.Algorithms
{
    public interface IAlgorithm<out T>
    {
        T Execute();
    }
}