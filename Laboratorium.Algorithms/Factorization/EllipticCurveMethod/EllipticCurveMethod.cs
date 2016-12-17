using System;
using System.Collections.Generic;
using System.Linq;
using Laboratorium.Algorithms.Factorization.GreatestCommonDivisor;
using Laboratorium.Resources.Properties;
using Laboratorium.Types.Common;

namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    public class EllipticCurveMethod<T> where T : IEquatable<T>, IComparable<T>
    {
        public T Execute(IGreaterCommonDivisorAlgorithm<T> greaterCommonDivisor, T n, T b1, T round)
        {
            var b2 = (new NumericWrapper<T>(b1) * new NumericWrapper<T>("100")).Value;

            return Execute(greaterCommonDivisor, n, b1, b2, round);
        }

        public T Execute(IGreaterCommonDivisorAlgorithm<T> greaterCommonDivisor, T n, T b1, T b2, T round)
        {
            var randomGenerator = new RandomGenerator<T>(n, new NumericRandomGenerator<T>(n));

            var primeNumbers = GetPrimeNumbers();

            var degrees = GetDegrees(b1, primeNumbers);

            for (var i = new NumericWrapper<T>(default(T)); i <= round; i++)
            {
                var point = randomGenerator.GetNextPoint();
                var ellipticCurve = randomGenerator.GetNextEllipticCurve(point);

                var d = Condition1(n, ellipticCurve, greaterCommonDivisor);

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
                                d = greaterCommonDivisor.Execute(n, d);

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

        private Dictionary<int, int> GetDegrees(int b, List<int> primeNumbers)
        {
            var result = new Dictionary<int, int>();

            foreach (var primeNumber in primeNumbers)
            {
                if (primeNumber < b)
                {
                    var k = GetK(b, primeNumber);
                    result[primeNumber] = k;
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

        private int GetLambda(EllipticCurve ellipticCurve, Point point1, Point point2)
        {
            double numerator = 0;
            double denumarator = 1;

            if (point1.Equals(point2))
            {
                numerator = 3 * Math.Pow(point1.X, 2) + ellipticCurve.A;
                denumarator = 2 * point1.Y;
            }
            else
            {
                numerator = point2.Y + point1.Y;
                denumarator = point2.X + point1.X;
            }

            var result = (int)(numerator / denumarator);

            return result;
        }

        private int Condition1(int n, EllipticCurve<int> ellipticCurve, IGreaterCommonDivisorAlgorithm<int> greaterCommonDivisor)
        {
            var g = (int)(4 * Math.Pow(ellipticCurve.A, 3) + 27 * Math.Pow(ellipticCurve.B, 2));
            var d = greaterCommonDivisor.Execute(n, g);

            return d;
        }
    }
}
