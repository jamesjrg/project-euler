module _29

open System

let answer = [for a in 2. .. 100. do
                for b in 2. .. 100. do yield (Math.Pow(a, b))]
                |> Set.ofList
                |> Set.count

