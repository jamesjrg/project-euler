module Unused

//from problem 3
let print_array_filtered arr = 
    Array.iteri(fun i x -> if x then printf "%i, " i) arr


let unique_chars =
            (Array.fold
            (fun acc item ->
                if (List.tryFind (fun elem -> elem = item) acc).IsSome then
                    acc
                else
                    item :: acc)
            []
            ch_arr).Length

