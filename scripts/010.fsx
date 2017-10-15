//Problem 10
//The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
//Find the sum of all the primes below two million.

open System.Numerics

let rec primes = function
    [] -> []
  | h::t -> h::primes(List.filter (fun (x:BigInteger) -> x % h > BigInteger.Zero) t)

let mass = primes [(BigInteger.Parse("2")) .. (BigInteger.Parse("2000000"))]

let sum = List.fold (+) BigInteger.Zero mass

//Bad luck:
//Process is terminated due to StackOverflowException.
//Session termination detected. Press Enter to restart.