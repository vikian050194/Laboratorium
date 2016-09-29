using System.Numerics;

namespace LaboratoriumLib.Factorization
{
    public class GreatestCommonDivisor: IAlgorithm
    {
        public object Execute(params object[] args)
        {
            var result = (BigInteger)args[0];

            for (var i = 1; i < args.Length && result != 1; i++)
            {
                var item = (BigInteger)args[i];

                result = BigInteger.GreatestCommonDivisor(result, item);
            }

            return result;
        }
    }
}
