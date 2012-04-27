//#load "C:\Users\james\dev\euler\euler\Lib.fs"
module Lib

open System.Collections.Generic

(* simplistic version of sieve of Eratosthenes, other options include both variations on sieves and variations on trial and error
use imperative style with a fixed size array to hopefully speed things up a bit
array is 0 indexed, but to keep things simple equate index to actual number, so position 0 represents number 0
perhaps should just have made a list of numbers rather than a list of bools, saves a little memory but makes code more confusing and means indexes have to be cast to uint64 later on *)

//not being able to store the iterator from the last search and continuing from there is annoying, maybe there is a better way of doing this
let rec try_find_first_true start (arr : bool []) = 
    match start with
    | start when start >= arr.Length -> None
    | start -> if arr.[start] then Some(start) else try_find_first_true (start + 1) arr

let primes_upto_bool max: bool array = 
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
    primes_bool

let primes_upto max: int64 array = 
    let primes = Array.mapi (fun i x -> if x then (int64 i) else 0L) (primes_upto_bool max)
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

let rec factorial n =
    Seq.fold ( * ) 1I [1I .. n]

let ncr_slow n r =
    factorial n / (factorial r * factorial (n - r))

//actual formula would be acc * ((n - (r-i)) / i)), but then you can't use integer arithmetic
let ncr n r =
    Seq.fold (fun acc i -> acc * (n - (r-i)) / i) 1I [1I .. r]

let test =
    Seq.fold (fun acc i -> acc * ((3I - (2I-i)) / i)) 1I [1I .. 2I]

let proper_divisors n =
    Array.collect (fun elem ->
        if n % elem <> 0 then Array.empty
        else if elem = 1 || elem * elem = n then [| elem |]
        else [| elem; n / elem |]) [| 1..int(sqrt (double n)) |]

let memoize f =
    let cache = Dictionary<_, _>()
    fun x ->
        let ok, res = cache.TryGetValue(x)
        if ok then res
        else
            let res = f x
            cache.[x] <- res
            res

let memoize2 f =
    let cache = Dictionary<_, _>()
    fun x y ->
        let ok, res = cache.TryGetValue((x,y))
        if ok then res
        else
            let res = f x y
            cache.[(x,y)] <- res
            res

let memoize3 f =
    let cache = Dictionary<_, _>()
    fun x y z ->
        let ok, res = cache.TryGetValue((x, y, z))
        if ok then res
        else
            let res = f x y z
            cache.[(x,y,z)] <- res
            res
