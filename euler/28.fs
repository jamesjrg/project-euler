module _28

let dim = 5
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
