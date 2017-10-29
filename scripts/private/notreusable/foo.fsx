let foo n = [1..n] |> List.map (fun x -> x * x)
let a = foo 5
let b = foo 10