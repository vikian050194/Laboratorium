//Problem 28 - Number spiral diagonals
//Starting with the number 1 and moving to the right in a clockwise direction a 5 by 5 spiral is formed as follows:
//21 22 23 24 25
//20  7  8  9 10
//19  6  1  2 11
//18  5  4  3 12
//17 16 15 14 13
//It can be verified that the sum of the numbers on the diagonals is 101.
//What is the sum of the numbers on the diagonals in a 1001 by 1001 spiral formed in the same way?

type State = 
    Center of int * int * int
    | First of int * int * int 
    | Second of int * int * int
    | Third of int * int * int
    | Fourth of int * int * int

let p28 n =
    let calcNewValue i currValur = currValur + i * 2
    let rec p28' st traceList =
        match st with
        Center(i,v,s) -> p28' (Fourth(i + 1,calcNewValue i v,s + calcNewValue i v)) (st::traceList)
        | First(i,v,s) -> p28' (Fourth(i + 1,-2 + calcNewValue (i + 1) v,-2 + s + calcNewValue (i + 1) v)) (st::traceList)
        | Second(i,v,s) -> p28' (First(i,calcNewValue i v,s + calcNewValue i v)) (st::traceList)
        | Third(i,v,s) -> p28' (Second(i,calcNewValue i v,s + calcNewValue i v)) (st::traceList)
        | Fourth(i,v,s) -> 
            if i = ((n - 1) / 2) + 1
                then s//List.rev (st::traceList)
                else p28' (Third(i, calcNewValue i v, s + calcNewValue i v)) (st::traceList)
    p28' (Center(0,1,0)) []

p28 1001