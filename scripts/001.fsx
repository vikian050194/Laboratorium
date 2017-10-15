//Problem 1 - Multiples of 3 and 5 - solved
//If we list all the natural numbers below 10 that are multiples of 3 or 5,
//we get 3, 5, 6 and 9. The sum of these multiples is 23.
//Find the sum of all the multiples of 3 or 5 below 1000.

let check x =
    x % 3 = 0 || x % 5 = 0

let rec sum acc a b =
    if a < b
    then 
        if check a
        then sum (acc + a) (a + 1) b
        else sum acc (a + 1) b
    else acc

sum 0 1 1000