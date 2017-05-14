using System.Numerics;

namespace Laboratorium.Algorithms.Elliptic_curve_method
{
    public class ProjectivePoint
    {
        public BigInteger X { get; set; }
        public BigInteger Y { get; set; }
        public BigInteger Z { get; set; }


        public ProjectivePoint(BigInteger x,BigInteger y,BigInteger z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
