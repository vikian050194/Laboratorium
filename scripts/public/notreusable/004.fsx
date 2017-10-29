//Problem 4 - Largest palindrome product - solved
//A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
//Find the largest palindrome made from the product of two 3-digit numbers.

open System

let IsPolindrom (s:string) =
    let o = s.ToCharArray()
    let r = s.ToCharArray()
    Array.Reverse(r)
    let rs = new String(r)
    o = r

[ for i = 100 to 999 do for j = 100 to 999 do yield (i * j) ]
|> List.filter (fun x -> IsPolindrom (x.ToString()))
|> List.reduce (fun a b -> Math.Max(a,b))

//===========================================================

open System

let split x =
    let rec split' i a =
        if i / 10 > 0
        then split' (i / 10) ((i % 10)::a)
        else ((i % 10)::a)
    split' x []


let polindrom a =
    let rec p a1 a2 =
            match a1 with
            [] -> true
            | h::t -> if h = (List.head a2) then p t (List.tail a2) else false
    p a (List.rev a)

let decart a b = List.map (fun x -> List.map (fun y -> (x,y)) b) a |> List.concat

let arr = [100..999]

decart arr arr |> List.map (fun (x,y) -> ((x*y) |> split |> polindrom, x*y)) |> List.filter (fun (x,y) -> x) |> List.map (fun (x,y) -> y) |> List.reduce (fun x y -> Math.Max(x,y))