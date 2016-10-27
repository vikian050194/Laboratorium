//#r @"D:\Code\MVC\Laboratorium\Laboratorium.Lib\bin\Debug\Laboratorium.Lib.dll";;
#r @"C:\Users\KirillV\Documents\Git\Laboratorium\Laboratorium.Lib\bin\Debug\Laboratorium.Lib.dll";;
open Laboratorium.Lib.Algorithms.Factorization;;
let gcd a b = SingleGCD(a,b).Execute();;
let lcm a b = SingleLCM(a,b).Execute();;
let t = gcd 128 112;;