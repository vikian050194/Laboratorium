namespace Laboratorium.Algorithms.Factorization.EllipticCurveMethod
{
    internal interface IRandomGenerator
    {
        EllipticCurve GetNextEllipticCurve(Point point);
        Point GetNextPoint();
    }
}