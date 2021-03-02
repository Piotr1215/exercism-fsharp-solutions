open System

// Functions can have names with spaces if enclosed with double back ticks
let sum (x:int, y:int) :int = x + y
let multiply (x:int, y:int) :int = (x:int)*(y:int)

let x = printfn "%i" x

let smulte =
    sum >> multiply >> x


