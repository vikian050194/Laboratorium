#r @"D:\Code\MVC\Laboratorium\LaboratoriumLib\bin\Debug\LaboratoriumLib.dll";;
open LaboratoriumLib.Algorithms.Factorization;;
let gcd a b = SingleGCD(a,b).Execute();;
let t = gcd 128 112;;