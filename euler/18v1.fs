﻿module _18v1

open System.Collections.Generic

let memoize f =
    let cache = Dictionary<_, _>()
    fun x y z ->
        let ok, res = cache.TryGetValue((x, y, z))
        if ok then res
        else
            let res = f x y z
            cache.[(x,y,z)] <- res
            res
            
let triangle =
    "75
    95 64
    17 47 82
    18 35 87 10
    20 04 82 47 65
    19 01 23 75 03 34
    88 02 77 73 07 63 67
    99 65 04 28 06 16 70 92
    41 41 26 56 83 40 80 70 33
    41 48 72 33 47 32 37 16 94 29
    53 71 44 65 25 43 91 52 97 51 14
    70 11 33 28 77 73 17 78 39 68 17 57
    91 71 52 38 17 14 91 43 58 50 27 29 48
    63 66 04 68 89 53 67 30 73 16 69 87 40 31
    04 62 98 27 23 09 70 98 73 93 38 53 60 04 23"

let lines_with_spaces = triangle.Split([|'\r'; '\n'|], System.StringSplitOptions.RemoveEmptyEntries)
let lines_str = Array.map (fun (x :string) -> x.Trim().Split()) lines_with_spaces
let lines = Array.map (fun line -> Array.map (fun value -> int value) line) lines_str

let rec route = memoize (fun total row col ->
    let mutable ret = []
    let new_total = total + lines.[row].[col]

    if row = 0 then ret <- new_total :: ret
    else        
        if col > 0 then
            ret <- ret @ (route new_total (row - 1) (col - 1))
        if col < lines.[row].Length - 1 then
            ret <- ret @ (route new_total (row - 1) (col))
    ret)

let routes = List.concat (List.map (fun x -> route 0 (lines.Length - 1) x) [0..lines.[lines.Length - 1].Length - 1])
    
let problem18 =
    List.max routes



