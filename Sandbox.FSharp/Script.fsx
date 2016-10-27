#r @"D:\Code\MVC\Laboratorium\Laboratorium.Lib\bin\Debug\Laboratorium.Lib.dll"
open Laboratorium.Lib.Algorithms.Factorization
let gcd a b = SingleGCD(a,b).Execute()
let t = gcd 128 112
let f = [1..10]