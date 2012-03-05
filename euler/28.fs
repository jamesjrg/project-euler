module _28

let dim = 1001

//2. much better than first version, using some extremely basic maths
let answer =
    let max_num = dim * dim
    let rec loop acc inc inc_count n =
        if n > max_num then (acc, n)
        else
            let new_inc, new_inc_count =
                if inc_count = 4 then inc + 2, 1
                else inc, inc_count + 1
            loop (acc + n) new_inc new_inc_count (n + inc)
    loop 0 2 1 1

//3. imperative style, and slightly different loop
let answer_imperative = 
    let mutable curr = 1
    let mutable total = 1
    let mutable add = 2

    for a in {1..(dim - 1) / 2} do
        for b in {1..4} do
            curr <- curr + add
            total <- total + curr
        add <- add + 2
    total

//4. copied off internet, much more compact (though obviously still less compact that people who have solved it analytically)
let problem028 =
    [1..500]
    |> List.fold (fun (accum, last) n ->
            (accum + 4*last + 20*n, last + 8*n)) (1,1)
    |> fst

