//Problem 5 - Smallest multiple - solved
//2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
//What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?

let rec gcd a b =
    if a <> 0 && b <> 0
    then
        if a < b
        then gcd a (b % a)
        else gcd b (a % b)
    else (a + b)

let lcm a b = (a * b) / (gcd a b)

let rec lcmForRange s e rlcm =
    if s < e
    then lcmForRange (s + 1) e (lcm s rlcm)
    else rlcm

lcmForRange 2 20 2