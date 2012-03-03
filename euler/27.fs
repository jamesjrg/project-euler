module _27

open System.Collections.Generic
open Lib

let max_arg = 999

let make_generator a b =
    let generator n =
        n * n + a * n + b
    generator

let primes = HashSet(Array.map (fun x -> int x) (Lib.primes_upto 8000))

let count_primes f =
    let mutable n = 0
    while primes.Contains(f n) do
        n <- n + 1
    n

let generators = seq {
    for a in [-max_arg..max_arg] do
        for b in [-max_arg..max_arg] do yield (make_generator a b, a * b)}

let answer = Seq.map (fun x -> (count_primes (fst x), snd x)) generators |> Seq.max



