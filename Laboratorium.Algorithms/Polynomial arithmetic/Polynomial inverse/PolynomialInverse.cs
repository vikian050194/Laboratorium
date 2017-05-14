using Laboratorium.Types.Algebra;

namespace Laboratorium.Algorithms.Polynomial_arithmetic.Polynomial_inverse
{
    public class PolynomialInverse
    {
        public Polynomial Inverse(Polynomial polynomial,Polynomial mod)
        {
            var exEuclideanAlgorithm = new PolynomialExtendedEuclideanAlgorithm();
            var bezoutCoeff = exEuclideanAlgorithm.FindBezoutCoefficients(polynomial, mod);
            return bezoutCoeff.Item1;
        }
    }
}
