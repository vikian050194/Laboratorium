namespace Laboratorium.Algorithms.Factorization
{
    [Function("gcd")]
    public class SingleGCD : IAlgorithmS<int>
    {
        public int Execute(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }
    }
}