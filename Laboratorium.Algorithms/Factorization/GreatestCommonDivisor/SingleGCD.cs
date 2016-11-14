﻿using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Factorization.GreatestCommonDivisor
{
    [FunctionAlias("gcd")]
    public class SingleGCD : IGCDAlgorithm<int>
    {
        public int Execute(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }
    }
}