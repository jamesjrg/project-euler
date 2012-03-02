module _19

open System

let mutable day = DateTime(1901, 1, 1)
let mutable first_day_sunday_count = 0

while day.Year <> 2001 do
    day <- day.AddMonths(1)
    if day.Day = 1 && day.DayOfWeek = DayOfWeek.Sunday then
        first_day_sunday_count <- first_day_sunday_count + 1
