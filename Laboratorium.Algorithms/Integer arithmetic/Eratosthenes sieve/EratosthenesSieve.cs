﻿using System;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Integer_arithmetic.Eratosthenes_sieve
{
    interface IEratosthenesSieve
    {
        ulong[] Execute(ulong lowerBound, ulong upperBound);
    }
    [FunctionAlias("GetPrimes"), DefaultImplementation]
    public class EratosthenesSieve:IEratosthenesSieve
    {
        public ulong[] Execute(ulong lowerBound, ulong upperBound)
        {
            return GetPrimes(lowerBound, upperBound);
        }
        public ulong[] GetPrimes(ulong lowerBound, ulong upperBound)
        {
            bool firstPrimeNeeded = lowerBound <= 2;
            ValidateBounds(ref lowerBound, ref upperBound);


            ulong intervalLength = ((upperBound - lowerBound) / 2) + 1;
            var primesCount = intervalLength;
            bool[] isNotPrime = new bool[intervalLength];
            for (ulong d = 3; d * d <= upperBound; d = d + 2)
            {
                ulong j;
                ulong r = lowerBound % d;
                if (r != 0)
                {
                    if (r % 2 == 1)
                    {
                        j = (d - r) / 2;
                    }
                    else
                    {
                        j = d - r / 2;
                    }
                }
                else
                {
                    j = 0;
                }
                if (d >= lowerBound)
                {
                    j = j + d;
                }
                for (ulong i = j; i < intervalLength; i += d)
                {
                    if (!isNotPrime[i])
                    {
                        primesCount--;
                    }
                    isNotPrime[i] = true;
                }
                if (d % 6 == 1)
                    d += 2;
            }


            var nextIndex = 0;
            ulong[] result;


            if (firstPrimeNeeded)
            {
                result = new ulong[primesCount + 1];
                result[nextIndex++] = 2;
            }
            else
            {
                result = new ulong[primesCount];
            }
            for (ulong i = 0; i < intervalLength; i++)
            {
                if (!isNotPrime[i])
                {
                    ulong p = lowerBound + 2 * i;
                    result[nextIndex++] = p;
                }
            }
            return result;
        }
        public long[] GetPrimes(long lowerBound, long upperBound)
        {
            bool firstPrimeNeeded = lowerBound <= 2;
            ValidateBounds(ref lowerBound, ref upperBound);


            long intervalLength = ((upperBound - lowerBound) / 2) + 1;
            var primesCount = intervalLength;
            bool[] isNotPrime = new bool[intervalLength];
            for (long d = 3; d * d <= upperBound; d = d + 2)
            {
                long j;
                long r = lowerBound % d;
                if (r != 0)
                {
                    if (r % 2 == 1)
                    {
                        j = (d - r) / 2;
                    }
                    else
                    {
                        j = d - r / 2;
                    }
                }
                else
                {
                    j = 0;
                }
                if (d >= lowerBound)
                {
                    j = j + d;
                }
                for (long i = j; i < intervalLength; i += d)
                {
                    if (!isNotPrime[i])
                    {
                        primesCount--;
                    }
                    isNotPrime[i] = true;
                }
                if (d % 6 == 1)
                    d += 2;
            }


            var nextIndex = 0;
            long[] result;


            if (firstPrimeNeeded)
            {
                result = new long[primesCount + 1];
                result[nextIndex++] = 2;
            }
            else
            {
                result = new long[primesCount];
            }
            for (long i = 0; i < intervalLength; i++)
            {
                if (!isNotPrime[i])
                {
                    long p = lowerBound + 2 * i;
                    result[nextIndex++] = p;
                }
            }
            return result;
        }

        void ValidateBounds(ref ulong lowerBound, ref ulong upperBound)
        {
            if (lowerBound < 2)
                lowerBound = 3;
            if (lowerBound >= upperBound)
            {
                throw new ArgumentException();
            }
            if (lowerBound % 2 == 0)
                lowerBound++;
            if (upperBound % 2 == 0)
                upperBound--;
        }


        void ValidateBounds(ref long lowerBound, ref long upperBound)
        {
            if (lowerBound < 2)
                lowerBound = 3;
            if (lowerBound >= upperBound)
            {
                throw new ArgumentException();
            }
            if (lowerBound % 2 == 0)
                lowerBound++;
            if (upperBound % 2 == 0)
                upperBound--;
        }


    }
}
