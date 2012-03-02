module _22

let name_value i (x:string) = 
    (Array.fold (fun acc elem -> acc + int elem - int 'A' + 1) 0 (x.ToCharArray())) * i

let names = System.IO.File.ReadAllText(@"22.txt").Split(',')
            |> Array.map (fun x -> x.Substring(1, x.Length - 2))
            |> Array.sort
            |> Array.mapi (fun i x -> name_value (i + 1) x)
            |> Array.sum


