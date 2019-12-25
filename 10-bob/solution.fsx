open System

let containsLetter (input:string) = (Seq.exists (fun c -> Char.IsLetter(c)) input)

let (|Yell|_|)      (command:string)   = if command.ToUpper() = command && containsLetter command then Some() else None
let (|Ask|_|)       (question:string)  = if question.EndsWith("?")                                then Some() else None
let (|NonVerbal|_|) (signal:string)    = if String.IsNullOrEmpty(signal) || signal.Contains("\t") then Some() else None

let response (input: string): string =
    match input.Trim() with
    | Yell & Ask      -> "Calm down, I know what I'm doing!"
    | Yell            -> "Whoa, chill out!"
    | Ask             -> "Sure."
    | NonVerbal       -> "Fine. Be that way!"
    | _               -> "Whatever."

response "1, 2, 3 GO!"