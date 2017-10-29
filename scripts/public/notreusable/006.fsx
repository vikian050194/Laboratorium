//Problem 6 - Sum square difference - solved
//The sum of the squares of the first ten natural numbers is,
//1^2 + 2^2 + ... + 10^2 = 385
//The square of the sum of the first ten natural numbers is,
//(1 + 2 + ... + 10)^2 = 552 = 3025
//Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.
//Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

let rec sum f acc i max =
    if i <= max
    then sum f (acc + (f i)) (i + 1) max
    else acc

let power = fun x -> x * x

let a = power (sum (fun x -> x) 0 1 100)

let b = sum power 0 1 100

let result = a - b