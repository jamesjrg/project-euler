module Lib

(* simplistic version of sieve of Eratosthenes, other options include both variations on sieves and variations on trial and error
use imperative style with a fixed size array to hopefully speed things up a bit
array is 0 indexed, but to keep things simple equate index to actual number, so position 0 represents number 0
perhaps should just have made a list of numbers rather than a list of bools, saves a little memory but makes code more confusing and means indexes have to be cast to uint64 later on *)

//not being able to store the iterator from the last search and continuing from there is annoying, maybe there is a better way of doing this
let rec try_find_first_true start (arr : bool []) = 
    match start with
    | start when start >= arr.Length -> None
    | start -> if arr.[start] then Some(start) else try_find_first_true (start + 1) arr

let primes_upto max: int64 array = 
    let primes_bool = Array.create (max + 1) true
    primes_bool.[0] <- false
    primes_bool.[1] <- false

    let mutable i = 2
    while i <= max do
        for j = 2 to max / i do
            primes_bool.[i*j] <- false
        let res = try_find_first_true (i + 1) primes_bool
        match res with
        | Some res -> i <- res
        | None -> i <- max + 1
    let primes = Array.mapi (fun i x -> if x then (int64 i) else 0L) primes_bool
    Array.filter(fun x -> x > 0L) primes

let primes_nth target_prime = 
    let max = 2000000
    //already got "2"
    let mutable prime_counter = 1
    let primes = Array.create (max + 1) true    
    let mutable i = 2
    while i <= max && prime_counter <> target_prime do
        for j = 2 to max / i do
            primes.[i*j] <- false
        let res = try_find_first_true (i + 1) primes
        match res with
        | Some res -> i <- res; prime_counter <- prime_counter + 1
        | None -> i <- max + 1
    i

