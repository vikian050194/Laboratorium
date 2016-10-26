using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorium.Lib.Algorithms.Number_theoretic_algorithms
{
    public static class GfMath
    {

        public static BigInteger Inverse(BigInteger number, BigInteger mod, out BigInteger gcd)
        {

            BigInteger bezoutCoefficient = BigInteger.One;
            BigInteger nextBezoutCoefficient = BigInteger.Zero;
            gcd = number % mod;
            BigInteger reminder = mod;
            BigInteger temp;
            BigInteger quotient;


            while (reminder != BigInteger.Zero)
            {
                temp = reminder;
                quotient = gcd / reminder;
                reminder = (gcd + (mod - (quotient * reminder) % mod)) % mod;
                gcd = temp;
                temp = nextBezoutCoefficient;
                nextBezoutCoefficient = (bezoutCoefficient + (mod - (quotient * nextBezoutCoefficient) % mod)) % mod;
                bezoutCoefficient = temp;


            }
            gcd = gcd % mod;
            return bezoutCoefficient % mod;
        }
        public static int JacobiSymbol(BigInteger a, BigInteger mod)
        {
            a = (mod + (a + mod) % mod) % mod;
            int t = 1;
            while (a != 0)
            {
                while (a % 2 == 0)
                {
                    a = a / 2;
                    var r = mod % 8;
                    if (r == 3 || r == 5)
                    {
                        t = -t;
                    }
                }
                var tmp = a;
                a = mod;
                mod = tmp;
                var resA = a % 4;
                var resMod = mod % 4;
                if (resA == 3 && resMod == 3)
                {
                    t = -t;
                }
                a = a % mod;
            }
            if (mod == 1)
                return t;
            return 0;
        }

        public static BigInteger Sqrt(BigInteger a, BigInteger p)
        {
            if (JacobiSymbol(a, p) == -1)
            {
                throw new ArgumentException("square root doesn't exist");
            }
            if (p == 2)
                return 1;
            BigInteger t = 0;
            for (BigInteger i = 0; i < p; i++)
            {
                if (JacobiSymbol((i * i - a), p) == -1)
                {
                    t = i;
                    break;
                }
            }
            return PowInGfP2(new Tuple<BigInteger, BigInteger>(t, 1), (p + 1) / 2, p, t * t + p - a).Item1;

        }

        static Tuple<BigInteger, BigInteger> PowInGfP2(Tuple<BigInteger, BigInteger> x, BigInteger pow, BigInteger p, BigInteger sqrGenerator)
        {
            if (pow == 0)
                return new Tuple<BigInteger, BigInteger>(1, 0);
            var res = new Tuple<BigInteger, BigInteger>(1, 0);
            Tuple<BigInteger, BigInteger> a = x;
            while (pow != 0)
            {

                if (pow % 2 != 0)
                {
                    res = new Tuple<BigInteger, BigInteger>((a.Item1 * res.Item1 + a.Item2 * res.Item2 * sqrGenerator) % p, (a.Item2 * res.Item1 + a.Item1 * res.Item2) % p);
                }

                a = new Tuple<BigInteger, BigInteger>((a.Item1 * a.Item1 + a.Item2 * a.Item2 * sqrGenerator) % p, (a.Item2 * a.Item1 + a.Item1 * a.Item2) % p);
                pow >>= 1;
            }
            return res;
        }


    }
}
