using LaboratoriumLib.Attributes;

namespace LaboratoriumLib.Algorithms.Factorization
{
    [Function("gcd")]
    public class SingleGCD : IAlgorithm<int>
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