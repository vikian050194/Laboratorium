//using System.Numerics;
//using FluentAssertions;
//using Laboratorium.Algorithms.Factorization.GreatestCommonDivisor;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Laboratorium.Tests
//{
//    [TestClass]
//    public class FactorizationTest
//    {
//        [TestMethod]
//        public void SingleGreaterCommonDivisor_Integer()
//        {
//            var gcd = new GreaterCommonDivisor<int>();
//            var a = 128;
//            var b = 112;

//            gcd.Execute(a, b)
//                .Should()
//                .Be(16);
//        }

//        [TestMethod]
//        public void SingleGreaterCommonDivisor_BigInteger()
//        {
//            var gcd = new GreaterCommonDivisor<BigInteger>();
//            var a = new BigInteger(128);
//            var b = new BigInteger(112);

//            gcd.Execute(a, b)
//                .Should()
//                .Be(16);
//        }
//    }
//}
