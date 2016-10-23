namespace Laboratorium.Lib
{
    public interface IAlgorithm<out T>
    {
        T Execute();
    }
}