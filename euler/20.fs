module _20

let problem20 =
    (string (Lib.factorial 100I)).ToCharArray()
    |> Array.map (fun x -> int (string x))
    |> Array.sum

