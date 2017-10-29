let pow a n =
    let rec loop result i =
        if i > 0
        then loop (result * a) (i-1)
        else result
    loop 1 n