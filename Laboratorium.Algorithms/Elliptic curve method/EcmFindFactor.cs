using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Elliptic_curve_method
{
    interface IEcm
    {
        BigInteger Execute(BigInteger number,ulong smoothBound, int curveCount);
    }
    [FunctionAlias("TryFindFactorEcm"), DefaultImplementation]
    public class EcmFindFactor:IEcm
    {
        public BigInteger Execute(BigInteger number,ulong smoothBound,int curveCount)
        {
            CurveGenerator g = new CurveGenerator();
            BigInteger gcd = 1;
            ulong b1 = smoothBound;
            ulong b2 = b1 * 100;
            ulong b3 = b2 + b1 * 100;
            var curve = new Curve[curveCount];
            BigInteger factor = 1;
            curve = curve.Select(x =>
            {
                var c = g.GenerateMontgomeryCurve(number, out gcd);
                if (gcd > 1)
                    factor = gcd;
                return c;

            }).ToArray();
            if (factor > 1)
            {
                return factor;
            }
            else
            {
                var lockObj=new object();
                Parallel.ForEach(curve, (c,state) =>
                {
                    var ecm = new Ecm();
                    var res = ecm.Calculate(c, b1, b2, b3);
                    if (res > 1)
                    {
                        lock (lockObj)
                        {
                            factor = res;
                      
                        }
                        state.Break();
                    }
                });
            
            }
            return factor;
        }
    }
}
