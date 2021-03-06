﻿module _1to10

open Lib

(*
problem 1

If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
Find the sum of all the multiples of 3 or 5 below 1000.
*)

let problem1 = List.sum[for x in [1..999] do if x % 3 = 0 || x % 5 = 0 then yield x]

(*
problem 2

Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2, the first 10 terms will be:

1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms.
*)

let problem2 =
    let rec accf prev_prev prev acc =
        match prev_prev + prev with
        | curr when curr > 4000000 -> acc
        | curr when curr % 2 = 0 -> accf prev curr (acc + curr)
        | curr -> accf prev curr acc
    accf 1 2 2

(*
problem 3

The prime factors of 13195 are 5, 7, 13 and 29.

What is the largest prime factor of the number 600851475143 ?
*)
let problem3 =
    let problem3_number = 600851475143UL
    let sqrt_number = int (sqrt (double problem3_number))

    let primes = Lib.primes_upto sqrt_number
    Array.find (fun x -> problem3_number % (uint64 x) = 0UL) (Array.rev primes)

(* problem 4

A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.

Find the largest palindrome made from the product of two 3-digit numbers.
*)
let is_palindrome n =
    let ch_arr = (string n).ToCharArray()
    ch_arr = (Array.rev ch_arr)

let problem4_v1 =
    //this version does the multiplication twice
    List.max([for x in [100..999] do for y in [100..999] do if is_palindrome (x*y) then yield (x*y)])

let problem4_v2 =
    //this version needs two steps to create the list
    List.max (List.filter (fun item -> is_palindrome item) [for x in [100..999] do for y in [100..999] -> x*y])

(* problem 5

2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.

What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
*)

//exclude numbers which are themselves factors of other numbers, also 1..19 because we only check every 20th number
let dividers = [for x in [1..19] do
                    if not (List.exists (fun y -> y % x = 0) [(x + 1)..19])
                    then yield x]

let problem5 =
    let rec rec_func x =
        if List.forall (fun elem -> x % elem = 0) dividers then x
        else rec_func (x + 20)
    rec_func 20

(* problem 6

The sum of the squares of the first ten natural numbers is,
1^2 + 2^2 + ... + 10^2 = 385

The square of the sum of the first ten natural numbers is,
(1 + 2 + ... + 10)^2 = 552 = 3025

Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is 3025 − 385 = 2640.

Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum. *)

let problem6 =
    List.sum([for x in [1..100] -> (float x)**2.]) - (float (List.sum([1..100])))**2.

(*
problem 7

By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

What is the 10 001st prime number?
*)

let problem7 =
    Lib.primes_nth 10001

(*
problem 8

Find the greatest product of five consecutive digits in the 1000-digit number.

73167176531330624919225119674426574742355349194934
96983520312774506326239578318016984801869478851843
85861560789112949495459501737958331952853208805511
12540698747158523863050715693290963295227443043557
66896648950445244523161731856403098711121722383113
62229893423380308135336276614282806444486645238749
30358907296290491560440772390713810515859307960866
70172427121883998797908792274921901699720888093776
65727333001053367881220235421809751254540594752243
52584907711670556013604839586446706324415722155397
53697817977846174064955149290862569321978468622482
83972241375657056057490261407972968652414535100474
82166370484403199890008895243450658541227588666881
16427171479924442928230863465674813919123162824586
17866458359124566529476545682848912883142607690042
24219022671055626321111109370544217506941658960408
07198403850962455444362981230987879927244284909188
84580156166097919133875499200524063689912560717606
05886116467109405077541002256983155200055935729725
71636269561882670428252483600823257530420752963450
*)

let problem8 =
    let num_arr = "7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450".ToCharArray()
    List.max [for x in [0..(num_arr.Length - 5)] ->
                    List.reduce (fun acc elem -> acc * elem)
                        [for y in [0..4] -> System.Int32.Parse(num_arr.[x + y].ToString())]]

(*
problem 9
A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,
a2 + b2 = c2

For example, 3^2 + 4^2 = 9 + 16 = 25 = 5^2.

There exists exactly one Pythagorean triplet for which a + b + c = 1000.
Find the product abc. *)

let problem9 =
    let getTriple m n =
        let a = 2 * m * n
        let b = m * m - n * n
        let c = m * m + n * n
        a, b, c

    let triples = Seq.unfold (fun (m, n) ->
                                let res = getTriple m n
                                let next = if n + 1 < m then m, n + 1 else m + 1, 1
                                Some(res, next))
                             (2, 1)

    triples
        |> Seq.find(fun (a, b, c) -> a + b + c = 1000)
        |> (fun (a, b, c) -> a * b * c)

(*
problem 10
The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

Find the sum of all the primes below two million.
*)

let problem10 =
    let primes = Lib.primes_upto 1999999
    Array.sum primes
    


