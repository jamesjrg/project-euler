module _28

let dim = 5

//much better than first version, using some extremely basic maths
let max_num = dim * dim
let answer =
    let rec loop acc inc num_inc n =
        if n > max_num then (acc, n)
        else
            let new_inc, new_num_inc =
                if num_inc = 3 then inc + 2, 0
                else inc, num_inc + 1
            loop (acc + n) new_inc new_num_inc (n + inc)            
    loop 0 2 0 1

//almost the same as above, but in imperative style. Actually seems much clearer this way...
let mutable curr = 1
let mutable total = 1
let mutable add = 2
for a in {1..(dim - 1) / 2} do
    for b in {1..4} do
        curr <- curr + add
        total <- total + curr
    add <- add + 2

