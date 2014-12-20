module _31

open System
open Lib

//blatantly copied off the interwebs
//http://www.mathblog.dk/project-euler-31-combinations-english-currency-denominations/

let target = 200;
let coinSizes = [| 1; 2; 5; 10; 20; 50; 100; 200 |]
let ways = Array.create (target + 1) 0
ways.[0] <- 1

for i = 0 to coinSizes.Length - 1 do
    for j = coinSizes.[i] to target do
        ways.[j] <- ways.[j] + ways.[j - coinSizes.[i]];

let answer = ways.[target]