module _21

let sum_divisors n = Lib.proper_divisors n |> Array.sum

let amicable_sum n =
    let da = sum_divisors n
    let db = sum_divisors da
    if db = n && n <> da then da else 0

let answer = Seq.fold (fun acc elem -> acc + (amicable_sum elem)) 0 {1..9999}



