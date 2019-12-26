type Roman = I |  V | X | L | C | D | M

type RomanNumber = {digits: Roman list}

let convert digit =
    match digit with
    | I -> 1
    | V -> 5
    | X -> 10
    | L -> 50
    | C -> 100
    | D -> 500
    | M -> 1000

let romanNumberToInt romanNumber =
    let digits = romanNumber.digits
    let ints = digits |> List.map convert
    let sum = ints |> List.sum
    sum

romanNumberToInt {digits = [I;V;I;X;X;X;D;L;X;M;L;L;L;L;L;L;M;M;M;M;M;M;M;M;M;M;M]}