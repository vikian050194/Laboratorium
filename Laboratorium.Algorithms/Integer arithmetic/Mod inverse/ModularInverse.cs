using System.Numerics;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Integer_arithmetic.Mod_inverse
{
    interface IModInverse
    {
        BigInteger Execute(BigInteger n, BigInteger m);
    }
    [FunctionAlias("ModInverse"), DefaultImplementation]
    public class ModularInverse:IModInverse
    {
        public BigInteger Execute(BigInteger n, BigInteger m)
        {
            return Inverse(n, m);
        }
        public BigInteger Inverse(BigInteger number,BigInteger mod,out BigInteger gcd)
        {
            var exEuclideanAlgorithm=new ExtendedEuclideanAlgorithm();
            var bezoutCoeff = exEuclideanAlgorithm.FindBezoutCoefficients(number, mod);
            gcd = bezoutCoeff.Item3;
            return bezoutCoeff.Item1;
        }
        public BigInteger Inverse(BigInteger number, BigInteger mod)
        {
            var exEuclideanAlgorithm = new ExtendedEuclideanAlgorithm();
            var bezoutCoeff = exEuclideanAlgorithm.FindBezoutCoefficients(number, mod);
            return bezoutCoeff.Item1;
        }
    }
}
