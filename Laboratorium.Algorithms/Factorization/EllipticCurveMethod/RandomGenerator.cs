using System.Numerics;

namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    internal class TestRandomGenerator : IRandomGenerator
    {
        public EllipticCurve GetNextEllipticCurve(Point point)
        {
            return new EllipticCurve(5, 455834);
        }

        public Point GetNextPoint()
        {
            return new Point(1, 1);
        }
    }

    internal class RandomGenerator : IRandomGenerator
    {
        private readonly NumericRandomGenerator _numericRandomGenerator;
        private readonly BigInteger _n;

        public RandomGenerator(BigInteger n, NumericRandomGenerator numericRandomGenerator)
        {
            _n = n;
            _numericRandomGenerator = numericRandomGenerator;
        }

        public Point GetNextPoint()
        {
            var x = _numericRandomGenerator.Next();
            var y = _numericRandomGenerator.Next();

            var point = new Point(x, y);

            return point;
        }

        public EllipticCurve GetNextEllipticCurve(Point point)
        {
            var a = _numericRandomGenerator.Next();
            var b = point.Y * point.Y - point.X * point.X * point.X - a * point.X;
            b = new ZnCutter().Cut(b, _n);

            var ellipticCurve = new EllipticCurve(a, b);

            return ellipticCurve;
        }
    }
}
