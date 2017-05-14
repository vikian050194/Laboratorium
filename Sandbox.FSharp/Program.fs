//open Laboratorium.Algorithms.Factorization.GreatestCommonDivisor
//open Laboratorium.Algorithms.Factorization.LeastCommonMultiple
//
//[<EntryPoint>]
//let main argv =    
//    let gcd a b = SingleGCD().Execute(a,b)
//    let gcdInstance fn1 = { new IGCDAlgorithm<int> with member this.Execute(a,b) = fn1 a b }
//    let lcm' a b g = SingleLCM().Execute(a, b, gcdInstance g)
//    let lcm a b = SingleLCM().Execute(a, b, gcdInstance gcd)
//    let answer = lcm 3 4
//    printfn "%A" gcd.GetType
//    0 // return an integer exit code