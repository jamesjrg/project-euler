module _27

open Lib

let max_arg = 999

let make_generator a b =
    let generator n =
        n * n + a * n + b
    generator

let primes = Lib.primes_upto_bool 20000

let count_primes f =
    let rec loop n =
        let next = f n
        if next > 0 && primes.[next] then loop (n + 1)
        else n
    loop 0

//n=0 shows that b must be prime
let generators = seq {
    for a in [-max_arg..max_arg] do
        for b in [-max_arg..max_arg] do if b > 0 && primes.[b] then yield (make_generator a b, a * b)}

let answer = Seq.map (fun x -> (count_primes (fst x), snd x)) generators |> Seq.max



