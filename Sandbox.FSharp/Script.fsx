//#r @"D:\Code\MVC\Laboratorium\Laboratorium.Algorithms\bin\Debug\Laboratorium.Algorithms.dll"
#r @"C:\Users\KirillV\Documents\Git\Laboratorium\Laboratorium.Algorithms\bin\Debug\Laboratorium.Algorithms.dll"
open Laboratorium.Algorithms.Factorization.GreatestCommonDivisor
open Laboratorium.Algorithms.Factorization.LeastCommonMultiple
let gcd a b = SingleGCD().Execute(a,b)
let gcdInstance fn1 = { new IGCDAlgorithm<int> with member this.Execute(a,b) = fn1 a b }
let lcm' a b g = SingleLCM().Execute(a, b, gcdInstance g)
let lcm a b = SingleLCM().Execute(a, b, gcdInstance gcd)