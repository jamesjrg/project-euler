module _17

let problem17 =
    let digits = Array.map (fun (x : string) -> x.Length)
                    [|""; "one"; "two"; "three"; "four"; "five"; "six"; "seven"; "eight"; "nine"|]

    let teens = Array.map (fun (x : string) -> x.Length)
                    [|""; "eleven"; "twelve"; "thirteen"; "fourteen"; "fifteen"; "sixteen"; "seventeen"; "eighteen"; "nineteen"|]

    let tens = Array.map (fun (x : string) -> x.Length)
                    [|""; "ten"; "twenty"; "thirty"; "forty"; "fifty"; "sixty"; "seventy"; "eighty"; "ninety"|]

    let hundred_length = "hundred".Length
    let thousand_length = "thousand".Length
    let and_length = "and".Length;

    let count_letters number =
        let rec count_remain count (remain : int list) =
            let curr_digit = remain.[0]
            let mutable recurse = false

            let my_count =
                match remain.Length with
                | 4 -> digits.[curr_digit] + thousand_length
                | 3 -> 
                    recurse <- true
                    if curr_digit = 0 then 0 else digits.[curr_digit] + hundred_length
                | 2 -> 
                    let final_digit = remain.[remain.Length - 1]
                    if curr_digit = 1 && final_digit <> 0 then teens.[final_digit]
                    else
                        recurse <- true
                        tens.[curr_digit]
                | 1 -> digits.[curr_digit]
                | _ -> 0
            if recurse then
                count_remain (count + my_count) (remain.Tail)
            else
                count + my_count

        let num_list = (string number).ToCharArray()
                        |> Array.map (fun x -> int (string x))
                        |> List.ofArray
        let count = count_remain 0 num_list
        if (number > 99 && number % 100 <> 0) then count + and_length else count

    Seq.fold (fun acc elem -> acc + (count_letters elem)) 0 {1..1000}
