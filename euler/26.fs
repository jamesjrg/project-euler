module _26

//1. regex version
//kind of fragile, assumes there will not be a repeating pattern of 4 or more digits within a larger repeating pattern, e.g. 1111222211112222

open System.Text.RegularExpressions

let big_num = bigint.Pow(10I, 2000)

let recurring_length n = 
    let decimal_str = (string (big_num / n)).PadLeft(2000, '0').TrimEnd('0')
    (Regex.Match(decimal_str, @"(\d{2,}?)\1").Groups.[1].Length, n)

let answer = Seq.map(fun x -> recurring_length x) {2I..999I}
             |> Seq.max


(*2. math version
http://en.wikipedia.org/wiki/Repeating_decimal#Fractions_with_prime_denominators
http://excelicious.wordpress.com/2009/08/18/project-euler-26/
http://duncan99.wordpress.com/2011/06/19/project-euler-problem-26/ (comments) *)

open Lib

let period d =
    let rec loop p prev_k = 
        let k = (prev_k * 10) % d
        if k = 1 then p else loop (p + 1) k
    loop 1 1

let answer2 = Seq.map(fun x -> period (int x), x) [for x in (Lib.primes_upto 999) do if x > 5L then yield x] |> Seq.max
