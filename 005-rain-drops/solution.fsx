let divisors = [("Pling", 3);("Plang",5);("Plong",7);("BigPlong",11)]

let divides number divisor = (number % divisor = 0)

let convert (number: int): string =
        divisors
        |> List.filter (snd >> divides number)
        |> List.map fst
        |> function
            | [] -> number.ToString()
            | s -> String.concat "" s

convert 105