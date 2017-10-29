//Problem 24 - Lexicographic permutations
//A permutation is an ordered arrangement of objects.
//For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4.
//If all of the permutations are listed numerically or alphabetically,
//we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:
//012   021   102   120   201   210
//What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9?

#load "../misc/tools.fsx"
open misc.Math

let getOptions used maxDigit = [0..maxDigit] |> List.except used 

let p24 indexOfPermutation maxDigit =
    let rec p24' result i =
        let opt = (getOptions result maxDigit)
        if i > 1
        then
            let index = ((indexOfPermutation - 1) / (factorial (i - 1))) % i
            p24' ((List.item index opt)::result) (i - 1)
        else (List.head opt)::result
    p24' [] maxDigit |> List.rev 

let f maxDigit =[1..(factorial maxDigit)] |> List.map (fun x -> p24 x maxDigit)