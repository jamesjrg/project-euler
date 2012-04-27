module _30

open System

(*
digit x is at least 1 * 10^x
meanwhile maximum that can be gained by raising digits to power of 5 is 9^5 * x

with 6 digits:
minimum value is 100000
maximum from powers is 9^5 * 5 = 354294

with 7 digits:
minimum value is 1000000
maximum from powers is 9^5 * 5 = 413343

So we cannot possibly make a number of greater than 6 digits, and therefore greater greater than 354294

*)

let sum_powers_of_digits n = 
    Array.fold (fun acc elem -> acc + Math.Pow(Char.GetNumericValue elem, 5.)) 0. (n.ToString().ToCharArray())

let answer = 
    Seq.sum (Seq.filter (fun x -> x = sum_powers_of_digits x) {2. ..354294.} )
