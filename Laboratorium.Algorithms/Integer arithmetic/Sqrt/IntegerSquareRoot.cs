using System;
using System.Numerics;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Integer_arithmetic.Sqrt
{
    interface ISqrt
    {
        BigInteger Execute(BigInteger n);
    }
    [FunctionAlias("Sqrt"), DefaultImplementation]
    public class IntegerSquareRoot:ISqrt
    {
        public BigInteger Execute(BigInteger n)
        {
            return Sqrt(n);
        }
        public BigInteger Sqrt(BigInteger number)
        {
            if (number == 0) return 0;
            if (number > 0)
            {
                int bitLength = Convert.ToInt32(Math.Ceiling(BigInteger.Log(number, 2)));
                BigInteger root = BigInteger.One << (bitLength / 2);
                BigInteger tmp = 1;
                while (bitLength>0)
                {
                    tmp = root + number/root;
                    tmp >>= 1;
                    if (tmp == root)
                    {
                        return tmp;
                    }
                    root = tmp;
                    bitLength >>= 1;
                }


                
                return root;
            }            
            throw new ArithmeticException("NaN");
        }

      
    }
}
