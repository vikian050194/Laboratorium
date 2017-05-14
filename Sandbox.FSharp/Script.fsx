//#r @"D:\Code\MVC\Laboratorium\Laboratorium.Algorithms\bin\Debug\Laboratorium.Algorithms.dll"
////#r @"C:\Users\KirillV\Documents\Git\Laboratorium\Laboratorium.Algorithms\bin\Debug\Laboratorium.Algorithms.dll"
//open Laboratorium.Algorithms.Factorization.GreatestCommonDivisor
//open Laboratorium.Algorithms.Factorization.LeastCommonMultiple
//let gcd a b = SingleGCD().Execute(a,b)
//let gcdInstance fn1 = { new IGCDAlgorithm<int> with member this.Execute(a,b) = fn1 a b }
//let lcm' a b g = SingleLCM().Execute(a, b, gcdInstance g)
//let lcm a b = SingleLCM().Execute(a, b, gcdInstance gcd)

//namespace Laboratorium.Core.Compiler
//
//open Microsoft.FSharp.Compiler.SimpleSourceCodeServices
//open System.IO
//
//module M =
//    let t = 2
//    printf "%d" t
//
//type Compiler() =      
//    member this.Compile(script) =
//        let scs = SimpleSourceCodeServices()
//        let fn = Path.GetTempFileName()
//        let fn2 = Path.ChangeExtension(fn, ".fs")
//        let fn3 = Path.ChangeExtension(fn, ".dll")
//        File.WriteAllText(fn2, script)
//        let errors, exitCode = scs.Compile([| "fsc.exe"; "-o"; fn3; "-a"; fn2 |])
//        fn3