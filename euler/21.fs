module _21

let sum_divisors n =
    Seq.collect (fun elem ->
        if n % elem <> 0 then Seq.empty
        else if elem = 1 || elem * elem = n then seq {yield elem}
        else seq {yield elem; yield n / elem}) {1..int(sqrt (double n))} |> Seq.sum

let amicable_sum n =
    let da = sum_divisors n
    let db = sum_divisors da
    if db = n && n <> da then da else 0

let answer = Seq.fold (fun acc elem -> acc + (amicable_sum elem)) 0 {1..9999}



