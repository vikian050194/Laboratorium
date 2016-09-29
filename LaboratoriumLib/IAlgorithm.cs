namespace LaboratoriumLib
{
    public interface IAlgorithm
    {
        int Execute(int a, int b);
    }

    public class Addition : IAlgorithm
    {
        public Addition()
        {
            
        }
        public int Execute(int a, int b)
        {
            return a + b;
        }
    }
}