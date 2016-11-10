#r @"D:\Code\MVC\Laboratorium\Laboratorium.Algorithms\bin\Debug\Laboratorium.Algorithms.dll"
//#r @"C:\Users\KirillV\Documents\Git\Laboratorium\Laboratorium.Algorithms\bin\Debug\Laboratorium.Algorithms.dll"
open Laboratorium.Algorithms.Factorization
open Laboratorium.Algorithms
let gcd a b = SingleGCD().Execute(a,b)
let gcdInstance(g) = { new IAlgorithmS<int32> with member this.Execute(a,b) = g a b }
let lcm a b g = SingleLCM().Execute(a,b,gcdInstance(g))