using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Laboratorium.Algorithms.Factorization.GreatestCommonDivisor;
using Laboratorium.Resources.Properties;
using Laboratorium.Types.Common;

namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    public class EllipticCurveMethod
    {
        public BigInteger Execute(BigInteger n, int b1, int round)
        {
            var b2 = b1 * 100;

            return Execute(n, b1, b2, round);
        }

        public BigInteger Execute(BigInteger n, int b1, int b2, int round)
        {
            var randomGenerator = new RandomGenerator(new NumericRandomGenerator(n));

            var degrees = GetDegrees(b1);

            for (var i = 1; i <= round; i++)
            {
                var point = randomGenerator.GetNextPoint();
                var ellipticCurve = randomGenerator.GetNextEllipticCurve(point);

                var d = FirstCondition(n, ellipticCurve);

                if (n == d)
                {
                    continue;
                }

                if (d > 1 && d < n)
                {
                    return d;
                }

                var suitablePrimeNumbers = degrees.Keys.OrderBy(k => k).ToList();

                foreach (var suitablePrimeNumber in suitablePrimeNumbers)
                {
                    var pointForIteration = point.Clone();

                    for (int r = 1; r <= degrees[suitablePrimeNumber]; r++)
                    {
                        var max = r != degrees[suitablePrimeNumber]
                            ? degrees[suitablePrimeNumber]
                            : degrees[suitablePrimeNumber] + 1;
                        for (int j = 1; j < max; j++)
                        {
                            pointForIteration = GetSumOfPoints(pointForIteration, point, ellipticCurve);
                            if (pointForIteration.X != point.X)
                            {
                                d = pointForIteration.X - point.X;
                                d = BigInteger.GreatestCommonDivisor(n, d);

                                if (d > 1 && d < n)
                                {
                                    return d;
                                }
                            }

                        }
                    }
                }
            }

            return -1;
        }

        private Point GetSumOfPoints(Point point1, Point point2, EllipticCurve ellipticCurve)
        {
            var lambda = GetLambda(ellipticCurve, point1, point2);

            var x = lambda * lambda - point1.X - point2.X;
            var y = lambda * (point1.X - x) - point1.Y;

            var result = new Point(x, y);

            return result;
        }

        private Dictionary<BigInteger, BigInteger> GetDegrees(int b)
        {
            var primeNumbers = GetPrimeNumbers();

            var result = new Dictionary<BigInteger, BigInteger>();

            foreach (var primeNumber in primeNumbers)
            {
                if (primeNumber < b)
                {
                    var k = BigInteger.Log(b, primeNumber);
                    result[new BigInteger(primeNumber)] = new BigInteger(k);
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        private int GetK(int b, int p)
        {
            int result = (int)Math.Floor(Math.Log(b, p));

            return result;
        }

        private List<int> GetPrimeNumbers()
        {
            var result = Settings.Default.PrimeNumbers.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).ToList();

            return result;
        }

        private BigInteger GetLambda(EllipticCurve ellipticCurve, Point point1, Point point2)
        {
            var numerator = BigInteger.Zero;
            var denumarator = BigInteger.One;

            if (point1.Equals(point2))
            {
                numerator = 3 * BigInteger.Pow(point1.X, 2) + ellipticCurve.A;
                denumarator = 2 * point1.Y;
            }
            else
            {
                numerator = point2.Y + point1.Y;
                denumarator = point2.X + point1.X;
            }

            var result = numerator / denumarator;

            return result;
        }

        private BigInteger FirstCondition(BigInteger n, EllipticCurve ellipticCurve)
        {
            var g = 4 * BigInteger.Pow(ellipticCurve.A, 3) + 27 * BigInteger.Pow(ellipticCurve.B, 2);
            var d = BigInteger.GreatestCommonDivisor(n, g);

            return d;
        }
    }
}