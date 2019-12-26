open System
(*****************************************************************************************)
// Active patterns: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/active-patterns
(*****************************************************************************************)
let (|UpperCase|LowerCase|) (inp:string) = if inp = inp.ToUpper() then UpperCase else LowerCase

let (|UpperCaseMaker|) (inp:string) = inp.ToUpper()

let detectCase input =
    match input with
    | UpperCase -> "All was upper"
    | LowerCase -> "All was lower"

let upperMapper inp =
    match inp with
    | UpperCaseMaker amIUpper -> printfn "%s" amIUpper
upperMapper "asd"
upperMapper "SADA"

let functionUpperMaker (UpperCaseMaker linput) =
    printfn "Upper %s" linput

functionUpperMaker "asd"

let (|Sentence|Word|WhiteSpace|) (inp:string) =
    match inp.Trim() with
    | "" -> WhiteSpace
    | inp when inp.Contains(" ") -> Sentence (inp.Split ([|' '|], StringSplitOptions.None))
    | allOther -> Word allOther

match "  yxcyxcyxcyxc  " with
| WhiteSpace -> printfn "space"
| Word w -> printfn "Word: %s" w
| Sentence sent -> printfn "Sentence: %A" sent

(*****************************************************************************************)
// Arrays: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/arrays
(*****************************************************************************************)

// Declare Function
let rec matchCount arrayElementCount =
    match arrayElementCount with
    | [|x|] -> printf "One element"
    | [|x; y|] -> printf "Two elements"
    | [|x; y; z|] -> printf "Three elements"
    | _ -> printf  "Lots of elements"
// Sample Arrays
let two = [|"asd";"dsa"|]
let one = [|"aaa"|]
let three = [|"aaa"; "bbb"; "ccc"|]
let combined = Array.append one three

// Call matchcount
combined |> matchCount

// Different ways of creating arrays
// [||] - array clamps
// Putting array on different lines allows to ommit the semicolons
let literal = [|1;2;3;4|]
let literalMultiline =
    [|
        "cat"
        "dog"
        "bird"
    |]

let comprehensionRange = [|10..150|]
let comprehensionRange' = [|10..10..150|]

let comprehensionLoop = [|for i = 1 to 10 do
                          yield i * (i*2)|]
let comprehensionLoop' = [|for i = 1 to 10 do
                           if i % 5 = 0 then yield i * (i*2) else yield i|]

let lastDays year = [| for i = 1 to 12 do yield System.DateTime.DaysInMonth(year,i)|]
let lastDays' year = Array.init 12 (fun x -> System.DateTime.DaysInMonth(year,x+1))

// Module functions
Array.create 10 "Same"

Array.init 10 (fun x -> x * 25)
Array.zeroCreate

let vowel (array:string) =
    let vowels = "aeiou"
    array.ToCharArray()
    |> Array.iteri (fun i e -> if vowels.Contains(e.ToString()) then
                                printfn "Letter %c in position %i" e i )

vowel "asasdasdd"

let tuplify (input:string) =
    (input, input.Length)

let capitalize (input:string) =
    input.ToUpper

let filter (array:string []) =
    array
    |> Array.filter (fun x -> x.Length < 15)

// Array reduce iterates
let reduce (array: string []) =
    array
    |> Array.reduce (fun acc elem -> sprintf "%s %s " acc elem )

(*****************************************************************************************)
// Classes: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/classes
(*****************************************************************************************)

type Greetings(name:string, surname:string) =
    member this.Name = name
    member this.Surname = surname
    member this.GreetMe() =
        printfn "Hallo Dear %s %s" name surname
    member this.GreetReturner (names:list<string>) = System.String.Join(" ", names)

(*****************************************************************************************)
// Discriminated Unions: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/discriminated-unions
(*****************************************************************************************)

type Cleaning =
    | Rumba
    | Vacum
    | Duo of string * string
let robot = Rumba
let standard = Vacum
let family = Duo ("Cleaner one", "Cleaner two")
let cleaningMeans = [|robot;standard;family|]
let whoCleans cleaning =
    match cleaning with
    | Rumba -> "Automatic cleaning"
    | Vacum -> "Cleaning with vacumcleaner"
    | Duo (p, d) -> "Today's cleaners are " + p + " and " + d

family |> whoCleans

cleaningMeans |> Array.map whoCleans

type EmailAddress = EmailAddress of string

// using the constructor as a function
"a" |> EmailAddress
["a"; "b"; "c"] |> List.map EmailAddress

// inline deconstruction
let a' = "a" |> EmailAddress
let (EmailAddress a'') = a'

let addresses =
    ["a"; "b"; "c"]
    |> List.map EmailAddress

let addresses' =
    addresses
    |> List.map (fun (EmailAddress e) -> e)

(*****************************************************************************************)
// Recursion: https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/functions/recursive-functions-the-rec-keyword
(*****************************************************************************************)

// Keep printing and returning string each time shorter by 1 char
// This is interesting BUT it makes a side effect while returning values
let rec stringer (s:string) =
    printfn "%s" s
    if s.Length = 1 then s
    else stringer (s.Substring(0, s.Length - 1))

stringer "asdasd"