module _28v1

let dim = 1001
let end_num = dim * dim + 1

type Direction =
   | Up = 0
   | Right = 1
   | Down = 2
   | Left = 3

type SeqState = {
    n: int
    d: Direction
    x: int
    y: int
    target: int
    }

let unfold_func state = 
    if state.n = end_num then None else
        let value = if abs state.x = abs state.y then state.n else 0

        let new_dir, new_target =
            if (((state.d = Direction.Up || state.d = Direction.Down) && state.y = state.target)
            || ((state.d = Direction.Left || state.d = Direction.Right) && state.x = state.target)) then
                let new_dir = enum<Direction> (((int state.d) + 1) % 4)
                let new_target = match new_dir with
                    | Direction.Up | Direction.Down -> -state.target
                    | Direction.Right -> state.target + 1
                    | Direction.Left -> state.target
                new_dir, new_target
            else
                state.d, state.target

        let new_x, new_y = match new_dir with
            | Direction.Up -> state.x, state.y + 1
            | Direction.Right -> state.x + 1, state.y
            | Direction.Down -> state.x, state.y - 1
            | Direction.Left -> state.x - 1, state.y

        Some(value, {n=state.n + 1; d=new_dir; x=new_x; y=new_y; target=new_target})

let answer = Seq.unfold unfold_func {n=1; d=Direction.Up; x=0; y=0; target=0}
            |> Seq.sum
            

