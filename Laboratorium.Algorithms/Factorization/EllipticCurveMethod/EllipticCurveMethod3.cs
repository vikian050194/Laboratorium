using System;
using System.Numerics;

namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    public class EllipticCurveMethod3 : EllipticCurveMethod
    {
        public Tuple<BigInteger, BigInteger> Execute(BigInteger n, BigInteger k, BigInteger attempts)
        {
            var count = BigInteger.Zero;

            IRandomGenerator randomGenerator = new RandomGenerator(n);

            var euclid = new AdvancedEuclid.AdvancedEuclid();
            var list = new RandomSequenceGenarator().GetList(n, attempts);

            for (var i = BigInteger.Zero; i < list.Count; i++)
            {
                var point = randomGenerator.GetNextPoint();
                var ellipticCurve = randomGenerator.GetNextEllipticCurve(point);

                var accumulator = point;

                for (var j = new BigInteger(2); j <= k; j++)
                {
                    var d = FirstCondition(n, ellipticCurve);

                    if (n == d)
                    {
                        break;
                    }

                    if (d > 1 && d < n)
                    {
                        return new Tuple<BigInteger, BigInteger>(d, count);
                    }

                    for (var l = BigInteger.One; l < j; l++)
                    {
                        var lambda = GetLambda(n, accumulator, point, ellipticCurve);
                        var table = euclid.Execute(lambda.Denumerator, n);

                        d = table[table.Count - 2].R;

                        if (d > 1 && d < n)
                        {
                            return new Tuple<BigInteger, BigInteger>(d, count);
                        }

                        var lambdaValue = GetLambdaValue(n, lambda, table);
                        accumulator = GetSumOfPoints(n, lambdaValue, accumulator, point);

                        count++;
                    }

                    point = accumulator;
                }
            }

            return new Tuple<BigInteger, BigInteger>(BigInteger.MinusOne, count); ;
        }
    }
}