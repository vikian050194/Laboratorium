using System.Collections.Generic;
using System.Numerics;
using Laboratorium.Algorithms.Factorization.AdvancedEuclid;

namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    public abstract class EllipticCurveMethod
    {
        protected BigInteger GetLambdaValue(BigInteger n, Lambda lambda, List<TableRow> table)
        {
            var lambdaValue = lambda.Numerator * table[table.Count - 2].V;
            lambdaValue = new ZnCutter().Cut(lambdaValue, n);
            return lambdaValue;
        }

        protected Point GetSumOfPoints(BigInteger n, BigInteger lambda, Point point1, Point point2)
        {
            var x = lambda * lambda - point1.X - point2.X;
            x = new ZnCutter().Cut(x, n);
            var y = lambda * (point1.X - x) - point1.Y;
            y = new ZnCutter().Cut(y, n);
            var result = new Point(x, y);

            return result;
        }

        protected Lambda GetLambda(BigInteger n, Point point1, Point point2, EllipticCurve ellipticCurve)
        {
            var numerator = BigInteger.Zero;
            var denumarator = BigInteger.One;

            if (point1.Equals(point2))
            {
                numerator = 3 * BigInteger.Pow(point1.X, 2) + ellipticCurve.A;
                numerator = new ZnCutter().Cut(numerator, n);
                denumarator = 2 * point1.Y;
                denumarator = new ZnCutter().Cut(denumarator, n);
            }
            else
            {
                numerator = point2.Y - point1.Y;
                numerator = new ZnCutter().Cut(numerator, n);
                denumarator = point2.X - point1.X;
                denumarator = new ZnCutter().Cut(denumarator, n);
            }

            var result = new Lambda { Numerator = numerator, Denumerator = denumarator };

            return result;
        }

        protected BigInteger FirstCondition(BigInteger n, EllipticCurve ellipticCurve)
        {
            var g = 4 * BigInteger.Pow(ellipticCurve.A, 3) + 27 * BigInteger.Pow(ellipticCurve.B, 2);
            var d = BigInteger.GreatestCommonDivisor(n, g);

            return d;
        }
    }
}