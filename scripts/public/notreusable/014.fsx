//Problem 14 - Longest Collatz sequence
//The following iterative sequence is defined for the set of positive integers:
//n → n/2 (n is even)
//n → 3n + 1 (n is odd)
//Using the rule above and starting with 13, we generate the following sequence:
//13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
//It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms.
//Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
//Which starting number, under one million, produces the longest chain?
//NOTE: Once the chain starts the terms are allowed to go above one million.

open System

let getNextN n =
    if n % 2 = 0
    then n / 2
    else 3 * n + 1

let getChainLength startN = 
    let rec getChainLength' n length=
        if n = 1
        then
            //Console.Write("{0}: -> {1}\n", startN, (n:int))
            length
        else
            //Console.Write("{0}: -> {1} | {2}\n", startN, (n:int), length)
            getChainLength' (getNextN n) (length + 1)
    getChainLength' startN 0

let findMax startIndex endIndex =
    let rec findMax' n maxLength value =
        if n <= endIndex
        then
            Console.WriteLine((n:int))
            let currentLength = getChainLength n
            if currentLength > maxLength
            then findMax' (n + 1) currentLength n
            else findMax' (n + 1) maxLength value
        else
            Console.Write("\n\n")            
            (maxLength,value)
    findMax' startIndex 0 0

findMax 134380 1000000

let t1 = async { return (findMax 1 250000) }
let t2 = async { return (findMax 250001 500000) }
let t3 = async { return (findMax 500001 750000) }
let t4 = async { return (findMax 750000 999999) }

Async.RunSynchronously(Async.Parallel [t1;t2;t3;t4]) |> Array.reduce (fun (l1, v1) (l2, v2) -> if l1 > l2 then (l1,v1) else (l2,v2))

//113383
//134379
//138367