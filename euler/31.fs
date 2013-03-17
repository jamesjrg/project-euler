module _31

open System
open Lib

//n choose r with repetitions allowed is equivalent to (n + r - 1) choose r
//http://www.mathsisfun.com/combinatorics/combinations-permutations.html
let ncr_with_rep n r =
    Lib.ncr (n + r - 1I) r

let rec combinations = Lib.memoize (fun x ->
    match x with
    | x when x = 200I -> 1I + ncr_with_rep (combinations 100I) 2I
    //£1, 5*20p, or 2 50s made up variously
    | x when x = 100I -> 2I + ncr_with_rep (combinations 50I) 2I
    | x when x = 50I -> 1I +
        //2*20p
        (combinations 10I) +
        //1*20p
        ncr_with_rep (combinations 10I) 3I +
        //0*20p
        ncr_with_rep (combinations 10I) 5I
    //1 10, 5*2p, or 2 5s made up variously
    | x when x = 10I -> 2I + ncr_with_rep (combinations 5I) 2I
    //1 5, 2 2s and a 1, 1 2 and 3 1s, 5 1s
    | x when x = 5I -> 4I)

let answer = combinations 10I

