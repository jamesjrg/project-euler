module _25

let fib_gen = Seq.unfold (fun state -> Some(fst state + snd state, (snd state, fst state + snd state))) (1I,1I)
let fib = Seq.append (seq {yield 1I; yield 1I}) fib_gen
let answer = (Seq.findIndex (fun x -> (string x).Length = 1000) fib) + 1
