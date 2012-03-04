module _27

open Lib

let max_arg = 999

let primes = Lib.primes_upto_bool 20000

let count_primes a b =
    Seq.unfold (fun n ->
        let res = n * n + a * n + b
        if res > 0 && primes.[res] then Some(res, n + 1) else None) 0
    |> Seq.length

//n=0 shows that b must be prime
let answer = seq {
    for a in [-max_arg..max_arg] do
        for b in [-max_arg..max_arg] do
            if b > 0 && primes.[b] then yield (count_primes a b, a * b)}
            |> Seq.max



