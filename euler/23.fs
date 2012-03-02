module _23

open System.Collections.Generic

let is_abundant n = (Array.sum (Lib.proper_divisors n)) > n

let abundants = List.filter (fun x -> is_abundant x) [ 12..28123 ]
let abundants_set = HashSet abundants

let is_abundant_sum n =
    let rec try_sum (list: int list) =
        let remain = n - list.Head
        match list with
        | _ when abundants_set.Contains(remain) -> true
        | head :: tail when remain > 0 -> try_sum tail
        | _ -> false
    try_sum abundants

let not_abundant_sum = Seq.filter (fun x -> not (is_abundant_sum x)) { 1..28123 } |> Seq.sum