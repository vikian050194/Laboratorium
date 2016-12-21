using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Laboratorium.Resources.Properties;

namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    public class EllipticCurveMethod2
    {
        private readonly BigInteger _n;
        private readonly int _b;
        private readonly int _round;

        public EllipticCurveMethod2(BigInteger n, int b, int round)
        {
            _n = n;
            _b = b;
            _round = round;
        }

        public BigInteger Execute()
        {
            //IRandomGenerator randomGenerator = new RandomGenerator(_n, new NumericRandomGenerator(_n));
            IRandomGenerator randomGenerator = new TestRandomGenerator();
            var euclid = new AdvancedEuclid.AdvancedEuclid();

            var degrees = GetDegrees();

            for (var i = 1; i <= _round; i++)
            {
                var point = randomGenerator.GetNextPoint();
                var ellipticCurve = randomGenerator.GetNextEllipticCurve(point);

                var d = FirstCondition(_n, ellipticCurve);

                if (_n == d)
                {
                    continue;
                }

                if (d > 1 && d < _n)
                {
                    return d;
                }

                var suitablePrimeNumbers = degrees.Keys.OrderBy(k => k).ToList();

                var accumulator = new Point();

                foreach (var suitablePrimeNumber in suitablePrimeNumbers)
                {
                    for (int r = 1; r <= degrees[suitablePrimeNumber]; r++)
                    {
                        var max = degrees[suitablePrimeNumber];

                        for (int j = 1; j <= max; j++)
                        {
                            if (!accumulator.IsZero)
                            {
                                var lambda = GetLambda(accumulator, point, ellipticCurve);

                                var table = euclid.Execute(lambda.Denumerator, _n);

                                d = table[table.Count - 2].R;

                                if (d > 1 && d < _n)
                                {
                                    return d;
                                }

                                var l = lambda.Numerator * table[table.Count - 2].V;
                                //l = new ZnCutter().Cut(l, _n);

                                accumulator = GetSumOfPoints(l, accumulator, point, ellipticCurve);
                            }
                            else
                            {
                                accumulator = point.Clone();
                            }
                        }
                    }
                }
            }

            return -1;
        }

        private Point GetSumOfPoints(BigInteger lambda, Point point1, Point point2, EllipticCurve ellipticCurve)
        {
            var x = lambda * lambda - point1.X - point2.X;
            x = new ZnCutter().Cut(x, _n);
            var y = lambda * (point1.X - x) - point1.Y;
            y = new ZnCutter().Cut(y, _n);
            var result = new Point(x, y);

            return result;
        }

        private Dictionary<BigInteger, BigInteger> GetDegrees()
        {
            var primeNumbers = GetPrimeNumbers();

            var result = new Dictionary<BigInteger, BigInteger>();

            foreach (var primeNumber in primeNumbers)
            {
                if (primeNumber < _b)
                {
                    var k = BigInteger.Log(_b, primeNumber);
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

        private Lambda GetLambda(Point point1, Point point2, EllipticCurve ellipticCurve)
        {
            var numerator = BigInteger.Zero;
            var denumarator = BigInteger.One;

            if (point1.Equals(point2))
            {
                numerator = 3 * BigInteger.Pow(point1.X, 2) + ellipticCurve.A;
                numerator = new ZnCutter().Cut(numerator, _n);
                denumarator = 2 * point1.Y;
                denumarator = new ZnCutter().Cut(denumarator, _n);
            }
            else
            {
                numerator = point2.Y - point1.Y;
                numerator = new ZnCutter().Cut(numerator, _n);
                denumarator = point2.X - point1.X;
                denumarator = new ZnCutter().Cut(denumarator, _n);
            }

            var result = new Lambda { Numerator = numerator, Denumerator = denumarator };

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