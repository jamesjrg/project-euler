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


//first version, without using library sum function for some practice with F# tail recursion
let problem1 =
    let sum list =    
        let rec accf list acc =
            match list with
            | [] -> acc
            | h :: t -> accf t (acc + h)
        accf list 0

    let divisible_by_3_or_5 x = if x % 3 = 0 || x % 5 = 0 then true else false

    sum [for x in [1..999] do if divisible_by_3_or_5 x then yield x]

    printfn "%f %f %f" a b c