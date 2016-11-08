namespace Laboratorium.Algorithms
{
    public interface IAlgorithmS<T>
    {
        T Execute(T a, T b);
    }

    public interface IAlgorithm2<T>
    {
        T Execute(T a, T b, IAlgorithmS<T> subAlgorithm);
    }
}