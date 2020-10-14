// THis was final solution
let leapYear (year: int): bool = year % 4 = 0 && year % 100 <> 0 || year % 400 = 0

// This was initial solution, too complex, there is no need to match on booleans
let leapYear' (year: int): bool =
    match (year % 4 = 0, year % 100 = 0, year % 400 = 0) with
    |(true, false, true) -> true
    |(_, _, _) -> false

leapYear 1996

leapYear' 2004