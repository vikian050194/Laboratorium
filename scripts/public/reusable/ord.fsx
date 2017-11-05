let modpow a n m =
	let rec loop result i =
		if i > 0
		then loop (result * a % m) (i-1)
		else result
	loop 1 n

let ord a n =
    let rec loop i =
        if i < n then
            if (modpow a i n) = 1
            then i
            else loop (i + 1)
        else -1
    loop 1