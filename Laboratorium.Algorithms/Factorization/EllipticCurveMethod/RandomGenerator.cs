namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    internal class RandomGenerator
    {
        private readonly NumericRandomGenerator _numericRandomGenerator;

        public RandomGenerator(NumericRandomGenerator numericRandomGenerator)
        {
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

            var ellipticCurve = new EllipticCurve(a, b);

            return ellipticCurve;
        }
    }
}
