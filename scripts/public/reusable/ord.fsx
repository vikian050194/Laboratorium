let ord a n =
    let rec loop i =
        if i < n then
            if (modpow a i n) = 1
            then i
            else loop (i + 1)
        else -1
    loop 1