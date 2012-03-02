module _24

open Lib

let rec loop acc (digits_remain: int list) target_remain =
    let curr_perms = int (Lib.factorial (bigint digits_remain.Length - 1I))
    let num_increments = target_remain / curr_perms
    let curr_digit = digits_remain.[num_increments]
    let new_digits_remain = List.filter (fun x -> x <> curr_digit) digits_remain
    if new_digits_remain = [] then curr_digit :: acc
    else
        loop (curr_digit :: acc) new_digits_remain (target_remain - curr_perms * num_increments)

let answer = List.rev (loop [] [0..9] 999999)



