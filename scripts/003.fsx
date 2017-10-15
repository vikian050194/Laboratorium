//Problem 3 - Largest prime factor - solved
//The prime factors of 13195 are 5, 7, 13 and 29.
//What is the largest prime factor of the number 600851475143 ?

open System.Numerics

let N = BigInteger.Parse("10")

open System.Numerics

let rec devider (a:BigInteger) (n:BigInteger) =
    if a % n = BigInteger.Zero
    then devider (a / n) n
    else a 

let rec lpf (a:BigInteger) (n:BigInteger)=
        if n < a
        then lpf (devider a n) (n + BigInteger.One)
        else a

lpf (BigInteger.Parse("600851475143")) (BigInteger.Parse("2"))