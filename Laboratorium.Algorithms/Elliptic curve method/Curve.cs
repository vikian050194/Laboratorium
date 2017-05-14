using System.Numerics;

namespace Laboratorium.Algorithms.Elliptic_curve_method
{
    public class Curve
    {
        public BigInteger Mod { get; set; }
        public BigInteger A { get; set; }
        public BigInteger B { get; set; }

        public ProjectivePoint Point { get; set; }
        //y^2=x^3+ax+b
        public Curve(BigInteger a, BigInteger b, BigInteger mod,ProjectivePoint point)
        {
            A = a;
            B = b;
            Mod = mod;
            Point = point;
        }
    }
}
